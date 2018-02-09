using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP9
{
    public delegate void Doing();
    public delegate bool IsWorkUser(bool workUSER);
    public class User
    {
        public double version;
        public string name;
        public bool iswork = false;
        public User(string nam, double ver)
        {
            name = nam;
            version = ver;
        }
        public event Doing Upgrade;
        public event Doing Work;
        public void Up()
        {
            Console.WriteLine("Замечен апгрейд!");
            Console.WriteLine("Производится обновление версии!");
            Upgrade?.Invoke();
        }
        public void Working()
        {
            Console.WriteLine("Начало работы!");
            Work?.Invoke();
        }
        public void Upe()
        {
            version += 0.1;
            Console.WriteLine("Версия обновленна!");
            Console.WriteLine("Актуальная версия:" + version);
        }
        public void Worke()
        {
            Console.WriteLine("Он заработал!");
            iswork = true;
            if (iswork == true)
                Console.WriteLine("Состояние:ON");
            else
                Console.WriteLine("Состояние:OFF");
        }
        public void StrUdZnak(string a, Action<string> test1) => test1(a);
        public void StrDobSimv(string a, int pozit, string j, Action<string, int, string> test3) => test3(a, pozit, j);
        public void StrDobProb(string a, int pozition, Action<string, int> test4) => test4(a, pozition);
        public void StrUdSimv(string a, char x, Action<string, char> test5) => test5(a, x);
        public string StrZaglav(string a, Func<string, string> test2)
        {
            return test2(a);
        }
         public IsWorkUser IsWork = s1 => s1 is true;
    }
    class Program
    {
        static void Main(string[] args)
        {
            User PO1 = new User("Mario",1.0);
            User PO2 = new User("Pinokio",0.1);
            User PO3 = new User("LolDarova.kek",0.12);
            PO1.Upgrade += new Doing(PO1.Upe);
            PO1.Upgrade += new Doing(PO1.Worke);
            PO1.Working();
            PO1.Up();
            PO2.Work += new Doing(PO2.Worke);
            PO2.Working();
            Action<string > test1;
            test1 = (string n) => {
                int d;
                if (n.Contains('.'))
                {
                    d = n.IndexOf('.');
                    n= n.Remove(d, 1);
                }
                if (n.Contains(','))
                {
                    d = n.IndexOf(',');
                    n= n.Remove(d, 1);
                }
                Console.WriteLine(n);
            };
            PO3.StrUdZnak(PO3.name, test1);
            Func<string, string> test2;
            test2 = (string m) =>
            {
                m = m.ToUpper();
                Console.WriteLine(m);
                return m;
            };
            PO2.StrZaglav(PO2.name, test2);
        Action<string,int,string> test3;
        test3 = (string stroka,int poz ,string simv) => {
            stroka=stroka.Insert(poz, simv);
            Console.WriteLine(stroka);
        };
        PO3.StrDobSimv(PO3.name,3,"MASHINA",test3);
        Action<string, int> test4;
        test4 = (string stroka, int poz) => {
            stroka = stroka.Insert(poz, " ");
            Console.WriteLine(stroka);
        };
        PO2.StrDobProb(PO2.name, 1, test4);
            Action<string, char> test5;
            test5 = (string stroka, char simv) => {
                int b;
                if (stroka.Contains(simv))
                {
                    b = stroka.IndexOf(simv);
                    stroka = stroka.Remove(b, 1);
                }
                Console.WriteLine(stroka);
            };
            PO1.StrUdSimv(PO1.name,'r', test5);
            Console.WriteLine(PO1.IsWork(PO1.iswork));
        }
    }
}
