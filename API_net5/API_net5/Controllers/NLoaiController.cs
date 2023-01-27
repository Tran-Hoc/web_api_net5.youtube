using API_net5.Data;
using API_net5.Model;
using API_net5.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_net5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NLoaiController : ControllerBase
    {
        private ILoaiRepository _loaiRepository;

        public NLoaiController(ILoaiRepository loaiRepository)
        {
            _loaiRepository = loaiRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_loaiRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                var data = _loaiRepository.GetByID(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiVM loaiVM)
        {
            if (id != loaiVM.MaLoai)
            {
                return BadRequest();
            }
            try
            {
                _loaiRepository.Update(loaiVM);
                return NoContent();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _loaiRepository.Delete(id);
                return Ok();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Add(LoaiModel loai)
        {
            try
            {
                return Ok(_loaiRepository.Add(loai));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
