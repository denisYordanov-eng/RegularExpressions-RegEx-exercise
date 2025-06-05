using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06_ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // “, “/”, “\”, “(“, “)”.
            var splittingPatern = @"[\s+,\/\\()]+";

            string validUsernamePatern = @"(^[A-Za-z][A-Za-z0-9_]{2,24}$)";

            string input = Console.ReadLine();

            var usernames = Regex.Split(input, splittingPatern).Where(u => u.Length > 0);


            List<string> validUsers = new List<string>();

            foreach (var user in usernames)
            {
                if (Regex.IsMatch(user, validUsernamePatern))
                {
                    validUsers.Add(user);
                }
            }
            StringBuilder sb = new StringBuilder();
            string user1 = String.Empty;
            string user2 = String.Empty;
            int BiggestSum = 0;
            for (int i = 0; i < validUsers.Count-1; i++) 
            {
                int currentSum = validUsers[i].Length + validUsers[i + 1].Length;
                if (currentSum > BiggestSum)
                {
                    BiggestSum = currentSum;
                    user1 = validUsers[i];
                    user2 = validUsers[i + 1];
                } 
            }
            sb.AppendLine(user1);
            sb.AppendLine(user2);
            Console.WriteLine($"{sb.ToString()}");
        }
    }
}
