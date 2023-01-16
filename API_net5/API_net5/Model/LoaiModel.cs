using System.ComponentModel.DataAnnotations;

namespace API_net5.Model
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
