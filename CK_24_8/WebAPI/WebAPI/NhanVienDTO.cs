using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class NhanVienDTO
    {
        public string Ma { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public double HsLuong { get; set; }
        public string TenDonVi { get; set; }
    }
}