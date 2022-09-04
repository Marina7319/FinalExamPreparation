using System;
using System.Collections.Generic;
namespace NeedforSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            var cars = new Dictionary<string, KeyValuePair<int, int>>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carsMileageFuel = Console.ReadLine().Split("|");
                string car = carsMileageFuel[0];
                int mileage = int.Parse(carsMileageFuel[1]);
                int fuel = int.Parse(carsMileageFuel[2]);
                if (!cars.ContainsKey(car))
                {
                    cars.Add(car, new KeyValuePair<int, int>(mileage, fuel));
                }
            }
            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] commands = input.Split(" : ");
                string command = commands[0];
                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(commands[2]);
                        string car = commands[1];
                        int fuel = int.Parse(commands[3]);
                        int forOneMileage = distance / fuel;
                        if (cars.ContainsKey(car))
                        {
                            if (cars[car].Value >= fuel)
                            {
                                int currDistance = distance + cars[car].Key;
                                int currFuel = cars[car].Value - fuel;
                                cars.Remove(car);
                                cars.Add(car, new KeyValuePair<int, int>(currDistance, currFuel));
                                Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                            }
                            else
                            {
                                Console.WriteLine($"Not enough fuel to make that ride");
                            }
                            if(cars[car].Key >= 100000)
                            {
                                cars.Remove(car);
                                Console.WriteLine($"Time to sell the {car}!");
                            }
                        }
                        break;
                    case "Refuel":
                        string currCar = commands[1];
                        int refillFuel = int.Parse(commands[2]);
                        int distanceOfCar = cars[currCar].Key;
                        int sumFuel = refillFuel + cars[currCar].Value;
                        int sumRefillFuel = 0;
                        if(sumFuel > 75)
                        {
                            sumFuel = 75;
                            sumRefillFuel = 75 - cars[currCar].Value;
                        }
                        else
                        {
                            sumRefillFuel = refillFuel;
                        }
                        Console.WriteLine($"{currCar} refueled with {sumRefillFuel} liters");
                        if (cars.ContainsKey(currCar))
                        {
                            cars.Remove(currCar);
                            cars.Add(currCar, new KeyValuePair<int, int>(distanceOfCar, sumFuel));
                        }
                        break;
                    case "Revert":
                        string givenCar = commands[1];
                        int givenKilometers = int.Parse(commands[2]);
                        if (cars.ContainsKey(givenCar))
                        {
                            int currKilometers = cars[givenCar].Key - givenKilometers;
                            int currFuelAmount = cars[givenCar].Value;
                            cars.Remove(givenCar);
                            if (currKilometers > 10000)
                            {
                                cars.Add(givenCar, new KeyValuePair<int, int>(currKilometers, currFuelAmount));
                                Console.WriteLine($"{givenCar} mileage decreased by {givenKilometers} kilometers");
                            }
                            else
                            {
                                cars.Add(givenCar, new KeyValuePair<int, int>(10000, currFuelAmount));
                            }
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Key} kms, Fuel in the tank: {car.Value.Value} lt.");
            }
        }
    }
}
