using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ThoiGianController : ApiController
    {
        ThuNghiem_timedataEntities db = new ThuNghiem_timedataEntities();
        [HttpGet]
        public IEnumerable<ThoiGian> getall()
        {
            return db.ThoiGians;
        }

        [HttpPost]
        [Route("api/post")]
        public IHttpActionResult post(DateTime new_time)
        {
            var time_check = db.ThoiGians.FirstOrDefault(x => x.Time ==  new_time);
            if (time_check != null)
            {
                return Ok("Đã tồn tại mốc thời gian này !");
            }
            var thoigian = new ThoiGian { Time = new_time };
            db.ThoiGians.Add(thoigian);
            db.SaveChanges();
            return Ok("Success !");
        }
    }
}
