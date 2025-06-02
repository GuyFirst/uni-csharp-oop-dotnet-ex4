using Ex04.Menus.Events;
using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            //interfaces
            MenuManager menuManager = new MenuManager(buildMainMenu());
            menuManager.ShowMainMenu();

            //delegates
            Events.MainMenu mainMenuDelegates = buildEventsMenu();
            mainMenuDelegates.Show();
        }

        private static Interfaces.MainMenu buildMainMenu()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Interfaces Main Menu");

            Interfaces.MenuItem lettersAndVersion = new Interfaces.MenuItem("Letters and Version");
            lettersAndVersion.AddSubMenu(new Interfaces.MenuItem("Show Version", new ShowVersionHandler()));
            lettersAndVersion.AddSubMenu(new Interfaces.MenuItem("Count Lowercase Letters", new CountLowercaseHandler()));

            Interfaces.MenuItem dateAndTime = new Interfaces.MenuItem("Show Current Date/Time");
            dateAndTime.AddSubMenu(new Interfaces.MenuItem("Show Current Date", new ShowDateHandler()));
            dateAndTime.AddSubMenu(new Interfaces.MenuItem("Show Current Time", new ShowTimeHandler()));

            mainMenu.AddSubMenu(lettersAndVersion);
            mainMenu.AddSubMenu(dateAndTime);

            return mainMenu;
        }

        private static Events.MainMenu buildEventsMenu()
        {
            Events.MainMenu menu = new Events.MainMenu("Delegates Main Menu");
            MenuActions menuActions = new Events.MenuActions();
            Events.MenuItem lettersAndVersion = new Events.MenuItem("Letters and Version");
            Events.MenuItem showVersionItem = new Events.MenuItem("Show Version");
            showVersionItem.SelectedAction += menuActions.showVersion_SelectedAction;
            lettersAndVersion.AddSubItem(showVersionItem);

            Events.MenuItem countLowercaseItem = new Events.MenuItem("Count Lowercase Letters");
            countLowercaseItem.SelectedAction += menuActions.CountLowercaseLetters_SelectedAction;
            lettersAndVersion.AddSubItem(countLowercaseItem);

            Events.MenuItem dateTime = new Events.MenuItem("Show Current Date/Time");
            Events.MenuItem showDateItem = new Events.MenuItem("Show Current Date");
            showDateItem.SelectedAction += menuActions.ShowDate_SelectedAction;
            dateTime.AddSubItem(showDateItem);

            Events.MenuItem showTimeItem = new Events.MenuItem("Show Current Time");
            showTimeItem.SelectedAction += menuActions.ShowTime_SelectedAction;
            dateTime.AddSubItem(showTimeItem);

            menu.AddSubItem(lettersAndVersion);
            menu.AddSubItem(dateTime);

            return menu;
        }
    }
}