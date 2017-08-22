using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TickTackToe
{
    enum Turn
    {
        P1, P2
    }

    class TickTackToeGame
    {
        char[] board = new char[9];
        Turn CurrentTurn = Turn.P1;

        List<int[]> WinningMatches = new List<int[]>
        {
            // horizontal wins
            new[] { 0, 1, 2 },
            new[] { 3, 4, 5 },
            new[] { 6, 7, 8 },

            // vertical wins
            new[] { 0, 3, 6 },
            new[] { 1, 4, 7 },
            new[] { 2, 5, 8 },

            // diagonal wins
            new[] { 0, 4, 8 },
            new[] { 2, 4, 6 }
        };

        public TickTackToeGame()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
        }

        private void CWrite(string text, ConsoleColor c = ConsoleColor.White)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.Write(text);
            Console.ForegroundColor = currentColor;
        }

        private int GetNumberInput()
        {
            while (true)
            {
                CWrite("Enter Move ");
                char piece = CurrentTurn == Turn.P1 ? 'X' : 'O';
                CWrite($"{CurrentTurn} ({piece})", CurrentTurn == Turn.P1 ? ConsoleColor.Red : ConsoleColor.Green);
                CWrite(": ");

                if (int.TryParse(Console.ReadLine(), out int res) 
                    && res >= 0 && res <= 8 
                    && board[res] == ' ')
                {
                    return res;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(this);
                    Console.WriteLine("\nPlease enter a valid move\n");
                }
            }
        }

        private void TakeTurns()
        {
            int pos = GetNumberInput();

            if (CurrentTurn == Turn.P1)
            {
                board[pos] = 'X';
                CurrentTurn = Turn.P2;
            }
            else
            {
                board[pos] = 'O';
                CurrentTurn = Turn.P1;
            }
        }

        string emptyLine = "\t\t\t---------";
        public override string ToString()
        {
            return $"{new string('\n', 5)}\t\t\t{board[0]} | {board[1]} | {board[2]}\t 0 | 1 | 2\n" +
                   emptyLine + "\t ---------" +
                   $"\n\t\t\t{board[3]} | {board[4]} | {board[5]}\t 3 | 4 | 5\n" +
                   emptyLine + "\t ---------" +
                   $"\n\t\t\t{board[6]} | {board[7]} | {board[8]}\t 6 | 7 | 8";
        }

        private (bool win, Turn winner) CheckWin()
        {
            foreach (var match in WinningMatches)
            {
                if (match.All(x => board[x] == 'X'))
                {
                    return (true, Turn.P1);
                }
                else if (match.All(x => board[x] == 'O'))
                {
                    return (true, Turn.P2);
                }
            }
            return (false, CurrentTurn);
        }

        public void Run()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Clear();
                Console.WriteLine(this);
                TakeTurns();

                var wonRes = CheckWin();
                if (wonRes.win)
                {
                    Console.Clear();
                    Console.WriteLine(this);
                    Console.WriteLine($"------------------\n   {wonRes.winner} has won!\n------------------\n");
                    return;
                }
            }

            Console.WriteLine("\n\n\nGame ended with a draw!\n\n");
        }
    }
}
