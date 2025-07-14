using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bai6_1_Bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("ĐỌC FILE XML VỀ SẢN PHẨM");
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load("SanPham.xml");
            XmlElement root = xml_doc.DocumentElement;
            PrintNode(root);
        }

        static void PrintNode(XmlNode root)
        {
            Console.WriteLine("Name: " + root.Name);
            Console.WriteLine("Value: " + root.Value);
            XmlNodeList lst_child = root.ChildNodes;
            if (lst_child.Count > 0)
            {
                Console.WriteLine($"----------Danh sách các node con của node {root.Name}");
                foreach (XmlNode node_c in lst_child)
                {
                    PrintNode(node_c);
                }
            }
        }
    }
}
