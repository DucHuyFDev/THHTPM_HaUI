using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Security.Cryptography;

namespace Bai8
{
    internal class DataUtil
    {
        XmlDocument doc;
        string filename;
        XmlElement root;

        public DataUtil()
        {
            filename = "CongTy.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement congty = doc.CreateElement("congty");
                root.AppendChild(congty);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public List<NhanVien> getAllNhanVien()
        {
            XmlNodeList lst = root.SelectNodes("nhanvien");
            List<NhanVien> lst_nv = new List<NhanVien>();
            foreach (XmlNode node in lst)
            {
                NhanVien add = new NhanVien();
                add.manv = node.Attributes["manv"].InnerText;
                add.tennv = node.SelectSingleNode("hoten").InnerText;
                add.tuoi = node.SelectSingleNode("tuoi").InnerText;
                add.luong = node.SelectSingleNode("luong").InnerText;
                add.dienthoai = node.SelectSingleNode("dienthoai").InnerText;

                XmlNode diachi = node.SelectSingleNode("diachi");
                
                add.xa = diachi.SelectSingleNode("xa").InnerText;
                add.huyen = diachi.SelectSingleNode("huyen").InnerText;
                add.tinh = diachi.SelectSingleNode("tinh").InnerText;
                lst_nv.Add(add);
            }
            return lst_nv;
        }

        public bool AddNhanVien (NhanVien nv)
        {
            XmlNode nvfind = root.SelectSingleNode($"nhanvien[@manv = '{nv.manv}']");
            if (nvfind != null)
            {
                return false;
            }
            XmlElement nhanvien = doc.CreateElement("nhanvien");
            nhanvien.SetAttribute("manv", nv.manv);
            XmlElement tennv = doc.CreateElement("hoten");
            tennv.InnerText = nv.tennv;
            XmlElement tuoi = doc.CreateElement("tuoi");
            tuoi.InnerText = nv.tuoi;
            XmlElement luong = doc.CreateElement("luong");
            luong.InnerText = nv.luong;
            XmlElement dienthoai = doc.CreateElement("dienthoai");
            dienthoai.InnerText = nv.dienthoai;
            XmlElement diachi = doc.CreateElement("diachi");
            XmlElement xa = doc.CreateElement("xa");
            xa.InnerText = nv.xa;
            XmlElement huyen = doc.CreateElement("huyen");
            huyen.InnerText = nv.huyen;
            XmlElement tinh = doc.CreateElement("tinh");
            tinh.InnerText = nv.tinh;
            diachi.AppendChild(xa);
            diachi.AppendChild(huyen);
            diachi.AppendChild(tinh);
            nhanvien.AppendChild(tennv);
            nhanvien.AppendChild(tuoi);
            nhanvien.AppendChild(luong);
            nhanvien.AppendChild(diachi);
            nhanvien.AppendChild(dienthoai);
            root.AppendChild(nhanvien);
            doc.Save(filename);
            return true;
        }

        public bool SuaNV(NhanVien nv)
        {
            XmlNode nvfind = root.SelectSingleNode($"nhanvien[@manv = '{nv.manv}']");
            if ( nvfind != null)
            {
                XmlElement nhanvien_new = doc.CreateElement("nhanvien");
                nhanvien_new.SetAttribute("manv", nv.manv);
                XmlElement tennv = doc.CreateElement("hoten");
                tennv.InnerText = nv.tennv;
                XmlElement tuoi = doc.CreateElement("tuoi");
                tuoi.InnerText = nv.tuoi;
                XmlElement luong = doc.CreateElement("luong");
                luong.InnerText = nv.luong;
                XmlElement dienthoai = doc.CreateElement("dienthoai");
                dienthoai.InnerText = nv.dienthoai;
                XmlElement diachi = doc.CreateElement("diachi");
                XmlElement xa = doc.CreateElement("xa");
                xa.InnerText = nv.xa;
                XmlElement huyen = doc.CreateElement("huyen");
                huyen.InnerText = nv.huyen;
                XmlElement tinh = doc.CreateElement("tinh");
                tinh.InnerText = nv.tinh;
                diachi.AppendChild(xa);
                diachi.AppendChild(huyen);
                diachi.AppendChild(tinh);
                nhanvien_new.AppendChild(tennv);
                nhanvien_new.AppendChild(tuoi);
                nhanvien_new.AppendChild(luong);
                nhanvien_new.AppendChild(diachi);
                nhanvien_new.AppendChild(dienthoai);
                root.ReplaceChild(nhanvien_new, nvfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }


        public bool XoaNV(string manv)
        {
            XmlNode nvfind = root.SelectSingleNode($"nhanvien[@manv = '{manv}']");
            if (nvfind == null)
                return false;
            root.RemoveChild(nvfind);
            doc.Save(filename);
            return true;
        }

        public List<NhanVien> findNhanVien()
        {
            XmlNodeList lst_find = root.SelectNodes("nhanvien[luong > 1000]");
            List<NhanVien> find_nv = new List<NhanVien>();
            foreach (XmlNode node in lst_find)
            {
                NhanVien a_nv = new NhanVien();
                a_nv.manv = node.Attributes["manv"].Value;
                a_nv.tennv = node.SelectSingleNode("hoten").InnerText;
                a_nv.luong = node.SelectSingleNode("luong").InnerText;
                a_nv.tuoi = node.SelectSingleNode("tuoi").InnerText;
                a_nv.dienthoai = node.SelectSingleNode("dienthoai").InnerText;
                XmlNode diachi = node.SelectSingleNode("diachi");
                a_nv.xa = diachi.SelectSingleNode("xa").InnerText;
                a_nv.huyen = diachi.SelectSingleNode("huyen").InnerText;
                a_nv.tinh = diachi.SelectSingleNode("tinh").InnerText;
                find_nv.Add(a_nv);
            }
            return find_nv;
        }

        public List<NhanVien> findNVwithtinh(string tinh_search)
        {
            XmlNodeList lst_find = root.SelectNodes($"nhanvien[diachi/tinh = '{tinh_search}']");
            List<NhanVien> find_nv = new List<NhanVien>();
            foreach (XmlNode node in lst_find)
            {
                NhanVien a_nv = new NhanVien();
                a_nv.manv = node.Attributes["manv"].Value;
                a_nv.tennv = node.SelectSingleNode("hoten").InnerText;
                a_nv.luong = node.SelectSingleNode("luong").InnerText;
                a_nv.tuoi = node.SelectSingleNode("tuoi").InnerText;
                a_nv.dienthoai = node.SelectSingleNode("dienthoai").InnerText;
                XmlNode diachi = node.SelectSingleNode("diachi");
                a_nv.xa = diachi.SelectSingleNode("xa").InnerText;
                a_nv.huyen = diachi.SelectSingleNode("huyen").InnerText;
                a_nv.tinh = diachi.SelectSingleNode("tinh").InnerText;
                find_nv.Add(a_nv);
            }
            return find_nv;
        }
    }
}
