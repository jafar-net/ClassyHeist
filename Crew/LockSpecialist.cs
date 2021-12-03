using System;

namespace heist
{

    public class LockSpecialists : IRobber
    {
        public string Name { get; set; }

        public int SkillLevel { get; set; }

        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;

            Console.WriteLine($"{Name} is cracking the vault! Decreasing it's security by {SkillLevel} points");

            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has opened the vault!");
            }
        }
    }
}