using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace Bai10.Controllers
{
    public class NhanVienController : ApiController
    {
        private QLLuongDataContext db;
        public NhanVienController()
        {
            string conn_string = ConfigurationManager.ConnectionStrings["QLLuongDataContext"].ConnectionString;
            db = new QLLuongDataContext(conn_string);
        }

        [HttpGet]
        public IEnumerable<NhanVienDTO> getAllNhanVien()
        {
            return db.NhanViens.Select(x => new NhanVienDTO
            {
                ma = x.Ma,
                hoten = x.HoTen,
                ngaysinh = (DateTime)x.NgaySinh,
                gioitinh = (bool)x.GioiTinh,
                hsluong = (double)x.HsLuong,
                tendonvi = x.DonVi.TenDonVi,
            });
        }

        [HttpPut]
        public IHttpActionResult PutNV(NhanVienDTO nv_new)
        {
            var dv  = db.DonVis.FirstOrDefault(x => x.TenDonVi == nv_new.tendonvi);
            var nvfind = db.NhanViens.FirstOrDefault(x => x.Ma == nv_new.ma);
            if (nvfind == null)
            {
                return NotFound();
            }
            nvfind.HoTen = nv_new.hoten;
            nvfind.NgaySinh = nv_new.ngaysinh;
            nvfind.GioiTinh = nv_new.gioitinh;
            nvfind.HsLuong = nv_new.hsluong;
            nvfind.DonVi.TenDonVi = dv.TenDonVi;
            db.SubmitChanges();
            return Ok("Sửa thành công");
        }

        [HttpDelete]
        public IHttpActionResult DeleteNV(string ma)
        {
            var nvfind = db.NhanViens.FirstOrDefault(x => x.Ma == ma);
            if (nvfind == null)
            {
                return NotFound();
            }
            db.NhanViens.DeleteOnSubmit(nvfind);
            db.SubmitChanges();
            return Ok("Xóa thành công !");
        }

        



    }
}
