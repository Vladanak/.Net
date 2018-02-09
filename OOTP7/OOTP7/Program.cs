using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OOTP7
{
    interface IDatak //интерфейс - набор абстрактных членов(методов, свойств и тд.), которые должны быть реализованы в производнных классах.
    {// можно создать объект интерфейса
        void Info();
    }
    interface ITakoije // интерфейс для работы с одноименным методом
    {
        void TotJe();
    }
    struct Info
    {
        public string begin;
        public string predm;
        public string end;
    }

    enum Predm
    {
        Math, Russian, English, History
    }
    public abstract class Ispitanie
    {
        protected string type;
        protected string test;
        protected string ekzamen;
        public int kol;
        public Ispitanie()
        {
            test += "Обычный тест";
            ekzamen += "Лучше не шутить";
            kol++;
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public override string ToString() // переопределяем метод 
        {
            return "" + base.ToString() + " " + Type;
        }
        public abstract void ToConsole(); // метод абстрактного класса
        public abstract void TotJe(); // метод ОДНОИМЕННЫЙ ( в интерфейсе такой же)
    }
    class Test : Ispitanie, IDatak,ITakoije
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
        public override string ToString()
        {
            return "Type " + base.ToString() + " " + Tst;
        }
        public override void ToConsole() // производный класс обязан переопределить и реализовать все абстрактные методы
        {
            Console.WriteLine(this.ToString());
        }
        public override void TotJe() // работа с ОДНОИМЕННЫМ методом
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }
        void ITakoije.TotJe() // работа с ОДНОИМЕННЫМ методом
        {
            Console.WriteLine("Я тоже одноименный метод(я из интерфейса)!");
        }
        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(typeoftest);
        }

    }
    partial class Vopros : Test, IDatak
    {
        protected string predmet; // Имя предмета
        public static int kolvo;
        public Vopros(string type, string dif, int max) : base(type, dif, max)  // конструктор
        {
            predmet = type;
            difficult = dif;
            if(max>10||max<0)
                throw new MaxException("Ошибка! Неверно указан максимальный балл!");
            else   
               maxball = max;
            kolvo++;
        }
        public string Predme // св-ва
        {
            get
            { return predmet; }
            set
            {
                predmet = value;
                kolvo++;
            }
        }
        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(predmet);
        }
    }
    class Ekzamen : Ispitanie, IDatak,ITakoije
    {
        protected string name; // имя экзамена
        public int koll = 0;
        public int kolvopr = Vopros.kolvo;
        Predm glav;
        public Ekzamen(string ima)// конструктор
        {
            name = ima;
            Debug.Assert(ima.CompareTo("PE") != 0, "ошибочка тут у нас нашли не тот предмет");
            koll++;
        }
        public string Name // св-ва
        {
            get
            { return name; }
            set
            {
                if( name!="English"||name!="Math"||name!="Russian"||name!="History")
                {
                    throw new PredmException("Ошибка! Неверно указан предмет!");
                }
                else
                {
                    name = value;
                    koll++;
                }
            }
        }
        public override string ToString()
        {
            return "Type " + base.ToString() + " " + Name;
        }
        public override void ToConsole()
        {
            Console.WriteLine(this.ToString());
        }
        public override void TotJe()
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }
        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(name);
        }
        public int Kol //св-ва
        {
            get
            {
                return kol;
            }
            set
            {
                kol = value;
                koll++;
            }
        }
    }
    sealed class VipusknoiEkzamen : Ispitanie
    {
        protected string typeofekz; // тип куста
        int d = 32;
        public VipusknoiEkzamen() // конструктор
        {
            typeofekz = "Vipusknoi";
        }
        public string TypeofEKZ // св-ва
        {
            get
            { return typeofekz; }
            set
            { typeofekz = value; }
        }
        public override void ToConsole() // производный класс обязан переопределить и реализовать все абстрактные методы
        {
            Console.WriteLine(this.ToString());
        }
        public override void TotJe()
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }
        //переопределим ToString (cтроковое представление объекта)
        public override string ToString()
        {
            return "Type " + base.ToString() + " " + TypeofEKZ;
        }
        //переопределим Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            VipusknoiEkzamen odin = (VipusknoiEkzamen)obj;
            return (this.typeofekz == odin.typeofekz);
        }
        public override int GetHashCode()
        {
            int hash = 47;
            string wie = Convert.ToString(typeofekz);
            hash = string.IsNullOrEmpty(wie) ? 0 : typeofekz.GetHashCode();
            hash = (hash * 47) + d.GetHashCode();
            return hash;
        }
    }
    public static class Printer
    {
        public static void iAmPrinting(Ispitanie isp)
        {
            Console.WriteLine(isp.GetType());
            Console.WriteLine(isp.ToString());
        }
    }
    class Zachet
    {
        protected string predm;
        public Zachet()
        {
            predm = "Предмет зачёта";
        }
        public string Predm
        {
            get { return predm; }
            set { predm = value; }
        }
    }
    class Sessia : Zachet
    {
        private List<Ispitanie> ekz;
        public Sessia(params Ispitanie[] values)
        {
            ekz = new List<Ispitanie>(values);
            Test kak = new Test("obicni", "Easy", 2);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].GetType() == kak.GetType())
                {
                    throw new EkzamenException("Обнаружена ошибка!Обычный Тест на экзамене?Не смешно..");
                }
                else
                {
                    ekz.Add(values[i]);
                }
            }
        }
        public void AddEkz(Ispitanie a) { ekz.Add(a); }
        public List<Ekzamen> FindEkz(string predm)
        {
            List<Ekzamen> lst = new List<Ekzamen>();
            foreach (Ekzamen ek in ekz)
            {
                if (ek.Name == predm)
                {
                    lst.Add(ek);
                }
            }
            return lst;
        }
        public void ToConsoleList(List<Ekzamen> ekz)
        {
            for (int i = 0; i < ekz.Count; i++)
            {
                Console.WriteLine("Ekzamen[{0}] = {1}", i, ekz[i].Name);
            }

        }
        public int FindKol()
        {
            int summ = 0;
            foreach (Ekzamen eek in ekz)
            {
                summ += eek.koll;
            }
            return summ;
        }
        public int FindTes(int chislovoprov)
        {
            int sum = 0;
            foreach (Ekzamen ek in ekz)
            {
                if (chislovoprov == ek.kolvopr)
                    sum++;
            }
            return sum;
        }
    }
    class EkzamenException : Exception
    {
        public EkzamenException(string message) : base(message) { }
    }
    class PredmException : Exception
    {
        public PredmException(string message) : base(message) { }
    }
    class MaxException : Exception
    {
        public MaxException(string message) : base(message) { }
    }

    class Glavni
    {
        static void Main(string[] args)
        {
            Test test = new Test("Kontrol", "Hard", 10);
            Test test2 = new Test("Obichni", "Easy", 10);
            Vopros vopr = new Vopros("", "Easy", 10);
            Ekzamen ekzam = new Ekzamen("Math");
            VipusknoiEkzamen vipusk = new VipusknoiEkzamen();
            Console.WriteLine(test.Tst + " " + test.Diffic + " " + test.Maxb);
            test.Tst = "Kontrolni";
            Console.WriteLine(test2.Tst + " " + test2.Diffic + " " + test2.Maxb);
            Console.WriteLine("------------------");
            test.ToConsole();
            test.Info();
            Console.WriteLine("------------------");
            test2.ToConsole();
            test2.Info();
            Console.WriteLine("------------------");
            // работа с одноименными методами
            test.TotJe();
            ((ITakoije)test).TotJe();
            Console.WriteLine("------------------");
            ((test2 as ITakoije)).TotJe(); // работа по ссылке (as)
            test2.TotJe();
            Console.WriteLine(test.Tst is string ? "is" : "is not");
            Console.WriteLine("------------------");
            Printer.iAmPrinting(test);
            Printer.iAmPrinting(test2);
            Printer.iAmPrinting(vopr);
            object[] mas = { test, test2, vopr, ekzam, vipusk };
            Console.WriteLine("--00--00---- 6-aя лаба ----00--00--");
            Test test3 = new Test("Kont", "medium", 3);
            Console.WriteLine(test3.Type + " " + test3.Tst + " " + test3.Maxb + " ");
            Info ekzm;
            ekzm.begin = "30.10.2017";
            ekzm.predm = "Math";
            ekzm.end = "7.11.2017";
            Console.WriteLine("Информация о тесте: Дата начала: " + ekzm.begin + " Предмет : " + ekzm.predm + " Конец: " + ekzm.end);
            Ekzamen ekzam1 = new Ekzamen("History");
            Ekzamen ekzam2 = new Ekzamen("Russian");
            Sessia kek = new Sessia(ekzam, ekzam1, ekzam2);
            Console.WriteLine(kek.FindKol());
            kek.FindTes(1);
            Console.WriteLine("Поиск по предмету");
            kek.ToConsoleList(kek.FindEkz("Russian"));
            Console.WriteLine("--00--00---- 7-aя лаба ----00--00--");
            try
            {
                Sessia buk = new Sessia(ekzam, ekzam1, ekzam2,test);
            }
            catch (EkzamenException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.WriteLine("Уберем сессию");
                Sessia sesia = new Sessia(ekzam, ekzam1);
            }
            try
            {
                Ekzamen ekzamen3 = new Ekzamen("Russian");
                ekzamen3.Name = "PE";
            }
            catch (PredmException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("End.");

            }
            try
            {
                Vopros v1 = new Vopros("KR", "Normal", 11);
            }
            catch(MaxException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("That's all!");
            }
            Ekzamen ekzam4 = new Ekzamen("PE");
        }
    }
}
