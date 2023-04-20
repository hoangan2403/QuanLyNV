using QuanLyNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanVien.Controllers
{
    public class DuAnController : Controller
    {
        // GET: DuAn
        public ActionResult Index()
        {
            var listDuAn = new DBNhanVienContext().DuAn.ToList();
            return View(listDuAn);
        }

        // GET: DuAn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DuAn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DuAn/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DuAn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DuAn/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DuAn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DuAn/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
