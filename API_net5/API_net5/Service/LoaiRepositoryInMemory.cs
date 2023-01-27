using API_net5.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace API_net5.Service
{
    public class LoaiRepositoryInMemory : ILoaiRepository
    {
        static List<LoaiVM> loais = new List<LoaiVM>()
        {
            new LoaiVM{MaLoai = 1, TenLoai = "Ti vi"},
            new LoaiVM{MaLoai = 2, TenLoai = "Tủ lạnh"},
            new LoaiVM{MaLoai = 3, TenLoai = "Máy giặt"},
            new LoaiVM{MaLoai = 4, TenLoai = "Điều Hoà"},
            new LoaiVM{MaLoai = 5, TenLoai = "Nồi cơm điện"},
            new LoaiVM{MaLoai = 6, TenLoai = "Đèn điện"},

        };
        public LoaiVM Add(LoaiModel loaiModel)
        {
            var _loai = new LoaiVM
            {
                MaLoai = loais.Max(l => l.MaLoai) + 1,
                TenLoai = loaiModel.TenLoai
            };
            loais.Add(_loai); return _loai;

        }

        public void Delete(int id)
        {
            var loai = loais.SingleOrDefault(l => l.MaLoai == id);
            loais.Remove(loai);
        }

        public List<LoaiVM> GetAll()
        {
            return loais.ToList();
        }

        public LoaiVM GetByID(int id)
        {
            return loais.SingleOrDefault(l => l.MaLoai == id);
        }

        public void Update(LoaiVM loaiVM)
        {
            var _loai = loais.SingleOrDefault(l => l.MaLoai == loaiVM.MaLoai);
            if (_loai != null) { _loai.TenLoai = loaiVM.TenLoai; };
        }
    }
}
