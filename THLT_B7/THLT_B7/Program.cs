using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace THLT_B7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("thuvien");
            CuonSach b = new CuonSach("j01", "Công nghệ thông tin","Lập trình Java", "500", "Nguyễn Đăng Hoàng",
               "0123456", "450");
            CuonSach.ThemSach(doc, root, b);
            CuonSach b2 = new CuonSach("j02", "Công nghệ sinh học","Sinh học đại cương", "500", "Nguyễn Hoàng Duyên",
               "0987654", "700");
            CuonSach.ThemSach(doc, root, b2);
            doc.AppendChild(root);
            doc.Save("thuvien.xml");

        }
    }
}
