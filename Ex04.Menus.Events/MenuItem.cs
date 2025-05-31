using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        public string Title { get; }
        public List<MenuItem> SubItems { get; } = new List<MenuItem>();
        public Action? Action { get; }

        public MenuItem(string i_Title, Action? i_Action = null)
        {
            Title = i_Title;
            Action = i_Action;
        }

        public void AddSubItem(MenuItem i_Item)
        {
            SubItems.Add(i_Item);
        }

        public void Show(bool i_IsRoot = false)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"** {Title} **");
                for(int i = 0; i < (Title.Length * 2); i++)
                {
                    Console.Write("-");
                }
 
                Console.WriteLine();
                for (int i = 0; i < SubItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {SubItems[i].Title}");
                }

                Console.WriteLine("0. " + (i_IsRoot ? "Exit" : "Back"));
                Console.WriteLine(
                    "Please enter your choice "
                    + (SubItems.Count <= 1
                           ? ("(1 or 0 to " + (i_IsRoot ? "Exit" : "Back"))
                           : ("(1-" + SubItems.Count + " or 0 to " + (i_IsRoot ? "Exit" : "Back"))) 
                    + "):");
                string usersChoice = Console.ReadLine();

                if (int.TryParse(usersChoice, out int choice))
                {
                    if(choice == 0)
                    {
                        Console.WriteLine("Bye Bye");
                        break;
                    }

                    if (choice > 0 && choice <= SubItems.Count)
                    {
                        MenuItem selected = SubItems[choice - 1];

                        if (selected.SubItems.Count > 0)
                        {
                            selected.Show();
                        }
                        else
                        {
                            Console.Clear();
                            selected.Action?.Invoke();
                            Console.WriteLine(@"
Press Enter to return...");
                            Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}