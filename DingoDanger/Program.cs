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
            StateMachine.Switch( new IntroState() );
            bool running = true;
            while( running ) {
                Keyboard.UpdateKeys();
                StateMachine.Update( 100 );
                Keyboard.Reset ();
                // Game render
                StateMachine.Draw();
                Curses.NapMs(100);
                Stdscr.Move(Curses.Lines - 1, Curses.Cols - 1);
                Stdscr.Refresh();
            }
            // Game end!
            Curses.EndWin();
        }
    }
}
