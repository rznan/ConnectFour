using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public class ConnectFour
    {
        private Cell[,] board;
        private Player[] players;
        private Player currentPlayer;
        private Player ?winner = null;
        public Player? Winner { get => winner; }
        private static readonly Dictionary<char, int> lettersValues = new()
        {
            {'A', 0},
            {'B', 1},
            {'C', 2},
            {'D', 3},
            {'E', 4},
            {'F', 5}
        };

        public ConnectFour()
        {
            // Recieve Names Through User Input
            players = new Player[2];
            board = new Cell[6, 7];
            currentPlayer = new Player();

            for(int line = 0; line < board.GetLength(0); line++)
            {
                for(int column = 0; column < board.GetLength(1); column++)
                {
                    board[line, column] = new Cell();
                }
            }
        }

        public void StartGame()
        {
            string[] colors = ["red", "yellow"];
            char[] symbols = ['O', 'X'];

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine
            (
                "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n" +
                "■          CONNECT4            ■\n" +
                "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■" 
            );
            Console.ResetColor();

            // Recieves the players names
            for(int i = 0; i < players.Length; i++)
            {
                Console.Write($"Nome do {i + 1}° Jogador: ");
                string ?nome = Console.ReadLine();

                if(nome is not null)
                {
                    players[i] = new Player(nome, symbols[i], colors[i]);
                }
            }

            currentPlayer = players[0];
        }

        public void DisplayBoard()
        {
            for(int line = board.GetLength(0) -1; line >= 0; line--)
            {
                // line separator
                Console.WriteLine("-----------------------------");

                // line contents
                for(int column = 0; column < board.GetLength(1); column++)
                {
                    Console.Write($"| ");
                    board[line, column].Write();
                    Console.Write(" ");
                }

                // line label
                Console.Write($"|\t");
                
                switch(line)
                {
                    case 5: 
                        Console.Write("F");
                        break;
                    case 4: 
                        Console.Write("E");
                        break;
                    case 3: 
                        Console.Write("D");
                        break;
                    case 2: 
                        Console.Write("C");
                        break;
                    case 1: 
                        Console.Write("B");
                        break;
                    case 0: 
                        Console.Write("A");
                        break;
                    default:
                        Console.Write(" ");
                        break;
                }

                Console.Write('\n');
            }

            // board footer
            Console.WriteLine("-----------------------------");
            Console.WriteLine("  1   2   3   4   5   6   7");
        }

        public bool MakeMove(string move)
        {
            if(ValidateMove(move))
            {
                int line = int.Parse(move[1].ToString()) -1;
                int column = lettersValues[move[0]];

                board[line, column] = new Cell(currentPlayer.Symbol, currentPlayer.Color);

                return true;
            }

            return false;
        }

        public bool ValidateMove(string move)
        {
            if(move.Length == 2)
            {
                int line;
                int column;
                // checks if the move is formated in the correct manner: letterNumber
                // and validates if the letter exists on the board
                if(!lettersValues.Any(letter => letter.Key == move[0]) ||
                   !char.IsAsciiDigit(move[1])) 
                {
                    return false;
                }

                line = int.Parse(move[1].ToString()) -1;
                if(!(line < 7 && line >= 0)) 
                    return false;

                column = lettersValues[move[0]];

                // checks if the square is empty
                if(board[line, column].Content == ' ')
                {
                    // returns true if the current square has a foundation
                    // i.ex is on the first line or above an element 
                    return line == 0 ? true : board[line - 1, column].Content != ' ';
                }
            }
            return false;
        }

        public bool CheckWin()
        {
            for (int line = 0; line < board.GetLength(0); line++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    char currentSymbol = board[line, col].Content;

                    if (currentSymbol == ' ')
                        continue;

                    if (CheckSequence(line, col, 1, 0, currentSymbol) ||
                        CheckSequence(line, col, 0, 1, currentSymbol) ||
                        CheckSequence(line, col, 1, 1, currentSymbol) ||
                        CheckSequence(line, col, 1, -1, currentSymbol))
                    {
                        winner = players[0].Symbol == currentSymbol ? players[0] : players[1];
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckSequence(int startLine, int startCol, int lineDelta, int colDelta, int currentSymbol)
        {
            int count = 0;

            for (int i = 0; i < 4; i++)
            {
                int line = startLine + i * lineDelta;
                int col = startCol + i * colDelta;

                if (line >= 0 && line < board.GetLength(0) && col >= 0 && col < board.GetLength(1))
                {
                    if (board[line, col].Content == currentSymbol)
                    {
                        count++;
                        if (count == 4)
                            return true;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return false;
        }

        private void SwichtPlayer()
        {
            if(currentPlayer == players[0])
            {
                currentPlayer = players[1];
            }
            else
            {
                currentPlayer = players[0];
            }
        }
    }
}