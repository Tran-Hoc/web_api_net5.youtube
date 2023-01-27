using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_net5.Model
{

    public class LoaiVM
    {
        public int MaLoai { get; set; }

        public string TenLoai { get; set; }

    }
}
