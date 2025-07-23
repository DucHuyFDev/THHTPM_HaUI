using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai9_1.Controllers
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
        public IEnumerable<SanPhamDTO> getAllData()
        {
            return db.SanPhams.Select(sp => new SanPhamDTO
            {
                ma = sp.Ma,
                ten = sp.Ten,
                dongia = (float)(sp.DonGia ?? 0),
                tendanhmuc = sp.DanhMuc.TenDanhMuc,
            });
        }

        [HttpGet]
        //[Route ("api/sanpham/danhmuc/{tendm}")]
        public IHttpActionResult Get(string tendm)
        {
            var ds = db.SanPhams.Where(x => x.DanhMuc.TenDanhMuc == tendm).Select(x => new SanPhamDTO
            {
                ma = x.Ma,
                ten = x.Ten,
                dongia = (float)(x.DonGia ?? 0),
                tendanhmuc = x.DanhMuc.TenDanhMuc
            }). ToList();
            if (ds .Count > 0)
            {
                return Ok(ds);  
            }
            else  { return NotFound(); }

        }
    }
}
