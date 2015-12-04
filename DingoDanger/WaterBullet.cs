using System;

namespace DingoDanger {
    public class WaterBullet : Entity {
        public Vector2f direction;
        public Vector2f realpos;
        public WaterBullet( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            realpos = (Vector2f)pos;
            sprite = "~";
            color = 1;
        }
        public override void Update( double dt ) {
            realpos = realpos + direction;
            pos = (Vector2)realpos;
            Dingo dog = World.GetDog( pos );
            if ( dog != null ) {
                dog.Kill();
                Kill();
                return;
            }
            if ( !World.Passable( pos ) ) {
                Kill();
                return;
            }
        }
        public void Kill() {
            World.Remove( this );
        }
    }
}
