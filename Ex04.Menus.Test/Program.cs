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

            // Letters and Version submenu
            Events.MenuItem lettersAndVersion = new Events.MenuItem("Letters and Version");
            lettersAndVersion.AddSubItem(new Events.MenuItem("Show Version", Events.MenuActions.ShowVersion));
            lettersAndVersion.AddSubItem(new Events.MenuItem("Count Lowercase Letters", Events.MenuActions.CountLowercaseLetters));
            // Date and Time submenu
            Events.MenuItem dateTime = new Events.MenuItem("Show Current Date/Time");
            dateTime.AddSubItem(new Events.MenuItem("Show Current Time", Events.MenuActions.ShowTime));
            dateTime.AddSubItem(new Events.MenuItem("Show Current Date", Events.MenuActions.ShowDate));
            menu.AddSubItem(lettersAndVersion);
            menu.AddSubItem(dateTime);

            return menu;
        }
    }
}