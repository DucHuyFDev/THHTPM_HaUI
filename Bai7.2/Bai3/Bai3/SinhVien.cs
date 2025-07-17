using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    internal class SinhVien
    {
        public string masv { get; set; }
        public string hoten { get; set; }
        public string tuoi { get; set; }
        public string diachi { get; set; }
        public string dienthoai { get; set; }

        public SinhVien(string masv, string hoten, string tuoi, string diachi, string dt)
        {
            this.masv = masv;
            this.hoten = hoten;
            this.tuoi = tuoi;
            this.diachi = diachi;
            this.dienthoai = dt;
        }
    }
}
