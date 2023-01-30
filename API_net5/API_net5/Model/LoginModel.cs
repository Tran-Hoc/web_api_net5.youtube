using System.ComponentModel.DataAnnotations;

namespace API_net5.Model
{
    public class LoginModel
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(290)]
        public string Password { get; set; }
    }
}
