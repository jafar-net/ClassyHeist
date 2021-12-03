using System;

namespace heist
{

    public class Hacker : IRobber
    {
        public string Name { get; set; }

        public int SkillLevel { get; set; }

        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;

            Console.WriteLine($"{Name} is hacking into the alarm system. Decreasing it's security by {SkillLevel} points");

            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm!");
            }
        }
    }
}