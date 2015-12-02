using System;
using System.Collections;
using CursesSharp;

namespace DingoDanger {
    public static class Keyboard {
        public static ArrayList keys = new ArrayList();
        // Since keypresses are like a stream, we "update" by getting all the
        // pressed key codes since the last UpdateKeys().
        // There's no asynchronous key inputs that is also multi-platform without
        // being a huge game engine like XNA so we're kinda screwed for feasible input
        // methods...
        public static void UpdateKeys() {
            int c = Stdscr.GetChar();
            while( c != -1 ) {
                //Console.WriteLine( "Key " + c + " pressed!" );
                keys.Add(c);
                c = Stdscr.GetChar();
            }
        }
        public static bool KeyDown( int key ) {
            if( keys.Contains( key ) ) {
                return true;
            }
            return false;
        }
        // We throw away all the pressed keys every frame.
        // The keys should repeatedly send inputs anyway.
        public static void Reset() {
            keys = new ArrayList();
        }
    }
}
