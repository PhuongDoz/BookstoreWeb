using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreWeb.Models
{
    public class Giohang
    {
        dbQLyBanSachDataContext data = new dbQLyBanSachDataContext();

        public int iMasach { set; get; }
        public string sTensach { set; get; }
        public string sHinhminhhoa { set; get; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }
        }
        public Giohang(int Masach)
        {
            iMasach = Masach;
            SACH sach = data.SACHes.Single(n => n.Masach == iMasach);
            sTensach = sach.Tensach;
            sHinhminhhoa = sach.Hinhminhhoa;
            dDongia = double.Parse(sach.Dongia.ToString());
            iSoluong = 1;
        }

    }
}