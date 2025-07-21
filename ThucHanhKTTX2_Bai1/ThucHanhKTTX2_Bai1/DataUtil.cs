using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ThucHanhKTTX2_Bai1
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUtil()
        {
            filename = "sanpham.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement node = doc.CreateElement("kho");
                root.AppendChild(node);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public List<sanpham> getAllData()
        {
            List<sanpham> data = new List<sanpham>();
            foreach (XmlNode node in root.ChildNodes)
            {
                sanpham tmp = new sanpham();
                tmp.masp = node.Attributes["masp"].Value;
                tmp.tensp = node.SelectSingleNode("tensp").InnerText;
                tmp.loai = node.SelectSingleNode("loai").InnerText;
                tmp.soluong = node.SelectSingleNode("soluong").InnerText;
                tmp.dongia = node.SelectSingleNode("dongia").InnerText;
                data.Add(tmp);
            }
            return data;
        }

        public bool addsp(sanpham sp_new)
        {
            XmlNode spfind = root.SelectSingleNode($"sanpham[@masp = '{sp_new.masp}']");
            if (spfind != null)
            {
                return false;
            }
            XmlElement sanpham = doc.CreateElement("sanpham");
            sanpham.SetAttribute("masp", sp_new.masp);
            XmlElement tensp = doc.CreateElement("tensp");
            XmlElement loai = doc.CreateElement("loai");
            XmlElement soluong = doc.CreateElement("soluong");
            XmlElement dongia = doc.CreateElement("dongia");
            tensp.InnerText = sp_new.tensp;
            loai.InnerText = sp_new.loai;
            soluong.InnerText = sp_new.soluong;
            dongia.InnerText = sp_new.dongia;
            sanpham.AppendChild(tensp);
            sanpham.AppendChild(loai);
            sanpham.AppendChild(soluong);
            sanpham.AppendChild(dongia);
            root.AppendChild(sanpham);
            doc.Save(filename);
            return true;
        }

        public bool xoasp (string masp)
        {
            XmlNode spfind = root.SelectSingleNode($"sanpham[@masp = '{masp}']");
            if (spfind != null)
            {
                DialogResult d = MessageBox.Show($"Bạn muốn xóa mặt hàng có mã là {masp} ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    root.RemoveChild(spfind);
                    doc.Save(filename);
                    return true;
                }
            }
            return false;
        }

        public bool updatesp(sanpham sp_new)
        {
            XmlNode spfind = root.SelectSingleNode($"sanpham[@masp = '{sp_new.masp}']");
            if (spfind == null)
            {
                return false;
            }
            XmlElement sanpham = doc.CreateElement("sanpham");
            sanpham.SetAttribute("masp", sp_new.masp);
            XmlElement tensp = doc.CreateElement("tensp");
            XmlElement loai = doc.CreateElement("loai");
            XmlElement soluong = doc.CreateElement("soluong");
            XmlElement dongia = doc.CreateElement("dongia");
            tensp.InnerText = sp_new.tensp;
            loai.InnerText = sp_new.loai;
            soluong.InnerText = sp_new.soluong;
            dongia.InnerText = sp_new.dongia;
            sanpham.AppendChild(tensp);
            sanpham.AppendChild(loai);
            sanpham.AppendChild(soluong);
            sanpham.AppendChild(dongia);
            root.ReplaceChild(sanpham, spfind);
            doc.Save(filename);
            return true;
        }
        
        public double TotalPrice()
        {
            List<sanpham> data = getAllData();
            double price = 0;
            foreach (sanpham item in data)
            {
                price += double.Parse(item.dongia) * double.Parse(item.soluong);
            }
            return price;
        }

        public List<sanpham> findWithPrice()
        {
            List<sanpham> data = new List<sanpham>();
            XmlNodeList spfind = root.SelectNodes($"sanpham[dongia > 500000]");
            foreach (XmlNode sp in spfind)
            {
                sanpham tmp = new sanpham();
                tmp.masp = sp.Attributes["masp"].Value;
                tmp.tensp = sp.SelectSingleNode("tensp").InnerText;
                tmp.loai = sp.SelectSingleNode("loai").InnerText;
                tmp.soluong = sp.SelectSingleNode("soluong").InnerText;
                tmp.dongia = sp.SelectSingleNode("dongia").InnerText;
                data.Add(tmp);
            }
            return data;
        }

        public List<sanpham> findWithType(string loai)
        {
            List<sanpham> data = new List<sanpham>();
            XmlNodeList spfind = root.SelectNodes($"sanpham[loai = '{loai}']");
            foreach (XmlNode sp in spfind)
            {
                sanpham tmp = new sanpham();
                tmp.masp = sp.Attributes["masp"].Value;
                tmp.tensp = sp.SelectSingleNode("tensp").InnerText;
                tmp.loai = sp.SelectSingleNode("loai").InnerText;
                tmp.soluong = sp.SelectSingleNode("soluong").InnerText;
                tmp.dongia = sp.SelectSingleNode("dongia").InnerText;
                data.Add(tmp);
            }
            return data;
        }
    }
}
