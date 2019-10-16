using System;
using System.Collections.Generic;
using System.Linq;

namespace heist2
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public bool IsSecure()
        {
            if (AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void FindSecurityLevel()
        {
            List<KeyValuePair<string, int>> originalList = new List<KeyValuePair<string, int>>();
            KeyValuePair<string, int> alarm = new KeyValuePair<string, int>( "Alarm Score", AlarmScore  );
            KeyValuePair<string, int> vault = new KeyValuePair<string, int>("Vault Score", VaultScore);
            KeyValuePair<string, int> security = new KeyValuePair<string, int>("Security Guard Score", SecurityGuardScore);
            originalList.Add(alarm);
            originalList.Add(vault);
            originalList.Add(security);
            var orderedList = originalList.OrderByDescending(item => item.Value);
            Console.WriteLine($"Most Secure: {orderedList.First().Key}");
            Console.WriteLine($"Least Secure: {orderedList.Last().Key}");
        }
    }
}