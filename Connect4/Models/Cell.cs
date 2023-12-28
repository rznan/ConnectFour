using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Connect4.Services;

namespace Connect4.Models
{
    public class Cell(char content = ' ', string color = "white")
    {
        private char content = content;
        public char Content 
        {
            get => content;
        }

        private string color = color;
        public string Color
        {
            get => color;
        }

        public void Write()
        {
            ConsoleColorChanger.ChangeColor(color);
            Console.Write(content);
            Console.ResetColor();
        }
    }
}