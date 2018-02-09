using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOTP11
{
    public class Student
    {
        public readonly string Univer = "ded";
        public const int Mesto = 3;
        public string ID;
        public string FIO;
        public int DR;
        public string Adress;
        public string Nomertelefona;
        public string Fakyltet;
        public int Kyrs;
        public int Gruppa;
        static Student()
        {
            kol = 0;
        }
        public static int kol;
        public Student()
        {
            kol++;
        }
        public Student(string I, string Fi, int dr, string Ad, string Num, string Fak, int K, int Gr)
        {
            ID = I;
            FIO = Fi;
            DR = dr;
            Adress = Ad;
            Nomertelefona = Num;
            Fakyltet = Fak;
            Kyrs = K;
            Gruppa = Gr;
            kol++;
        }
        public virtual int Raschet(int dr, int k)
        {
            int c = 18;
            dr = 0;
            c = c + (k - 1);
            return c;
        }

        public string Id
        {
            get { return ID; }
            set
            {
                if (Int32.TryParse(value, out int tempId) == true)
                {
                    tempId = Int32.Parse(value);
                    if (tempId > 0 && tempId < 100)
                    {
                        ID = value;
                    }
                }
                else
                    Console.WriteLine("Вводите нормальные числа!");
            }
        }
        public string Nomert
        {
            get { return Nomertelefona; }
            set
            {
                if (Int32.TryParse(value, out int tempId) == true)
                {
                    tempId = Int32.Parse(Nomertelefona);
                    if (tempId > 0 && tempId < 100)
                    {
                        Nomertelefona = value;
                    }
                }
                else
                    Console.WriteLine("Вводите нормальные числа!");
            }
        }
        public string Fio
        {
            get { return FIO; }
            set
            {
                if (Regex.IsMatch(value, "^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$") == true)
                {
                    FIO = value;
                }
                else
                    Console.WriteLine("Вводите нормально!");
            }
        }
        public static void INFO(Student cla)
        {
            Console.WriteLine("ИНФО О КЛАССЕ:");
            Console.WriteLine("Количество объектов:" + kol);
            Console.WriteLine("ID:" + cla.ID);
            Console.WriteLine("ФИО:" + cla.FIO);
            Console.WriteLine("День Рождения:" + cla.DR);
            Console.WriteLine("Адрес:" + cla.Adress);
            Console.WriteLine("Номер телефона:" + cla.Nomertelefona);
            Console.WriteLine("Факультет:" + cla.Fakyltet);
            Console.WriteLine("Курс:" + cla.Kyrs);
            Console.WriteLine("Группа:" + cla.Gruppa);
        }
        public partial class DevBlog
        {
            private string nul = "Hello";
            private string nik = "World";
        }
        public partial class DevBlog
        {
            public DevBlog()
            { this.nul = "top"; this.nik = "kot"; }
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Student ded = (Student)obj;
            return (this.ID == ded.ID && this.FIO == ded.FIO);
        }
        public override int GetHashCode()
        {
            int hash = 47;
            string wie = Convert.ToString(ID);
            hash = string.IsNullOrEmpty(wie) ? 0 : ID.GetHashCode();
            hash = (hash * 47) + Nomertelefona.GetHashCode();
            return hash;
        }
        public override string ToString()
        {
            return "Type" + base.ToString() + ID + "" + FIO + "";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> spisok = new List<Student>();
            string[] mas = new string[] {"January","February", "Mart", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int k = 4;
            IEnumerable<string> rezult1 = mas
                 .Where(n => (n.Length == k))
                 .Select(n => n);
            foreach(string month in rezult1)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();
            IEnumerable<string> rezult2 = mas
                .Where(n => (n.Equals("December")|| n.Equals("January") || n.Equals("February") || n.Equals("May")|| n.Equals("June") || n.Equals("July")))
                .Select(n => n);
            foreach (string month in rezult2)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();
            var ordered = from i in mas
                                 orderby i
                                 select i;
            foreach (string month in ordered)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();
            IEnumerable<string> rezult3 = mas
                .Where(n => (n.Contains('u')&& n.Length>=4))
                .Select(n => n);
            foreach (string month in rezult3)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();
            Student first = new Student("1", "Vlad", 30, "Central", "375", "FIT", 2, 4);
            Student second = new Student("2", "DOD", 01, "Central", "829", "IEF", 1, 7);
            Student third = new Student("3", "Bro", 10, "Central", "332", "TOV", 3, 4);
            spisok.Add(first);
            spisok.Add(second);
            spisok.Add(third);
            IEnumerable<Student> rezult4 = spisok
               .Where(n => (n.Fakyltet=="TOV"))
               .Select(n => n);
            foreach (Student month in rezult4)
            {
                Console.WriteLine(month.ID);
            }
            Console.WriteLine();
            IEnumerable<Student> rezult5 = spisok
              .Where(n => (n.Gruppa==4 && n.Kyrs==2))
              .Select(n => n);
            foreach (Student month in rezult5)
            {
                Console.WriteLine(month.ID);
            }
            Console.WriteLine();
            var result6 = from i in spisok
                          where (i.Kyrs==1)
                          select i;
            foreach (Student month in result6)
            {
                Console.WriteLine(month.ID);
            }
            Console.WriteLine();
            var result7 = from i in spisok
                          where (i.Gruppa == 4 && i.Kyrs == 2)
                          orderby i
                          select i;
            foreach (Student month in result7)
            {
                Console.WriteLine(month.FIO);
            }
            Console.WriteLine(result7.LongCount());
            Console.WriteLine();
            var result8 = spisok.First(p => (p.FIO == "DOD"));
            Console.WriteLine(result8.FIO);
            var result9 = spisok.Where(p=>(p.Raschet(p.DR,p.Kyrs)<=18));
            Console.WriteLine();
            foreach (Student month in result9)
            {
                Console.WriteLine(month.FIO);
            }
        }
    }
}
