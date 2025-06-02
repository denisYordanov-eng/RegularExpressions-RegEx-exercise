using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01_ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"(?<=\s)([a-z0-9])+([\.\-]\w*)*@([a-z])+([\.\-]\w*)*(\.[a-z]+)");

            string inputText = Console.ReadLine();
            var emailMatches = regex.Matches(inputText);

            foreach (Match email in emailMatches)
            {
                Console.WriteLine(email);
            }
        }
    }
}
