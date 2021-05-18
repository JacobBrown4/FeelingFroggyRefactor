using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeelingFroggy
{
    public class Game
    {
        public int _lane1Counter = 0;
        private World MyWorld = new World(GetGrid());
        private Frog CurrentFrog;
        public int Window_Height = 12;
        public int Window_Width = 19;
        private bool _gameOn = true;
        //public int BuffW = 24;
        //public int BuffH = 30;


        public void Start()
        {
            CurrentFrog = new Frog(8, 10, 1);
            _gameOn = true;
            GameLoop();

        }

        public void PlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (IsSafe(CurrentFrog.X, CurrentFrog.Y - 1))
                    {
                        CurrentFrog.Y -= 1;
                        break;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (IsSafe(CurrentFrog.X, CurrentFrog.Y + 1))
                    {
                        CurrentFrog.Y += 1;
                        break;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (IsSafe(CurrentFrog.X - 1, CurrentFrog.Y))
                    {
                        CurrentFrog.X -= 1;
                        break;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (IsSafe(CurrentFrog.X + 1, CurrentFrog.Y))
                    {
                        CurrentFrog.X += 1;
                        break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void DrawFrame()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            MyWorld.Draw();
            CurrentFrog.Draw();
        }

        public void GameLoop()
        {
            List<Enemy> lvl1 = new List<Enemy>()
            {
            new Enemy(3, 9, true),
            new Enemy(7, 8, true),
            new Enemy(5, 7, false),
            new Enemy(8, 4, false),
            new Enemy(13, 3, false),
            new Enemy(3, 2, true),
            };

            // This is lazy, should setup a better way but just showing the idea of multiple levels
            List<Enemy> lvl2 = new List<Enemy>()
            {
            new Enemy(3, 9, false),
            new Enemy(7, 8, true),
            new Enemy(5, 7, true),
            new Enemy(5, 5, true),
            new Enemy(8, 4, true),
            new Enemy(13, 3, false),
            new Enemy(3, 2, false),
            };

            LevelMaker(lvl1, 31);
            //LevelMaker(lvl2, 12); Lower phase means faster cars

            Start();
        }

        public static string[,] GetGrid()
        {

            string[,] grid = {
                {"|" , "~" , "~" , "~" , "~" , "~" , "~" , "~" , "~" , "~" ,"~" , "~" , "~" , "~" , "~" , "|" }, //  16x12
                {"|" , "=" , "=" , "$" , "$" , "=" , "=" , "=" , "=" , "=" ,"=" , "$" , "$" , "=" , "=" , "|" }, // End
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Safe
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Safe
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Start 
                {"|" , "=" , "=" , "=" , "=" , "=" , "=" , "=" , "=" , "=" ,"=" , "=" , "=" , "=" , "=" , "|" },

            };
            return grid;
        }

        public string Grid2()
        {
            //16x12
            string grid =
                "\n|~~~~~~~~~~~~~~|\n" +
                "|==$$======$$==|\n" +
                "|              |\n" +
                "|              |\n" +
                "|              |\n" +
                "|              |\n" +
                "|              |\n" +
                "|              |\n" +
                "|              |\n" +
                "|              |\n" +
                "|              |\n" +
                "|              |\n" +
                "|==============|";

            return grid;
        }
        public bool wasCollision(int x, int y, int carLength)
        {
            for (int i = 0; i < carLength; i++)
            {
                if (x+i == CurrentFrog.X && y == CurrentFrog.Y)
                {
                    YouLoose();
                    return true;
                }
            }
            return false;
        }

        public void MoveCar(Enemy car, int phase)
        {
            if (phase % car.Speed == 0)
            {
                car.Move(car.PosX, car.PosY);
                if (wasCollision(car.PosX, car.PosY, car.Car.Length) == false)
                {

                    if (car.GoRight)
                    {
                        if (car.PosX > 14) { car.PosX = 0; }
                    }
                    else
                    {
                        if (car.PosX == 1) { car.PosX = 14; }
                    }
                }
            }
            else car.Stay(car.PosX, car.PosY);
        }

        public bool IsSafe(int x, int y)
        {
            Game newgame = new Game();

            if (MyWorld.Grid[y, x] == "|" || y <= 0 || x <= 0 || MyWorld.Grid[y, x] == "=")
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You flew off \nthe Map! \nGame Over");
                Console.ResetColor();
                Console.ReadKey();
                _gameOn = false;
                return false;
            }
            else if (MyWorld.Grid[y, x] == "$")
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations, \nyou WON!");
                Console.ResetColor();
                Console.ReadKey();
                _gameOn = false;
                return false;
            }

            return true;

        }

        public void YouLoose()
        {
            _gameOn = false;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("OH NO, \n Splattered by a car. \nBetter luck \nnext time.");
            Console.ReadKey();
            Console.ResetColor();
        }

        public void LevelMaker(List<Enemy> cars, int phaseCap)
        {
            int phase = 1;
            while (_gameOn)
            {
                DrawFrame();

                foreach (Enemy car in cars)
                {
                    MoveCar(car, phase);
                }
                ++phase;
                if (phase == phaseCap)
                { phase = 1; }

                while (Console.KeyAvailable) { PlayerInput(); }
                System.Threading.Thread.Sleep(15);
            }
        }
    }

}
