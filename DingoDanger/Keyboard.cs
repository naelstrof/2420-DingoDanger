using System.Collections;
using CursesSharp;

namespace DingoDanger {
    public static class Keyboard {
        public static ArrayList keys = new ArrayList();
        public static void UpdateKeys() {
            int c = Stdscr.GetChar();
            while( c != -1 ) {
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
        public static void Reset() {
            keys = new ArrayList();
        }
    }
}
