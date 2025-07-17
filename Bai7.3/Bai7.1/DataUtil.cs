using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace Bai7._1
{
    internal class DataUtil
    {
        string filename;
        XmlDocument doc;
        XmlElement root;

        public DataUtil()
        {
            filename = "NganHang.xml";
            doc = new XmlDocument();  // tạo 1 file xml mới
            if (!File.Exists(filename)) // nếu chưa tồn tại file xml
            {
                XmlElement bank = doc.CreateElement("nganhang"); // tạo 1 node mới là node gốc - ngân hàng
                doc.AppendChild(bank); // cho node nganhang là con của file doc
                doc.Save(filename); // lưu file để tạo file mới
            }
            doc.Load(filename); // đọc data từ file xml
            root = doc.DocumentElement; // cho node gốc chính là node cao nhất trong file (chính là ngân hàng)
        }

        public List <TaiKhoan> GetAllData()
        {
            XmlNodeList child_nodes = root.SelectNodes("taikhoan");
            List<TaiKhoan> lst = new List<TaiKhoan>();
            foreach (XmlNode node in child_nodes)
            {
                TaiKhoan t = new TaiKhoan();
                t.stk = node.SelectSingleNode("sotaikhoan").InnerText;
                t.tentk = node.SelectSingleNode("tentaikhoan").InnerText;
                t.diachi = node.SelectSingleNode("diachi").InnerText;
                t.dienthoai = node.SelectSingleNode("dienthoai").InnerText;
                t.sotien = node.SelectSingleNode("sotien").InnerText;
                lst.Add(t);
            }
            return lst;
        }

        public bool AddTK(TaiKhoan tk)
        {
            XmlNode stk_check = root.SelectSingleNode($"taikhoan[sotaikhoan = '{tk.stk}']");
            if (stk_check == null)
            {
                XmlElement new_tk = doc.CreateElement("taikhoan");
                XmlElement stk_new = doc.CreateElement("sotaikhoan");
                stk_new.InnerText = tk.stk;
                XmlElement tentk_new = doc.CreateElement("tentaikhoan");
                tentk_new.InnerText = tk.tentk;
                XmlElement diachi_new = doc.CreateElement("diachi");
                diachi_new.InnerText = tk.diachi;
                XmlElement dt_new = doc.CreateElement("dienthoai");
                dt_new.InnerText = tk.dienthoai;
                XmlElement sotien_new = doc.CreateElement("sotien");
                sotien_new.InnerText = tk.sotien;
                new_tk.AppendChild(stk_new);
                new_tk.AppendChild(tentk_new);
                new_tk.AppendChild(diachi_new);
                new_tk.AppendChild(dt_new);
                new_tk.AppendChild(sotien_new);
                root.AppendChild(new_tk);
                doc.Save(filename);
                return true;
            }
            return false;

        }

        public bool UpdateTK (TaiKhoan tk)
        {
            XmlNode tkfind = root.SelectSingleNode($"taikhoan[sotaikhoan = '{tk.stk}']");
            if (tkfind != null)
            {
                XmlElement tk_update = doc.CreateElement("taikhoan");
                XmlElement stk_new = doc.CreateElement("sotaikhoan");
                stk_new.InnerText = tk.stk;
                XmlElement tentk_new = doc.CreateElement("tentaikhoan");
                tentk_new.InnerText = tk.tentk;
                XmlElement diachi_new = doc.CreateElement("diachi");
                diachi_new.InnerText = tk.diachi;
                XmlElement dt_new = doc.CreateElement("dienthoai");
                dt_new.InnerText = tk.dienthoai;
                XmlElement sotien_new = doc.CreateElement("sotien");
                sotien_new.InnerText = tk.sotien;
                tk_update.AppendChild(stk_new);
                tk_update.AppendChild(tentk_new);
                tk_update.AppendChild(diachi_new);
                tk_update.AppendChild(dt_new);
                tk_update.AppendChild(sotien_new);
                root.ReplaceChild(tk_update, tkfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }

        public bool Delete_TK(TaiKhoan tk)
        {
            XmlNode tkfind = root.SelectSingleNode($"taikhoan[sotaikhoan = '{tk.stk}']");
            if (tkfind != null)
            {
                DialogResult d = MessageBox.Show($"Bạn có muốn xóa tài khoản có stk là {tk.stk} không ?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    root.RemoveChild(tkfind);
                    doc.Save(filename);
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<TaiKhoan> Search_TK(string stk)
        {
            XmlNodeList tkfind = root.SelectNodes($"taikhoan[sotaikhoan = '{stk}']");
            if (tkfind != null)
            {
                List<TaiKhoan> lst_find = new List<TaiKhoan>();
                foreach (XmlNode tknode in tkfind)
                {
                    TaiKhoan tk_temp = new TaiKhoan();
                    tk_temp.stk = tknode.SelectSingleNode("sotaikhoan").InnerText;
                    tk_temp.tentk = tknode.SelectSingleNode("tentaikhoan").InnerText;
                    tk_temp.diachi = tknode.SelectSingleNode("diachi").InnerText;
                    tk_temp.dienthoai = tknode.SelectSingleNode("dienthoai").InnerText;
                    tk_temp.sotien = tknode.SelectSingleNode("sotien").InnerText;
                    lst_find.Add(tk_temp);
                }
                return lst_find;
            }
            return null;
        }
    }
}
