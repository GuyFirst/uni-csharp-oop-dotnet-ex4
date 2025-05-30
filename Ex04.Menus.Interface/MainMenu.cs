namespace Ex04.Menus.Interface
{
    public class MainMenu
    {
        private readonly MenuItem m_Root;

        public MainMenu(string i_Title)
        {
            m_Root = new MenuItem(i_Title);
        }

        public void AddSubMenu(MenuItem i_SubItem)
        {
            m_Root.AddSubMenu(i_SubItem);
        }

        public void Show()
        {
            m_Root.Execute();
        }
    }
}

