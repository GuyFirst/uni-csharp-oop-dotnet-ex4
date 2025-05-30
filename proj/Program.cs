using System;
using Ex04.Menus.Interface;
using System.Collections.Generic;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            
            MainMenu mainMenu = new MainMenu("Main Menu");

            MenuItem lettersAndVersion = new MenuItem("Letters and Version");
            lettersAndVersion.AddSubMenu(new MenuItem("Show Version", new ShowVersionNotifier()));
            lettersAndVersion.AddSubMenu(new MenuItem("Count Lowercase Letters", new CountLowercaseNotifier()));

            MenuItem dateAndTime = new MenuItem("Show Current Date/Time");
            dateAndTime.AddSubMenu(new MenuItem("Show Current Date", new ShowDateNotifier()));
            dateAndTime.AddSubMenu(new MenuItem("Show Current Time", new ShowTimeNotifier()));

            mainMenu.AddSubMenu(lettersAndVersion);
            mainMenu.AddSubMenu(dateAndTime);

            mainMenu.Show();
        }
    }

    public class ShowVersionNotifier : IMenuItemNotifier
    {
        public void Execute()
        {
            Console.WriteLine("App Version: 25.2.4.4480");
        }
    }

    public class CountLowercaseNotifier : IMenuItemNotifier
    {
        public void Execute()
        {
            Console.Write("Please enter a sentence: ");
            string input = Console.ReadLine();
            int count = 0;

            foreach (char c in input)
            {
                if (char.IsLower(c))
                {
                    count++;
                }
            }

            Console.WriteLine("There are {0} lowercase letters.", count);
        }
    }

    public class ShowDateNotifier : IMenuItemNotifier
    {
        public void Execute()
        {
            Console.WriteLine("Current Date is: {0}", DateTime.Now.ToShortDateString());
        }
    }

    public class ShowTimeNotifier : IMenuItemNotifier
    {
        public void Execute()
        {
            Console.WriteLine("Current Time is: {0}", DateTime.Now.ToShortTimeString());
        }
    }
}
