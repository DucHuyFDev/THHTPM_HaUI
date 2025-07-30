using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KTTX2_28_7
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUtil()
        {
            filename = "../../ThuVien.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement tv = doc.CreateElement("thuvien");
                doc.AppendChild(tv);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public List<Sach> getAllData()
        {
            XmlNodeList lst_node_data = root.SelectNodes("sach");
            List<Sach> data = new List<Sach>();
            foreach (XmlNode node in lst_node_data)
            {
                Sach tmp = new Sach();
                tmp.masach = node.Attributes["masach"].Value;
                tmp.tensach = node.SelectSingleNode("tensach").InnerText;
                tmp.sotrang = int.Parse(node.SelectSingleNode("sotrang").InnerText);
                XmlNode tg = node.SelectSingleNode("tacgia");
                tmp.tentacgia = tg.Attributes["hoten"].Value;
                tmp.diachitgia = tg.SelectSingleNode("diachi").InnerText;
                data.Add(tmp);
            }
            return data;
        }

        public bool addSach(Sach s)
        {
            XmlNode sachfind = root.SelectSingleNode($"sach[@masach = '{s.masach}']");
            if (sachfind != null)
            {
                return false;
            }
            XmlElement sach = doc.CreateElement("sach");
            XmlElement tensach = doc.CreateElement("tensach");
            XmlElement sotrang = doc.CreateElement("sotrang");
            XmlElement tacgia = doc.CreateElement("tacgia");
            XmlElement dctg = doc.CreateElement("diachi");
            sach.SetAttribute("masach", s.masach);
            tacgia.SetAttribute("hoten", s.tentacgia);
            tensach.InnerText = s.tensach;
            sotrang.InnerText = s.sotrang.ToString();
            dctg.InnerText = s.diachitgia;
            tacgia.AppendChild(dctg);
            sach.AppendChild(tensach);
            sach.AppendChild(sotrang);
            sach.AppendChild(tacgia);
            root.AppendChild(sach);
            doc.Save(filename);
            return true;

        }

        public bool updateSach(Sach s)
        {
            XmlNode sachfind = root.SelectSingleNode($"sach[@masach = '{s.masach}']");
            if (sachfind == null)
            {
                return false;
            }
            XmlElement sach_new = doc.CreateElement("sach");
            XmlElement tensach = doc.CreateElement("tensach");
            XmlElement sotrang = doc.CreateElement("sotrang");
            XmlElement tacgia = doc.CreateElement("tacgia");
            XmlElement dctg = doc.CreateElement("diachi");
            sach_new.SetAttribute("masach", s.masach);
            tacgia.SetAttribute("hoten", s.tentacgia);
            tensach.InnerText = s.tensach;
            sotrang.InnerText = s.sotrang.ToString();
            dctg.InnerText = s.diachitgia;
            tacgia.AppendChild(dctg);
            sach_new.AppendChild(tensach);
            sach_new.AppendChild(sotrang);
            sach_new.AppendChild(tacgia);
            root.ReplaceChild(sach_new, sachfind);
            doc.Save(filename);
            return true;
        }

        public List<Sach> searchSach(string hotentg)
        {
            List<Sach> search_result = new List<Sach>();
            XmlNodeList sachfind = root.SelectNodes($"sach[tacgia/@hoten = '{hotentg}']");
            if (sachfind != null)
            {
                foreach (XmlNode node in sachfind)
                {
                    Sach tmp = new Sach();
                    tmp.masach = node.Attributes["masach"].Value;
                    tmp.tensach = node.SelectSingleNode("tensach").InnerText;
                    tmp.sotrang = int.Parse(node.SelectSingleNode("sotrang").InnerText);
                    XmlNode tg = node.SelectSingleNode("tacgia");
                    tmp.tentacgia = tg.Attributes["hoten"].Value;
                    tmp.diachitgia = tg.SelectSingleNode("diachi").InnerText;
                    search_result.Add(tmp);
                }
            }
            return search_result;
        }

        public bool deleteSach(string id)
        {
            XmlNode sachfind = root.SelectSingleNode($"sach[@masach = '{id}']");
            if (sachfind == null)
            {
                return false;
            }
            root.RemoveChild( sachfind );
            doc.Save(filename);
            return true;
        }
    }
}
