using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using API_QLNhanVien_11_8.Models;

namespace API_QLNhanVien_11_8.Controllers
{
    public class NhanVienController : ApiController
    {
        QLNhanVienEntities db = new QLNhanVienEntities();
        [HttpGet]
        [Route("api/nhanvien/getall")]
        public IEnumerable<NhanVien> getAllNV()
        {
            return db.NhanViens;
        }

        [HttpGet]
        [Route("api/nhanvien/getbyid/{id}")]
        public IEnumerable<NhanVien> getNVById(string id)
        {
            return db.NhanViens.Where(x => x.MaNV == id);
        }

        [HttpPost]
        [Route("api/nhanvien/post")]
        public IHttpActionResult addNV(NhanVien nv)
        {
            var nvfind = db.NhanViens.FirstOrDefault(x => x.MaNV == nv.MaNV);
            if (nvfind != null)
            {
                return BadRequest("Đã có nhân viên giữ mã này !");
            }
            db.NhanViens.Add(nv);
            db.SaveChanges();
            return Ok("Thêm thành công !");
        }

        [HttpPut]
        [Route("api/nhanvien/put")]
        public IHttpActionResult putNV(NhanVien nv)
        {
            var nvfind = db.NhanViens.FirstOrDefault(x => x.MaNV == nv.MaNV);
            if (nvfind == null)
            {
                return BadRequest("Không có nhân viên giữ mã này !");
            }
            nvfind.TenNV = nv.TenNV;
            nvfind.TrinhDo = nv.TrinhDo;
            nvfind.Luong = nv.Luong;
            db.SaveChanges();
            return Ok("Cập nhật thành công !");
        }

        [HttpDelete]
        [Route("api/nhanvien/delete/{id}")]
        public IHttpActionResult deleteNV(string id)
        {
            var nvfind = db.NhanViens.FirstOrDefault(x => x.MaNV == id);
            if (nvfind == null)
            {
                return BadRequest("Không có nhân viên giữ mã này !");
            }
            db.NhanViens.Remove(nvfind);
            db.SaveChanges();
            return Ok("Xóa thành công !");
        }
    }
}