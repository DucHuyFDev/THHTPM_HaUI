using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Restful1_8.Controllers
{
    public class NhanVienController : ApiController
    {
        private QLLuongDataContext db;
        public NhanVienController()
        {
            string conn_string = ConfigurationManager.ConnectionStrings["QLLuongDataContext"].ConnectionString;
            db =  new QLLuongDataContext(conn_string);
        }

        [HttpGet]
        // Chạy test link trong Postman ..../api/nhanvien
        public IEnumerable<NhanVienDTO> get()
        {
            return db.NhanViens.Select(x => new NhanVienDTO
            {
                manv = x.MaNhanVien,
                hoten = x.HoTen,
                ngaysinh = (DateTime)x.NgaySinh,
                gioitinh = (bool)x.GioiTinh,
                hesoluong = (double)x.HsLuong,
                tendonvi = x.DonVi.TenDonVi,
            });
        }
    }
}
