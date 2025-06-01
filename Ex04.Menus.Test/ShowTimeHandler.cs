using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class ShowTimeHandler : IMenuItemNotifier
    {
        public void OnSelected()
        {
            Console.WriteLine("Current Time is: {0}", DateTime.Now.ToShortTimeString());
        }
    }
}