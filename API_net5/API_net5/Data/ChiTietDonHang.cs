using System.ComponentModel.DataAnnotations;
using System;

namespace API_net5.Data
{
    public class ChiTietDonHang
    {
        [Key]
        public Guid MaHangHoa { get; set; }
        public Guid MaDonHang { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        //relationship
        public DonHang donHang { get; set; }
        public HangHoa hangHoa { get; set; }
    }
}
