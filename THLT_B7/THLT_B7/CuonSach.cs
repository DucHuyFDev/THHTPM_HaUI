using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace THLT_B7
{
    internal class CuonSach
    {
        public string masach { get; set; }
        public string theloai { get; set; }
        public string tensach { get; set; }
        public string sotrang { get; set; }
        public string hoten { get; set; }
        public string dienthoai { get; set; }
        public string giatien { get; set; }
        public CuonSach()
        {

        }
        public CuonSach(string masach, string theloai, string tensach, string sotrang, string hoten, string dienthoai, string giatien)
        {
            this.masach = masach;
            this.theloai = theloai;
            this.tensach = tensach;
            this.sotrang = sotrang;
            this.hoten = hoten;
            this.dienthoai = dienthoai;
            this.giatien = giatien;
        }

        public static void ThemSach (XmlDocument doc, XmlElement root, CuonSach b)
        {
            XmlElement cuonsach = doc.CreateElement("cuonsach");
            cuonsach.SetAttribute("masach", b.masach);
            cuonsach.SetAttribute("theloai", b.theloai);
            XmlElement tensach = doc.CreateElement("tensach");
            
            XmlElement sotrang = doc.CreateElement("sotrang");
            
            XmlElement tacgia = doc.CreateElement("tacgia");
            XmlElement hoten = doc.CreateElement("hoten");
            
            XmlElement dienthoai = doc.CreateElement("sdt");
            
            XmlElement giatien = doc.CreateElement("giatien");
            
            root.AppendChild(cuonsach);
            cuonsach.AppendChild(tensach);
            tensach.InnerText = b.tensach;
            cuonsach.AppendChild(sotrang);
            sotrang.InnerText = b.sotrang;
            cuonsach.AppendChild(tacgia);
            cuonsach.AppendChild(giatien);
            tacgia.AppendChild(hoten);
            hoten.InnerText = b.hoten;
            tacgia.AppendChild(dienthoai);
            dienthoai.InnerText = b.dienthoai;
        }
    }
}
