using System;

namespace DingoDanger {
    public class Bullet : Entity {
        public int penetration = 3;
        public Vector2f direction;
        public Vector2f realpos;
        public Bullet( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            realpos = (Vector2f)pos;
            // Heh, unicode BULLET ;)
            // Aw just kidding, since cmd.exe doesn't support string printing...
            sprite = "o";
            //sprite = "•";
        }
        public override void Update( double dt ) {
            realpos = realpos + direction;
            pos = (Vector2)realpos;
            Dingo dog = World.GetDog( pos );
            if ( dog != null ) {
                dog.Kill();
                if ( --penetration == 0 ) {
                    Kill();
                }
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
