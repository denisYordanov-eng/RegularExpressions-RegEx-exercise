using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05_KeyReplacer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regexSplitter = @"([\<\|\\])(?<=.*)";
            string keyStrings = Console.ReadLine();
    
            var keys = Regex.Split(keyStrings, regexSplitter);

            var startKey = keys.First();
            var endKey = keys.Last();

           string text = Console.ReadLine();
            string regex = $@"(?<start>{Regex.Escape(startKey)})(?<word>.*?)(?<end>{Regex.Escape(endKey)})";
           // string regex = $@"(?<start>{startKey})(?<word>.*?)(?<end>{endKey})";

            var words = Regex.Matches(text, regex);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (Match word in words)
            {
                if (word.Success)
                {
                    string wordToAppend = word.Groups["word"].Value;
                    stringBuilder.Append(wordToAppend);
                   
                }
            }
            if (stringBuilder.Length > 0)
            {
                Console.WriteLine(stringBuilder.ToString());
            }
            else
            {
                Console.WriteLine("Empty result");
            }
        }
    }
}
