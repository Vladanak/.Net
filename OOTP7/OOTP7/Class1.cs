using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTP7
{
    partial class Vopros : Test, IDatak
    {
        public override string ToString()
        {
            return "Type " + base.ToString() + " " + Predme;
        }
        public override void ToConsole()
        {
            Console.WriteLine(this.ToString());
        }
        public override void TotJe()
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }
    }
}
