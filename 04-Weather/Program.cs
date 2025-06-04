using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_Weather
{
    class WeatherInfo
    {
        public double AverageTemp { get; set; }
        public string Weather { get; set; }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
           
            var regex = 
                new Regex(@"(?<city>[A-Z]{2})(?<temperature>\d{2}\.\d+)(?<weather>[a-zA-Z]+)\|"); // make a regex patern.

            var cities = new Dictionary<string, WeatherInfo>(); //make a dictionary to hold the information in it.

            var line = Console.ReadLine(); // reading the input from the console.

            while (line != "end") // make a while loop.
            {
                var weatherMatch = regex.Match(line); // make a regex match using line and partern.
                if(!weatherMatch.Success) // check if the input match the regex patern.
                {
                    line = Console.ReadLine();
                    continue;
                }
                var city = weatherMatch.Groups["city"].Value; //take the city from the input.
                var averageTemp =
                    double.Parse(weatherMatch.Groups["temperature"].Value); // take the  temperature from the input.
                var weatherType = weatherMatch.Groups["weather"].Value;// take the weather type from the input.

                var weatherInfo = new WeatherInfo() // make a new object.
                {
                    AverageTemp = averageTemp,
                    Weather = weatherType,
                };
                cities[city] = weatherInfo; // add to the dictionary with the option of rewrite the values.

               line = Console.ReadLine(); // read new input.
            }
            var sortedCities = cities
                .OrderBy(t => t.Value.AverageTemp)
                .ToDictionary(a => a.Key, a => a.Value); // sort the dictionary.

            foreach (var cityInfo in sortedCities)
            {
                var city = cityInfo.Key; // make a variable for the key.
                var weatherInfo = cityInfo.Value; // make a variable for the value.

                Console.WriteLine($"{city} => {weatherInfo.AverageTemp:F2} => {weatherInfo.Weather}"); // print the output.
            }
        }
    }
}
