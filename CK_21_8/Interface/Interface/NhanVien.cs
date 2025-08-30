using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class NhanVien
    {
        [DisplayName("Mã nhân viên")]

        public string MaNV { get; set; }
        [DisplayName("Tên nhân viên")]
        public string HoTen { get; set; }
        [DisplayName("Trình độ")]
        public string TrinhDo { get; set; }
        [DisplayName("Lương")]
        public double Luong { get; set; }
        [DisplayName("Tên phòng ban")]
        public string TenPB { get; set; }
    }
}
