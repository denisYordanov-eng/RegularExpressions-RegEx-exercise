using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_QueryMess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<key>[^&=?]+)=(?<value>[^&=?]+)";// regex matche patern/
            string regexReplacePatern = @"(\+|%20)"; // regex replace patern.
            string line = Console.ReadLine(); // reading inputLine.
            while (line != "END") //make a while loop 
            {
                Dictionary<string,List<string>>dict = new Dictionary<string,List<string>>(); // make a dictionary.
                
                var matches = Regex.Matches(line, regex); // check are there any matches.
                foreach ( Match match in matches )  // make a foreach through the matches.
                {
                    string key = match.Groups["key"].Value;  // make  the key.
                    string value = match.Groups["value"].Value; // make the value.

                    key = Regex.Replace(key, regexReplacePatern, " ").Trim(); // replace and trim the key.
                    key = Regex.Replace(key, @"\s+", " ");
                    value = Regex.Replace(value, regexReplacePatern, " ").Trim();// replace and trim the key.
                    value = Regex.Replace(value, @"\s+", " ");
                    if (!dict.ContainsKey(key)) // check if dict contains the key 
                    {
                        dict[key] = new List<string>();   // make a new list of the new key.
                    }
                    dict[key].Add(value); // add value
                }
                
                foreach (var item in dict) // go through the dict kvp
                {
                    Console.Write($"{item.Key}=[{String.Join(", ", item.Value)}]"); // write on the console the key and the values.
                }
                Console.WriteLine(); // make a new line.
                line = Console.ReadLine(); // read new inputLine.
            }

        }
    }
}
