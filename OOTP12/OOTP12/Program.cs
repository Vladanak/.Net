using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ConsoleApp1
{
    // Тестовый класс, содержащий некоторые конструкции
    interface ITets
    {
        void Set(int a, int b);
    }
    interface ITest
    {
        double Sum();
        void Info();
    }
    class MyTestClass : ITest, ITets
    {
        public double d;
        double f;

        public double F
        {
            get
            {
                return f;
            }
            set
            {
                f = value;
            }
        }
        public string ToConsole(string aye)
        {
            return aye;
        }

        public MyTestClass(double d, double f)
        {
            this.d = d;
            this.f = f;
        }


        public double Sum()
        {
            return d + f;
        }

        public void Info()
        {
            Console.WriteLine("d = {0} f = {1}", d, f);
        }

        public void Set(int a, int b)
        {
            d = (double)a;
            f = (double)b;
        }

        public void Set(double a, double b)
        {
            d = a;
            f = b;
        }

        public override string ToString()
        {
            return "MyTestClass";
        }
        private void Privat()
        {
            Console.WriteLine("я только тут");
        }
    }
    class Reflect
    {
        public static void MethodOne<T>(T obj) where T : class
        {
            FileStream file = new FileStream("D:\\file.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            Type t = typeof(T);
            MethodInfo[] MArr = t.GetMethods();
            Type[] interNames = t.GetInterfaces();
            FieldInfo[] fieldNames = t.GetFields();
            PropertyInfo[] propertyNames = t.GetProperties();
            foreach (MethodInfo m in MArr)
            {
                writer.WriteLine(" -- " + m.ReturnType.Name + " \t" + m.Name + "\n");
            }
            foreach (FieldInfo m in fieldNames)
            {
                writer.WriteLine(" -- " + m.ReflectedType.Name + " \t" + m.Name + "\n");
            }
            foreach (PropertyInfo m in propertyNames)
            {
                writer.WriteLine(" -- " + m.ReflectedType.Name + " \t" + m.Name + "\n");
            }
            foreach (Type m in interNames)
            {
                writer.WriteLine(" -- " + m.Name + "\n");
            }
            writer.Close();
            Console.WriteLine("Запись выполнена!");
        }
        public static void MethodTwo<T>(T obj) where T : class
        {
            Type t = typeof(T);
            MethodInfo[] MArr = t.GetMethods();
            Console.WriteLine("Список методов класса {0}\n", obj.ToString());
            foreach (MethodInfo m in MArr)
            {
                Console.Write(" -- " + m.ReturnType.Name + " \t" + m.Name + "\n");
            }
        }
        public static void MethodThree<T>(T obj) where T : class
        {
            Type t = typeof(T);
            FieldInfo[] fieldNames = t.GetFields();
            PropertyInfo[] propertyNames = t.GetProperties();
            Console.WriteLine("Список полей и свойств класса {0}\n", obj.ToString());
            foreach (FieldInfo m in fieldNames)
            {
                Console.Write(" -- " + m.ReflectedType.Name + " \t" + m.Name + "\n");
            }
            foreach (PropertyInfo m in propertyNames)
            {
                Console.Write(" -- " + m.ReflectedType.Name + " \t" + m.Name + "\n");
            }
        }
        public static void MethodFour<T>(T obj) where T : class
        {
            Type t = typeof(T);
            Type[] interNames = t.GetInterfaces();
            Console.WriteLine("Список реализуемых интерфейсов класса {0}\n", obj.ToString());
            foreach (Type m in interNames)
            {
                Console.Write(" -- " + m.Name + "\n");
            }
        }
        public static void MethodTwoDOP<T>(T obj, string mth) where T : class
        {
            Type t = typeof(T);
            MethodInfo[] MArr = t.GetMethods();
            Console.WriteLine("Список методов класса {0}\n", obj.ToString());
            for (int i = 0; i < MArr.Length; i++)
            {
                ParameterInfo[] PArr = MArr[i].GetParameters();
                for (int j = 0; j < PArr.Length; j++)
                {
                    if (mth == PArr[j].ParameterType.Name)
                    {
                        Console.WriteLine(MArr[i]);
                    }
                }
            }
        }
        public static void LastMethod<T>(T obj, string mth) where T : class
        {
            Console.WriteLine("Читаем из файла параметр и передаем его в метод!");
            FileStream file2 = new FileStream("D:\\tut.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file2);
            object[] Arro = { reader.ReadLine() };
            Type t = typeof(T);
            MethodInfo metod = t.GetMethod(mth);
            object mval = metod.Invoke(obj,Arro);
            Console.WriteLine(mval);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyTestClass myTestClass = new MyTestClass(12.2, 13.3);
            Reflect.MethodOne<MyTestClass>(myTestClass);
            Reflect.MethodTwo<MyTestClass>(myTestClass);
            Reflect.MethodThree<MyTestClass>(myTestClass);
            Reflect.MethodFour<MyTestClass>(myTestClass);
            string s;
            Console.WriteLine("Введите тип аргумента(Double, Int32): ");
            s = Console.ReadLine();
            Reflect.MethodTwoDOP<MyTestClass>(myTestClass, s);
            Reflect.LastMethod<MyTestClass>(myTestClass, "ToConsole");
        }
    }
}