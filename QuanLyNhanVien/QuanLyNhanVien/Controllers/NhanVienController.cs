using QuanLyNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QuanLyNhanVien.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
            var listNhanVien = new DBNhanVienContext().NhanVien.ToList();
            return View(listNhanVien);
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(int id)
        {
            var context = new DBNhanVienContext();
            var detail = context.NhanVien.Find(id);
            return View(detail);
        }

        public ActionResult Salary(int id)
        {
            var context = new DBNhanVienContext();
            var detail = context.NhanVien.Find(id);
            return View(detail);
        }


        // GET: NhanVien/Create
        public ActionResult Create()
        {
            var context = new DBNhanVienContext();
            var ChucVuSelect = new SelectList(context.ChucVu, "id", "TenChucVu");
            var DuAnSelect = new SelectList(context.DuAn, "id", "TenDuAn");
            var PhongBanSelect = new SelectList(context.PhongBan, "id", "TenPhongBan");

            ViewBag.idChucVu = ChucVuSelect;
            ViewBag.idDuAn = DuAnSelect;
            ViewBag.ibPhongBan = PhongBanSelect;
            return View();
        }

        // POST: NhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVien model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBNhanVienContext();
                context.NhanVien.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new DBNhanVienContext();
            var editing = context.NhanVien.Find(id);
            var ChucVuSelect = new SelectList(context.ChucVu, "id", "TenChucVu", editing.idChucVu);
            var DuAnSelect = new SelectList(context.DuAn, "id", "TenDuAn", editing.idDuAn);
            var PhongBanSelect = new SelectList(context.PhongBan, "id", "TenPhongBan", editing.ibPhongBan);
            ViewBag.idChucVu = ChucVuSelect;
            ViewBag.idDuAn = DuAnSelect;
            ViewBag.ibPhongBan = PhongBanSelect;
            return View(editing);
        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(NhanVien model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBNhanVienContext();
                var oldItem = context.NhanVien.Find(model.id);
                oldItem.HoVaTen = model.HoVaTen;
                oldItem.GioiTinh = model.GioiTinh;
                oldItem.Email  = model.Email;
                oldItem.SoDienThoai = model.SoDienThoai;
                oldItem.SoCanCuoc = model.SoCanCuoc;
                oldItem.idChucVu = model.idChucVu;
                oldItem.idDuAn = model.idDuAn;
                oldItem.ibPhongBan = model.ibPhongBan;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new DBNhanVienContext();
            var delete = context.NhanVien.Find(id);
            return View(delete);
         
        }

        // POST: NhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new DBNhanVienContext();
                var delete = context.NhanVien.Find(id);
                var listPhongBan = (context.PhongBan.Where(nv => nv.idTruongPhong == id));
                int num = 0;
                foreach (var pb in listPhongBan)
                {
                    if (delete.id == pb.idTruongPhong)
                    {
                        return RedirectToAction("Delete", new { id = id, error = true });
                    }
                    
                }
                context.NhanVien.Remove(delete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult listDUAN()
        {
            var listDuAn = new DBNhanVienContext().DuAn.ToList();
            return View(listDuAn);
        }

        public ActionResult DetailsDuAn(int id)
        {
            var context = new DBNhanVienContext();
            var listNhanVien2 = new SelectList(context.NhanVien.Where(nv => nv.idDuAn == id),"id", "HoVaTen");
            var detail = context.DuAn.Find(id);
            ViewBag.NhanVienList = listNhanVien2;
            return View(detail);
        }

        public ActionResult CreateDuAn()
        {
            var context = new DBNhanVienContext();
            var QuanLySelect = new SelectList(context.NhanVien, "id", "HoVaTen");
            ViewBag.idQuanLy = QuanLySelect;
            return View();
        }

        [HttpPost]
        public ActionResult CreateDuAn(DuAn model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBNhanVienContext();
                context.DuAn.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Edit/5
        public ActionResult EditDuAn(int id)
        {
            var context = new DBNhanVienContext();
            var editing = context.DuAn.Find(id);
            var QuanLySelect = new SelectList(context.NhanVien, "id", "HoVaTen", editing.idQuanLy);
            ViewBag.idQuanLy = QuanLySelect;
            return View(editing);
        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult EditDuAn(DuAn model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBNhanVienContext();
                var oldItem = context.DuAn.Find(model.id);
                oldItem.TenDuAn = model.TenDuAn;
                oldItem.ThongTinDuAn = model.ThongTinDuAn;
                oldItem.idQuanLy = model.idQuanLy;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Delete/5
        public ActionResult DeleteDuAn(int id)
        {
            var context = new DBNhanVienContext();
            var delete = context.DuAn.Find(id);
            var listNhanVien2 = new SelectList(context.NhanVien.Where(nv => nv.idDuAn == id), "id", "HoVaTen");
            ViewBag.NhanVienList = listNhanVien2;
            return View(delete);

        }

        // POST: NhanVien/Delete/5
        [HttpPost]
        public ActionResult DeleteDuAn(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new DBNhanVienContext();
                var delete = context.DuAn.Find(id);
                var listNhanVien = context.NhanVien.Where(nv => nv.idDuAn == id);
                foreach (var nv in listNhanVien)
                {
                    nv.idDuAn = null;
                }
                context.DuAn.Remove(delete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult listPhongBan()
        {
            var listPhongBan = new DBNhanVienContext().PhongBan.ToList();
            return View(listPhongBan);
        }
        public ActionResult CreatePhongBan()
        {
            var context = new DBNhanVienContext();
            var TruongPhongSelect = new SelectList(context.NhanVien.Where(nv => nv.idChucVu == 8), "id", "HoVaTen");
            ViewBag.idTruongPhong = TruongPhongSelect;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePhongBan(PhongBan model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBNhanVienContext();
                context.PhongBan.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: NhanVien/Edit/5
        public ActionResult EditPhongBan(int id)
        {
            var context = new DBNhanVienContext();
            var editing = context.PhongBan.Find(id);
            var QuanLySelect = new SelectList(context.NhanVien.Where(nv => nv.idChucVu == 8), "id", "HoVaTen", editing.idTruongPhong);
            ViewBag.idTruongPhong = QuanLySelect;
            return View(editing);
        }


        [HttpPost]
        public ActionResult EditPhongBan(PhongBan model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBNhanVienContext();
                var oldItem = context.PhongBan.Find(model.id);
                oldItem.TenPhongBan = model.TenPhongBan;
                oldItem.idTruongPhong = model.idTruongPhong;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DetailsPhongBan(int id)
        {
            var context = new DBNhanVienContext();
            var listNhanVien2 = new SelectList(context.NhanVien.Where(nv => nv.ibPhongBan == id), "id", "HoVaTen");
            var detail = context.PhongBan.Find(id);
            ViewBag.NhanVienList = listNhanVien2;
            return View(detail);
        }
        public ActionResult DeletePhongBan(int id)
        {
            var context = new DBNhanVienContext();
            var listNhanVien2 = new SelectList(context.NhanVien.Where(nv => nv.ibPhongBan == id), "id", "HoVaTen");
            ViewBag.NhanVienList = listNhanVien2;

            var delete = context.PhongBan.Find(id);
            return View(delete);

        }

        // POST: NhanVien/Delete/5
        [HttpPost]
        public ActionResult DeletePhongBan(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new DBNhanVienContext();
                var delete = context.PhongBan.Find(id);
                var listNhanVien = context.NhanVien.Where(nv => nv.ibPhongBan == id);
                int num = 0;
                foreach (var nv in listNhanVien)
                {
                    num++;
;               }
                if (num != 0)
                {
                    return RedirectToAction("DeletePhongBan", new { id = id, error = true });
                }
                context.PhongBan.Remove(delete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
