using System;

namespace DingoDanger {
    public class Bullet : Entity {
        public Vector2 direction;
        public int penetration = 3;
        public Bullet( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            // Heh, unicode BULLET ;)
            sprite = "•";
        }
        public override void Update( double dt ) {
            Dingo dog = World.GetDog( pos + direction );
            if ( dog != null ) {
                dog.Kill();
                if ( --penetration == 0 ) {
                    Kill();
                }
                return;
            }
            if ( !World.Passable( pos + direction ) ) {
                Kill();
                return;
            }
            pos = pos + direction;
        }
        public void Kill() {
            World.Remove( this );
        }
    }
}
