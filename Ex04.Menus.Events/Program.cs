namespace Ex04.Menus.Events
{
    internal class Program
    {
        static void Main()
        {
            MainMenu mainMenu = buildEventsMenu();
            mainMenu.Show();
        }

        private static MainMenu buildEventsMenu()
        {
            MainMenu menu = new MainMenu("Delegates Main Menu");

            // Letters and Version submenu
            MenuItem lettersAndVersion = new("Letters and Version");
            lettersAndVersion.AddSubItem(new MenuItem("Show Version", MenuActions.ShowVersion));
            lettersAndVersion.AddSubItem(new MenuItem("Count Lowercase Letters", MenuActions.CountLowercaseLetters));

            // Date and Time submenu
            MenuItem dateTime = new("Show Current Date/Time");
            dateTime.AddSubItem(new MenuItem("Show Current Time", MenuActions.ShowTime));
            dateTime.AddSubItem(new MenuItem("Show Current Date", MenuActions.ShowDate));

            menu.AddSubItem(lettersAndVersion);
            menu.AddSubItem(dateTime);

            return menu;
        }
    }
}