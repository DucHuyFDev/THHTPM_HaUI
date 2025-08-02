using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restful1_8
{
    public class NhanVienDTO
    {
        public int manv { get; set; }
        public string hoten { get; set; }
        public DateTime ngaysinh { get; set; }
        public bool gioitinh { get; set; }
        public double hesoluong { get; set; }
        public string tendonvi { get; set; }
    }
}