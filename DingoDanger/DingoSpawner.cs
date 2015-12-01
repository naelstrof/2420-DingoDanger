using System;

namespace DingoDanger {
    public class DingoSpawner : Entity {
        public float passedTime = 0;
        public DingoSpawner( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
        }
        public override void Update( double dt ) {
            passedTime += (float)dt;
            if ( passedTime > 1000 ) {
                World.AddDynamicEntity( new Dingo( "d", (int)pos.x, (int)pos.y ) );
                passedTime = 0;
            }
        }
    }
}
