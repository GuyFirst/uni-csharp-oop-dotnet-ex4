using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class MenuManager
    {
        private MainMenu m_MainMenu;

        public MenuManager(MainMenu i_MainMenu)
        {
            m_MainMenu = i_MainMenu;
        }

        public void ShowMainMenu()
        {
            m_MainMenu.Show();
        }
    }
}
