using API_net5.Data;
using API_net5.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API_net5.Service
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public HangHoaRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string search)
        {
            var allProducts = _context.HangHoa.Where(hh => hh.TenHangHoa.Contains(search));
            var result = allProducts.Select(h => new HangHoaModel
            {
                MaHangHoa = h.MaHangHoa,
                TenHang = h.TenHangHoa,
                DonGia = h.DonGia,
                TenLoai = h.Loai.TenLoai
            });
            return result.ToList();
        }
        public List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1)
        {
            var allProducts = _context.HangHoa.Include(hh => hh.Loai).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.TenHangHoa.Contains(search));
            }
            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia >= from);
            }
            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia <= to);
            }
            #endregion


            #region Sorting
            //Default sort by Name (TenHh)
            allProducts = allProducts.OrderBy(hh => hh.TenHangHoa);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc": allProducts = allProducts.OrderByDescending(hh => hh.TenHangHoa); break;
                    case "gia_asc": allProducts = allProducts.OrderBy(hh => hh.DonGia); break;
                    case "gia_desc": allProducts = allProducts.OrderByDescending(hh => hh.DonGia); break;
                }
            }
            #endregion

            //#region Paging
            //allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var result = allProducts.Select(hh => new HangHoaModel
            //{
            //    MaHangHoa = hh.MaHh,
            //    TenHangHoa = hh.TenHh,
            //    DonGia = hh.DonGia,
            //    TenLoai = hh.Loai.TenLoai
            //});

            //return result.ToList();

            var result = PaginatedList<Data.HangHoa>.Create(allProducts, page, PAGE_SIZE);

            return result.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHangHoa,
                TenHang = hh.TenHangHoa,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai?.TenLoai
            }).ToList();
        }

        public Model.HangHoa Add(HangHoaModel model)
        {
            throw new System.NotImplementedException();
        }

        //public Model.HangHoa Add(HangHoaModel model)
        //{
        //    var hanghoa = new Model.HangHoa
        //    {
        //        TenHang = model.TenHang,


        //    };
        //    _context.Add(hanghoa);
        //    _context.SaveChanges();
        //    return new Model.HangHoa
        //    {
        //        MaHang = hanghoa.MaHang,
        //        TenHang = hanghoa.TenHang
        //    };
        //}
    }
}

