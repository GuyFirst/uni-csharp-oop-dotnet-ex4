using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class CountLowercaseHandler : IMenuItemNotifier
    {
        public void OnSelected()
        {
            Console.Write("Please enter a sentence: ");
            string userInput = Console.ReadLine();
            int lowercaseCount = 0;

            foreach (char character in userInput)
            {
                if (char.IsLower(character))
                {
                    lowercaseCount++;
                }
            }

            Console.WriteLine("There are {0} lowercase letters.", lowercaseCount);
        }
    }
}