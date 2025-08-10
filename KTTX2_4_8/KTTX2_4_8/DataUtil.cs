using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KTTX2_4_8
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string path;

        public DataUtil()
        {
            doc = new XmlDocument();
            path = "../../ketquahoctap.xml";
            if (!File.Exists(path))
            {
                XmlElement bd = doc.CreateElement("bangdiem");
                doc.AppendChild(bd);
                doc.Save(path);
            }
            doc.Load(path);
            root = doc.DocumentElement;
        }

        public List<SinhVien> getAllData()
        {
            XmlNodeList data_xml = root.SelectNodes("sinhvien");
            List<SinhVien> result = new List<SinhVien>();
            foreach (XmlNode node in data_xml)
            {
                SinhVien tmp = new SinhVien();
                tmp.masv = node.Attributes["masv"].Value;
                tmp.monhoc = node.Attributes["monhoc"].Value;
                tmp.diemlan1 = double.Parse(node.SelectSingleNode("diemlan1").InnerText);
                tmp.diemlan2 = double.Parse(node.SelectSingleNode("diemlan2").InnerText);
                result.Add(tmp);
            }
            return result;
        }

        public bool addSV(SinhVien sv)
        {
            if (sv.masv == "")
            {
                return false;
            }
            XmlNode svfind = root.SelectSingleNode($"sinhvien[@masv = '{sv.masv}']");
            if (svfind != null)
            {
                return false;
            }
            XmlElement sinhvien = doc.CreateElement("sinhvien");
            XmlElement diemlan1 = doc.CreateElement("diemlan1");
            XmlElement diemlan2 = doc.CreateElement("diemlan2");
            sinhvien.SetAttribute("masv", sv.masv);
            sinhvien.SetAttribute("monhoc", sv.monhoc);
            diemlan1.InnerText = sv.diemlan1.ToString();
            diemlan2.InnerText = sv.diemlan2.ToString();
            sinhvien.AppendChild(diemlan1);
            sinhvien.AppendChild(diemlan2);
            root.AppendChild(sinhvien);
            doc.Save(path);
            return true;
        }

        public bool updateSV (SinhVien sv)
        {
            if (sv.masv == "")
            {
                return false;
            }
            XmlNode svfind = root.SelectSingleNode($"sinhvien[@masv = '{sv.masv}']");
            if (svfind == null)
            {
                return false;
            }
            XmlElement sinhvien = doc.CreateElement("sinhvien");
            XmlElement diemlan1 = doc.CreateElement("diemlan1");
            XmlElement diemlan2 = doc.CreateElement("diemlan2");
            sinhvien.SetAttribute("masv", sv.masv);
            sinhvien.SetAttribute("monhoc", sv.monhoc);
            diemlan1.InnerText = sv.diemlan1.ToString();
            diemlan2.InnerText = sv.diemlan2.ToString();
            sinhvien.AppendChild(diemlan1);
            sinhvien.AppendChild(diemlan2);
            root.ReplaceChild(sinhvien, svfind);
            doc.Save(path);
            return true;
        }

        public bool deleteSV(string id)
        {
            if (id == "")
            {
                return false;
            }
            XmlNode svfind = root.SelectSingleNode($"sinhvien[@masv = '{id}']");
            if (svfind == null)
            {
                return false;
            }
            root.RemoveChild(svfind);
            doc.Save(path);
            return true;
        }
    }
}
