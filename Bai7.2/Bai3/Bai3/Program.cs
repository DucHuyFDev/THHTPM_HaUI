using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<SinhVien> lst= new List<SinhVien>();
            lst.Add(new SinhVien("SV001", "Nguyễn Văn A", "20", "Hà Nội", "0123456789"));
            lst.Add(new SinhVien("SV002", "Trần Thị B", "20", "Nghệ An", "0987654321"));
            string json = JsonConvert.SerializeObject(lst, Formatting.Indented);
            File.WriteAllText("sinhvien.dat", json);


            // Đọc file.dat
            Console.OutputEncoding = Encoding.UTF8;
            string json_readdata = File.ReadAllText("sinhvien.dat");
            List<SinhVien> ds2 = JsonConvert.DeserializeObject<List<SinhVien>>(json_readdata);

            Console.WriteLine("\n== Danh sách sinh viên ==");
            foreach (var sv in ds2)
            {
                Console.WriteLine($"{sv.masv} - {sv.hoten} - {sv.tuoi} - {sv.diachi} - {sv.dienthoai}");
            }

        }
    }
}
