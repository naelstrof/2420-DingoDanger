using System;

namespace DingoDanger {
    public class Player : Entity {
        public string gun = "Water Gun";
        public Player( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = spr;
        }
        public override void Update( double dt ) {
            // UP 65
            // DOWN 66
            // LEFT 67
            // RIGHT 68
            // W 119
            // A 97
            // S 115
            // D 100

            // Movement
            int vert = -Convert.ToInt32( Keyboard.KeyDown( 119 ) ) + Convert.ToInt32( Keyboard.KeyDown( 115 ) );
            int horz = -Convert.ToInt32( Keyboard.KeyDown( 97 ) ) + Convert.ToInt32( Keyboard.KeyDown( 100 ) );
            Vector2 newPos = new Vector2( horz, vert );
            if ( World.Passable( pos + newPos ) ) {
                pos = pos + new Vector2( horz, vert );
            }

            // Bullets!
            int bv = -Convert.ToInt32( Keyboard.KeyDown( 105 ) ) + Convert.ToInt32( Keyboard.KeyDown( 107 ) );
            int bh = -Convert.ToInt32( Keyboard.KeyDown( 106 ) ) + Convert.ToInt32( Keyboard.KeyDown( 108 ) );
            if ( bv != 0 || bh != 0 ) {
                Shoot( new Vector2( bh, bv ) );
            }
            if ( World.TouchingDog( pos ) ) {
                StateMachine.Switch( new LoseState() );
            }
        }
        public void Shoot( Vector2 dir ) {
            switch( gun ) {
                case "Water Gun": {
                    WaterBullet b = new WaterBullet( "~", pos.x, pos.y );
                    b.direction = dir;
                    World.AddDynamicEntity( b );
                    break;
                                  }
                case "Cannon Gun": {
                    Bullet b = new Bullet( "~", pos.x, pos.y );
                    b.direction = dir;
                    World.AddDynamicEntity( b );
                    break;
                                  }
                case "Confetti Gun": {
                    ExplodeyBullet b = new ExplodeyBullet( "*", pos.x, pos.y );
                    b.direction = dir;
                    World.AddDynamicEntity( b );
                    break;
                                  }
            }
        }
    }
}
