using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace THLT_Bai7_2
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUtil()
        {
            filename = "Course.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement course = doc.CreateElement("course");
                doc.AppendChild(course);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public List<SinhVien> GetAllSV()
        {
            XmlNodeList node = root.SelectNodes("sinhvien");
            List<SinhVien> li = new List<SinhVien>();
            foreach (XmlNode item in node)
            {
                SinhVien s = new SinhVien();
                s.id = item.Attributes[0].InnerText;
                s.name = item.SelectSingleNode("name").InnerText;
                s.age = item.SelectSingleNode("age").InnerText;
                s.city = item.SelectSingleNode("city").InnerText;
                li.Add(s);
            }
            return li;
        }


        public bool AddSV(SinhVien s)
        {
            XmlNode stfind = root.SelectSingleNode($"sinhvien[@id = '{s.id}']");
            if (stfind == null)
            {
                XmlElement st = doc.CreateElement("sinhvien");
                st.SetAttribute("id", s.id);
                XmlElement name = doc.CreateElement("name");
                name.InnerText = s.name;
                XmlElement age = doc.CreateElement("age");
                age.InnerText = s.age;
                XmlElement city = doc.CreateElement("city");
                city.InnerText = s.city;
                st.AppendChild(name);
                st.AppendChild(age);
                st.AppendChild(city);
                root.AppendChild(st);
                doc.Save(filename);
                return true;
            }
            return false;
        }

       
        public bool UpdateStudent_check(SinhVien s)
        {
            XmlNode stfind = root.SelectSingleNode($"sinhvien[@id = '{s.id}']");
            if (stfind != null)
            {
                XmlElement st = doc.CreateElement("sinhvien");
                st.SetAttribute("id", s.id);
                XmlElement name = doc.CreateElement("name");
                name.InnerText = s.name;
                XmlElement age = doc.CreateElement("age");
                age.InnerText = s.age;
                XmlElement city = doc.CreateElement("city");
                city.InnerText = s.city;
                st.AppendChild(name);
                st.AppendChild(age);
                st.AppendChild(city);
                root.ReplaceChild(st, stfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }

        public bool deleteSinhVien(string id)
        {
            XmlNode stfind = root.SelectSingleNode($"sinhvien[@id = '{id}']");
            if (stfind != null)
            {
                root.RemoveChild(stfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }

        public SinhVien findbySVID (string id)
        {
            XmlNode stfind = root.SelectSingleNode($"sinhvien[@id = '{id}']");
            SinhVien s = null;
            if (stfind != null)
            {
                s = new SinhVien();
                s.id = stfind.Attributes[0].InnerText;
                s.name = stfind.SelectSingleNode("name").InnerText;
                s.age = stfind.SelectSingleNode("age").InnerText;
                s.city = stfind.SelectSingleNode("city").InnerText;
            }
            return s;

        }
    }

}
