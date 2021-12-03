using System;
using System.Collections.Generic;
using System.Linq;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Muscle muscle1 = new Muscle()
            {
                Name = "Danny Ocean",
                SkillLevel = 50,
                PercentageCut = 10
            };
            Muscle muscle2 = new Muscle()
            {
                Name = "Rusty Ryan",
                SkillLevel = 50,
                PercentageCut = 10
            };
            Hacker hacker1 = new Hacker()
            {
                Name = "Linus Caldwell",
                SkillLevel = 50,
                PercentageCut = 10
            };
            Hacker hacker2 = new Hacker()
            {
                Name = "Basher Tarr",
                SkillLevel = 50,
                PercentageCut = 10
            };
            LockSpecialists lock1 = new LockSpecialists()
            {
                Name = "Virgil Malloy",
                SkillLevel = 50,
                PercentageCut = 10
            };
            LockSpecialists lock2 = new LockSpecialists()
            {
                Name = "'The Amazing' Yen",
                SkillLevel = 50,
                PercentageCut = 10
            };

            List<IRobber> rolodex = new List<IRobber> {
                muscle1,
                muscle2,
                hacker1,
                hacker2,
                lock1,
                lock2
            };

            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($"{robber.Name}");
            }


            Console.Write("Enter new crew member name: ");
            string crewMember = Console.ReadLine();

            while (crewMember != "")
            {

                Console.WriteLine();

                Console.Write($"Enter a specialty for {crewMember} (Hacker, Lock Specialist, Muscle): ");
                string specialty = Console.ReadLine();

                Console.WriteLine();

                Console.Write($"Enter the skill level for {crewMember} (1-100): ");
                int skillLevel = Int32.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.Write($"Enter the percentage of the cut {crewMember} will get: ");
                int cutPer = Int32.Parse(Console.ReadLine());

                switch (specialty)
                {
                    case "Hacker":
                        rolodex.Add(new Hacker()
                        {
                            Name = crewMember,
                            SkillLevel = skillLevel,
                            PercentageCut = cutPer
                        });
                        break;
                    case "Muscle":
                        rolodex.Add(new Muscle()
                        {
                            Name = crewMember,
                            SkillLevel = skillLevel,
                            PercentageCut = cutPer
                        });
                        break;
                    case "Lock Specialist":
                        rolodex.Add(new LockSpecialists()
                        {
                            Name = crewMember,
                            SkillLevel = skillLevel,
                            PercentageCut = cutPer
                        });
                        break;
                }

                foreach (IRobber robber in rolodex)
                {
                    Console.WriteLine($"{robber.Name}");
                }

                Console.WriteLine();

                Console.Write("Enter new crew member name: ");
                crewMember = Console.ReadLine();
            }

            Random randInt = new Random();

            Bank bank1 = new Bank()
            {
                AlarmScore = randInt.Next(0, 100),
                VaultScore = randInt.Next(0, 100),
                SecurityGuardScore = randInt.Next(0, 100),
                CashOnHand = randInt.Next(50000, 1000000)
            };
            Dictionary<string, int> systemList = new Dictionary<string, int>(){
               {"Alarm", bank1.AlarmScore},
               {"Vault", bank1.VaultScore},
               {"Secuirty Guard", bank1.SecurityGuardScore}
           };

            var sortedDict = from entry in systemList orderby entry.Value ascending select entry;

            Console.WriteLine($"Least Secure: {systemList.ElementAt(0).Key}");
            Console.WriteLine($"Most Secure: {systemList.ElementAt(2).Key}");

            for (int i = 0; i < rolodex.Count; i++)
            {
                Console.WriteLine($"{i}. {rolodex[i].Name}:  {rolodex[i].SkillLevel} {rolodex[i].PercentageCut}%");
                Console.WriteLine($"    Speciality: {rolodex[i].GetType().ToString().Split('.')[1]}");
                Console.WriteLine($"    Skill Level: {rolodex[i].SkillLevel}");
                Console.WriteLine($"    Skill Level: {rolodex[i].PercentageCut}%");
            }
            List<IRobber> crew = new List<IRobber>();
            string output = "value";
            while (output != "")
            {
                Console.Write("Enter the number of the operative you want to include in the heist:");
                output = Console.ReadLine();
                if (output == "")
                {
                    continue;
                }
                int num = int.Parse(output);
                List<IRobber> filtered = rolodex.Where(r => !crew.Contains(r) && r.PercentageCut < 100 - crew.Select(s => s.PercentageCut).Sum()).ToList();
                if (filtered.Contains(rolodex[num]))
                {
                    crew.Add(rolodex[num]);
                    Console.WriteLine("Operative successfully added!");
                }
                else
                {
                    Console.WriteLine("Operative is already included.");

                }
            }
            foreach (IRobber robber in crew)
            {
                robber.PerformSkill(bank1);
            };
            if (bank1.isSecure)
            {
                Console.WriteLine("Bank is secure.");

                double crewTake = bank1.CashOnHand;
            }
            else
            {
                Console.WriteLine("Bank is not secure.");
                foreach (IRobber robber in crew)
                {
                    Console.WriteLine($"{robber.Name} gets ${(robber.PercentageCut * .01) * bank1.CashOnHand}");
                }
            }
        }
    }
}