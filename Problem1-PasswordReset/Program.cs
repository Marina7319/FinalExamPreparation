using System;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            int passwordLength = password.Length;
            string input = Console.ReadLine();
            while (input != "Done")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string tokens = commands[0];
                switch (tokens)
                {
                    case "TakeOdd":
                        string oddLetters = "";
                        for (int i = 0; i < passwordLength; i++)
                        {
                            if (i % 2 != 0)
                            {
                                oddLetters += password[i];
                            }
                        }
                        password = password.Replace(password, oddLetters);
                        passwordLength = password.Length;
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int startIndex = int.Parse(commands[1]);
                        password = password.Remove(startIndex, int.Parse(commands[2]));
                        passwordLength = password.Length;
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string substring = commands[1];
                        string replaceSubstring = commands[2];
                        passwordLength = password.Length;
                        if (password.Contains(substring))
                        {
                            password = password.Replace(substring, replaceSubstring);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
