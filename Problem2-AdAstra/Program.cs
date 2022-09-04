using System;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[#|](?<itemName>[A-z\s]+)*[#|](?<day>\d{2})/(?<month>\d{2})/(?<year>\d{2})*[#|](?<calories>\d+)*";
            string input = Console.ReadLine();
            Regex matches = new Regex(pattern);
            MatchCollection productList = Regex.Matches(input, pattern);
            double sumDays = 0;
            foreach (Match match in productList)
            {
                var calories = match.Groups["calories"].Value;
                double sumCalories = 0;
                sumCalories += double.Parse(calories);
                double days = sumCalories / 2000;
                sumDays += days;
            }
            double sumFood = Math.Floor(sumDays);
            Console.WriteLine($"You have food to last you for: {sumFood} days!");
            if (sumFood == 0)
            {

            }
            else
            {
                foreach (Match match in productList)
                {
                    var itemName = match.Groups["itemName"].Value;
                    var day = match.Groups["day"].Value;
                    var month = match.Groups["month"].Value;
                    var year = match.Groups["year"].Value;
                    var calories = match.Groups["calories"].Value;
                    if (int.Parse(day) <= 31 && int.Parse(month) <= 12 && int.Parse(calories) <= 10000 && int.Parse(day) > 0 && int.Parse(month) > 0)
                    {
                        Console.WriteLine($"Item: {itemName}, Best before: {day}/{month}/{year}, Nutrition: {calories}");
                    }
                }
            }
        }
    }
}

