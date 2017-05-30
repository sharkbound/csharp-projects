using System;
using System.Collections.Generic;

namespace TrollMaze
{
    internal class Game
    {
        public List<(int, int)> Enemies { get; set; } = new List<(int, int)>();
        public (int x, int y) PlayerPos { get; set; } = (0, 0);
        public int[,] Level { get; set; }

        public Dictionary<MoveDirection, (int x, int y)> MovementDict { get; set; } = new Dictionary<MoveDirection, (int x, int y)>
        {
            [MoveDirection.UP] = (0, -1),
            [MoveDirection.DOWN] = (0, 1),
            [MoveDirection.LEFT] = (-1, 0),
            [MoveDirection.RIGHT] = (1, 0),
            [MoveDirection.NONE] = (0, 0),
        };

        public Game(int width, int height)
        {
            Level = new int[width, height];
        }

        public MoveDirection GetMoveDirection()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return MoveDirection.LEFT;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return MoveDirection.RIGHT;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return MoveDirection.DOWN;

                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return MoveDirection.UP;

                default:
                    return MoveDirection.NONE;
            }
        }
    }
}