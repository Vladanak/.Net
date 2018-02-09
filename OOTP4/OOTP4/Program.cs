using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP4
{
    public class Stroka
    {
        public int ID;
        public string name;
        public string ORG;
        public static char[] chisla = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public string Value{get; set;}
        public char Simvol { get; set; }
        public static string operator +(Stroka str1,Stroka str2)
        {
            string stroka = str1.Value;
            stroka = str1.Value;
            for(var i=1;i<=stroka.Length;i+=2)
            stroka = stroka.Remove(i,1);
            return stroka;
        }
        public static bool operator ==(Stroka str1, Stroka str2)
        {
            if (str1.Value.Length == str2.Value.Length)
                return true;
            else return false;
        }
        public static bool operator !=(Stroka str1,Stroka str2)
        {
            if (str1.Value.Length != str2.Value.Length)
                return true;
            else return false;
        }
        public static string operator <(Stroka str1,Stroka str2)
        {
            int index;
            string stroka = str1.Value;
            bool f = false;
            if ((stroka.Contains(str1.Simvol)))
            {
                index = str1.Value.IndexOf(str1.Simvol);
                stroka = str1.Value.Remove(index, 1);
            }
            while (f == false)
            {
                if ((stroka.Contains(str1.Simvol)))
                {
                    index = stroka.IndexOf(str1.Simvol);
                    stroka = stroka.Remove(index, 1);
                }
                else
                    f = true;
            }
                return stroka;
        }
        public static string operator >(Stroka str1, Stroka str2)
        {
            int index;
            string stroka = str1.Value;
            bool f = false;
            if ((stroka.Contains(str1.Simvol)))
            {
                index = str1.Value.IndexOf(str1.Simvol);
                stroka = str1.Value.Remove(index, 1);
            }
            while (f == false)
            {
                if ((stroka.Contains(str1.Simvol)))
                {
                    index = stroka.IndexOf(str1.Simvol);
                    stroka = stroka.Remove(index, 1);
                }
                else
                    f = true;
            }
            return stroka;
        }
        public static bool operator true(Stroka str1)
        {
            if ((str1.Value.Contains('.')) || (str1.Value.Contains(',')))
                return true;
            else return false;
        }
        public static bool operator false(Stroka str1)
        {
            if ((!str1.Value.Contains ('.')) || (!str1.Value.Contains(',')))
                return true;
            else
                return false;
        }
        public class Date
        {
            public int day;
            public int month;
            public int year;
            public Date() { }
        }
    }
    static class Method
    {
        public static int SQR(this Stroka str)
        {
            string stroka = str.Value;
            int a=stroka.GetHashCode();
            return a;
        }
        public static string Doub(this Stroka str)
        {
            string stroka = str.Value;
            string a = stroka.Replace('a','A');
            return a;
        }
        public static string  BigSize(this Stroka str)
        {
            string stroka = str.Value;
            string a = stroka.ToUpper();
            return a;
        }
        public static bool Proverka(this Stroka str)
        {
            if (str.Value.Contains(str.Simvol))
                return true;
            else return false;
        }
        public static string Udalenie(this Stroka str)
        {
            int index;
            string stroka = str.Value;
            for(var i=0;i<stroka.Length;i++)
            {
                for(var j=0;j<Stroka.chisla.Length;j++)
                {
                    if (stroka[i].Equals(Stroka.chisla[j]) == true)
                    {
                        index = i;
                        stroka = stroka.Remove(index, 1);
                    }
                }
            }
            return stroka;
        }
    }
    class Owner
    {
      public Stroka Id;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stroka.Date day = new Stroka.Date();
            day.day = 25;
            day.month = 9;
            day.year = 1991;
            Owner ded = new Owner();
            ded.Id.ID = 3;
            ded.Id.name = "Vlad";
            ded.Id.ORG = "FEAD";
            Stroka pervaia = new Stroka();
            pervaia.Value = "Privet,chelovek";
            pervaia.Simvol = 'e';
            Stroka vtoraia = new Stroka();
            vtoraia.Value = "Tri";
            vtoraia.Simvol = 'i';
            Stroka tretia = new Stroka();
            Stroka chetvort = new Stroka();
            tretia.Value = "T.";
            chetvort.Value = "T.";
            Console.WriteLine(pervaia < vtoraia);
            Console.WriteLine(pervaia + vtoraia);
            Console.WriteLine(pervaia != vtoraia);
            if (pervaia)
                Console.WriteLine("ECT");
            Console.WriteLine(pervaia.Proverka());
            Console.WriteLine(pervaia.Udalenie());
        }
    }
}
