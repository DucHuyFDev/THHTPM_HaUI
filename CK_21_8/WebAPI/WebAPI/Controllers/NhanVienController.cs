using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    public class NhanVienController : ApiController
    {
        QLDAEntities db = new QLDAEntities();
        [HttpGet]
        [Route("nhanvien/getnv")]
        public IEnumerable<NhanVienDTO> getNV()
        {
            return db.NhanViens.Select(x => new NhanVienDTO
            {
                MaNV = x.MaNV,
                HoTen = x.HoTen,
                Luong = x.Luong,
                TrinhDo = x.TrinhDo,
                TenPB = db.PhongBans.FirstOrDefault(y => y.MaPB == x.MaPB).TenPB
            });
        }

        [HttpPost]
        [Route("nhanvien/postnv")]
        public IHttpActionResult postNV(NhanVienDTO nv)
        {
            try
            {
                var pbfind = db.PhongBans.FirstOrDefault(x => x.TenPB == nv.TenPB);
                if (pbfind == null)
                {
                    return Ok("Phòng ban không tồn tại !");
                }
                var nvfind = db.NhanViens.FirstOrDefault(x => x.MaNV == nv.MaNV);
                if (nvfind != null)
                {
                    return Ok("Đã có mã nhân viên vừa nhập !");
                }
                NhanVien new_nv = new NhanVien
                {
                    MaNV = nv.MaNV,
                    HoTen = nv.HoTen,
                    TrinhDo = nv.TrinhDo,
                    Luong = nv.Luong,
                    MaPB = pbfind.MaPB
                };
                db.NhanViens.Add(new_nv);
                db.SaveChanges();
                return Ok("Thêm thành công !");
            }
            catch (Exception ex)
            {
                return BadRequest($"Có lỗi xảy ra khi thêm: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("nhanvien/putnv")]
        public IHttpActionResult putNV(NhanVienDTO nv)
        {
            try
            {
                var pbfind = db.PhongBans.FirstOrDefault(x => x.TenPB == nv.TenPB);
                if (pbfind == null)
                {
                    return Ok("Phòng ban không tồn tại !");
                }
                var nvfind = db.NhanViens.FirstOrDefault(x => x.MaNV == nv.MaNV);
                if (nvfind == null)
                {
                    return Ok("Không có mã nhân viên vừa nhập !");
                }
                nvfind.HoTen = nv.HoTen;
                nvfind.TrinhDo = nv.TrinhDo;
                nvfind.Luong = nv.Luong;
                nvfind.MaPB = pbfind.MaPB;
                db.SaveChanges();
                return Ok("Cập nhật thành công !");
            }
            catch (Exception ex)
            {
                return BadRequest($"Có lỗi xảy ra khi cập nhật: {ex.Message}");
            }
        }
    }
}
