using API_net5.Model;
using System.Collections.Generic;

namespace API_net5.Service
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetByID(int id);
        LoaiVM Add(LoaiModel loaiModel);
        void Update(LoaiVM loaiVM);
        void Delete(int id);    

    }
}
