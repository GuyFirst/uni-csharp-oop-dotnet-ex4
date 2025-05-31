using Ex04.Menus.Interface;

namespace Ex04.Menus.Test
{
    internal class MenuManager
    {
        private readonly MainMenu m_mainMenu;

        public MenuManager(MainMenu i_MainMenu)
        {
            m_mainMenu = i_MainMenu;
        }

        public void ShowMainMenu()
        {
            m_mainMenu.Show();
        }
    }
}
