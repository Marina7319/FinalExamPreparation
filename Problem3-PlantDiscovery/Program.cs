using System;
using System.Collections.Generic;

namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var plant = new Dictionary<string, int>();
            var plantRating = new Dictionary<string, List<int>>();
            for (int i = 0; i < n; i++)
            {
                string[] plants = Console.ReadLine().Split("<->");
                string plantName = plants[0];
                int rarity = int.Parse(plants[1]);
                if (!plant.ContainsKey(plantName))
                {
                    plant.Add(plantName, rarity);
                    plantRating.Add(plantName, new List<int>());
                }
                plant[plantName] = rarity;
            }
            string input = Console.ReadLine();
            while (input != "Exhibition")
            {
                string[] commands = input.Split(": ");
                string tokens = commands[0];
                switch (tokens)
                {
                    case "Reset":
                        if (plantRating.ContainsKey(commands[1]))
                        {
                            plantRating[commands[1]].Add(0);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Rate":
                        string[] rate = commands[1].Split(" - ");
                        if (plantRating.ContainsKey(rate[0]))
                        {
                            plantRating[rate[0]].Add(int.Parse(rate[1]));
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update":
                        string[] updatePlant = commands[1].Split(" - ");
                        string currPlant = updatePlant[0];
                        int updateRarity = int.Parse(updatePlant[1]);
                        if (plant.ContainsKey(currPlant))
                        {
                            plant[currPlant] = updateRarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var plants in plant)
            {
                Console.Write($"- {plants.Key}; Rarity: {plants.Value}; ");
                double avgRating = 0;
                foreach (var x in plantRating)
                {
                    if (plants.Key == x.Key)
                    {
                        foreach (var nums in x.Value)
                        {
                            if (nums != 0)
                            {
                                avgRating += nums;
                            }
                            else
                            {
                                avgRating = 0;
                                break;
                            }
                        }
                        int numberCount = x.Value.Count;
                        double averageSum = avgRating / numberCount; 
                        Console.WriteLine($"Rating: {averageSum:f2}");
                    }
                }
            }
        }
    }
}
