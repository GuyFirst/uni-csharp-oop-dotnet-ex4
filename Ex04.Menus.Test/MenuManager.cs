using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class MenuManager
    {
        private readonly MainMenu r_MainMenu;

        public MenuManager(MainMenu i_MainMenu)
        {
            r_MainMenu = i_MainMenu;
        }

        public void ShowMainMenu()
        {
            r_MainMenu.Show();
        }
    }
}
