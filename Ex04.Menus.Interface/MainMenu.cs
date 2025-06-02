namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly MenuItem r_Root;
        
        public MainMenu(string i_Title)
        {
            const bool v_IsRoot = true;

            r_Root = new MenuItem(i_Title, v_IsRoot);
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

