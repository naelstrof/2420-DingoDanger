using System;

namespace DingoDanger {
    public class Entity {
        public Entity( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
        }
        public Vector2 pos;
        public string sprite = "•";
    }
}
