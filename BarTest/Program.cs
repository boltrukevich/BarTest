using System;
using System.Collections.Generic;
using System.Linq;

namespace BarTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var barVisitor = new List<Visitor>();
            var barAlcohol = new List<Alcohol>();
            var barMixture = new List<Mixture>();

            barAlcohol.Add(new Alcohol() { Name = "Absent", Strengt = 83, Volume = 60 });
            barAlcohol.Add(new Alcohol() { Name = "Vodka", Strengt = 40, Volume = 100 });
            barAlcohol.Add(new Alcohol() { Name = "Vine", Strengt = 12, Volume = 180 });
            barAlcohol.Add(new Alcohol() { Name = "Beer", Strengt = 5, Volume = 330 });
            //start 

            Console.WriteLine($"Input team size:");
            int teamSize = Convert.ToInt32(Console.ReadLine());
            //create visitors
            for (int j = 0; j < teamSize * 2; j++)
            {
                AddVisitor(barVisitor, barVisitor.Count);
            }
            Console.WriteLine($"Kolvo uchastnikov = {barVisitor.Count}");
            //split on team

            List<Visitor> team1 = barVisitor.GetRange(0, teamSize);
            List<Visitor> team2 = barVisitor.GetRange(teamSize, teamSize);

            //start competition
            Competition(team1, team2);
            RoundStart(barAlcohol, barMixture, team1, team2);
        }
        public static void AddVisitor(List<Visitor> barVisitor, int index)
        {
            int indexFaction = GetRandom(Enum.GetNames(typeof(Visitor.faction)).Length);
            if (indexFaction == 0)
            {
                barVisitor.Add(new Biker() { Name = Convert.ToString((Visitor.nameList)Program.GetRandom(Enum.GetNames(typeof(Visitor.nameList)).Length)), Endurance = 30 + GetRandom(30), Drunk = true });
            }
            else if (indexFaction == 1)
            {
                barVisitor.Add(new Stalker() { Name = Convert.ToString((Visitor.nameList)Program.GetRandom(Enum.GetNames(typeof(Visitor.nameList)).Length)), Endurance = 25 + GetRandom(30), Punch = true });
            }
            else if (indexFaction == 2)
            {
                barVisitor.Add(new Tolchok() { Name = Convert.ToString((Visitor.nameList)Program.GetRandom(Enum.GetNames(typeof(Visitor.nameList)).Length)), Endurance = 25 + GetRandom(30), pretendDead = true });
            }
            else
            {
                barVisitor.Add(new Visitor() { Name = Convert.ToString((Visitor.nameList)Program.GetRandom(Enum.GetNames(typeof(Visitor.nameList)).Length)), Endurance = 20 + GetRandom(30) });
            }

        }


        static void Competition(List<Visitor> team1, List<Visitor> team2)
        {
            Console.WriteLine($"Team #1. Number of competitors: {team1.Count}");
            int i = 0;
            foreach (var player in team1)
            {
                i++;
                Console.Write($"Competitor №{i}: ");
                player.SaySomething();
            }

            Console.WriteLine();

            Console.WriteLine($"Team #2. Number of competitors: {team1.Count}");
            i = 0;
            foreach (var player in team2)
            {
                i++;
                Console.Write($"Competitor №{i}: ");
                player.SaySomething();
            }
            Console.ReadKey();
        }

        public static void RoundStart(List<Alcohol> barAlcohol, List<Mixture> barMixture, List<Visitor> team1, List<Visitor> team2)
        {
            int counter = 0;
            counter++;
            Console.Clear();
            Console.WriteLine($"Round №{counter}.");
            while (team1.Count > 0 & team2.Count > 0)
            {
                Console.WriteLine($"Сompetitors are called to the counter: {team1[0].Name}({team1[0].Endurance}) and {team2[0].Name}({team2[0].Endurance})");

                bool teamOneLoseRound = false;
                bool teamTwoLoseRound = false;

                AlcoMixer(barAlcohol);
                //StartRoundAbilityCheck(team1, team2);
                
                while (team1[0].Endurance > 0 & team2[0].Endurance > 0)
                {
                    //int damage = barMixture[barMixture.Count-1].Ratio;
                    int damage = 10;

                    team1[0].Endurance = team1[0].Endurance - damage;
                    if (team1[0].Endurance <= 0)
                    {
                        Console.WriteLine($"{team1[0].Name} drop on floor.");
                        teamOneLoseRound = true;
                        EndRoundAbilityCheck(team1, team2, teamOneLoseRound, teamTwoLoseRound);
                        if (teamOneLoseRound == true) { team1.RemoveAt(0); };
                        break;
                    }
                    Console.WriteLine($"{team1[0].Name} drunk and has {team1[0].Endurance} endurance");

                    team2[0].Endurance = team2[0].Endurance - damage;
                    if (team2[0].Endurance <= 0)
                    {
                        Console.WriteLine($"{team2[0].Name} drop on floor.");
                        teamTwoLoseRound = true;
                        EndRoundAbilityCheck(team1, team2, teamOneLoseRound, teamTwoLoseRound);
                        if (teamTwoLoseRound == true) { team2.RemoveAt(0); };

                        break;
                    }
                    

                    Console.WriteLine($"{team2[0].Name} drunk and has {team2[0].Endurance} endurance");
                    Console.ReadKey();
                }
            } CompetitionFinal( team1,  team2);
        }

        public static void CompetitionFinal(List<Visitor> team1, List<Visitor> team2)
        {
            if (team1.Count > team2.Count)
            {
                Console.WriteLine($"Team one win!");
                Console.WriteLine($"On foot stay {team1.Count}competitor!");
                foreach (var player in team1)
                {
                    player.SaySomething();
                }
                Console.ReadKey();
            }
            else if (team1.Count < team2.Count)
            {
                Console.WriteLine($"Team two win!");
                Console.WriteLine($"On foot stay {team2.Count} competitor:");
                foreach (var player in team2)
                {
                    player.SaySomething();
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"This is draw! All down.");
                Console.ReadKey();
            }
        }

        public static void StartRoundAbilityCheck(List<Visitor> team1, List<Visitor> team2)
        {
            //    if (team1[0].Punch == true){ }
        }
        public static void EndRoundAbilityCheck(List<Visitor> team1, List<Visitor> team2, bool teamOneLoseRound, bool teamTwoLoseRound)
        {
            /*teamOneLoseRound = true;
            if (team1[0].PretendDead == true)
            {
            teamOneLoseRound = false;
            team1[0].PretendDead = false;
            team1[0].Endurance = 10;
            Console.WriteLine($"{team1[0].Name} pretend dead.");
            }

            teamTwoLoseRound = true;
            if (team2[0].PretendDead == true)
            {
            teamTwoLoseRound = false;
            team2[0].PretendDead = false;
            team2[0].Endurance = 10;
            Console.WriteLine($"{team2[0].Name} pretend dead.");

            }
 
            if (team1[0].Drunk == true || team1[0].Endurance > 20)
            {
                team1[0].Drunk= false;
                Console.WriteLine($"Go buhat, epta!");
                for (int i = 0; i < 2; i++;)
            {
                AlcoMixer(List<Alcohol> barAlcohol);
                iRand = GetRandom(team2.Counter-1);
                Console.WriteLine($"{team1[0].Name}Spaivaet {team2[iRand].Name}!");
                team1[0].Endurance -= barMixture[iRand].Ratio;
                team2[GetRandom(team2[iRand].Endurance -= barMixture[iRand].Ratio;].

            if (team2[0].Drunk == true || team2[0].Endurance > 20)
            {
                team2[0].Drunk= false;
                Console.WriteLine($"Go buhat, epta!");
                for (int i = 0; i < 2; i++;)
            {
                AlcoMixer(List<Alcohol> barAlcohol);
                iRand = GetRandom(team1.Counter-1);
                Console.WriteLine($"{team2[0].Name}Spaivaet {team1[iRand].Name}!");
                team2[0].Endurance -= barMixture[iRand].Ratio;
                team1[GetRandom(team1[iRand].Endurance -= barMixture[barMixture.Count - 1].Ratio;].
            {*/

        }
        public static void AlcoMixer(List<Alcohol> barAlcohol)
{
var barMixture = new List<Mixture>();
int mixOneNumber = GetRandom(barAlcohol.Count);
int mixTwoNumber = GetRandom(barAlcohol.Count);
barMixture.Add(new Mixture() 
{ 
    Name = $"Mixture of {barAlcohol[mixOneNumber].Name} and {barAlcohol[mixTwoNumber].Name}",
    Strengt = Convert.ToInt32((barAlcohol[mixOneNumber].Strengt + barAlcohol[mixTwoNumber].Strengt) / 2),
    Volume = Convert.ToInt32(barAlcohol[mixOneNumber].Volume + barAlcohol[mixTwoNumber].Volume),
    Ratio = Convert.ToInt32((Convert.ToInt32((barAlcohol[mixOneNumber].Strengt + barAlcohol[mixTwoNumber].Strengt) / 2) * Convert.ToInt32(barAlcohol[mixOneNumber].Volume + barAlcohol[mixTwoNumber].Volume)) / 1000 * (double)0.789)
});
Console.WriteLine($" Bartender make coctail \"{barMixture[barMixture.Count - 1].Name}\", with {barMixture[barMixture.Count - 1].Strengt} strenght and {barMixture[barMixture.Count - 1].Volume} volume. Alcohol unit in it - {barMixture[barMixture.Count - 1].Ratio}");
}

public static int GetRandom(int index)
{
    Random rnd = new Random();
    int value = rnd.Next(0, index);
    return value;
}
}
}
