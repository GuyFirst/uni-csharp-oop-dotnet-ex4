using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        public string Title { get; }
        public List<MenuItem> SubItems { get; }
        public IMenuItemNotifier Action { get; }
        public readonly bool m_IsRoot;

        public bool IsLeaf
        {
            get
            {
                return (SubItems.Count == 0);
            }
        }

        public MenuItem(string i_Title, IMenuItemNotifier i_Action)
        {
            Title = i_Title;
            Action = i_Action;
            SubItems = new List<MenuItem>();
            m_IsRoot = false;
        }

        public MenuItem(string i_Title)
        {
            Title = i_Title;
            SubItems = new List<MenuItem>();
            Action = null;
            m_IsRoot = false;
        }

        public MenuItem(string i_Title, bool i_IsRoot)
        {
            Title = i_Title;
            SubItems = new List<MenuItem>();
            Action = null;
            m_IsRoot = i_IsRoot;
        }

        public void AddSubMenu(MenuItem i_SubItem)
        {
            SubItems.Add(i_SubItem);
        }

        public void Invoke()
        {
            if (IsLeaf)
            {
                Console.Clear();
                Action?.OnSelected();
                Console.WriteLine(
                    """
                    Press Enter to return...
                    """);
                Console.ReadLine();
            }
            else
            {
                ShowSubMenu();
            }
        }

        private void ShowSubMenu()
        {
            bool exitSubMenu = false;

            while (!exitSubMenu)
            {
                Console.Clear();
                Console.Write(buildMenuDisplay());
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int choice) && choice >= 0 && choice <= SubItems.Count)
                {
                    if (choice == 0)
                    {
                        exitSubMenu = true;
                    }
                    else
                    {
                        SubItems[choice - 1].Invoke();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Press Enter to try again...");
                    Console.ReadLine();
                }
            }
        }

        private string buildMenuDisplay()
        {
            StringBuilder menuBuilder = new StringBuilder();
            menuBuilder.AppendLine($"** {Title} **");
            menuBuilder.AppendLine(new string('-', Title.Length + 6));

            for (int i = 0; i < SubItems.Count; i++)
            {
                menuBuilder.AppendLine((i + 1) + ". " + SubItems[i].Title);
            }

            string backOrExit = m_IsRoot ? "Exit" : "Back";

            menuBuilder.Append("0. ");
            menuBuilder.AppendLine(backOrExit);
            menuBuilder.Append("Please enter your choice (0 - " + SubItems.Count + "): ");

            return menuBuilder.ToString();
        }
    }
}