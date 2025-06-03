using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace _02_ExtractSentencesByKeyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputWord = Console.ReadLine(); //Read matching word
            string text = Console.ReadLine(); // read text.

            string sepatators = @"[\.!\?]"; // make regex separatos.

            var splitedSenteces = Regex.Split(text, sepatators);// split text into senteces using separators.
            string wordToMatch = $@"\b{Regex.Escape(inputWord)}\b";// make sure matching only word

          
           

            foreach (string match in splitedSenteces) // go through the separated sentences.
            {
                if (Regex.IsMatch(match, wordToMatch))  // if you find a match.
                {
                    Console.WriteLine(match.TrimEnd()); // print the match.
                } 
            }

        }
    }
}
