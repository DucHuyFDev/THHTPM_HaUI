using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PhongBanController : ApiController
    {
        QLDAEntities db = new QLDAEntities();
        [HttpGet]
        [Route("phongban/getpb")]
        public IEnumerable<PhongBanDTO> getPB()
        {
            return db.PhongBans.Select(x => new PhongBanDTO
            {
                MaPB = x.MaPB,
                TenPB = x.TenPB,
                DiaChi = x.DiaChi
            });
        }
        [HttpDelete]
        [Route("phongban/deletepb/{tenpb}")]
        public IHttpActionResult deletePB(string tenpb)
        {
            var pbfind = db.PhongBans.FirstOrDefault(x => x.TenPB == tenpb);
            if (pbfind == null)
            {
                return Ok("Không có mã phòng ban cần xóa !");
            }
            var cnt_nv = db.NhanViens.Where(x => x.MaPB == pbfind.MaPB).Count();
            if (cnt_nv != 0)
            {
                return Ok("Phòng ban còn người, không được xóa !");
            }
            db.PhongBans.Remove(pbfind);
            db.SaveChanges();
            return Ok("Xóa thành công !");
        }
        

    }
}
