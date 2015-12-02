using System;
using CursesSharp;

namespace DingoDanger {
    public class Entity {
        public Vector2 pos;
        public string sprite = "•";
        public int color = 7;
        public UInt32 attrs = 0;
        public Entity() {
        }
        public Entity( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
        }
        public virtual void Update( double dt ) {
        }
        public void Draw() {
            Stdscr.Attr = Attrs.NORMAL | Curses.COLOR_PAIR(color) | attrs;
            AddStr( (int)pos.y, (int)pos.x, sprite );
            Stdscr.Attr = Attrs.NORMAL;
        }
        private static void AddStr(int y, int x, string str) {
            x -= str.Length/2;
            if (x >= 0 && x < Curses.Cols && y >= 0 && y < Curses.Lines) {
                try {
                    Stdscr.Add(y, x, str);
                } catch ( Exception e ) {
                }
            }
        }
    }
}
