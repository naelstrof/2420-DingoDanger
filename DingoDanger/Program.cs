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
            World.LoadFile( "map.txt" );
            bool running = true;
            DogSong.Play();
            while( running ) {
                Keyboard.UpdateKeys();
                World.Update( 100 );
                Keyboard.Reset ();
                // Game render
                World.Draw();
                Curses.NapMs(100);
                Stdscr.Move(Curses.Lines - 1, Curses.Cols - 1);
                Stdscr.Refresh();
            }
            // Game end!
            Curses.EndWin();
        }
    }
}
