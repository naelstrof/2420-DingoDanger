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
            DrawBlock( pos.x, pos.y, sprite );
            Stdscr.Attr = Attrs.NORMAL;
        }
        public static void DrawBlock( int x, int y, string text ) {
            string[] lines = text.Split( '\n' );
            int width = text.IndexOf('\n');
            int height = lines.Length;
            x -= width/2;
            y -= width/2;
            int rx = x;
            foreach( string line in lines ) {
                foreach( char c in line.ToCharArray() ) {
                    if ( x >= 80 || x<0 ) {
                        continue;
                    }
                    if ( y >= 24 || y<0 ) {
                        continue;
                    }
                    try {
                        Stdscr.Add(y, x, c);
                    } catch { }
                    x++;
                }
                x = rx;
                y++;
            }
        }
    }
}
