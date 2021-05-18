﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeelingFroggy
{
    class Program
    {
        public static void Main(string[] args)
        {
            int Window_Height = 12;
            int Window_Width = 19;
            Program runner = new Program();
            Console.Title = "Feeling Froggy";
            Console.BufferHeight = Console.WindowHeight = Window_Height;
            Console.BufferWidth = Console.WindowWidth = Window_Width;
            runner.FrogScreen();
            runner.InstructionScreen();
            Game newGame = new Game();
            newGame.Start();
               
        }

        public void FrogScreen()
        {
            Console.CursorVisible = false;
            Console.WriteLine("    Welcome");
            Console.WriteLine("      To   ");
            Console.WriteLine("  Ben, Ryan, and");
            Console.WriteLine("      Jacob's");
            Console.WriteLine("  Rendition Of");
            Console.WriteLine("    Frogger!  ");
            Console.WriteLine("              ");
            Console.WriteLine("  Please Press");
            Console.WriteLine("     Any Key");
            Console.WriteLine("     To Be");
            Console.WriteLine("     Amazed");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("       _  _");
            Console.WriteLine("       (.)(.)");
            Console.WriteLine("   ,-.(.____.),-.  ");
            Console.WriteLine("  (\\ \\ '--' / / )");
            Console.WriteLine("  \\ \\ / ,.\\ / / ");
            Console.WriteLine("    ) '| || |' (   ");
            Console.WriteLine(" oO'- OoO''OoO -'Oo");
            System.Threading.Thread.Sleep(750);
            Console.Clear();
        }
        public void InstructionScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n");
            Console.WriteLine("    Arrow Keys");
            Console.WriteLine("     Move The");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("       Frog");
            Console.WriteLine("                 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Cars Kill You");
            Console.WriteLine("  Walls Kill You");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
