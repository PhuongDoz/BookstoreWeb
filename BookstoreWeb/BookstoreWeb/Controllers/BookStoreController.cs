using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookstoreWeb.Models;

using PagedList;
using PagedList.Mvc;

namespace BookstoreWeb.Controllers
{
    public class BookStoreController : Controller
    {
        // GET: BookStore
        dbQLyBanSachDataContext data = new dbQLyBanSachDataContext();
        private List<SACH> Laysachmoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index(int ? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var sachmoi = Laysachmoi(18);
            return View(sachmoi.ToPagedList(pageNum,pageSize));
        }
        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;


            return PartialView(chude);
        }
        public ActionResult Nhaxuatban()
        {
            var nxb = from NHAXUATBAN in data.NHAXUATBANs select NHAXUATBAN;


            return PartialView(nxb);
        }
        public ActionResult SPTheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SPTheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes
                       where s.Masach == id
                       select s;
            return View(sach.Single());
        }

    }
}