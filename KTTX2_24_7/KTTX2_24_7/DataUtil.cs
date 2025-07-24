using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KTTX2_24_7
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUtil()
        {
            filename = "../../ketquahoctap.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement tmp = doc.CreateElement("bangdiem");
                root.AppendChild(tmp);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public List<SinhVien> getAllSinhVien()
        {
            XmlNodeList lst_node = root.SelectNodes("sinhvien");
            List<SinhVien> data = new List<SinhVien>();
            foreach (XmlNode node in lst_node)
            {
                SinhVien add_sv = new SinhVien();
                add_sv.masv = node.Attributes["masv"].Value;
                add_sv.monhoc = node.Attributes["monhoc"].Value;
                add_sv.diemlan1 = double.Parse(node.SelectSingleNode("diemlan1").InnerText);
                add_sv.diemlan2 = double.Parse(node.SelectSingleNode("diemlan2").InnerText);
                data.Add(add_sv);
            }
            return data;
        }

        public bool addSV(SinhVien add_sv)
        {
            XmlNode svfind = root.SelectSingleNode($"sinhvien[@masv = '{add_sv.masv}']");
            if (svfind != null)
            {
                return false;
            }
            XmlElement sv = doc.CreateElement("sinhvien");
            XmlElement dl1 = doc.CreateElement("diemlan1");
            XmlElement dl2 = doc.CreateElement("diemlan2");
            sv.SetAttribute("masv", add_sv.masv);
            sv.SetAttribute("monhoc", add_sv.monhoc);
            dl1.InnerText = add_sv.diemlan1.ToString();
            dl2.InnerText = add_sv.diemlan2.ToString();
            sv.AppendChild(dl1);
            sv.AppendChild(dl2);
            root.AppendChild(sv);
            doc.Save(filename);
            return true;

        }
        public bool UpdateSV(SinhVien sv_update)
        {
            XmlNode svfind = root.SelectSingleNode($"sinhvien[@masv = '{sv_update.masv}']");
            if (svfind == null)
            {
                return false;
            }
            XmlElement sv_new = doc.CreateElement("sinhvien");
            XmlElement dl1 = doc.CreateElement("diemlan1");
            XmlElement dl2 = doc.CreateElement("diemlan2");
            sv_new.SetAttribute("masv", sv_update.masv);
            sv_new.SetAttribute("monhoc", sv_update.monhoc);
            dl1.InnerText = sv_update.diemlan1.ToString();
            dl2.InnerText = sv_update.diemlan2.ToString();
            sv_new.AppendChild(dl1);
            sv_new.AppendChild(dl2);
            root.ReplaceChild(sv_new, svfind);
            doc.Save(filename);
            return true;
        }

        public bool DeleteSV(string masv)
        {
            XmlNode svfind = root.SelectSingleNode($"sinhvien[@masv = '{masv}']");
            if (svfind == null)
            {
                return false;
            }
            root.RemoveChild(svfind);
            doc.Save(filename);
            return true;
        }
    }
}
