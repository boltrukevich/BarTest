using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTest
{
    public class Stalker : Visitor
    {
        public bool Punch { get; set; }
        public override void SaySomething()
        {
            Console.WriteLine($"{ Name } the {(faction)1}!");
        }

    }
}
