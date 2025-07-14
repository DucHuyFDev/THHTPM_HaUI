using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace THLT_B6_1
{
    internal class readfile2
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("ĐỌC FILE XML");
            XmlDocument file = new XmlDocument();
            file.Load("ThuVien.xml");
            XmlElement root = file.DocumentElement;
            PrintNode(root);
        }

        static void PrintNode(XmlNode node)
        {
            Console.Write("Type: " + node.NodeType);
            Console.WriteLine(", Name: " + node.Name);
            Console.WriteLine("Value: " + node.Value);
            XmlNodeList lst_children = node.ChildNodes;
            if (lst_children.Count > 0)
            {
                Console.WriteLine($"------------------Con của node: {node.Name}");
                foreach (XmlNode node_tmp in lst_children)
                {
                    PrintNode(node_tmp);
                }
            }
            Console.WriteLine($"Hết node {node.Name}");
        }
    }
}
