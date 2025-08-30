using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class PhongBan
    {
        [DisplayName("Mã phòng ban")]
        public string MaPB { get; set; }
        [DisplayName("Tên phòng ban")]
        public string TenPB { get; set; }
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
    }
}
