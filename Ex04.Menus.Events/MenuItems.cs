using System;
using System.Text;

namespace Ex04.Menus.Events
{
    public class MenuActions
    {
        private const string k_AppVersion = "25.2.4.4480";
        public static void ShowVersion()
        {
            Console.WriteLine($"App Version: {k_AppVersion}");
        }

        public static void CountLowercaseLetters()
        {
            Console.Write("Enter a sentence: ");
            string userInput = Console.ReadLine();
            int numberOfLowercasedLetters = 0;

            if(userInput != null)
            {
                foreach(char c in userInput)
                {
                    if(char.IsLower(c))
                    {
                        numberOfLowercasedLetters++;
                    }
                }
            }

            string letterSuffix = ("letter" + (numberOfLowercasedLetters != 1 ? "s" : ""));
            Console.WriteLine($"There are {numberOfLowercasedLetters} lowercase {letterSuffix} in your text.");
        }

        public static void ShowTime()
        {
            Console.WriteLine($"Current Time is {DateTime.Now:HH:mm}");
        }

        public static void ShowDate()
        {
            Console.WriteLine($"Today's date is {DateTime.Now:dd/MM/yyyy}");
        }
    }
}