using System;

namespace DingoDanger {
    public class WaterBullet : Entity {
        public Vector2 direction;
        public WaterBullet( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = "~";
            color = 1;
        }
        public override void Update( double dt ) {
            Dingo dog = World.GetDog( pos + direction );
            if ( dog != null ) {
                dog.Kill();
                Kill();
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
