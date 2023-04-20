namespace QuanLyNhanVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuAn")]
    public partial class DuAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DuAn()
        {
            NhanVien1 = new HashSet<NhanVien>();
        }

        public long id { get; set; }

        [Required]
        [StringLength(200)]
        [Display (Name = "Tên Dự Án")]
        public string TenDuAn { get; set; }

        [StringLength(500)]
        [Display (Name = "Thông Tin Dự Án")]
        public string ThongTinDuAn { get; set; }
        [Display (Name = "Phụ Cấp(Thưởng dự án)")]
        public int? PhuCap { get; set; }
        [Display (Name = "Quản Lý ")]
        public long idQuanLy { get; set; }
        [Display (Name = "Quản Lý Dự Án")]
        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanVien1 { get; set; }
    }
}
