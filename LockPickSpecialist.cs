using System;

namespace heist2
{
    public class LockPickSpecialist : IRobber
    {
        public string name { get; set; }
        public string specialty {get;} = "Lock Pick Specialist";
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.VaultScore = bank.VaultScore - SkillLevel;
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{name} has disabled the vault system!");
            }
            else
            {
                Console.WriteLine($"{name} is picking the vault system. Decreased security {SkillLevel} points");
            }
        }
    }
}