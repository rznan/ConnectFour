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
            throw new NotImplementedException();
        }

        private bool CheckWin()
        {
            throw new NotImplementedException();
        }

        private bool SwichtPlayer()
        {
            throw new NotImplementedException();
        }
    }
}