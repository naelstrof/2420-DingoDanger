using System;
using CursesSharp;

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
            if (World.Passable(pos + newPos)) {
                pos = pos + new Vector2(horz, vert);
            }
            else {
                if ((pos + newPos).x > World.width - 3) {
                    if (World.Passable(1, pos.y)) {
                        pos.x = 1;
                    }
                }
                if ((pos + newPos).x <= 0) {
                    if (World.Passable(World.width - 3, pos.y)) {
                        pos.x = World.width - 3;
                    }
                }
                if ((pos + newPos).y >= World.height - 2) {
                    if (World.Passable(pos.x, 2)) {
                        pos.y = 1;
                    }
                }
                if ((pos + newPos).y <= 0) {
                    if (World.Passable(pos.x, World.height - 3)) {
                        pos.y = World.height - 3;
                    }
                }
            }

            // Bullets!
            float bv, bh;
            bv = -Convert.ToInt32( Keyboard.KeyDown( 105 ) ) + Convert.ToInt32( Keyboard.KeyDown( 107 ) );
            bh = -Convert.ToInt32( Keyboard.KeyDown( 106 ) ) + Convert.ToInt32( Keyboard.KeyDown( 108 ) );
            bv += -Convert.ToInt32( Keyboard.KeyDown( 259 ) ) + Convert.ToInt32( Keyboard.KeyDown( 258 ) );
            bh += -Convert.ToInt32( Keyboard.KeyDown( 260 ) ) + Convert.ToInt32( Keyboard.KeyDown( 261 ) );
            if ( Keyboard.MouseDown() && bh == 0 && bv == 0 ){
                Vector2 mp = Keyboard.GetMouse();
                bh = mp.x-pos.x;
                bv = mp.y-pos.y;
            }
            if ( bv != 0 || bh != 0 ) {
                Shoot( (new Vector2f( bh, bv )).Normalize() );
            }
            if ( World.TouchingDog( pos ) ) {
                StateMachine.Switch( new LoseState() );
            }
        }
        public void Shoot( Vector2f dir ) {
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
