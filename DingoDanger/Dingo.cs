using System;

namespace DingoDanger {
    public class Dingo : Entity {
        public double passedTime = 0;
        public double randomMove = 1000 + World.Rand(-200,200);
        public Dingo( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
        }
        public override void Update( double dt ) {
            passedTime += dt;
            if ( passedTime < randomMove ) {
                return;
            }
            randomMove = 1000 + World.Rand(-200,200);
            passedTime = 0;
            int vert = World.Rand(-1,1);
            int horz = World.Rand(-1,1);
            Vector2 newPos = new Vector2( horz, vert );
            if ( World.Passable( pos + newPos ) ) {
                pos = pos + new Vector2( horz, vert );
            }
        }
    }
}
