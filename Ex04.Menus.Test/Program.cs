namespace Ex04.Menus.Test
{
    public class Program
    {
        private static Interfaces.MainMenu m_InterfaceMainMenu;
        private static Events.MainMenu m_DelegatesMainMenu;

        public static void Main()
        {
            m_InterfaceMainMenu = MainMenuBuilder.BuildMainInterfaceMenu();
            m_InterfaceMainMenu.Show();
            m_DelegatesMainMenu = MainMenuBuilder.BuildMainEventMenu();
            m_DelegatesMainMenu.Show();
        }
    }
}