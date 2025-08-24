using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LeDucHuy_2022600377.Models;

namespace LeDucHuy_2022600377.Controllers
{
    public class SinhVienController : ApiController
    {
        QLSVEntities db = new QLSVEntities();
        [HttpGet]
        [Route("api/getall")]
        public IEnumerable<SinhVien> getall()
        {
            return db.SinhViens;
        }
        [HttpGet]
        [Route("api/getbyclass/{class_name}")]
        public IEnumerable<SinhVien> getbyclass(string class_name)
        {
            return db.SinhViens.Where (x => x.Lop == class_name);
        }
        [HttpPost]
        [Route("api/post")]
        public IHttpActionResult post(SinhVien s)
        {
            try
            {
                if (s.DiemTB < 0 || s.DiemTB > 10)
                {
                    return BadRequest("Điểm không hợp lệ ! Thêm thất bại !");
                }
                var svfind = db.SinhViens.FirstOrDefault(x => x.MaSV == s.MaSV);
                if (svfind == null)
                {
                    db.SinhViens.Add(s);
                    db.SaveChanges();
                    return Ok("Thêm thành công");
                }
                return BadRequest("Đã có sinh viên tồn tại mã này ! Thêm thất bại");
            }
            catch(Exception ex)
            {
                return BadRequest($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("api/put")]
        public IHttpActionResult put(SinhVien s)
        {
            try
            {
                if (s.DiemTB < 0 || s.DiemTB > 10)
                {
                    return BadRequest("Điểm không hợp lệ ! Thêm thất bại !");
                }
                var svfind = db.SinhViens.FirstOrDefault(x => x.MaSV == s.MaSV);
                if (svfind != null)
                {
                    svfind.HoTen = s.HoTen;
                    svfind.Lop = s.Lop;
                    svfind.DiemTB = s.DiemTB;
                    svfind.NgaySinh = s.NgaySinh;
                    db.SaveChanges();
                    return Ok("Cập nhật thành công");
                }
                return BadRequest("Không có sinh viên tồn tại mã này ! Cập nhật thất bại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/delete/{id}")]
        public IHttpActionResult delete(string id)
        {
            try
            {
                var svfind = db.SinhViens.FirstOrDefault(x => x.MaSV == id);
                if (svfind != null)
                {
                    db.SinhViens.Remove(svfind);
                    db.SaveChanges();
                    return Ok("Xóa thành công");
                }
                return BadRequest("Không có sinh viên tồn tại mã này ! Xóa thất bại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Có lỗi xảy ra: {ex.Message}");
            }
        }

    }
}
