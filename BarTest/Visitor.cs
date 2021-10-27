using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTest
{
    public class Visitor
    {
        public string Name { get; set; }
        public int Endurance { get; set; }

        public virtual void SaySomething()
        {
            Console.WriteLine($"{Name}!");
        }

        public static void Naming()
        {
            var naming = (nameList)Program.GetRandom(Enum.GetNames(typeof(nameList)).Length);
            Console.WriteLine(naming);
        }

        public enum nameList
        {
            Alex,
            Samuel,
            Jack,
            Joseph,
            Harry,
            Alfie,
            Jacob,
            Thomas,
            Charlie,
            Oscar,
            James,
            William,
            Joshua,
            George,
            Ethan,
            Noah,
            Archie,
            Henry,
            Leo,
            John,
            Oliver,
            David,
            Ryan,
            Dexter,
            Connor,
            Albert,
            Austin,
            Stanley,
            Theodore,
            Owen,
            Caleb
        }

        public enum faction {
            Biker,
            Stalker,
            Tolchok,
            Civic
        }
    }
}
