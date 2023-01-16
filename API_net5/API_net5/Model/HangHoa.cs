using System;

namespace API_net5.Model
{
    public class HangHoaVM
    {
        public string TenHang { get; set; }
        public double DonGia { get; set; }
    }
    public class HangHoa : HangHoaVM
    {
        public Guid MaHang { get; set; }

    }
}
