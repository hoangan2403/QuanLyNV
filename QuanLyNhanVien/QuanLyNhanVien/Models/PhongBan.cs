namespace QuanLyNhanVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongBan")]
    public partial class PhongBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongBan()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        public long id { get; set; }

        [Required]
        [StringLength(10)]
        [Display (Name = "Tên Phòng Ban")]
        public string TenPhongBan { get; set; }
        [Display (Name = "Trưởng Phòng")]
        public long idTruongPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanVien { get; set; }
        [Display (Name = "Trường Phòng")]
        public virtual NhanVien NhanVien1 { get; set; }
    }
}
