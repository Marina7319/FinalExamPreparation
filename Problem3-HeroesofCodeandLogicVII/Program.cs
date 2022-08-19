using System;
using System.Collections.Generic;

namespace HeroesofCodeandLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            var heroes = new Dictionary<string, KeyValuePair<int, int>>();
            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroe = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = heroe[0];
                int HP = int.Parse(heroe[1]);
                int MP = int.Parse(heroe[2]);
                if (!heroes.ContainsKey(name))
                {
                    heroes.Add(name, new KeyValuePair<int, int>(HP, MP));
                }
                else
                {
                    int currentHP = heroes[name].Key + HP;
                    int currentMP = heroes[name].Value + MP;
                    heroes.Remove(name);
                    if (currentHP < 100 && currentMP < 200)
                    {
                        heroes.Add(name, new KeyValuePair<int, int>(currentHP, currentMP));
                    }
                    else if (currentHP < 100 && currentMP > 200)
                    {
                        heroes.Add(name, new KeyValuePair<int, int>(currentHP, 200));
                    }
                    else if (currentHP > 100 && currentMP < 200)
                    {
                        heroes.Add(name, new KeyValuePair<int, int>(100, currentMP));
                    }
                    else
                    {
                        heroes.Add(name, new KeyValuePair<int, int>(100, 200));
                    }
                }
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                switch (action)
                {
                    case "CastSpell":
                        int requeredMP = int.Parse(commands[2]);
                        string heroeName = commands[1];
                        string spellName = commands[3];
                        if (heroes.ContainsKey(heroeName))
                        {
                            if (heroes[heroeName].Value >= requeredMP)
                            {
                                int manaPointsLeft = heroes[heroeName].Value - requeredMP;
                                int HPOfHeroe = heroes[heroeName].Key;
                                heroes.Remove(heroeName);
                                Console.WriteLine($"{heroeName} has successfully cast {spellName} and now has {manaPointsLeft} MP!");
                                heroes.Add(heroeName, new KeyValuePair<int, int>(HPOfHeroe, manaPointsLeft));
                            }
                            else
                            {
                                Console.WriteLine($"{heroeName} does not have enough MP to cast {spellName}!");
                            }
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(commands[2]);
                        string heroe = commands[1];
                        string attacker = commands[3];
                        if (heroes.ContainsKey(heroe))
                        {
                            if (heroes[heroe].Key >= damage)
                            {
                                int hpLeft = heroes[heroe].Key - damage;
                                int MPOfHeroe = heroes[heroe].Value;
                                heroes.Remove(heroe);
                                Console.WriteLine($"{heroe} was hit for {damage} HP by {attacker} and now has {hpLeft} HP left!");
                                heroes.Add(heroe, new KeyValuePair<int, int>(hpLeft, MPOfHeroe));
                            }
                            else
                            {
                                heroes.Remove(heroe);
                                Console.WriteLine($"{heroe} has been killed by {attacker}!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{heroe} has been killed by {attacker}!");
                        }
                        break;
                    case "Recharge":
                        int amount = int.Parse(commands[2]);
                        string rechargeHeroeName = commands[1];
                        if (heroes.ContainsKey(rechargeHeroeName))
                        {
                            int result = 0;
                            int amountRecovered = heroes[rechargeHeroeName].Value + amount;
                            int currentHP = heroes[rechargeHeroeName].Key;
                            if (amountRecovered > 200)
                            {
                                result = 200 - heroes[rechargeHeroeName].Value;
                                amountRecovered = 200;
                            }
                            else
                            {
                                result = amount;
                            }
                            heroes.Remove(rechargeHeroeName);
                            Console.WriteLine($"{rechargeHeroeName} recharged for {result} MP!");
                            heroes.Add(rechargeHeroeName, new KeyValuePair<int, int>(currentHP, amountRecovered));
                        }
                        break;
                    case "Heal":
                        int amountHP = int.Parse(commands[2]);
                        string healHeroesHP = commands[1];
                        if (heroes.ContainsKey(healHeroesHP))
                        {
                            int amountRecoveredHP = heroes[healHeroesHP].Key + amountHP;
                            int sumRecovered = 0;
                            if (amountRecoveredHP > 100)
                            {
                                sumRecovered = 100 - heroes[healHeroesHP].Key;
                                amountRecoveredHP = 100;
                            }
                            else
                            {
                                sumRecovered = amountHP;
                            }
                            int currentMP = heroes[healHeroesHP].Value;
                            heroes.Remove(healHeroesHP);
                            Console.WriteLine($"{healHeroesHP} healed for {sumRecovered} HP!");
                            heroes.Add(healHeroesHP, new KeyValuePair<int, int>(amountRecoveredHP, currentMP));
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            foreach (var heroe in heroes)
            {
                Console.WriteLine($"{heroe.Key}");
                Console.WriteLine($" HP: {heroe.Value.Key}");
                Console.WriteLine($" MP: {heroe.Value.Value}");
            }
        }
    }
}
