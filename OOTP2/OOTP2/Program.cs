using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start a
            sbyte sb = 1;
            short s = 2;
            int i = 3;
            long l = 4;
            byte b = 5;
            ushort us = 6;
            uint ui = 7;
            ulong ul = 8;
            char c = 'a';
            char ci = '1';
            bool bo = true;
            float f = 3.5f;
            double d = 4.432f;
            decimal dec = 4;
            string str = "ded";
            Object obj;
            //////////// b
            long ii = i;
            decimal decc = dec;
            int i2 = ci;
            int i3 = s;
            decimal decc2 = sb;
            ///////////  b
            int i4 = (int)s;
            double d1 = (double)f;
            decimal d2 = (decimal)d1;
            long l1 = (long)ul;
            short s1 = (short)us;
            ////////// c
            byte bb = 8;
            Object bbb = bb;
            long bb1 = (long)(byte)bbb;
            /////////d
            var v = 18;
            var v1 = "double";
            Console.WriteLine(v.GetType()); Console.WriteLine(v1.GetType());
            var v2 = 2.3f;
            var vv = v2 * v;
            Console.WriteLine(vv.GetType());
            Console.WriteLine(vv);
            ////////e
            int? x = null;
            int? x1 = null;
            double? xx = 3.14f;
            Console.WriteLine(x1 == xx);
            int x2 = x1 ?? 10;
            //////// 2 a
            string a = "a";
            string aa = "bb";
            string aaa = "cdcc";
            if (a == aa) Console.WriteLine("равны");
            else Console.WriteLine("не равны");
            //////// b
            string ab = String.Concat(a, aa);
            Console.WriteLine(ab);
            string ac = String.Copy(aaa);
            Console.WriteLine(ac);
            string ad = aaa.Substring(1, 1);
            Console.WriteLine(ad);
            char det = 'd';
            string[] af = aaa.Split(det);
            Console.WriteLine(af);
            string ah = aaa.Insert(2, a);
            Console.WriteLine(ah);
            string az = aaa.Remove(1, 1);
            Console.WriteLine(az);
            ///////// c
            string zz = "";
            string zx = null;
            string za = String.Concat(a, zz);
            Console.WriteLine(az);
            if (zx == a) Console.WriteLine("true");
            else Console.WriteLine("false");
            string zb = String.Concat(zx, aa);
            Console.WriteLine(zb);
            ////////// d
            StringBuilder sbs = new StringBuilder("HELLO WORLD", 100);
            StringBuilder ssb = sbs.Remove(2, 1);
            Console.WriteLine(ssb);
            ssb.Append(new char[] { 'd' });
            ssb.Insert(0, 'D');
            Console.WriteLine(ssb);
            /////////// 3 a
            int[][] z = { new int[2] { 1, 2 }, new int[2] { 3, 4 } };
            foreach (int[] n in z)
            {
                foreach (var m in n)
                    Console.Write("\t" + m);
                Console.WriteLine();
            }
            ////////// b
            string[] nm = { "hello", "world", "all" };

            foreach (var n in nm)
                Console.WriteLine(n);
            int nn = nm.Length;
            Console.WriteLine(nn);
            nm.SetValue("double", 1);
            foreach (var n in nm)
                Console.WriteLine(n);
            ///////// c
            float[][] mega = new float[3][];
            mega[0] = new float[1];
            mega[0][0] = 999.9f;
            mega[1] = new float[2];
            mega[1][0] = 0.2f;
            mega[1][1] = 1.1f;
            mega[2] = new float[3];
            mega[2][0] = 1.2f;
            mega[2][1] = 2.3f;
            mega[2][2] = 2.333f;
            foreach (float[] n in mega)
            {
                foreach (float m in n)
                {
                    Console.Write("\t" + m);
                }
                Console.WriteLine();
            }
            ///////// d
            var mass = new[] {1,3,5};
            var mastak = new[]{"LOL"};
            Console.WriteLine(mass);
            Console.WriteLine(mastak);
            //////// 4  a b

            (int first, string second, char third, string fourth, ulong fifth) something = (10, "VLAD", 'a', "mbal", 14);
            Console.WriteLine(something.GetType().Name);
            // c
            Console.WriteLine($"{something}");
            Console.WriteLine($"{something.first}");
            Console.WriteLine($"{something.third}");
            Console.WriteLine($"{something.fourth}");
            // d
            var one = something.Item1;
            var two = something.Item2;
            var three = something.Item3;
            var four = something.Item4;
            var five = something.Item5;
            // e
            (int , string , char , string , ulong ) someone = (1, "VLD", 'd', "l", 2);
            if(someone.Item1>something.first)
                Console.WriteLine("WINNER");
            else Console.WriteLine("Loser");
            /////////// 5
            int[] masiv= { 2, 5, 9 };
            int Locfun(int[] yy,string net )
                {
                int max = yy.Max();
                int min=yy.Min();
                int sum=yy.Sum();
                string first=net.Substring(0,1);
                (int, int, int, string) some = (max, min, sum, first);
                Console.WriteLine(some);
                return 0;
                }
            Locfun(masiv, aaa);
        }
    }
}
