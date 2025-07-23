using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace THLT_B9.Controllers
{
    public class SanPhamController : ApiController
    {
        private TestDataContext db;
        
        public SanPhamController()
        {
            string connection_string = ConfigurationManager.ConnectionStrings["TestDataContext"].ConnectionString;
            db = new TestDataContext(connection_string);
        }

        [HttpGet]
        public List<SanPhamDTO> LaySanPham()
        {
            return db.SanPhams.Select(sp => new SanPhamDTO
            {
                Ma = sp.Ma,
                Ten = sp.Ten,
                DonGia = sp.DonGia ?? 0,
                TenDanhMuc = sp.DanhMuc.TenDanhMuc
            }).ToList();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var sp = db.SanPhams.FirstOrDefault(s => s.Ma == id);
            if (sp == null)
                return NotFound();
            return Ok(new SanPhamDTO
            {
                Ma = sp.Ma,
                Ten = sp.Ten,
                DonGia = sp.DonGia ?? 0,
                TenDanhMuc = sp.DanhMuc.TenDanhMuc
            });
        }
        [HttpPost]
        public IHttpActionResult Post(SanPhamDTO dto)
        {
            var dm = db.DanhMucs.FirstOrDefault(d => d.TenDanhMuc == dto.TenDanhMuc);
            if (dm == null)
            {
                return BadRequest("Danh mục không tồn tại !"); 
            }
            SanPham sp = new SanPham
            {
                Ma = dto.Ma,
                Ten = dto.Ten,
                DonGia = (int?)dto.DonGia,
                MaDanhMuc = dm.MaDanhMuc,
            };

            db.SanPhams.InsertOnSubmit(sp);
            db.SubmitChanges();
            return Ok();

        }

        [HttpPut]
        public IHttpActionResult Put(int id, SanPhamDTO dto)
        {
            var sp = db.SanPhams.FirstOrDefault(s => s.Ma == id);
            if (sp == null)
                return NotFound();
            sp.Ten = dto.Ten;
            sp.DonGia = (int?)dto.DonGia;
            var dm = db.DanhMucs.FirstOrDefault(d => d.TenDanhMuc == dto.TenDanhMuc);
            if (dm != null)
            {
                sp.MaDanhMuc = dm.MaDanhMuc;
            }
                
            db.SubmitChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var sp = db.SanPhams.FirstOrDefault(s => s.Ma == id);
            if (sp == null) return NotFound();
            db.SanPhams.DeleteOnSubmit(sp);
            db.SubmitChanges();
            return Ok();
        }
        
        

    }
}
    