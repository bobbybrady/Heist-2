using System;

namespace heist2
{
    public class Muscle : IRobber
    {
        public string name { get; set; }
        public string specialty {get;} = "Muscle";
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{name} has disabled the security guards!");
            }
            else
            {
                Console.WriteLine($"{name} is beating the security guards. Decreased security {SkillLevel} points");
            }
        }
    }
}