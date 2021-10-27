using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTest
{
    public class Biker : Visitor
    {
        public bool Drunk { get; set; }
        public override void SaySomething()
        {
            Console.WriteLine($"{ Name } the {(faction)0}!");
        }
    }
}
