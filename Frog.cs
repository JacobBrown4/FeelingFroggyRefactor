﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeelingFroggy
{
    public class Frog
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        private string Froggy;
        private ConsoleColor FrogColor;
        public Frog(int initialX, int initialY, int width)
        {
            X = initialX;
            Y = initialY;
            Froggy = "\u03A9";
            FrogColor = ConsoleColor.Green;
            Width = width;
        }
        public void Draw()
        {
            Console.ForegroundColor = FrogColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(Froggy);
            Console.ResetColor();

        }

    }
    public class Enemy
    {
        static readonly Random rng = new Random();
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Car { get; set; }
        public int Speed { get; set; }
        public ConsoleColor Color { get; set; }
        public Enemy(int x, int y, bool goRight)
        {
            PosX = x;
            PosY = y;
            Speed = rng.Next(2, 6);
            Car = CarType(Speed, goRight);
            Color = (ConsoleColor)rng.Next(9,15);
            GoRight = goRight;
        }
        public bool GoRight { get; set; }

        public string CarType(int speed, bool goRight)
        {
            if (goRight)
            {
                if (speed == 4)
                {
                    return "■■¤";
                }
                else if (speed == 3)
                {
                    if (rng.Next(0, 2) == 1)
                    {
                        return "■■";
                    }
                    else
                        return "■■¤";
                }
                else if (speed <= 2)
                {
                    return "■■";
                }
                else
                {
                    return "▓▓▓■";

                }
            }
            else
            {
                if (speed == 4)
                {
                    return "¤■■";
                }
                else if (speed == 3)
                {
                    if (rng.Next(0, 2) == 1)
                    {
                        return "■■";
                    }
                    else
                        return "¤■■";
                }
                else if (speed <= 2)
                {
                    return "■■";
                }
                else
                {
                    return "■▓▓▓";
                }
            }

        }
        public void Move(int x, int y)
        {
            if (GoRight)
                MoveRight(x, y);
            else
                MoveLeft(x, y);
        }
        public void MoveRight(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            x++;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = Color;
            Console.Write(Car);
            PosX += 1;
        }
        public void MoveLeft(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            x--;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = Color;
            Console.Write(Car);
            PosX -= 1;
        }

        public void Stay(int x, int y)
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(x, y);
            Console.Write(Car);
        }

    }
}
