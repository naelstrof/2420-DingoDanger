using System;
using CursesSharp;

namespace DingoDanger {
    public class Dingo : Entity {
        public double passedTime = 0;
        public double passedTimeBark = 0;
        public double randomMove = 300 + World.Rand(-200,200);
        public double randomBark = 2000 + World.Rand( -1000, 1000 );
        public Dingo( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
            color = World.Rand(0,7);
        }
        public override void Update( double dt ) {
            passedTime += dt;
			passedTimeBark += dt;
            if ( passedTime < randomMove ) {
                return;
            }
            if (passedTimeBark > randomBark) {
                attrs = Attrs.BOLD;
                sprite = "Bark!";
                passedTimeBark = 0;
                randomBark = 2000 + World.Rand( -1000, 1000 );
            } else {
                attrs = 0;
                sprite = "d";
            }
            randomMove = 300 + World.Rand(-200,200);
            passedTime = 0;
            //int vert = World.Rand(-1,1);
            //int horz = World.Rand(-1,1);
            Vector2 direction = AI.GetPath( pos );
            if ( World.Passable( pos + direction ) ) {
                pos = pos + direction;
            }
        }
        public void Kill() {
            Entity ent = World.GetTile( pos );
            if ( ent != null ) {
                ent.attrs = Attrs.DIM;
                ent.sprite = "p";
                ent.color = 4;
            }
            World.Remove( this );
        }
    }
}
