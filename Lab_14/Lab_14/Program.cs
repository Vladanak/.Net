using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace Lab_14
{
    [DataContract]
    public class Prog
    {
        [DataMember]
        public string str { get; set; }
        [DataMember]
        public int chisl { get; set; }
        [DataMember]
        public Comp comp { get; set; }
        public Prog() { }
        public Prog(string sstr,int cchisl,Comp compp)
        {
            str = sstr;
            cchisl = chisl;
            comp = compp;
        }
    }
    [DataContract]
    public class Comp
    {
        [DataMember]
        public string sttr { get; set; }
        public Comp() { }
        public Comp(string strrr)
        {
            sttr = strrr;
        }
    }
    public static class XMLer
    {
        public static void XPath()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("buttons.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("//Button/title");
            foreach (XmlNode n in childnodes)
            { Console.WriteLine(n.InnerText); }
        }
        public static void CreateDoc()
        {
            XDocument xdoc = new XDocument();
            XElement accept = new XElement("button");
            XAttribute title = new XAttribute("title", "accept");
            XElement count = new XElement("count", "3");
            accept.Add(title);
            accept.Add(count);
            XElement exit = new XElement("button");
            XAttribute title1 = new XAttribute("title", "exit");
            XElement count1 = new XElement("count", "1");
            exit.Add(title1);
            exit.Add(count1);
            XElement buttons = new XElement("buttons");
            buttons.Add(accept);
            buttons.Add(exit);
            xdoc.Add(buttons);
            xdoc.Save("buttonLINQ.xml");
        }
        public static void Print()
        {
            XDocument xdoc = XDocument.Load("buttonLINQ.xml");
            foreach (XElement button in xdoc.Element("buttons").Elements("button"))
            {
                XAttribute title = button.Attribute("title");
                XElement count = button.Element("count");
                if (title != null && count != null)
                {
                    Console.WriteLine("Button's title: {0}", title.Value);
                    Console.WriteLine("Count of: {0}", count.Value);
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            serizClass sc = new serizClass();
            sc.num = 1;
            sc.str = "qwe";

            BinaryFormatter binFormat = new BinaryFormatter();

            Prog p1 = new Prog("str", 1, new Comp("d"));
            Prog p2 = new Prog("strr", 2, new Comp("bc"));
            Prog[] pp = new Prog[] { p1, p2 };
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Prog[]));

            using (FileStream fs = new FileStream("C:\\jF.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, pp);
            }
            using (FileStream fs = new FileStream("C:\\jF.json", FileMode.OpenOrCreate))
            {
                Prog[] newpp = (Prog[])jsonFormatter.ReadObject(fs);
            }
            //       using (FileStream fs = new FileStream("C://jF.json", FileMode.OpenOrCreate))
            //       {
            //           jsonFormatter.WriteObject(fs, sc);
            //       }
            //       // Сохранить объект в локальном файле.
            //       using (Stream fStream = new FileStream("C://bf.dat",
            //          FileMode.Create, FileAccess.Write, FileShare.None))
            //       {
            //           binFormat.Serialize(fStream, sc);
            //       }

            //       SoapFormatter sF = new SoapFormatter();
            //       using (Stream fStream = new FileStream("C://sF.soap",
            //         FileMode.Create, FileAccess.Write, FileShare.None))
            //       {
            //           sF.Serialize(fStream, sc);
            //       }


            //       XmlSerializer xF = new XmlSerializer(sc.GetType());
            //       using (Stream fStream = new FileStream("C://xF.xml",
            //         FileMode.Create, FileAccess.Write, FileShare.None))
            //       {
            //           xF.Serialize(fStream, sc);
            //       }


            //       BinaryFormatter bindes = new BinaryFormatter();

            //using (Stream fStream = File.OpenRead("C://bf.dat"))
            //{
            //     serizClass dsc =
            //          (serizClass)binFormat.Deserialize(fStream);
            //     Console.WriteLine(dsc.num);
            //     Console.WriteLine(dsc.str);
            //}


            //using (Stream fStream = File.OpenRead("C://xf.xml"))
            //{
            //    serizClass dsc =
            //         (serizClass)xF.Deserialize(fStream);
            //    Console.WriteLine(dsc.num);
            //    Console.WriteLine(dsc.str);
            //}
            //using (Stream fStream = File.OpenRead("C://jF.json"))
            //{
            //    serizClass dsc = (serizClass)jsonFormatter.ReadObject(fStream);
            //    Console.WriteLine(dsc.num);
            //    Console.WriteLine(dsc.str);
            //}

            //List<serizClass> myList = new List<serizClass>();
            //myList.Add(sc);
            //     using (Stream fStream = new FileStream("C://cxF.xml",
            //  FileMode.Create, FileAccess.Write, FileShare.None))
            //{

            //         foreach (serizClass ml in myList)
            //         {
            //    xF.Serialize(fStream, ml);
            //         }
            //}
            //       using (Stream fStream = File.OpenRead("C://cxf.xml"))
            //       {
            //           serizClass dsc =
            //                (serizClass)xF.Deserialize(fStream);
            //           Console.WriteLine(dsc.num);
            //           Console.WriteLine(dsc.str);
            //       }
            //       XMLer.XPath();
            //       XMLer.CreateDoc();
            //       XMLer.Print();
            Console.ReadKey();
        }
    }
}


//Что такое сериализация, десериализация
//что такое XPath (XML Path Language)— язык запросов к элементам XML-документа.
//Какие существуют форматы сериализации?