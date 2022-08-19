using System;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();
            string result = string.Empty;
            while (input != "Reveal")
            {
                string[] command = input.Split(":|:");
                string tokens = command[0];
                switch (tokens)
                {
                    case "InsertSpace":
                        int index = int.Parse(command[1]);
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        string substring = command[1];
                        int startIndex = message.IndexOf(substring);
                        if (message.Contains(substring))
                        {
                            for (int i = substring.Length - 1; i >= 0; i--)
                            {
                                result += substring[i];
                            }
                            message = message.Insert(message.Length, result);
                            message = message.Remove(startIndex, substring.Length);
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        string inputSubstring = command[1];
                        string replacementText = command[2];
                        if (message.Contains(inputSubstring))
                        {
                            message = message.Replace(inputSubstring, replacementText);
                        }
                        Console.WriteLine(message);
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
