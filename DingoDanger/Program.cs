using System.Diagnostics;
using CursesSharp;

namespace DingoDanger {
    class Program {
        private static short[] color_table = {
            Colors.RED, Colors.BLUE, Colors.GREEN, Colors.CYAN,
            Colors.RED, Colors.MAGENTA, Colors.YELLOW, Colors.WHITE
        };
        static void Main(string[] args) {
            // Init Curses
            Curses.InitScr();
            Stdscr.Blocking = false;
            Curses.Echo = false;
            if (Curses.HasColors) {
                Curses.StartColor();
                for (short i = 1; i < 8; ++i) {
                    Curses.InitPair(i, color_table[i], Colors.BLACK);
                }
            }
            // Init world.
            StateMachine.Switch( new IntroState() );
            bool running = true;
            Stopwatch time = new Stopwatch();
            time.Start();
            long spillover = 0;
            while( running ) {
                if ( time.ElapsedMilliseconds + spillover > 100 ) {
                    Keyboard.UpdateKeys();
                    StateMachine.Update( 100 );
                    Keyboard.Reset ();
                    // Game render
                    StateMachine.Draw();
                    Stdscr.Move(Curses.Lines - 1, Curses.Cols - 1);
                    Stdscr.Refresh();

                    spillover = (time.ElapsedMilliseconds + spillover) - 100;
                    time.Restart();
                }
            }
            // Game end!
            Curses.EndWin();
        }
    }
}
