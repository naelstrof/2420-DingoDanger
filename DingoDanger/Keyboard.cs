using System;
using System.Collections;
using CursesSharp;

namespace DingoDanger {
    public static class Keyboard {
        public static bool mouse = false;
        public static bool mousedown = false;
        public static Vector2 mousepos = new Vector2(0,0);
        public static ArrayList keys = new ArrayList();
        // Since keypresses are like a stream, we "update" by getting all the
        // pressed key codes since the last UpdateKeys().
        // There's no asynchronous key inputs that is also multi-platform without
        // being a huge game engine like XNA so we're kinda screwed for feasible input
        // methods...
        public static void Init() {
            MouseState foo = Curses.MouseMask (MouseState.BUTTON1_CLICKED | MouseState.REPORT_MOUSE_POSITION);
            if ( !Curses.HasMouse ) {
                return;
            }
            mouse = foo == (MouseState.BUTTON1_CLICKED | MouseState.REPORT_MOUSE_POSITION );
        }
        public static bool MouseDown() {
            if ( !mouse ) {
                return false;
            }
            return mousedown;
        }
        public static Vector2 GetMouse() {
            if ( !mouse ) {
                return new Vector2(0,0);
            }
            return mousepos;
        }
        public static void UpdateKeys() {
            int c = Stdscr.GetChar();
            while( c != -1 ) {
                //Console.WriteLine( "Key " + c + " pressed!" );
                if ( c == Keys.MOUSE && mouse ) {
                    try {
                        MouseEvent e = Curses.GetMouse();
                        // We want to toggle the mouse so...
                        if ( e.State == MouseState.BUTTON1_CLICKED ) {
                            mousedown = !mousedown;
                        }
                        mousepos = new Vector2( e.X, e.Y );
                    } catch { }
                }
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
            //mousedown = false;
            keys = new ArrayList();
        }
    }
}
