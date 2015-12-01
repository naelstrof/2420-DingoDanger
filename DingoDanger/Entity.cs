﻿using System;
using CursesSharp;

namespace DingoDanger {
    public class Entity {
        public Vector2 pos;
        public string sprite = "•";
        public Entity() {
        }
        public Entity( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
        }
        public virtual void Update( double dt ) {
        }
        public void Draw() {
            AddStr( (int)pos.y, (int)pos.x, sprite );
        }
        private static void AddStr(int y, int x, string str) {
            if (x >= 0 && x < Curses.Cols && y >= 0 && y < Curses.Lines) {
                Stdscr.Add(y, x, str);
            }
        }
    }
}
