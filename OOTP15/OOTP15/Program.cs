using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;
using System.IO.Compression;

namespace OOTP15
{
    class Program
    {
        static FileInfo oshfile = new FileInfo("obshfile.txt");
        static AutoResetEvent waitHandler = new AutoResetEvent(false);
        static AutoResetEvent waitHandler2 = new AutoResetEvent(false);
        static int w = 0;
        static void Main(string[] args)
        {
            //работаем с процессами
            foreach (Process pr in Process.GetProcesses())
            {
                Console.WriteLine("Имя процесса: " + pr.ProcessName + " Приоритет: " + pr.BasePriority + /*" Время запуска: " + pr.StartTime + */" Состояние: " + pr.Responding + /*" Использование времени процессора: " + pr.PrivilegedProcessorTime*/ " Использует физ. памяти: " + pr.WorkingSet64);
            }
            //исследуем текущий домен
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Name: " + domain.FriendlyName);
            Console.WriteLine("Directory: " + domain.BaseDirectory);
            foreach (Assembly a in domain.GetAssemblies())
            {
                Console.WriteLine(a.GetName().Name);
            }
            //создаем домен, загружаем туда сборку, выгружаем домен
            AppDomain secdomain = AppDomain.CreateDomain("Second Domain");
            secdomain.Load(new AssemblyName("OOTP15"));
            Console.WriteLine("Name: " + secdomain.FriendlyName);
            foreach (Assembly a in secdomain.GetAssemblies())
            {
                Console.WriteLine(a.GetName().Name);
            }
            AppDomain.Unload(secdomain);
            //работаем с потоками
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            Thread mythread = new Thread(new ParameterizedThreadStart(ToConsoleFile));//делегат threadstart
            mythread.Start(n);
            mythread.Name = "MyThread00";
            Console.WriteLine("Поток: " + mythread.Name + " Состояние: " + mythread.ThreadState + " Приоритет: " + mythread.Priority);
            for (int i = 0; i < n; i++)
            {
                i++;
                Console.WriteLine("Главный поток: " + i);
                Thread.Sleep(300);
                mythread.Suspend();
            }
            mythread.Resume();
            Console.WriteLine("Введите x: ");
            int x = int.Parse(Console.ReadLine());
            using (FileStream fs = new FileStream(oshfile.ToString(), FileMode.Create, FileAccess.Write))
            { }
            Thread first = new Thread(new ParameterizedThreadStart(Chet));
            Thread second = new Thread(new ParameterizedThreadStart(Nechet));
            second.Priority = ThreadPriority.Highest;
            Console.WriteLine(first.Priority);
            Console.WriteLine(second.Priority);
            first.Start(x);
            second.Start(x);
            Console.WriteLine("Введите количество секунд(таймер): ");
            int ch;
            ch = int.Parse(Console.ReadLine());
            TimerCallback tm = new TimerCallback(TimerSec); // метод обратного вызова
            Timer tmr = new Timer(tm, ch, 500, 1000);
            Thread.Sleep(ch * 1000);
            tmr.Dispose();
            Console.ReadKey();
        }
        public static void TimerSec(object obj)
        {
            w++;
            int x = (int)obj;
            Console.WriteLine("Таймер: {0}", w);
            if (w == x)
            {
                Console.WriteLine("Время вышло!");
                Process music = Process.Start("shum.mp3");
            }
        }
        public static void Chet(object x)
        {
            int n = (int)x;
            for (int i = 1; i < n; i++)
            {
                if ((i % 2) == 0)
                {
                    Console.WriteLine("First Thread: " + i);
                    Thread.Sleep(300);

                    using (StreamWriter writer = new StreamWriter(oshfile.ToString(), true, System.Text.Encoding.Default))
                    {
                        writer.Write("First Thread: " + i + " ");
                    }
                    waitHandler.WaitOne();
                    waitHandler2.Set();
                }
            }
            //waitHandler.Set(); // 4.1)
        }
        public static void Nechet(object x)
        {
            //waitHandler.WaitOne(); // 4.1) 
            int n = (int)x;
            for (int i = 1; i < n; i++)
            {
                if ((i % 2) != 0)
                {
                    Console.WriteLine("Second Thread: " + i);
                    Thread.Sleep(500);
                    using (StreamWriter writer = new StreamWriter(oshfile.ToString(), true, System.Text.Encoding.Default))
                    {
                        writer.Write(" Second Thread: " + i + " ");
                    }
                    waitHandler.Set();
                    waitHandler2.WaitOne();
                }

            }
        }

        //public static void ChetNechet(object x)
        //{
        //    int n = (int)x;
        //    for (int i = 1; i < n; i++)
        //    {
        //        if ((i % 2) == 0)
        //        {
        //            Console.WriteLine("First Thread: " + i);
        //            Thread.Sleep(300);

        //            using (StreamWriter writer = new StreamWriter(oshfile.ToString(), true, System.Text.Encoding.Default))
        //            {
        //                writer.Write("First Thread: " + i + " ");
        //            }
        //        }
        //        if ((i % 2) != 0)
        //        {
        //            Console.WriteLine("Second Thread: " + i);
        //            Thread.Sleep(500);
        //            using (StreamWriter writer = new StreamWriter(oshfile.ToString(), true, System.Text.Encoding.Default))
        //            {
        //                writer.Write(" Second Thread: " + i + " ");
        //            }
        //        }
        //    }
        //}
        public static void ToConsoleFile(object x)
        {
            FileInfo file = new FileInfo("file.txt");
            int n = (int)x;
            for (int i = 0; i < n; i++)
            {
                i++;
                Console.Write("Второстепенный поток: " + i + "\n");
                using (StreamWriter writer = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
                {
                    writer.Write(i + " ");
                }
                Thread.Sleep(500);
            }
        }


    }
}
