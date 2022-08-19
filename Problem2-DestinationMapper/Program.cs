using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string firstPattern = @"[=](?<first>[A-Z]+[A-z][A-z][A-z]+)[=]";
            string secondPatterm = @"[/](?<second>[A-Z]+[A-z][A-z][A-z]+)[/]";
            List<string> city = new List<string>();
            Regex regexFirst = new Regex(firstPattern);
            MatchCollection matchesFromRegexFirst = regexFirst.Matches(input);
            int sum = 0;
            foreach (Match match in matchesFromRegexFirst)
            {
                var first = match.Groups["first"].Value;
                if (!city.Contains(first))
                {
                    city.Add(first);
                    sum += first.Length;
                }
            }

            Regex regexSecond = new Regex(secondPatterm);
            MatchCollection matchesFromRegexecond = regexSecond.Matches(input);
            foreach (Match match in matchesFromRegexecond)
            {
                var second = match.Groups["second"].Value;
                if (!city.Contains(second))
                {
                    city.Add(second);
                    sum += second.Length;
                }
            }
            Console.Write("Destinations: ");
            Console.WriteLine(string.Join(", ", city));
            Console.WriteLine("Travel Points: " + sum);
        }
    }
}
