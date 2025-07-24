using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai10.Controllers
{
    public class DonViController : ApiController
    {
        private QLLuongDataContext db;
        public DonViController()
        {
            string conn_string = ConfigurationManager.ConnectionStrings["QLLuongDataContext"].ConnectionString;
            db = new QLLuongDataContext(conn_string);
        }
        [HttpPut]
        public IHttpActionResult put(DonViDTO update_dv)
        {
            var dvfind = db.DonVis.FirstOrDefault(x => x.MaDonVi == update_dv.madonvi);
            if (dvfind == null)
            {
                return NotFound();
            }
            
            dvfind.TenDonVi = update_dv.tendonvi;
            db.SubmitChanges();
            return Ok("Sửa thành công");
        }
        // Action Method Decorator này sẽ xóa hết các nhân viên của đơn vị đó , sau đó mới xóa đơn vị
        [HttpDelete]
        public IHttpActionResult delete(string madv)
        {
            var dvfind = db.DonVis.FirstOrDefault(x => x.MaDonVi == madv);
            if (dvfind == null)
            {
                return NotFound();
            }
            var nv_in_dv = db.NhanViens.Where(x => x.DonVi.MaDonVi == madv).ToList();
            db.NhanViens.DeleteAllOnSubmit(nv_in_dv);
            db.DonVis.DeleteOnSubmit(dvfind);
            db.SubmitChanges();
            return Ok("Xóa đơn vị và các nhân viên thuộc đơn vị xong !");
        }
    }
}
