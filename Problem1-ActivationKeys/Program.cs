using System;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Generate")
            {
                string[] command = input.Split(">>>");
                string tokens = command[0];
                switch (tokens)
                {
                    case "Contains":
                        string substring = command[1];
                        if (rawActivationKey.Contains(substring))
                        {
                            Console.WriteLine($"{rawActivationKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string letters = command[1];
                        int startIndex = int.Parse(command[2]);
                        int endIndex = int.Parse(command[3]);
                        string result = "";
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            result += rawActivationKey[i].ToString();
                        }
                        if (letters == "Upper")
                        {
                            rawActivationKey = rawActivationKey.Insert(startIndex, result.ToUpper());
                        }
                        else
                        {
                            rawActivationKey = rawActivationKey.Insert(startIndex, result.ToLower());
                        }
                        rawActivationKey = rawActivationKey.Remove(endIndex, result.Length);
                        Console.WriteLine(rawActivationKey);
                        break;
                    case "Slice":
                        int startNum = int.Parse(command[1]);
                        int endNum = int.Parse(command[2]);
                        rawActivationKey = rawActivationKey.Remove(startNum, endNum - startNum);
                        Console.WriteLine(rawActivationKey);
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Your activation key is: " + rawActivationKey);
        }
    }
}
