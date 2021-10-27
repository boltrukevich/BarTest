using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTest
{

    public class Alcohol
    {
        public string Name;
        public double Strengt;
        public double Volume;


        public virtual void AlcoholAtribute()
        {
            Console.WriteLine($"One portion of {Name} have a {Volume} volume and {Strengt} strengt.");

        }


    }
}