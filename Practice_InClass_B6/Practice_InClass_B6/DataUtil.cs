using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Practice_InClass_B6
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUtil()
        {
            filename = "../../thongtincuocgoi.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement node = doc.CreateElement("thongtincuocgoi");
                root.AppendChild(node);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public List<thongtincuocgoi> GetAllCall()
        {
            List<thongtincuocgoi> lst_data = new List<thongtincuocgoi>();
            XmlNodeList data_xml = root.SelectNodes("cuocgoi");
            foreach (XmlNode node in data_xml)
            {
                thongtincuocgoi tmp = new thongtincuocgoi();
                tmp.chinhanh = node.Attributes["chinhanh"].Value;
                tmp.sogoidi = node.Attributes["sodien"].Value;
                tmp.sogoiden = node.SelectSingleNode("sogoiden").InnerText;
                tmp.ngaygoi = node.SelectSingleNode("ngaygoi").InnerText;
                tmp.sophut = node.SelectSingleNode("sophut").InnerText;
                lst_data.Add(tmp);
            }
            return lst_data;
        }

        public void AddCall(thongtincuocgoi add_call)
        {
            XmlElement cuocgoi = doc.CreateElement("cuocgoi");
            cuocgoi.SetAttribute("sodien", add_call.sogoidi);
            cuocgoi.SetAttribute("chinhanh", add_call.chinhanh);
            XmlElement sogoiden = doc.CreateElement("sogoiden");
            XmlElement ngaygoi = doc.CreateElement("ngaygoi");
            XmlElement sophut = doc.CreateElement("sophut");
            sogoiden.InnerText = add_call.sogoiden;
            ngaygoi.InnerText = add_call.ngaygoi;
            sophut.InnerText = add_call.sophut;
            cuocgoi.AppendChild(sogoiden);
            cuocgoi.AppendChild(ngaygoi);
            cuocgoi.AppendChild(sophut);
            root.AppendChild(cuocgoi);
            doc.Save(filename);
        }

        public bool deleteCall(string sogoiden)
        {
            XmlNodeList lst_find = root.SelectNodes($"cuocgoi[sogoiden = '{sogoiden}']");
            DialogResult d = MessageBox.Show($"Bạn có muốn xóa các cuộc gọi có số gọi đến là {sogoiden} không ?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool check = false;
            if (d == DialogResult.Yes)
            {
                if (lst_find.Count > 0)
                {
                    foreach (XmlNode node in lst_find)
                    {
                        root.RemoveChild(node);
                    }
                    check = true;
                }
                
            }
            return check;
            
        }

        public bool updateCall(thongtincuocgoi update_call)
        {
            XmlNode call_find = root.SelectSingleNode($"cuocgoi[sogoiden = '{update_call.sogoiden}']");
            if (call_find != null)
            {
                XmlElement cuocgoi_new = doc.CreateElement("cuocgoi");
                cuocgoi_new.SetAttribute("sodien", update_call.sogoidi);
                cuocgoi_new.SetAttribute("chinhanh",  update_call.chinhanh);
                XmlElement sogoiden = doc.CreateElement("sogoiden");
                XmlElement ngaygoi = doc.CreateElement("ngaygoi");
                XmlElement sophut = doc.CreateElement("sophut");
                sogoiden.InnerText = update_call.sogoiden;
                ngaygoi.InnerText = update_call.ngaygoi;
                sophut.InnerText = update_call.sophut;
                cuocgoi_new.AppendChild(sogoiden);
                cuocgoi_new.AppendChild(ngaygoi);
                cuocgoi_new.AppendChild(sophut);
                root.ReplaceChild(cuocgoi_new,call_find);
                doc.Save(filename);
                return true;
            }
            return false;
        }
    }
}
