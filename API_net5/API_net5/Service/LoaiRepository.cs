using API_net5.Data;
using API_net5.Model;
using System.Collections.Generic;
using System.Linq;

namespace API_net5.Service
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDbContext _context;
        public LoaiRepository(MyDbContext context)
        {
            _context = context;
        }
        public LoaiVM Add(LoaiModel loaiModel)
        {
            var loai = new Loai
            {
                TenLoai = loaiModel.TenLoai,

            };
            _context.Add(loai);
            _context.SaveChanges();
            return new LoaiVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai
            };
        }

        public void Delete(int id)
        {
            var loai =  _context.Loais.SingleOrDefault(l=> l.MaLoai== id);  
            if (loai!=null)
            {
                _context.Remove(loai);
                _context.SaveChanges(); 
            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(l => new LoaiVM
            {
                MaLoai = l.MaLoai,
                TenLoai = l.TenLoai,
            });
            return loais.ToList();
        }

        public LoaiVM GetByID(int id)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                return new LoaiVM
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai
                };
            }
            return null;    
        }

        public void Update(LoaiVM loaiVM)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == loaiVM.MaLoai);
            loai.TenLoai = loaiVM.TenLoai; 
            _context.SaveChanges();
        }
    }
}
