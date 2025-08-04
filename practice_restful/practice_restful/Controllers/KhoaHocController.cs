using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using practice_restful.Models;

namespace practice_restful.Controllers
{
    public class KhoaHocController : ApiController
    {
       QL_KhoaHocEntities db = new QL_KhoaHocEntities();

        [HttpGet]
        public IEnumerable<KhoaHoc> get()
        {
            return db.KhoaHocs;
        }

        [HttpGet]
        [Route("api/khoahoc/{id}")]
        public IEnumerable<KhoaHoc> getbyID(string id)
        {
            return db.KhoaHocs.Where(x => x.MaKhoaHoc == id);
        }

        [HttpPost]
        public IHttpActionResult post(KhoaHoc kh)
        {
            var khfind = db.KhoaHocs.Any(x => x.MaKhoaHoc.Equals(kh.MaKhoaHoc));
            if (khfind)
            {
                return BadRequest("Đã tồn tại khóa học có mã giống mã đã nhập");
            }
            db.KhoaHocs.Add(kh);
            db.SaveChanges();
            return Ok("Thêm khóa học thành công !");
        }
        [HttpPut]
        public IHttpActionResult put(KhoaHoc kh)
        {
            var khfind = db.KhoaHocs.FirstOrDefault(x => x.MaKhoaHoc.Equals(kh.MaKhoaHoc));
            if (khfind == null)
            {
                return BadRequest("Không tồn tại mã khóa học !");
            }
            khfind.TenKhoaHoc = kh.TenKhoaHoc;
            khfind.HocPhi = kh.HocPhi;
            khfind.ThoiLuong = kh.ThoiLuong;
            db.SaveChanges();
            return Ok("Đã sửa thành công !");
        }

        [HttpDelete]
        public IHttpActionResult delete(string id)
        {
            var khfind = db.KhoaHocs.FirstOrDefault(x => x.MaKhoaHoc.Equals(id));
            if (khfind == null)
            {
                return BadRequest("Không tồn tại mã khóa học !");
            }
            db.KhoaHocs.Remove(khfind);
            db.SaveChanges();
            return Ok("Đã xóa thành công !");
        }
    }
}
