using System;

namespace heist
{

    public class Muscle : IRobber
    {
        public string Name { get; set; }

        public int SkillLevel { get; set; }

        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;

            Console.WriteLine($"{Name} is beating up the guards! Decreasing it's security by {SkillLevel} points");

            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has incapacitated the guards!");
            }
        }
    }
}