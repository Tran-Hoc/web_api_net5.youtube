using Microsoft.EntityFrameworkCore;

namespace API_net5.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        #region DBSet
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<HangHoa> HangHoa { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDonHang);
                e.Property(dh => dh.NgDat).HasDefaultValueSql("GETUTCDATE()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<ChiTietDonHang>(e =>
            {
                e.ToTable("ChiTietDonHang");
                e.HasKey(e => new { e.MaDonHang, e.MaHangHoa });
                e.HasOne(e => e.donHang).WithMany(e => e.chitietdonhangs).HasForeignKey(e => e.MaDonHang).HasConstraintName("FK_DonHangCT_DonHang");
                e.HasOne(e => e.hangHoa).WithMany(e => e.chiTietDonHangs).HasForeignKey(e => e.MaHangHoa).HasConstraintName("FK_DonHangCT_HangHoa");

            });
            modelBuilder.Entity<NguoiDung>(e =>
            {
                e.ToTable("NguoiDung");
                e.HasIndex(e => e.UserName).IsUnique();
                e.Property(e=>e.HoTen).IsRequired().HasMaxLength(200);
                e.Property(e=> e.Email).HasMaxLength(200);
            });


        }
    }
}
