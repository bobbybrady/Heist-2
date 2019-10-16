using System;

namespace heist2
{
    public class Hacker : IRobber
    {
        public string name { get; set; }
        public string specialty { get; } = "Hacker";
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore = bank.AlarmScore - SkillLevel;
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{name} has disabled the alarm system!");
            }
            else
            {
                Console.WriteLine($"{name} is hacking the alarm system. Decreased security {SkillLevel} points");
            }
        }
    }
}