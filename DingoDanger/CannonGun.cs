using System;
using CursesSharp;

namespace DingoDanger {
    public class CannonGun : Entity {
        public CannonGun( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
            attrs = Attrs.BOLD;
        }
        public override void Update( double dt ) {
            Player p = World.GetPlayer();
            if ( p == null ) {
                return;
            }
            if ( p.pos == pos ) {
                p.gun = "Cannon Gun";
                Kill();
            }
        }
        public void Kill() { 
            World.Remove( this );
        }
    }
}
