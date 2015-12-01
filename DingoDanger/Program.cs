using System;
using CursesSharp;

namespace DingoDanger
{
    class Program
    {
        static void Main(string[] args)
        {
            Curses.InitScr();
            Stdscr.Blocking = false;
            Curses.Echo = false;
            // Init world.
            World world = new World("map.txt");
            bool running = true;
            while( running ) {
                // Game logic

                // Game render
                world.Draw();
                Curses.NapMs(100);
                Stdscr.Move(Curses.Lines - 1, Curses.Cols - 1);
                Stdscr.Refresh();
            }
            // Game end!
            Curses.EndWin();
        }
    }
}
