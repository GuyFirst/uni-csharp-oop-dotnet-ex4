//using System;
//using System.Collections.Generic;

//namespace Ex04.Menus.Events
//{
//    public class MenuItem
//    {
//        private const string k_InvalidInputDigitsOnlyMessage = """
//                                                               Invalid input. Please enter digits only.
//                                                               Press Enter to try again.
//                                                               """;
//        private const int k_BackOrExitOption = 0;
//        public string Title { get; }
//        public List<MenuItem> SubItems { get; } = new List<MenuItem>();
//        public event Action SelectedAction;

//        public MenuItem(string i_Title, Action i_Action = null)
//        {
//            Title = i_Title;
//            SelectedAction = i_Action;
//        }

//        public void AddSubItem(MenuItem i_SubMenuItem)
//        {
//            SubItems.Add(i_SubMenuItem);
//        }

//        private void printMenuHeader()
//        {
//            Console.Clear();
//            Console.WriteLine($"** {Title} **");
//            for (int i = 0; i < Title.Length * 2; i++)
//            {
//                Console.Write("-");
//            }

//            Console.WriteLine();
//        }

//        public void Show(bool i_IsRootMenuItem = false)
//        {
//            while (true)
//            {
//                printMenuHeader();
//                for (int i = 0; i < SubItems.Count; i++)
//                {
//                    Console.WriteLine($"{i + 1}. {SubItems[i].Title}");
//                }

//                string backOption = i_IsRootMenuItem ? "Exit" : "Back";
//                string optionsToChooseFrom = (SubItems.Count <= 1
//                                                  ? ("(1 or 0 to " + backOption)
//                                                  : ("(1-" + SubItems.Count + " or 0 to " + backOption) + "):");

//                Console.WriteLine("0. " + backOption);
//                Console.WriteLine("Please enter your choice " + optionsToChooseFrom);
//                string usersChoice = Console.ReadLine();

//                if (int.TryParse(usersChoice, out int choice))
//                {
//                    if (choice == k_BackOrExitOption)
//                    {
//                        if (i_IsRootMenuItem)
//                        {
//                            Console.WriteLine("Bye Bye (:");
//                        }

//                        break;
//                    }

//                    if (choice > 0 && choice <= SubItems.Count)
//                    {
//                        MenuItem selected = SubItems[choice - 1];

//                        if (selected.SubItems.Count > 0)
//                        {
//                            selected.Show();
//                        }
//                        else
//                        {
//                            Console.Clear();
//                            selected.SelectedAction?.Invoke();
//                            Console.WriteLine("""
//                                              Press Enter to return...
//                                              """);
//                            Console.ReadLine();
//                        }
//                    }
//                    else
//                    {
//                        Console.WriteLine(
//                            $"""
//                             Invalid choice. Please enter a number between 0 and {SubItems.Count}.
//                             Press Enter to try again.
//                             """);
//                        Console.ReadLine();
//                    }
//                }
//                else
//                {
//                    Console.WriteLine($"{k_InvalidInputDigitsOnlyMessage}");
//                    Console.ReadLine();
//                }
//            }
//        }
//    }
//}

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

            string backText = i_IsRoot ? "Exit" : "Back";
            
            Console.WriteLine($"0. {backText}");
            string rangePart = i_SubItems.Count <= 1
                ? $"(1 or 0 to {backText}):"
                : $"(1-{i_SubItems.Count} or 0 to {backText}):";

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