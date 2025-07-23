using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai9_3
{
    public class NhanVienDTO
    {
        public string ma { get; set; }
        public string hoten { get; set; }
        public DateTime ngaysinh { get; set; }
        public bool gioitinh { get; set; }
        // Từ các bài tiếp theo nên sử dụng decimal tránh bị sai số
        public float hesoluong { get; set; }
        public string tendonvi { get; set; }
    }
}