using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeDucHuy_2022600377_call
{
    internal class SinhVien
    {
        [DisplayName("Mã sinh viên")]
        public string masv { get; set; }
        [DisplayName("Tên sinh viên")]
        public string hoten { get; set; }
        [DisplayName("Lớp")]
        public string lop { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime ngaysinh { get; set; }
        [DisplayName("Điểm TB")]
        public float diemtb { get; set; }
    }
}
