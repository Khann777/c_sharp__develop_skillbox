using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XElement xmlTree1 =
                new XElement("Address",
                    new XElement("Street", "Street Name"),
                    new XElement("HouseNumber", "House Number"),
                    new XElement("FlatNumber", "Flat Number")
                    );

            XElement xmlTree2 =
                new XElement("Phones",
                    new XElement("MobilePhone", "89999999999999"),
                    new XElement("FlatPhone", "123-45-67")
                    );

            XElement xmlName = new XElement("Person",
                new XAttribute("name", "Full Name"),
                xmlTree1,
                xmlTree2
                );
            Console.WriteLine(xmlName);
            Console.ReadKey();
        }
    }
}