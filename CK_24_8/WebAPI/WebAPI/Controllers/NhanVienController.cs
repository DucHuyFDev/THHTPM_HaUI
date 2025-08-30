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
        QLLuongEntities db = new QLLuongEntities();

        [HttpGet]
        [Route("api/nhanvien/getall")]

        public IEnumerable<NhanVienDTO> getAll()
        {
            return db.NhanViens.Select(x => new NhanVienDTO
            {
                Ma = x.Ma,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh,
                GioiTinh = x.GioiTinh,
                HsLuong = x.HsLuong,
                TenDonVi = db.DonVis.Where(y => y.MaDonVi == x.MaDonVi).Select(y => y.TenDonVi).FirstOrDefault()
            });
        }

        [HttpGet]
        [Route("api/nhanvien/getbymanv/{manv}")]
        public NhanVienDTO getbyMaNV(string manv)
        {
            return db.NhanViens.Where(x => x.Ma == manv).Select(x => new NhanVienDTO
            {
                Ma = x.Ma,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh,
                GioiTinh = x.GioiTinh,
                HsLuong = x.HsLuong,
                TenDonVi = db.DonVis.Where(y => y.MaDonVi == x.MaDonVi).Select(y => y.TenDonVi).FirstOrDefault()
            }).FirstOrDefault();
        }

        [HttpGet]
        [Route("api/nhanvien/getbydv/{madv}")]
        public IEnumerable<NhanVienDTO> getbyMaDV(string madv)
        {
            return db.NhanViens.Where(x => x.MaDonVi == madv).Select(x => new NhanVienDTO
            {
                Ma = x.Ma,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh,
                GioiTinh = x.GioiTinh,
                HsLuong = x.HsLuong,
                TenDonVi = db.DonVis.Where(y => y.MaDonVi == x.MaDonVi).Select(y => y.TenDonVi).FirstOrDefault()
            });
        }

    }
}
