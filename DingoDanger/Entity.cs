using System;
using CursesSharp;

namespace DingoDanger {
    public class Entity {
        public Entity cameFrom;
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
            DrawBlock( (int)pos.x, (int)pos.y, sprite );
            Stdscr.Attr = Attrs.NORMAL;
        }
        private static void DrawBlock(int x, int y, string str) {
            string[] array = str.Split('\n');
            int width = str.IndexOf('\n');
            int height = array.Length;
            x -= width/2;
            y -= height/2;
            foreach( string line in array ) {
                if (x >= 0 && x < Curses.Cols && y >= 0 && y < Curses.Lines) {
                    try {
                        Stdscr.Add(y, x, line);
                    } catch { }
                }
                y++;
            }
        }
    }
}
