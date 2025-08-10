using QLBanHang_10_8_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;

namespace QLBanHang_10_8_api.Controllers
{
    public class SanPhamController : ApiController
    {
        QLBanHangEntities db = new QLBanHangEntities();

        [HttpGet]
        [Route("api/sanpham/getsp")]
        public IEnumerable<SanPham> getAllSP()
        {
            return db.SanPhams;
        }

        [HttpGet]
        [Route("api/sanpham/getbyid/{id}")]
        public IEnumerable<SanPham> getSPbyID(string id)
        {
            return db.SanPhams.Where(x => x.MaSP ==  id);
        }

        [HttpPost]
        [Route("api/sanpham/postsp")]
        public IHttpActionResult postSP(SanPham sp)
        {
            var spfind = db.SanPhams.FirstOrDefault(x => x.MaSP == sp.MaSP);
            if (spfind == null)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return Ok("Thêm thành công !");
            }
            return BadRequest("Mã sản phẩm đã tồn tại");
        }

        [HttpPut]
        [Route("api/sanpham/putsp/{id}")]
        public IHttpActionResult putSP(SanPham sp)
        {
            var spfind = db.SanPhams.FirstOrDefault(x => x.MaSP == sp.MaSP);
            if (spfind != null)
            {
                spfind.TenSP = sp.TenSP;
                spfind.DonGia = sp.DonGia;
                spfind.SoLuong = sp.SoLuong;
                db.SaveChanges();
                return Ok("Đã cập nhật thành công !");
            }
            return BadRequest("Không sản phẩm nào tồn tại mã đã nhập");
        }

        [HttpDelete]
        [Route("api/sanpham/deletesp/{id}")]
        public IHttpActionResult deleteSP(string id)
        {
            var spfind = db.SanPhams.FirstOrDefault(x => x.MaSP == id);
            if (spfind != null)
            {
                db.SanPhams.Remove(spfind);
                db.SaveChanges();
                return Ok("Đã xóa thành công !");
            }
            return BadRequest("Không sản phẩm nào tồn tại mã đã nhập");
        }
    }
}
