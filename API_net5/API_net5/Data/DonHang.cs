using System;
using System.Collections;
using System.Collections.Generic;

namespace API_net5.Data
{
    public enum TinhTrangDonDatHang
    {
        New = 0,
        Payment = 1,
        Complete = 2,
        Cancel = -1
    }
    public class DonHang
    {
        public Guid MaDonHang { get; set; }
        public DateTime NgDat { get; set; }
        public DateTime? NgGiao { get; set; }
        public TinhTrangDonDatHang TinhTrangDonHang { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiGiao { get; set; }
        public string SoDienThoai { get; set; }

        public ICollection<ChiTietDonHang> chitietdonhangs { get; set; } 
        public DonHang()
        {
            chitietdonhangs = new List<ChiTietDonHang>();
        }
    }
}
