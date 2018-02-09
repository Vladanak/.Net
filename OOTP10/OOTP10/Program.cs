using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace OOTP10
{
    interface IDatak //интерфейс - набор абстрактных членов(методов, свойств и тд.), которые должны быть реализованы в производнных классах.
    {// можно создать объект интерфейса
        void Info();
    }
    class Test : IDatak
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
        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(typeoftest);
            Console.WriteLine(difficult);
            Console.WriteLine(maxball);
        }

    }
    class Polza<T> where T:Test
    {
        public List<T> kek = new List<T>();
        public Stack<T> lol = new Stack<T>();

        public void Add(T elem)
        {
            kek.Add(elem);
        }
        public void Push(T elem)
        {
            lol.Push(elem);
        }
        public void Write()
        {
            foreach (object a in kek)
                Console.Write("{0}\t", a);
            Console.WriteLine("\n");
        }
        public void Writestack()
        {
            for (int i = 0; i < lol.Count + 3; i++)
            {
                object k = lol.Pop();
                Console.WriteLine(k);
            }
        }
        public void SearchEl(T a, ref Stack<T> arr)
        {
            if (arr.Contains(a) == true)
            {
                Console.WriteLine("Такой элемент присутствует!" + a);
            }
        }
    }
    class ArayList
    {
        public static ArrayList NewCollection(int i)
        {
            Random ran = new Random();
            ArrayList arr = new ArrayList();

            for (int j = 0; j < i; j++)
                arr.Add(ran.Next(1, 50));
            return arr;
        }

        public static void RemoveElement(int i, ref ArrayList arr)
        {
            arr.RemoveAt(i);
        }
        public static void SearchElement(string a, ref ArrayList arr)
        {
            if (arr.Contains(a) == true)
            {
                Console.WriteLine("Такой элемент присутствует!Его индекс:" + arr.IndexOf(a));
            }
        }
        public static void AddElement(int i, ref ArrayList arr)
        {
            Random ran = new Random();
            for (int j = 0; j < i; j++)
                arr.Add(ran.Next(1, 50));
        }
        public static void AddElementStr(ref ArrayList arr)
        {
            arr.Add(Console.ReadLine());
        }
        public static void WriteCollect(ArrayList arr)
        {
            foreach (object a in arr)
                Console.Write("{0}\t", a);
            Console.WriteLine("\n");
        }

        public class Listt<T> where T : struct
        {
            public List<T> kek = new List<T>();
            public Stack<T> lol = new Stack<T>();
            
            public void Add(T elem)
            {
                kek.Add(elem);
            }
            public void Push(T elem)
            {
                lol.Push(elem);
            }
            public void Write()
            {
                foreach (object a in kek)
                    Console.Write("{0}\t", a);
                Console.WriteLine("\n");
            }
            public void Writestack()
            {
                for (int i = 0; i < lol.Count+3; i++)
                {
                    object k = lol.Pop();
                    Console.WriteLine(k);
                }
            }
            public  void SearchEl(T a, ref Stack<T> arr)
            {
                if (arr.Contains(a) == true)
                {
                    Console.WriteLine("Такой элемент присутствует!" + a);
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                int kol = 0;
                ArrayList Coll = ArayList.NewCollection(5);
                Console.WriteLine("Исходная коллекция чисел: ");
                ArayList.WriteCollect(Coll);
                Console.WriteLine("Добавили 1 элемент(строка): ");
                Coll.Add("KEK");
                ArayList.WriteCollect(Coll);
                for (int i = 0; i < Coll.Count; i++)
                {
                    kol++;
                }
                Console.WriteLine("Кол-во элементов листа: " + kol);
                ArayList.RemoveElement(2, ref Coll);
                ArayList.WriteCollect(Coll);
                ArayList.SearchElement("KEK", ref Coll);
                Listt<double> ux = new Listt<double>();
                ux.Add(3.5);
                ux.Add(4);
                ux.Add(5);
                ux.Add(5.5);
                for (int i = 0; i < ux.kek.Count; i++)
                    ux.Push(ux.kek[i]);
                ux.kek.RemoveRange(0, 1);
                ux.Write();
                ux.Writestack();
                ux.SearchEl(5,ref ux.lol);
                Test ekzemp = new Test("dde","ddddee",2);
                Test ekeemp = new Test("adas"," zcc", 2);
                Polza<Test> p = new Polza<Test>();
                p.Add(ekzemp);
                p.Add(ekeemp);
                p.Write();
                var data = new ObservableCollection<Test>();
                data.CollectionChanged += Data_CollectionChanged;
                data.Add(ekzemp);
                data.Add(ekeemp);
                data.Insert(0,ekeemp);
                data.Remove(ekeemp);
            }

            private static void Data_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add: // если добавление
                        Test newUser = e.NewItems[0] as Test;
                        Console.WriteLine("Добавлен новый объект: {0}", newUser.Diffic);
                        break;
                    case NotifyCollectionChangedAction.Remove: // если удаление
                        Test oldUser = e.OldItems[0] as Test;
                        Console.WriteLine("Удален объект: {0}", oldUser.Tst);
                        break;
                    case NotifyCollectionChangedAction.Replace: // если замена
                        Test replacedUser = e.OldItems[0] as Test;
                        Test replacingUser = e.NewItems[0] as Test;
                        Console.WriteLine("Объект {0} заменен объектом {1}",
                                            replacedUser.Maxb, replacingUser.Maxb);
                        break;
                }
            }
        }
    }
}
