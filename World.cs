﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeelingFroggy
{
    public class World
    {
        public string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string [,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);            
        }

        public void Draw ()
        {
            for(int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
                    if (element == "$")
                    {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.Write(element);
                    Console.ResetColor();
                }
            }
            
        }

    }
}
