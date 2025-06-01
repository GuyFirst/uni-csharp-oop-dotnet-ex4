namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private const bool k_IsRoot = true;
        private readonly MenuItem r_RootMenu;

        public MainMenu(string i_Title)
        {
            r_RootMenu = new MenuItem(i_Title);
        }

        public void AddSubItem(MenuItem i_Item)
        {
            r_RootMenu.AddSubItem(i_Item);
        }

        public void Show()
        {
            r_RootMenu.Show(k_IsRoot);
        }
    }
}