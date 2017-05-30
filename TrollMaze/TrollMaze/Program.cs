using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMaze
{
    class Program
    {
        static void Main(string[] args) => new Program().Start();

        private void Draw(string s, int x, int y)
        {
            var oldPos = (left: Console.CursorLeft, top: Console.CursorTop);
            Console.SetCursorPosition(x, y);
            Console.Write(s);
            Console.SetCursorPosition(oldPos.left, oldPos.top);
        }

        private void Start()
        {
            Console.CursorVisible = false;
            Game game = new Game(20, 20);

            while (true)
            {
                var dir = game.GetMoveDirection();
                Console.Clear();

                var move = game.MovementDict[dir];
                var curPos = game.PlayerPos;
                game.PlayerPos = (curPos.x + move.x, curPos.y + move.y);

                Draw("*", game.PlayerPos.x, game.PlayerPos.y);
            }
        }
    }
}
