using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KTTX2_29_7
{
    internal class DataUtil
    {
        XmlElement root;
        XmlDocument doc;
        string path;

        public DataUtil()
        {
            path = "../../ThuVien.xml";
            doc = new XmlDocument();
            if (!File.Exists(path))
            {
                XmlElement tv = doc.CreateElement("ThuVien");
                doc.AppendChild(tv);
                doc.Save(path);
            }
            doc.Load(path);
            root = doc.DocumentElement;
        }

        public List<Sach> getAllData()
        {
            XmlNodeList lst_node_data = root.SelectNodes("Sach");
            List<Sach> sach_list = new List<Sach>();    
            foreach(XmlNode node in lst_node_data)
            {
                Sach tmp = new Sach();
                tmp.masach = node.Attributes["masach"].Value;
                tmp.tensach = node.SelectSingleNode("TenSach").InnerText;
                tmp.sotrang = int.Parse(node.SelectSingleNode("SoTrang").InnerText);
                XmlNode tg = node.SelectSingleNode("TacGia");
                tmp.hotentg = tg.SelectSingleNode("HoTen").InnerText;
                tmp.diachitg = tg.SelectSingleNode("DiaChi").InnerText;
                sach_list.Add(tmp);
            }
            return sach_list;
        }

        public bool addSach(Sach s)
        {
            XmlNode sachfind = root.SelectSingleNode($"Sach[@masach = '{s.masach}']");
            if ( sachfind != null)
            {
                return false;
            }
            XmlElement sach = doc.CreateElement("Sach");
            XmlElement tensach = doc.CreateElement("TenSach");
            XmlElement sotrang = doc.CreateElement("SoTrang");
            XmlElement tacgia = doc.CreateElement("TacGia");
            XmlElement hoten = doc.CreateElement("HoTen");
            XmlElement diachi = doc.CreateElement("DiaChi");
            sach.SetAttribute("masach", s.masach);
            tensach.InnerText = s.tensach;
            sotrang.InnerText = s.sotrang.ToString();
            hoten.InnerText = s.hotentg;
            diachi.InnerText = s.diachitg;
            tacgia.AppendChild(hoten);
            tacgia.AppendChild(diachi);
            sach.AppendChild(tensach);
            sach.AppendChild(sotrang);
            sach.AppendChild(tacgia);
            root.AppendChild(sach);
            doc.Save(path);
            return true;
        }

        public bool deleteSach(string id)
        {
            XmlNode sachfind = root.SelectSingleNode($"Sach[@masach = '{id}']");
            if (sachfind == null)
            {
                return false;
            }
            root.RemoveChild(sachfind);
            doc.Save(path);
            return true;

        }

        public List<Sach> searchSach(int from, int to)
        {
            XmlNodeList sach_list = root.SelectNodes($"Sach[SoTrang >= {from} and SoTrang <= {to}]");
            List<Sach> find = new List<Sach>();
            foreach (XmlNode node in sach_list)
            {
                Sach tmp = new Sach();
                tmp.masach = node.Attributes["masach"].Value;
                tmp.tensach = node.SelectSingleNode("TenSach").InnerText;
                tmp.sotrang = int.Parse(node.SelectSingleNode("SoTrang").InnerText);
                XmlNode tg = node.SelectSingleNode("TacGia");
                tmp.hotentg = tg.SelectSingleNode("HoTen").InnerText;
                tmp.diachitg = tg.SelectSingleNode("DiaChi").InnerText;
                find.Add(tmp);
            }
            return find;
        }

        public bool updateSach(Sach s)
        {
            XmlNode sachfind = root.SelectSingleNode($"Sach[@masach = '{s.masach}']");
            if (sachfind == null)
            {
                return false;
            }
            XmlElement sach_new = doc.CreateElement("Sach");
            XmlElement tensach = doc.CreateElement("TenSach");
            XmlElement sotrang = doc.CreateElement("SoTrang");
            XmlElement tacgia = doc.CreateElement("TacGia");
            XmlElement hoten = doc.CreateElement("HoTen");
            XmlElement diachi = doc.CreateElement("DiaChi");
            sach_new.SetAttribute("masach", s.masach);
            tensach.InnerText = s.tensach;
            sotrang.InnerText = s.sotrang.ToString();
            hoten.InnerText = s.hotentg;
            diachi.InnerText = s.diachitg;
            tacgia.AppendChild(hoten);
            tacgia.AppendChild(diachi);
            sach_new.AppendChild(tensach);
            sach_new.AppendChild(sotrang);
            sach_new.AppendChild(tacgia);
            root.ReplaceChild(sach_new, sachfind);
            doc.Save(path);
            return true;
        }
    }
}
