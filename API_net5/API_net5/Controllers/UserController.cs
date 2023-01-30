using API_net5.Data;
using API_net5.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace API_net5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private MyDbContext _context;
        public AppSetting _appsetting;
        public UserController(MyDbContext context, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _appsetting = optionsMonitor.CurrentValue;
            _context = context;
        }
        [HttpPost("Login")]
        public IActionResult Valivate(LoginModel loginModel)
        {
            var user = _context.NguoiDungs.SingleOrDefault(p => p.UserName == loginModel.UserName && p.Password == loginModel.Password);
            if (user == null)
            {
                return Ok(new ApiResponse { Success = false, Message = "Username or password is invalid" });
            }

            //cap token
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user)
            });
        }
        private string GenerateToken(NguoiDung nguoidung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appsetting.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, nguoidung.HoTen),
                    new Claim(ClaimTypes.Email, nguoidung.Email),
                    new Claim("UserName", nguoidung.UserName),
                    new Claim("Id", nguoidung.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)

            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }

    }
}
