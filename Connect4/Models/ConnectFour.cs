using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public class ConnectFour
    {
        private Cell[,] board = new Cell[6, 7];
        private Player[] players;
        private Player currentPlayer;
        private static readonly Dictionary<char, int> columnsLetters = new()
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
            players[0] = new Player("Renan", 'O', "red");
            players[1] = new Player("Sants", 'X', "magenta");

            currentPlayer = players[0];

            board.Initialize();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void DisplayBoard()
        {
            throw new NotImplementedException();
        }

        public bool MakeMove(string move)
        {
            if(ValidateMove(move))
            {
                int line = int.Parse(move[1].ToString()) -1;
                int column = columnsLetters[move[0]];

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
                if(!columnsLetters.Any(letter => letter.Key == move[0]) ||
                   !char.IsAsciiDigit(move[1])) 
                {
                    return false;
                }

                line = int.Parse(move[1].ToString()) -1;
                if(!(line < 6 && line >= 0)) 
                    return false;

                column = columnsLetters[move[0]];

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

        private bool CheckWin()
        {
            throw new NotImplementedException();
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