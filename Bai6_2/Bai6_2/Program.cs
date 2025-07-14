using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Bai6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("KẾT QUẢ ĐỌC FILE NHÂN VIÊN CÔNG TY");
            Console.WriteLine();
            XmlDocument doc_xml = new XmlDocument();
            doc_xml.Load("CongTy.xml");
            XmlElement root = doc_xml.DocumentElement;
            PrintInfo (root);
            
        }

        static void PrintInfo(XmlNode root, int level = 0)
        {
            string indent = new string(' ', level * 2);

            // In tên node
            Console.WriteLine($"{indent}{root.Name}");

            // In thuộc tính nếu có
            if (root.Attributes != null && root.Attributes.Count > 0)
            {
                foreach (XmlAttribute attr in root.Attributes)
                {
                    Console.WriteLine($"{indent}{attr.Name} = {attr.Value}");
                }
            }

            // Nếu node là node lá chứa text
            if (root.ChildNodes.Count == 1 && root.FirstChild.NodeType == XmlNodeType.Text)
            {
                Console.WriteLine($"{indent}{root.InnerText}");
            }

            // Đệ quy node con (chỉ Element, bỏ qua #text)
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    PrintInfo(node, level + 1);
                }
            }
        }

    }
}
