namespace QuanLyNhanVien.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBNhanVienContext : DbContext
    {
        public DBNhanVienContext()
            : base("name=DBNhanVienConnestionString")
        {
        }

        public virtual DbSet<ChucVu> ChucVu { get; set; }
        public virtual DbSet<DuAn> DuAn { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhongBan> PhongBan { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.NhanVien)
                .WithOptional(e => e.ChucVu)
                .HasForeignKey(e => e.idChucVu);

            modelBuilder.Entity<DuAn>()
                .HasMany(e => e.NhanVien1)
                .WithOptional(e => e.DuAn1)
                .HasForeignKey(e => e.idDuAn);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.DuAn)
                .WithRequired(e => e.NhanVien)
                .HasForeignKey(e => e.idQuanLy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhongBan1)
                .WithRequired(e => e.NhanVien1)
                .HasForeignKey(e => e.idTruongPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.TenPhongBan)
                .IsFixedLength();

            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.NhanVien)
                .WithRequired(e => e.PhongBan)
                .HasForeignKey(e => e.ibPhongBan)
                .WillCascadeOnDelete(false);
        }
    }
}
