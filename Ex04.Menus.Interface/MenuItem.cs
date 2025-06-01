using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interface
{
    public class MenuItem
    {
        public string Title { get; }
        public List<MenuItem> SubItems { get; }
        public IMenuItemNotifier Action { get; }

        public bool IsLeaf
        {
            get
            {
                return SubItems.Count == 0;
            }
        }

        public MenuItem(string i_Title, IMenuItemNotifier i_Action)
        {
            Title = i_Title;
            Action = i_Action;
            SubItems = new List<MenuItem>();
        }

        public MenuItem(string i_Title)
        {
            Title = i_Title;
            SubItems = new List<MenuItem>();
            Action = null;
        }

        public void AddSubMenu(MenuItem i_SubItem)
        {
            SubItems.Add(i_SubItem);
        }

        public void Execute()
        {
            if (IsLeaf)
            {
                Console.Clear();
                if (Action != null)
                {
                    Action.OnSelected();
                }
                Console.WriteLine("\nPress Enter to return...");
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
                Console.Write(BuildMenuDisplay());

                string userInput = Console.ReadLine();
                int choice;

                if (int.TryParse(userInput, out choice) && choice >= 0 && choice <= SubItems.Count)
                {
                    if (choice == 0)
                    {
                        exitSubMenu = true;
                    }
                    else
                    {
                        SubItems[choice - 1].Execute();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Press Enter to try again...");
                    Console.ReadLine();
                }
            }
        }

        private string BuildMenuDisplay()
        {
            StringBuilder menuBuilder = new StringBuilder();
            menuBuilder.AppendLine("** " + Title + " **");
            menuBuilder.AppendLine(new string('-', Title.Length + 6));

            for (int i = 0; i < SubItems.Count; i++)
            {
                menuBuilder.AppendLine((i + 1).ToString() + ". " + SubItems[i].Title);
            }

            menuBuilder.AppendLine("0. Back");
            menuBuilder.Append("Please enter your choice (0-" + SubItems.Count + "): ");

            return menuBuilder.ToString();
        }
    }
}
