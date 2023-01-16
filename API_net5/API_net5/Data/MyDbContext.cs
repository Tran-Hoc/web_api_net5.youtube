using Microsoft.EntityFrameworkCore;

namespace API_net5.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        #region DBSet
        public DbSet<HangHoa> HangHoa { get; set;}
        public DbSet<Loai> Loais { get; set; }

        #endregion
    }
}
