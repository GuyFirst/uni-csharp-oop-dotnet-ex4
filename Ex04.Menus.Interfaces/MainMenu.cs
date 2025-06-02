namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const bool k_IsRoot = true;
        private readonly MenuItem r_Root;

        public MainMenu(string i_Title)
        {
            r_Root = new MenuItem(i_Title, k_IsRoot);
        }

        public void AddSubMenu(MenuItem i_SubItem)
        {
            r_Root.AddSubMenu(i_SubItem);
        }

        public void Show()
        {
            r_Root.Invoke();
        }
    }
}