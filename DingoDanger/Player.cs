using System;

namespace DingoDanger {
    public class Player : Entity {
        public Player( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
        }
        public override void Update( double dt ) {
            float vert = -Convert.ToInt32( Keyboard.KeyDown( 65 ) ) + Convert.ToInt32( Keyboard.KeyDown( 66 ) );
            float horz = -Convert.ToInt32( Keyboard.KeyDown( 68 ) ) + Convert.ToInt32( Keyboard.KeyDown( 67 ) );
            pos = pos + new Vector2( horz, vert );
        }
    }
}
