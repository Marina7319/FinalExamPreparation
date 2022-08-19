using System;
using System.Collections.Generic;
namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            var city = new Dictionary<string, KeyValuePair<int, int>>();
            string input = Console.ReadLine();
            while (input != "Sail")
            {
                string[] cities = input.Split("||");
                string cityName = cities[0];
                int population = int.Parse(cities[1]);
                int gold = int.Parse(cities[2]);
                if (!city.ContainsKey(cityName))
                {
                    city.Add(cityName, new KeyValuePair<int, int>(population, gold));
                }
                else
                {
                    int sumPopulation = city[cityName].Key + population;
                    int sumGold = city[cityName].Value + gold;
                    city.Remove(cityName);
                    city.Add(cityName, new KeyValuePair<int, int>(sumPopulation, sumGold));
                }
                input = Console.ReadLine();
            }
            string inputLine = Console.ReadLine();
            while (inputLine != "End")
            {
                string[] events = inputLine.Split("=>");
                string token = events[0];
                switch (token)
                {
                    case "Plunder":
                        string currCity = events[1];
                        int currPeople = int.Parse(events[2]);
                        int currGold = int.Parse(events[3]);
                        if (city.ContainsKey(currCity))
                        {
                            int people = city[currCity].Key - currPeople;
                            int cityGold = city[currCity].Value - currGold;
                            city.Remove(currCity);
                            Console.WriteLine($"{currCity} plundered! {currGold} gold stolen, {currPeople} citizens killed.");
                            city.Add(currCity, new KeyValuePair<int, int>(people, cityGold));
                            if (people == 0 || cityGold == 0)
                            {
                                Console.WriteLine($"{currCity} has been wiped off the map!");
                                city.Remove(currCity);
                            }
                        }
                        break;
                    case "Prosper":
                        int givenAmoutOfGold = int.Parse(events[2]);
                        string town = events[1];
                        if (givenAmoutOfGold <= 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            int populationTown = city[town].Key;
                            int cityGold = city[town].Value + givenAmoutOfGold;
                            city.Remove(town);
                            Console.WriteLine($"{givenAmoutOfGold} gold added to the city treasury. {town} now has {cityGold} gold.");
                            city.Add(town, new KeyValuePair<int, int>(populationTown, cityGold));
                        }
                        break;
                }
                inputLine = Console.ReadLine();
            }
            Console.WriteLine($"Ahoy, Captain! There are {city.Count} wealthy settlements to go to:");
            foreach (var cities in city)
            {
                Console.WriteLine($"{cities.Key} -> Population: {cities.Value.Key} citizens, Gold: {cities.Value.Value} kg");
            }
        }
    }
}
