using API_net5.Model;
using System.Collections.Generic;

namespace API_net5.Service
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1);
        HangHoa Add(HangHoaModel model);
    }
}
