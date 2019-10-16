using System;
using System.Collections.Generic;

namespace heist2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hacker will = new Hacker()
            {
                name = "Will",
                SkillLevel = 50,
                PercentageCut = 15
            };
            Hacker noah = new Hacker()
            {
                name = "Noah",
                SkillLevel = 48,
                PercentageCut = 12
            };
            Muscle bobby = new Muscle()
            {
                name = "Bobby",
                SkillLevel = 12,
                PercentageCut = 7
            };
            Muscle liam = new Muscle()
            {
                name = "Liam Neeson",
                SkillLevel = 88,
                PercentageCut = 27
            };
            LockPickSpecialist ted = new LockPickSpecialist()
            {
                name = "Teddy Roosevelt",
                SkillLevel = 68,
                PercentageCut = 30
            };
            LockPickSpecialist grover = new LockPickSpecialist()
            {
                name = "Grover Cleveland",
                SkillLevel = 56,
                PercentageCut = 25
            };
            List<IRobber> rolodex = new List<IRobber>() {
                will, noah, bobby, liam, ted, grover
            };
            Console.WriteLine("WELCOME TO HEIST 2");
            Console.WriteLine("------------------");
            Console.WriteLine($"Number of Operatives in the Rolodex: {rolodex.Count}");
            Console.WriteLine("");

            Console.WriteLine("Create a New Operative");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            while (name != "")
            {
                Console.WriteLine("Choose a Specialty");
                Console.WriteLine("");
                Console.WriteLine("- Hacker (Disables alarms)");
                Console.WriteLine("- Muscle (Disarms guards)");
                Console.WriteLine("- Lock Specialist (cracks vault)");
                Console.WriteLine("");
                Console.Write("Specialty: ");
                string specialty = Console.ReadLine();
                while (specialty.ToLower() != "")
                {
                    if (specialty.ToLower() == "hacker")
                    {
                        break;
                    }
                    else if (specialty.ToLower() == "muscle")
                    {
                        break;
                    }
                    else if (specialty.ToLower() == "lock specialist")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid specialty!");
                        Console.Write("Specialty: ");
                        specialty = Console.ReadLine();
                    }
                }
                Console.WriteLine("");
                Console.Write("Enter a Skill Level (Between 1-100): ");
                int skillLevel = int.Parse(Console.ReadLine());

                Console.WriteLine("");
                Console.Write("Enter the operatives cut of the heist(Between 1-100): ");
                int percentageCut = int.Parse(Console.ReadLine());

                if (specialty.ToLower() == "hacker")
                {
                    Hacker newHacker = new Hacker()
                    {
                        name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    };
                    rolodex.Add(newHacker);
                }
                if (specialty.ToLower() == "muscle")
                {
                    Muscle newMuscle = new Muscle()
                    {
                        name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    };
                    rolodex.Add(newMuscle);
                }
                if (specialty.ToLower() == "lock specialist")
                {
                    LockPickSpecialist newLockPickSpcialist = new LockPickSpecialist()
                    {
                        name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    };
                    rolodex.Add(newLockPickSpcialist);
                }

                Console.WriteLine("");
                Console.WriteLine("Create another operative (or press enter to continue)");
                Console.Write("Name: ");
                name = Console.ReadLine();
            }
            Random rnd = new Random();
            Bank HSBC = new Bank()
            {
                AlarmScore = rnd.Next(101),
                VaultScore = rnd.Next(101),
                SecurityGuardScore = rnd.Next(101),
                CashOnHand = rnd.Next(50_000, 1_000_001)
            };
            Console.WriteLine("");
            HSBC.FindSecurityLevel();
            Console.WriteLine("");
            Console.WriteLine("Pick Your team");
            for (int i = 0; i < rolodex.Count; i++)
            {
                Console.WriteLine("- - - - - - - - - -");
                Console.WriteLine($"Name: {rolodex[i].name}");
                Console.WriteLine($"Index: {i + 1}");
                Console.WriteLine($"Specialty: {rolodex[i].specialty}");
                Console.WriteLine($"Skill Level: {rolodex[i].SkillLevel}");
                Console.WriteLine($"Percentage Cut: {rolodex[i].PercentageCut}%");
            }

            Console.WriteLine("");
            List<IRobber> crew = new List<IRobber>();
            Console.Write("Add crew by Index: ");
            string addCrew = Console.ReadLine();
            int finalCut = 0;
            while (addCrew != "")
            {
                crew.Add(rolodex[int.Parse(addCrew) - 1]);
                Console.WriteLine("");
                Console.WriteLine($"{rolodex[int.Parse(addCrew) - 1].name} has been added!");
                Console.WriteLine("");
                finalCut += rolodex[int.Parse(addCrew) - 1].PercentageCut;
                Console.WriteLine($"------------------------------");
                Console.WriteLine($"Current Total Cut: {finalCut}%");
                Console.WriteLine($"------------------------------");
                rolodex.Remove(rolodex[int.Parse(addCrew) - 1]);
                Console.WriteLine("");
                Console.WriteLine("Pick Your team");
                for (int i = 0; i < rolodex.Count; i++)
                {
                    if ((finalCut + rolodex[i].PercentageCut) > 100)
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("- - - - - - - - - -");
                        Console.WriteLine($"Name: {rolodex[i].name}");
                        Console.WriteLine($"Index: {i + 1}");
                        Console.WriteLine($"Specialty: {rolodex[i].specialty}");
                        Console.WriteLine($"Skill Level: {rolodex[i].SkillLevel}");
                        Console.WriteLine($"Percentage Cut: {rolodex[i].PercentageCut}%");
                    }
                }
                Console.WriteLine("");
                Console.Write("Add more crew by Index: ");
                addCrew = Console.ReadLine();
            }
            foreach (IRobber robber in crew)
            {
                robber.PerformSkill(HSBC);
                Console.WriteLine("");
            }
            bool bankSecure = HSBC.IsSecure();
            if (bankSecure == true)
            {
                Console.WriteLine("- - - - - - - - - - - - - - - ");
                Console.WriteLine("The Heist was a SUCCESS!!!");
                Console.WriteLine($"Heist Profits: {HSBC.CashOnHand}");
                Console.WriteLine("- - - - - - - - - - - - - - - ");
                foreach (IRobber robber in crew)
                {
                    double cutPercentage = (robber.PercentageCut * .01);
                    double profit = (cutPercentage * HSBC.CashOnHand);
                    Console.WriteLine($"{robber.name} recieves ${Math.Round(profit, 2)} from the heist!");
                }
                double yourPercentage = (100 - finalCut);
                double yourProfit = ((yourPercentage * .01) * HSBC.CashOnHand);
                Console.WriteLine("- - - - - - - - - - - - - - -");
                Console.WriteLine($"Your total profit from the Heist ${Math.Round(yourProfit, 2)}");
            }
            else
            {
                Console.WriteLine("- - - - - - - - - - - - - - - ");
                Console.WriteLine("The Heist was a failure, you are a failure.");
                Console.WriteLine("- - - - - - - - - - - - - - - ");
            }
        }
    }
}
