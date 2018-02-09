using System;

namespace OOTP3
{
    public class Vichislenia
    {
        private Vichislenia()
        { }
        public static int Perimetr(ref int dlina, ref int shirina)
        {
            int c;
            c = 2 * (dlina + shirina);
            return c;
        }
        public static int Ploshad(int dlina, int shirina)
        {
            int c;
            c = dlina * shirina;
            return c;
        }
    }
    public class Priamougolnik
    {
        public int weight;
        public int high;
        public int diagonal;
        public int diagonal1;
        public readonly int chtenie;
        public const int e = 100;
        public Priamougolnik(int weigh, int hig, int dig1, int dig2) : this()
        {
            weight = weigh;
            high = hig;
            diagonal = dig1;
            diagonal1 = dig2;
            obje++;
        }
        public Priamougolnik()
        {
            weight = 10;
            high = 30;
            diagonal = 5;
            diagonal1 = 9;
            chtenie = GetHashCode();
            obje++;
        }
        static Priamougolnik()
        {
            obje=0;
        }
        static int ugol;
        static int obje;
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Priamougolnik ded = (Priamougolnik)obj;
            return (this.weight == ded.weight && this.high == ded.high);
        }
        public override int GetHashCode()
        {
            int hash = 47;
            string wie = Convert.ToString(weight);
            hash = string.IsNullOrEmpty(wie) ? 0 : weight.GetHashCode();
            hash = (hash * 47) + high.GetHashCode();
            return hash;
        }
        public override string ToString()
        {
            return "Type" + base.ToString() + weight + "" + high + "";
        }
        public int Weight
        {
            get { return weight; }
            set
            {
                if ((value <= 0) && (value < high))
                    Console.WriteLine("Невозможно задать такой размер!");
                else
                    weight = value;
            }
        }
        public int Diagonal
        {
            get { return diagonal; }
            set
            {
                if ((value <= 0) && (value < high))
                    Console.WriteLine("Невозможно задать такой размер!");
                else
                    diagonal = value;
            }
        }
        public int Diagonal2
        {
            get { return diagonal1; }
            set
            {
                if ((value <= 0) && (value < high))
                    Console.WriteLine("Невозможно задать такой размер!");
                else
                    diagonal1 = value;
            }
        }
        public int High
        {
            get { return high; }
            set
            {
                if ((value <= 0) && (value > weight))
                    Console.WriteLine("Невозможно задать такой размер!");
                else
                    high = value;
            }
        }
        public double ROMB(int d1, out int d2)
        {
            double romb;
            d2 = d1 + 2;
            d1++;
            romb = 0.5 * d1 * d2;
            return romb;
        }
        public static void INFO(Priamougolnik cla)
        {
            Console.WriteLine("ИНФО О КЛАССЕ:");
            Console.WriteLine("Количество объектов:" + obje);
            Console.WriteLine("Ширина сторон:" + cla.weight);
            Console.WriteLine("Длина сторон:" + cla.high);
            Console.WriteLine("Длина первой диагонали:" + cla.diagonal);
            Console.WriteLine("Длина второй диагонали:" + cla.diagonal1);
            Console.WriteLine("Площадь:" + cla.ROMB(cla.diagonal, out cla.diagonal1));
        }
    }
    public partial class DevBlog
    {
        private string nul = "Hello";
        private string nik = "World";
    }
    public partial class DevBlog
    {
        public DevBlog()
        { this.nul = "top";this.nik = "kot"; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int kvadrat = 0;
            int priamougolnik = 0;
            int romb = 0;
            Priamougolnik a = new Priamougolnik(10,20,4,7);
            Console.WriteLine(a.GetType());
            Priamougolnik[] mas = new Priamougolnik[3];
            for(var i=0;i<mas.Length;i++)
            {
                mas[i] = new Priamougolnik();
            }
            mas[0].High = 20;
            mas[0].Weight = 20;
            kvadrat++;
            mas[1].High = 25;
            mas[1].Weight = 25;
            kvadrat++;
            mas[2].High = 20;
            mas[2].Weight = 7;
            priamougolnik++;
            a.High = 25;
            a.Weight = 12;
            priamougolnik++;
            Console.WriteLine("Количество квадратов:"+kvadrat);
            Console.WriteLine("Количество Прямоугольников:"+priamougolnik);
            Console.WriteLine("Количество ромбов:"+romb);
            int alfa = Vichislenia.Perimetr(ref a.high, ref a.weight);
            int beta = Vichislenia.Ploshad(a.high, a.weight);
            if (Vichislenia.Ploshad(mas[0].high, mas[0].weight) > Vichislenia.Ploshad(mas[1].high, mas[1].weight))
            { Console.WriteLine("Первый квадрат больше второго по площади"); }
            else { Console.WriteLine("Второй квадрат больше первого по площади"); }
            if (Vichislenia.Ploshad(mas[2].high, mas[2].weight) > beta)
            { Console.WriteLine("Первый прямоугольник больше второго по площади"); }
            else { Console.WriteLine("Второй прямоугольник больше первого по площади"); }
            if(romb==0)
                Console.WriteLine("Нету ромбов");
            else
                if (romb==1)
                  Console.WriteLine("Т.К. ромб один то он является как самым наибольшим так и самым наименьшим по площади(периметру)");
            Console.WriteLine("Периметр="+alfa);
            Console.WriteLine("Площадь=" +beta);
            bool result;
            result = mas[0].Equals(mas[1]);
            if (result == true) Console.WriteLine("Два квадрата равны!");
            else Console.WriteLine("Два квадрата не равны!");
            Console.WriteLine("Хэш-код : {0}", mas[0].GetHashCode());
            Console.WriteLine("Хэш-код : {0}", mas[2].GetHashCode());
            //ANON
            var anon = 5;
            Console.WriteLine(anon);
            var anonObj = new Priamougolnik(10,14,5,7);
            Priamougolnik.INFO(anonObj);
        }
    }
}