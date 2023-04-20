namespace QuanLyNhanVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            DuAn = new HashSet<DuAn>();
            PhongBan1 = new HashSet<PhongBan>();
        }

        public long id { get; set; }

        [Required]
        [StringLength(200)]
        [Display (Name ="Họ Và Tên")]
        public string HoVaTen { get; set; }
        [Display (Name = "Giới Tính")]
        public bool GioiTinh { get; set; }

        [StringLength(200)]
        [Display (Name = "Email")]
        public string Email { get; set; }

        [StringLength(20)]
        [Display (Name = "Số Điện Thoại")]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        [Display (Name = "Số Căn Cước")]
        public string SoCanCuoc { get; set; }

        [StringLength(200)]
        [Display (Name = "Tên Đăng Nhập")]
        public string TenDangNhap { get; set; }

        [StringLength(200)]
        [Display (Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
        [Display (Name = "Chức Vụ")]
        public long? idChucVu { get; set; }
        [Display (Name = "Là Quản Trị")]
        public bool LaQuanTri { get; set; }
        [Display(Name = "Là Chuyên Viên")]
        public bool LaChuyenVien { get; set; }
        [Display (Name = "Là Nhân Viên")]
        public bool LaNhanVien { get; set; }
        [Display (Name = "Phòng Ban")]
        public long ibPhongBan { get; set; }
        [Display(Name = "Dự Án")]
        public long? idDuAn { get; set; }
        [Display (Name = "Chức Vụ")]
        public virtual ChucVu ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DuAn> DuAn { get; set; }
        [Display (Name = "Dự Án")]
        public virtual DuAn DuAn1 { get; set; }
        [Display (Name = "Phòng Ban")]
        public virtual PhongBan PhongBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongBan> PhongBan1 { get; set; }
    }
}
