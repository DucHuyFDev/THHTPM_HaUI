using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeDucHuy_2022600377_De1
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string path;

        public DataUtil()
        {
            path = "../../BangDiem.xml";
            doc = new XmlDocument();
            if (!File.Exists(path))
            {
                XmlElement bd = doc.CreateElement("BangDiem");
                doc.AppendChild(bd);
                doc.Save(path);
            }
            doc.Load(path);
            root = doc.DocumentElement;
            
        }

        public List<SinhVien> getAllData()
        {
            XmlNodeList node_list = root.SelectNodes("SinhVien");
            List<SinhVien> data = new List<SinhVien>();
            foreach (XmlNode node in node_list)
            {
                SinhVien tmp = new SinhVien();
                tmp.masv = node.Attributes["masv"].Value;
                tmp.monhoc = node.Attributes["monhoc"].Value;
                tmp.diemlan1 = double.Parse(node.SelectSingleNode("DiemLan1").InnerText);
                tmp.diemlan2 = double.Parse(node.SelectSingleNode("DiemLan2").InnerText);
                data.Add(tmp);
            }
            return data;
        }

        public bool addSV(SinhVien sv)
        {
            XmlNode svfind = root.SelectSingleNode($"SinhVien[@masv = '{sv.masv}']");
            if (svfind != null)
            {
                return false;
            }
            XmlElement sv_new = doc.CreateElement("SinhVien");
            XmlElement dl1 = doc.CreateElement("DiemLan1");
            XmlElement dl2 = doc.CreateElement("DiemLan2");
            sv_new.SetAttribute("masv", sv.masv);
            sv_new.SetAttribute("monhoc", sv.monhoc);
            dl1.InnerText = sv.diemlan1.ToString();
            dl2.InnerText = sv.diemlan2.ToString();
            sv_new.AppendChild(dl1);
            sv_new.AppendChild(dl2);
            root.AppendChild(sv_new);
            doc.Save(path);
            return true;
        }

        public bool updateSV(SinhVien sv)
        {
            XmlNode svfind = root.SelectSingleNode($"SinhVien[@masv = '{sv.masv}']");
            if (svfind == null)
            {
                return false;
            }
            XmlElement sv_new = doc.CreateElement("SinhVien");
            XmlElement dl1 = doc.CreateElement("DiemLan1");
            XmlElement dl2 = doc.CreateElement("DiemLan2");
            sv_new.SetAttribute("masv", sv.masv);
            sv_new.SetAttribute("monhoc", sv.monhoc);
            dl1.InnerText = sv.diemlan1.ToString();
            dl2.InnerText = sv.diemlan2.ToString();
            sv_new.AppendChild(dl1);
            sv_new.AppendChild(dl2);
            root.ReplaceChild(sv_new, svfind);
            doc.Save(path);
            return true;
        }

        public bool deleteSV(string id)
        {
            XmlNode svfind = root.SelectSingleNode($"SinhVien[@masv = '{id}']");
            if(svfind == null)
            {
                return false;
            }
            root.RemoveChild(svfind);
            doc.Save(path);
            return true;
        }
    }
}
