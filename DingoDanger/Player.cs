using System;

namespace DingoDanger {
    public class Player : Entity {
        public Player( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
        }
        public override void Update( double dt ) {
            int vert = -Convert.ToInt32( Keyboard.KeyDown( 65 ) ) + Convert.ToInt32( Keyboard.KeyDown( 66 ) );
            int horz = -Convert.ToInt32( Keyboard.KeyDown( 68 ) ) + Convert.ToInt32( Keyboard.KeyDown( 67 ) );
            Vector2 newPos = new Vector2( horz, vert );
            if ( World.Passable( pos + newPos ) ) {
                pos = pos + new Vector2( horz, vert );
            }
            if ( World.TouchingDog( pos ) ) {
                StateMachine.Switch( new LoseState() );
            }
        }
    }
}
