using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08_UseYourChainsBuddy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ParagraphRegex = new Regex(@"(<p>)(?<input>.+?)(<\/p>)");

            var inputText = Console.ReadLine();
            var paragraphs = ParagraphRegex.Matches(inputText)
                .Cast<Match>()
                .Select(a => a.Groups["input"].Value)
                .Select(a => Regex.Replace(a, @"[^a-z\d]", " "))
                .Select(a => Regex.Replace(a, @"\s+", " "))
                .ToArray();

            for (int i = 0; i < paragraphs.Length; i++)
            {
                paragraphs[i] = Rot13String(paragraphs[i]);
            }
            var result = new StringBuilder();
            foreach (var paragraph in paragraphs)
            {
                result.Append(paragraph);
            }
            Console.WriteLine(result.ToString());
        }

        private static string Rot13String(string input)
        {
            var result = new StringBuilder();
            foreach (var letter in input)
            {
                result.Append(Rot13(letter));
            }
            return result.ToString();
        }

        private static char Rot13(char letter)
        {
            if (!char.IsLetter(letter)) 
            {
                return letter;
            }
            var offset = char.IsUpper(letter)? 'A':'a';
            char rotatedLetter = (char)(((letter - offset) + 13) % 26 + offset);
            return (char)rotatedLetter;
        }
    }
}