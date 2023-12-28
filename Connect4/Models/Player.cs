using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public class Player(string name="No Name", char symbol=' ', string color="white")
    {
        private string name = name;
        private char symbol = symbol;
        private string color = color;

        public string Name { get => name; }
        public char Symbol { get => symbol; }
        public string Color { get => color; }
    }
}