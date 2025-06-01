using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private const int k_BackOrExitFlag = 0;
        private const string k_InvalidInputDigitsOnlyMessage = """
                                                               Invalid input. Please enter digits only.
                                                               Press Enter to try again.
                                                               """;

        public string Title { get; }
        
        public List<MenuItem> SubItems { get; } = new List<MenuItem>();
        
        public MenuItem ParentMenuItem { get; private set; }
        
        public event Action SelectedAction;

        public MenuItem(string i_Title, MenuItem i_ParentMenuItem = null)
        {
            Title = i_Title;
            ParentMenuItem = i_ParentMenuItem;
        }

        public void AddSubItem(MenuItem i_SubMenuItem)
        {
            i_SubMenuItem.ParentMenuItem = this;
            SubItems.Add(i_SubMenuItem);
        }

        public void Show()
        {
            MenuItem currentMenuItem = this;

            while (true)
            {
                bool isRoot = (currentMenuItem.ParentMenuItem == null);

                printGenericMenuItemHeader(currentMenuItem.Title);
                printSubMenuItemOptions(currentMenuItem.SubItems, isRoot);

                if (!tryGetUserChoice(currentMenuItem.SubItems.Count, out int choice))
                {
                    continue;
                }

                if (choice == k_BackOrExitFlag)
                {
                    if (isRoot)
                    {
                        Console.WriteLine("Bye Bye (:");
                        break;
                    }

                    currentMenuItem = currentMenuItem.ParentMenuItem;
                    continue;
                }

                MenuItem next = currentMenuItem.SubItems[choice - 1];

                if (next.SubItems.Count > 0)
                {
                    currentMenuItem = next;
                }
                else
                {
                    Console.Clear();
                    next.SelectedAction?.Invoke();
                    Console.WriteLine("Press Enter to return...");
                    Console.ReadLine();
                }
            }
        }

        private static void printGenericMenuItemHeader(string i_MenusTitle)
        {
            Console.Clear();
            Console.WriteLine($"** {i_MenusTitle} **");
            for (int i = 0; i < i_MenusTitle.Length * 2; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }

        private static void printSubMenuItemOptions(List<MenuItem> i_SubItems, bool i_IsRoot)
        {
            for (int i = 0; i < i_SubItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {i_SubItems[i].Title}");
            }

            string backMenuText = i_IsRoot ? "Exit" : "Back";
            
            Console.WriteLine($"0. {backMenuText}");
            string rangePart = i_SubItems.Count <= 1
                ? $"(1 or 0 to {backMenuText}):"
                : $"(1-{i_SubItems.Count} or 0 to {backMenuText}):";

            Console.WriteLine("Please enter your choice " + rangePart);
        }

        private static bool tryGetUserChoice(int i_MaxOptions, out int io_Choice)
        {
            bool isValidUserChoice = true;
            string input = Console.ReadLine();

            if (!int.TryParse(input, out io_Choice))
            {
                Console.WriteLine(k_InvalidInputDigitsOnlyMessage);
                Console.ReadLine();
            
                isValidUserChoice = false;
            }

            if (isValidUserChoice && (io_Choice < 0 || io_Choice > i_MaxOptions))
            {
                Console.WriteLine(
                    $"""
                     Invalid choice. Please enter a number between 0 and {i_MaxOptions}.
                     Press Enter to try again.
                     """);
                Console.ReadLine();
                isValidUserChoice = false;
            }

            return isValidUserChoice;
        }
    }
}