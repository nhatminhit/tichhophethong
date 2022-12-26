using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ONTAPTHI.Models;

namespace ONTAPTHI.Controllers
{
    public class SanPhamController : ApiController
    {
        THHTEntities db = new THHTEntities();
        [HttpGet]
        public IEnumerable<SanPham> LayToanBoSP()
        {
            IEnumerable<SanPham> query = db.SanPham;
            return query;
        }
        [HttpGet]
        public SanPham LaySPTheoMa(int ma)
        {
            SanPham sp = db.SanPham.FirstOrDefault(x => x.MaSP == ma);
            return sp;
        }
        [HttpGet]
        public IEnumerable<SanPham> LaySPTheoDM(int madm)
        {
            IEnumerable<SanPham> query = db.SanPham.Where(x => x.MaDanhMuc == madm);
            return query;
        }
        [HttpPost]
        public bool Insert(int ma, string ten, decimal gia, int madm)
        {
            SanPham sp = db.SanPham.FirstOrDefault(x => x.MaSP == ma);
            if (sp == null)
            {
                SanPham spnew = new SanPham();
                spnew.MaSP = ma;
                spnew.TenSP = ten;
                spnew.DonGia = gia;
                spnew.MaDanhMuc = madm;
                db.SanPham.Add(spnew);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool Update(int ma, string ten, decimal gia, int madm)
        {
            SanPham sp = db.SanPham.FirstOrDefault(x => x.MaSP == ma);
            if (sp != null)
            {
                sp.MaSP = ma;
                sp.TenSP = ten;
                sp.DonGia = gia;
                sp.MaDanhMuc = madm;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool XoaSP(int ma)
        {
            SanPham sp = db.SanPham.FirstOrDefault(x => x.MaSP == ma);
            if (sp != null)
            {
                db.SanPham.Remove(sp);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
