using System;
using Ex04.Menus.Interface;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            MenuManager menuManager = new MenuManager(BuildMainMenu());
            menuManager.ShowMainMenu();
        }

        private static MainMenu BuildMainMenu()
        {
            MainMenu mainMenu = new MainMenu("Main Menu");

            MenuItem lettersAndVersion = new MenuItem("Letters and Version");
            lettersAndVersion.AddSubMenu(new MenuItem("Show Version", new ShowVersionHandler()));
            lettersAndVersion.AddSubMenu(new MenuItem("Count Lowercase Letters", new CountLowercaseHandler()));

            MenuItem dateAndTime = new MenuItem("Show Current Date/Time");
            dateAndTime.AddSubMenu(new MenuItem("Show Current Date", new ShowDateHandler()));
            dateAndTime.AddSubMenu(new MenuItem("Show Current Time", new ShowTimeHandler()));

            mainMenu.AddSubMenu(lettersAndVersion);
            mainMenu.AddSubMenu(dateAndTime);

            return mainMenu;
        }
    }
}