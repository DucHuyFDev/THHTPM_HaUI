using QLHocSinh_restful_10_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLHocSinh_restful_10_8.Controllers
{
    public class HocSinhController : ApiController
    {
        QLHocSinhEntities db = new QLHocSinhEntities();

        [HttpGet]
        [Route("api/geths")]
        public IEnumerable<HocSinh> getHS()
        {
            return db.HocSinhs;
        }

        [HttpGet]
        [Route("api/geths/{id}")]
        public IEnumerable<HocSinh> getHSByID(string id)
        {
            return db.HocSinhs.Where(x => x.MaHS == id);
        }

        [HttpPost]
        [Route("api/posths")]
        public IHttpActionResult postHS(HocSinh hs)
        {
            var hsfind = db.HocSinhs.FirstOrDefault(x => x.MaHS == hs.MaHS);
            if (hsfind == null)
            {
                db.HocSinhs.Add(hs);
                db.SaveChanges();
                return Ok("Thêm thành công !");
            }
            return BadRequest("Đã có sinh viên có mã này");
        }

        [HttpPut]
        [Route("api/puths/{id}")]
        public IHttpActionResult putHS(HocSinh hs)
        {
            var hsfind = db.HocSinhs.FirstOrDefault(x => x.MaHS == hs.MaHS);
            if (hsfind != null)
            {
                hsfind.TenHS = hs.TenHS;
                hsfind.Lop = hs.Lop;
                hsfind.QueQuan = hs.QueQuan;
                db.SaveChanges();
                return Ok("Cập nhật thành công !");
            }
            return BadRequest("Không có sinh viên có mã này");
        }

        [HttpDelete]
        [Route("api/deletehs/{id}")]
        public IHttpActionResult deleteHS(string id)
        {
            var hsfind = db.HocSinhs.FirstOrDefault(x => x.MaHS == id);
            if (hsfind != null)
            {
                db.HocSinhs.Remove(hsfind);
                db.SaveChanges();
                return Ok("Xóa thành công !");
            }
            return BadRequest("Không có sinh viên có mã này");
        }

        
    }
}
