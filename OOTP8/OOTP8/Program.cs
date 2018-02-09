using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOTP8
{
    public interface IDol<T>
    {
        void Add(T d);
        void Delete(T d);
        void Show();

    }
    public class Test
    {
        protected string typeoftest; // поле тип теста
        protected string difficult;
        protected int maxball;
        public Test(string type, string dif, int max)
        {
            typeoftest = type;
            difficult = dif;
            maxball = max;
        }
        public string Tst
        {
            get { return typeoftest; }
            set { typeoftest = value; }
        }
        public string Diffic
        {
            get { return difficult; }
            set { difficult = value; }
        }
        public int Maxb
        {
            get { return maxball; }
            set { maxball = value; }
        }
    }
    public class Polza<U> where U : class
    {
    }
        public class CollectionType<T> : IDol<T> where T : struct
        {
            public List<T> lol = new List<T>();
            public int ID;
            public static string[] chisla = new string[10];
            public string Value { get; set; }
            public char Simvol { get; set; }
            public class Date
            {
                public Date() { }
            }
            public void Add(T d) { lol.Add(d); }
            public void Delete(T d) { lol.Remove(d); }
            public void Show() { Console.WriteLine(lol); }
            public int Len() { int ss = lol.Count; return ss; }
        }


        class Program
        {
            static void Main(string[] args)
            {
                string line;
                CollectionType<int> lol = new CollectionType<int>();
                Polza<Test> kek = new Polza<Test>();
                try
                {
                    lol.Show();
                    lol.Add(2);
                }
                catch { Console.WriteLine("Popalsia!"); }
                finally { Console.WriteLine("This is the end!"); }
                StreamWriter write = new StreamWriter(@"D:\text.txt", true, System.Text.Encoding.Default);
                for (int i = 0; i < lol.Len(); i++)
                    write.WriteLine(lol.lol[i]);
                write.Close();
                StreamReader read = new StreamReader(@"D:\text.txt", System.Text.Encoding.Default);
                for (int i = 0; i < lol.Len(); i++)
                {
                    line = read.ReadLine();
                    Console.WriteLine(line);
                }
                read.Close();
            }
        }

    }

