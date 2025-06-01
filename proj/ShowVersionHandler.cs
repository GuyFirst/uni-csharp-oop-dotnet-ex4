using Ex04.Menus.Interface;
using System;

namespace Ex04.Menus.Test
{
    public class ShowVersionHandler : IMenuItemNotifier
    {
        public void OnSelected()
        {
            Console.WriteLine("App Version: 25.2.4.4480");
        }
    }
}
