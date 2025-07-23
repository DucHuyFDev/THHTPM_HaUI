using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai9_2.Controllers
{
    public class SanPhamController : ApiController
    {
        private QLBanHangDataContext db;
        public SanPhamController()
        {
            string connect_string = ConfigurationManager.ConnectionStrings["QLBanHangDataContext"].ConnectionString;
            db = new QLBanHangDataContext(connect_string);
        }

        [HttpGet]
        public IEnumerable<SanPhamDTO> LaySP()
        {
            return db.SanPhams.Select(x => new SanPhamDTO
            {
                ma = x.Ma,
                ten = x.Ten,
                dongia = (float)(x.DonGia ?? 0),
                tendanhmuc = x.DanhMuc.TenDanhMuc
            });
        }

        [HttpPost]
        public IHttpActionResult Post(SanPhamDTO new_sp)
        {
            var dm = db.DanhMucs.FirstOrDefault(x => x.TenDanhMuc == new_sp.tendanhmuc);
            if (dm == null)
            {
                return BadRequest();
            }
            var spfind = db.SanPhams.FirstOrDefault(x => x.Ma == new_sp.ma);
            if (spfind != null)
            {
                return BadRequest();
            }
            SanPham sp = new SanPham
            {
                Ma = new_sp.ma,
                Ten = new_sp.ten,
                DonGia = new_sp.dongia,
                MaDanhMuc = dm.MaDanhMuc
            };
            db.SanPhams.InsertOnSubmit(sp);
            db.SubmitChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(SanPhamDTO update_sp)
        {
            var spfind = db.SanPhams.FirstOrDefault(x => x.Ma == update_sp.ma);
            if (spfind == null)
                return NotFound();
            spfind.Ten = update_sp.ten;
            spfind.DonGia = update_sp.dongia;
            var dm = db.DanhMucs.FirstOrDefault(x => x.TenDanhMuc == update_sp.tendanhmuc);
            spfind.MaDanhMuc = dm.MaDanhMuc;
            db.SubmitChanges();
            return Ok();
        }

        public IHttpActionResult Delete (string id)
        {
            var spfind = db.SanPhams.FirstOrDefault(x => x.Ma == id);
            if (spfind == null) return NotFound();
            db.SanPhams.DeleteOnSubmit(spfind);
            db.SubmitChanges();
            return Ok();
        }
    }
}
