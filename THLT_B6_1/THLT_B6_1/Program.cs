using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace THLT_B6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Chương trình đọc file XML");
            XmlDocument doc = new XmlDocument();
            doc.Load("ThuVien.xml");
            XmlElement root = doc.DocumentElement;
            XmlNodeList lst = root.SelectNodes("cuonsach");
            int i = 1;
            foreach (XmlNode node in lst)
            {
                Console.WriteLine($"Phần tử thứ {i}");
                Console.WriteLine("Tên sách: " + node.SelectSingleNode("tensach").InnerText);
                Console.WriteLine("Số trang: " + node.SelectSingleNode("sotrang").InnerText);
                Console.WriteLine("Họ tên tác giả: " + node.SelectSingleNode("tacgia/hoten").InnerText);
                Console.WriteLine("ĐT tác giả: " + node.SelectSingleNode("tacgia/dienthoai").InnerText);
                Console.WriteLine("Giá: " + node.SelectSingleNode("giatien").InnerText);
                i++;
            }
            Console.WriteLine("Số lượng sách có trong file: " + lst.Count);
        }
    }
}
