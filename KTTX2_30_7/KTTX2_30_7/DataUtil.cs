using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KTTX2_30_7
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string path;

        public DataUtil()
        {
            doc = new XmlDocument();
            path = "../../DanhSachKhachHang.xml";
            if (!File.Exists(path))
            {
                XmlElement dskh = doc.CreateElement("DanhSachKhachHang");
                doc.AppendChild(dskh);
                doc.Save(path);
            }
            doc.Load(path);
            root = doc.DocumentElement;
        }

        public List<KhachHang> getAllData()
        {
            XmlNodeList ds_node = root.SelectNodes("KhachHang");
            List<KhachHang> dskh = new List<KhachHang>();
            foreach (XmlNode node in ds_node)
            {
                KhachHang tmp = new KhachHang();
                tmp.makh = node.Attributes["makh"].Value;
                tmp.chinhanh = node.Attributes["chinhanh"].Value;
                tmp.hoten = node.SelectSingleNode("HoTen").InnerText;
                tmp.diachi = node.SelectSingleNode("DiaChi").InnerText;
                tmp.sodt = node.SelectSingleNode("SoDT").InnerText;
                dskh.Add(tmp);
            }
            return dskh;
        }

        public XmlElement taoNode(KhachHang tmp)
        {
            XmlElement kh = doc.CreateElement("KhachHang");
            XmlElement ht = doc.CreateElement("HoTen");
            XmlElement dc = doc.CreateElement("DiaChi");
            XmlElement sdt = doc.CreateElement("SoDT");
            kh.SetAttribute("makh", tmp.makh);
            kh.SetAttribute("chinhanh", tmp.chinhanh);
            ht.InnerText = tmp.hoten;
            dc.InnerText = tmp.diachi;
            sdt.InnerText = tmp.sodt;
            kh.AppendChild(ht);
            kh.AppendChild(dc);
            kh.AppendChild(sdt);
            return kh;
        }

        public bool AddKH(KhachHang add_kh)
        {
            XmlNode khfind = root.SelectSingleNode($"KhachHang[@makh = '{add_kh.makh}']");
            if (khfind != null )
            {
                return false;
            }
            XmlNode kh_new = taoNode(add_kh);
            root.AppendChild(kh_new);
            doc.Save(path);
            return true;
            
        }

        public bool updateKH(KhachHang add_kh)
        {
            XmlNode khfind = root.SelectSingleNode($"KhachHang[@makh = '{add_kh.makh}']");
            if (khfind == null)
            {
                return false;
            }
            XmlNode kh_new = taoNode(add_kh);
            root.ReplaceChild(kh_new, khfind);
            doc.Save(path);
            return true;

        }

        public bool deleteKH(string makh)
        {
            XmlNode khfind = root.SelectSingleNode($"KhachHang[@makh = '{makh}']");
            if (khfind == null)
            {
                return false;
            }
            root.RemoveChild(khfind);
            doc.Save(path);
            return true;
        }
    }
}
