namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly MenuItem r_RootMenu;

        public MainMenu(string i_Title)
        {
            r_RootMenu = new MenuItem(i_Title);
        }

        public void AddSubItem(MenuItem i_SubMenuItem)
        {
            r_RootMenu.AddSubItem(i_SubMenuItem);
        }

        public void Show()
        {
            r_RootMenu.Show();
        }
    }
}