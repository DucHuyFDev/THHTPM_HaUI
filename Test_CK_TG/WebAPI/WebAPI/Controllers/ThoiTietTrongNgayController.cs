using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ThoiTietTrongNgayController : ApiController
    {
        DBTTEntities db = new DBTTEntities();
        [HttpGet]
        [Route("thoitiet/get")]
        public IEnumerable<ThoiTietTrongNgay> ThongTinThoiTiet()
        {
            return db.ThoiTietTrongNgays;
        }

        [HttpPost]
        [Route("thoitiet/post")]
        public IHttpActionResult Them(ThoiTietTrongNgay new_tt)
        {
            var ttfind = db.ThoiTietTrongNgays.FirstOrDefault(x => x.MaKhuVuc == new_tt.MaKhuVuc
                                                                && x.Gio == new_tt.Gio);
            if (ttfind != null)
            {
                return Ok("This time already exists ! Fail to add !");
            }
            db.ThoiTietTrongNgays.Add(new_tt);
            db.SaveChanges();
            return Ok("Time saved successfully !"); 
        }

        [HttpDelete]
        [Route("thoitiet/delete")]
        public IHttpActionResult Xoa(DateTime dt, string makv)
        {
            var ttfind = db.ThoiTietTrongNgays.FirstOrDefault(x => x.MaKhuVuc == makv
                                                               & x.Gio == dt);
            if (ttfind == null)
            {
                return Ok("This time doesn't exists ! Fail to delete !");
            }
            db.ThoiTietTrongNgays.Remove(ttfind);
            db.SaveChanges();
            return Ok("Deleted successfully !");
        }
    }
}
