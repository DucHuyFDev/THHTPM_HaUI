using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bai6_1
{
    internal class Program
    {

        static void WriteToFile()
        {
            List<NhanVien> ds = new List<NhanVien>()
            {
                new NhanVien {MaNV = "NV01" , HoTen = "Nguyễn Văn A", Tuoi= 30,ChucVu= "Trưởng phòng"},
                new NhanVien {MaNV ="NV02" ,HoTen = "Lê Văn B",Tuoi= 25, ChucVu="Nhân viên"},
            };
            // Chuyển các class C# thành file JSON (Formating Indented nghĩa là có xuống dòng và thụt lề)
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            
            File.WriteAllText("nhanvien.json", json);
            Console.WriteLine("Đã ghi file nhân viên với định dạng json");
        }

        static void ReadFormFile()
        {
            if (!File.Exists("nhanvien.json"))
            {
                Console.WriteLine("File không tồn tại !");
                return;
            }

            string json_file = File.ReadAllText("nhanvien.json");
            // Chuyển file JSON thành class C#: Tạo thành 1 list các nhân viên dựa trên file json đã có
            List<NhanVien> ds = JsonConvert.DeserializeObject<List<NhanVien>>(json_file);
            foreach(var nv in ds)
            {
                Console.WriteLine(nv.MaNV + "   " + nv.HoTen + "    " + nv.ChucVu);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            WriteToFile();
            ReadFormFile();
        }
    }
}
