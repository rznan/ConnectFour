using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Services
{
    public abstract class ConsoleColorChanger
    {
        public static void ChangeColor(string color)
        {
            switch(color.ToLower())
            {
                case "white": 
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "black": 
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "yellow": 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "red": 
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green": 
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "blue": 
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "darkBlue": 
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "magenta": 
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                default: 
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}