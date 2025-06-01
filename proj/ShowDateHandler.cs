using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class ShowDateHandler : IMenuItemNotifier
    {
        public void OnSelected()
        {
            Console.WriteLine("Current Date is: {0}", DateTime.Now.ToShortDateString());
        }
    }
}