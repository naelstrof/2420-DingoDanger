using System;
using CursesSharp;

namespace DingoDanger {
    public class ExplodeyGun : Entity {
        public ExplodeyGun( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
            attrs = Attrs.BOLD;
        }
        public override void Update( double dt ) {
            Player p = World.GetPlayer();
            if ( p.pos == pos ) {
                p.gun = "Confetti Gun";
                Kill();
            }
            color = World.Rand(0,7);
        }
        public void Kill() { 
            World.Remove( this );
        }
    }
}
