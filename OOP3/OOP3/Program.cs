using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP3b
{
    class STUD
    {
        private STUD()
        { }
    }
    public class Student
    {
        public readonly string Univer="ded";
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
        public Student(string I,string Fi,int dr,string Ad,string Num,string Fak,int K,int Gr)
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
        public virtual void Raschet(int dr, int k)
        {
            int c=18;
            dr = 0 ;
            c = c + (k-1);
            Console.WriteLine("Ему " + (c+dr) + " лет");
            k = c; 
        }

        public string Id
        {
            get { return ID; }
            set {
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
        
        Student pervi = new Student("1", "Муравейо В.С", 30, "Brest", "32", "FIT", 2, 4);
            Student vtoroi = new Student("2", "BOBR", 29, "Brest", "33", "IEF", 1, 2);
            Student treti = new Student("3", "PETR", 28, "Brest", "34", "TOV", 2, 7);
            pervi.Raschet(out pervi.DR, ref pervi.Kyrs);
            Console.WriteLine("Вводите ID");
            pervi.Id = Console.ReadLine();
            Console.WriteLine("Вводите Ф И О");
            pervi.Fio = Console.ReadLine();
            //ANON
            var anon = 5;
            Console.WriteLine(anon);
            var anonObj = new Student("10", "14", 5, "7","55","d",2,4);
            Student.INFO(anonObj);
            Student.INFO(pervi);
            bool result;
            result = pervi.Equals(anonObj);
            if (result == true) Console.WriteLine("Один и тот же студент");
            else Console.WriteLine("Разные студенты");
            Console.WriteLine("Хэш-код : {0}", pervi.GetHashCode());
            Console.WriteLine("Хэш-код : {0}", anonObj.GetHashCode());
            Student[] mas = { pervi, vtoroi, treti };
            string a = "FIT";
            for (var i=0;i<mas.Length;i++)
            {
                if (a.Contains(mas[i].Fakyltet) == true)
                    Console.WriteLine("Студент " +mas[i].FIO+" факультета " + mas[i].Fakyltet);
            }
            for (var z = 0; z < mas.Length; z++)
            {
                if ((mas[z].Kyrs == 2)&&((mas[z].Gruppa == 4)))
                    Console.WriteLine("Студент "+ mas[z].FIO + "" + mas[z].Kyrs+" курса "+ mas[z].Gruppa+" группы");
            }
        }
    }
}
