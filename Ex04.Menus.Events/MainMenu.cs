using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MainMenu : MenuItem
    {
        private const bool k_IsRoot = true;

        public MainMenu(string i_Title)
            : base(i_Title)
        {
        }

        public void Show()
        {
            base.Show(k_IsRoot);
        }
    }
}