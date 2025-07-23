using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai9_3.Controllers
{
    public class NhanVienController : ApiController
    {
        private QLLuongDataContext db;
        public NhanVienController()
        {
            string con_string = ConfigurationManager.ConnectionStrings["QLLuongDataContext"].ConnectionString;
            db = new QLLuongDataContext(con_string);
        }

        [HttpGet]
        public IEnumerable<NhanVienDTO> GetAllNV()
        {
            return db.NhanViens.Select(x => new NhanVienDTO
            {
                ma = x.Ma,
                hoten = x.HoTen,
                ngaysinh = (DateTime)x.NgaySinh,
                gioitinh = (bool)x.GioiTinh,
                hesoluong = (float)(x.HsLuong ?? 0),
                tendonvi = x.DonVi.TenDonVi
            });
        }

        [HttpGet]
        [Route ("api/nhanvien")]
        public IHttpActionResult GetNVById(string manv)
        {
            var nvfind = db.NhanViens.FirstOrDefault(x => x.Ma == manv);
            if (nvfind == null)
                return NotFound();
            return Ok(new NhanVienDTO
            {
                ma = nvfind.Ma,
                hoten = nvfind.HoTen,
                ngaysinh = (DateTime)nvfind.NgaySinh,
                gioitinh = (bool)nvfind.GioiTinh,
                hesoluong = (float)(nvfind.HsLuong ?? 0),
                tendonvi = nvfind.DonVi.TenDonVi
            });
        }

        [HttpGet]
        [Route ("api/nhanvien")]
        public IHttpActionResult GetNVByDV(string tendv)
        {
            var lst_nv_find = db.NhanViens.Where(x => x.DonVi.TenDonVi == tendv).Select(x => new NhanVienDTO
            {
                ma = x.Ma,
                hoten = x.HoTen,
                ngaysinh = (DateTime)x.NgaySinh,
                gioitinh = (bool)x.GioiTinh,
                hesoluong = (float)(x.HsLuong ?? 0),
                tendonvi = x.DonVi.TenDonVi
            }).ToList();
            if (lst_nv_find.Count == 0)
            {
                return NotFound();
            }
            return Ok(lst_nv_find);
        }

        [HttpGet]
        [Route ("api/nhanvien/findbysex/{gt}")]
        public IHttpActionResult GetNVBySex(bool gt)
        {
            var nvfind = db.NhanViens.Where(x => x.GioiTinh == gt).Select(x => new NhanVienDTO
            {
                ma = x.Ma,
                hoten = x.HoTen,
                ngaysinh = (DateTime)x.NgaySinh,
                gioitinh = (bool)x.GioiTinh,
                hesoluong = (float)(x.HsLuong ?? 0),
                tendonvi = x.DonVi.TenDonVi
            }).ToList ();
            if (nvfind.Count == 0)
            {
                return NotFound();
            }
            else return Ok(nvfind);
        }

        [HttpGet]
        [Route ("api/nhanvien/findbyhsl")]

        // Khi truy vấn hoặc kiểm sử dụng cấu trúc điều kiện "vd: api/nhanvien/findbyhsl?a=1.5&b=1.8"
        public IHttpActionResult GetNVBySalaryRate(float a, float b)
        {
            var nvfind = db.NhanViens.Where(x => x.HsLuong >= a && x.HsLuong <= b).Select(x => new NhanVienDTO
            {
                ma = x.Ma,
                hoten = x.HoTen,
                ngaysinh = (DateTime)x.NgaySinh,
                gioitinh = (bool)x.GioiTinh,
                hesoluong = (float)(x.HsLuong ?? 0),
                tendonvi = x.DonVi.TenDonVi
            }).ToList();
            if (nvfind.Count == 0)
            {
                return NotFound();
            }
            else return Ok(nvfind);
        }
        [HttpGet]
        [Route("api/donvi")]
        public IHttpActionResult GetAllDV()
        {
            var dv_list = db.DonVis.Select(x => x.TenDonVi).ToList();
            if (dv_list.Count == 0)
            {
                return NotFound();
            }
            else return Ok(dv_list);
        }
        [HttpGet]
        [Route("api/nhanvien/getbydv")]
        public IHttpActionResult GetNVInDV(string tendv)
        {
            var dv = db.DonVis.FirstOrDefault(x => x.TenDonVi == tendv);
            if (dv == null)
                return NotFound();
            var nv_find = db.NhanViens.Where(x => x.DonVi.MaDonVi == dv.MaDonVi).Select(x => new NhanVienDTO
            {
                ma = x.Ma,
                hoten = x.HoTen,
                ngaysinh = (DateTime)x.NgaySinh,
                gioitinh = (bool)x.GioiTinh,
                hesoluong = (float)(x.HsLuong ?? 0),
                tendonvi = x.DonVi.TenDonVi
            }).ToList();
            if (nv_find.Count == 0)
                return NotFound();
            else return Ok(nv_find);
        }

        [HttpPost]
        [Route("api/donvi")]

        // Nên viết ra donvicontroller sẽ đỡ rối hơn
        public IHttpActionResult Post(DonVi add_dv)
        {
            var dvfind = db.DonVis.FirstOrDefault(x => x.MaDonVi == add_dv.MaDonVi);
            if (dvfind != null) 
            {
                return BadRequest("Đơn vị đã tồn tại");
            }
            db.DonVis.InsertOnSubmit(add_dv);
            db.SubmitChanges();
            return Ok("Đã thêm thành công");
        }

        [HttpPost]
        [Route("api/nhanvien")]
        public IHttpActionResult Post(NhanVienDTO add_nv)
        {
            var dvfind = db.DonVis.FirstOrDefault(x => x.TenDonVi == add_nv.tendonvi);
            if (dvfind == null)
            {
                return BadRequest("Đơn vị không tồn tại");
            }
            var nv_find = db.NhanViens.FirstOrDefault(x => x.Ma == add_nv.ma);
            if (nv_find != null)
                return BadRequest("Đã có nhân viên có mã này");
            NhanVien new_nv = new NhanVien
            {
                Ma = add_nv.ma,
                HoTen = add_nv.hoten,
                NgaySinh = (DateTime)add_nv.ngaysinh,
                GioiTinh = (bool)add_nv.gioitinh,
                HsLuong = add_nv.hesoluong,
                MaDonVi = dvfind.MaDonVi
            };
            db.NhanViens.InsertOnSubmit(new_nv);
            db.SubmitChanges();
            return Ok("Đã thêm thành công !");
        }

        
    }
}
