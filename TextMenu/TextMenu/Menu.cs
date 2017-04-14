using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMenu
{
    enum Direction
    {
        Up, Down
    }

    class Menu
    {
        public int currentIndex = 0;
        public List<MenuItem> Items;
        public string SelectedPrefix;

        public Menu(string selectedPrefix, List<MenuItem> items)
        {
            Items = items;
            SelectedPrefix = selectedPrefix;
        }

        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                Render();

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        SelectNext(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        SelectNext(Direction.Down);
                        break;
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Items[currentIndex].OnSelect();
                        Console.WriteLine("\n\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (i == currentIndex)
                {
                    Console.WriteLine(SelectedPrefix + Items[i].Text);
                }
                else
                {
                    Console.WriteLine("    " + Items[i].Text);
                }
            }
        }

        public void SelectNext(Direction dir)
        {
            if (dir == Direction.Up)
            {
                currentIndex--;
            }
            else if (dir == Direction.Down)
            {
                currentIndex++;
            }

            if (currentIndex < 0)
            {
                currentIndex = Items.Count - 1;
            }
            else if (currentIndex > Items.Count - 1)
            {
                currentIndex = 0;
            }
        }
    }
}
