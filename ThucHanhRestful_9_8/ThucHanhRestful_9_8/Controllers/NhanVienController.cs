using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucHanhRestful_9_8.Models;

namespace ThucHanhRestful_9_8.Controllers
{
    public class NhanVienController : ApiController
    {
        QLNhanVienEntities db = new QLNhanVienEntities();

        [HttpGet]
        [Route("api/nhanvien")]
        public IEnumerable<NhanVien> getAllData()
        {
            return db.NhanViens;
        }

        [HttpGet]
        [Route("api/nhanvien/{id}")]
        public IEnumerable<NhanVien> getDataByID(string id)
        {
            return db.NhanViens.Where(x => x.MaNV == id);
        }

        [HttpPost]
        [Route("api/nhanvien")]
        public IHttpActionResult postNV(NhanVien nv)
        {
            var nvfind = db.NhanViens.FirstOrDefault(x => x.MaNV == nv.MaNV);
            if (nvfind  == null)
            {
                db.NhanViens.Add(nv);
                db.SaveChanges();
                return Ok("Thêm thành công !");
            }
            return BadRequest("Đã tồn tại mã nhân viên này !");
        }

        [HttpPut]
        [Route("api/nhanvien")]
        public IHttpActionResult putNV(NhanVien nv)
        {
            var nvfind = db.NhanViens.FirstOrDefault(x => x.MaNV == nv.MaNV);
            if (nvfind != null)
            {
                nvfind.TenNV = nv.TenNV;
                nvfind.Luong = nv.Luong;
                db.SaveChanges();
                return Ok("Cập nhật thành công !");
            }
            return BadRequest("Không tồn tại mã nhân viên này !");
        }

        [HttpDelete]
        [Route("api/nhanvien/{id}")]
        public IHttpActionResult deleteNV(string id)
        {
            var nvfind = db.NhanViens.FirstOrDefault(x => x.MaNV == id);
            if (nvfind != null)
            {
                db.NhanViens.Remove(nvfind);
                db.SaveChanges();
                return Ok("Xóa thành công !");
            }
            return BadRequest("Không tồn tại mã nhân viên này !");
        }
    }
}
