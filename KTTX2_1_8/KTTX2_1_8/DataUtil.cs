using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KTTX2_1_8
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string path;
        public DataUtil()
        {
            path = "../../LopHoc.xml";
            doc  = new XmlDocument();
            if (!File.Exists(path))
            {
                XmlElement sv = doc.CreateElement("lophoc");
                doc.AppendChild(sv);
                doc.Save(path);
            }
            doc.Load(path);
            root = doc.DocumentElement;
        }


        public List<SinhVien> getAllData()
        {
            XmlNodeList node_list = root.SelectNodes("sinhvien");
            List<SinhVien> lst_data = new List<SinhVien>();
            foreach (XmlNode node in node_list)
            {
                SinhVien tmp = new SinhVien();
                tmp.MaSV = node.Attributes["masv"].Value;
                tmp.HoTen = node.SelectSingleNode("hoten").InnerText;
                tmp.DiaChi = node.SelectSingleNode("diachi").InnerText;
                tmp.Tuoi = int.Parse(node.SelectSingleNode("tuoi").InnerText);
                tmp.TenMonHoc = node.SelectSingleNode("monhoc/@tenmon").InnerText;
                tmp.Diem =double.Parse( node.SelectSingleNode("monhoc/diem").InnerText);
                lst_data.Add(tmp);
            }
            return lst_data;
        }

        public XmlElement taoNode(SinhVien sv)
        {
            XmlElement sv_new = doc.CreateElement("sinhvien");
            XmlElement ht = doc.CreateElement("hoten");
            XmlElement dc = doc.CreateElement("diachi");
            XmlElement t = doc.CreateElement("tuoi");
            XmlElement mh = doc.CreateElement("monhoc");
            XmlElement d = doc.CreateElement("diem");
            sv_new.SetAttribute("masv", sv.MaSV);
            ht.InnerText = sv.HoTen;
            dc.InnerText = sv.DiaChi;
            t.InnerText = sv.Tuoi.ToString();
            mh.SetAttribute("tenmon", sv.TenMonHoc);
            d.InnerText = sv.Diem.ToString();
            mh.AppendChild(d);
            sv_new.AppendChild(ht);
            sv_new.AppendChild(dc);
            sv_new.AppendChild(t);
            sv_new.AppendChild(mh);
            return sv_new;
        }

        public bool addSV(SinhVien sv)
        {
            XmlNode svfind = root.SelectSingleNode($"sinhvien[@masv = '{sv.MaSV}']");
            if(svfind != null)
            {
                return false;
            }
            XmlElement new_sv = taoNode(sv);
            root.AppendChild(new_sv);
            doc.Save(path);
            return true;
        }

        public bool updateSV(SinhVien sv)
        {
            XmlNode svfind = root.SelectSingleNode($"sinhvien[@masv = '{sv.MaSV}']");
            if (svfind == null)
            {
                return false;
            }
            XmlElement new_sv = taoNode(sv);
            root.ReplaceChild(new_sv, svfind);
            doc.Save(path);
            return true;
        }

        public bool deleteSV(string id)
        {
            XmlNode svfind = root.SelectSingleNode($"sinhvien[@masv = '{id}']");
            if (svfind == null)
            {
                return false;
            }
            root.RemoveChild(svfind);
            doc.Save(path);
            return true;
        }

        public List<SinhVien> findSVbyMark(double from, double to)
        {
            XmlNodeList svfind = root.SelectNodes($"sinhvien[monhoc/diem >= {from} and monhoc/diem <= {to}]");
            List<SinhVien> result = new List<SinhVien>();
            foreach (XmlNode node in svfind)
            {
                SinhVien tmp = new SinhVien();
                tmp.MaSV = node.Attributes["masv"].Value;
                tmp.HoTen = node.SelectSingleNode("hoten").InnerText;
                tmp.DiaChi = node.SelectSingleNode("diachi").InnerText;
                tmp.Tuoi = int.Parse(node.SelectSingleNode("tuoi").InnerText);
                tmp.TenMonHoc = node.SelectSingleNode("monhoc/@tenmon").InnerText;
                tmp.Diem = double.Parse(node.SelectSingleNode("monhoc/diem").InnerText);
                result.Add(tmp);
            }
            return result;
        }
    }
}
