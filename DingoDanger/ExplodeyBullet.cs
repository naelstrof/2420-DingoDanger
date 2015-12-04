using System;
using CursesSharp;

namespace DingoDanger {
    public class ExplodeyBullet : Entity {
        public Vector2f direction;
        public Vector2f realpos;
        public ExplodeyBullet( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            realpos = (Vector2f)pos;
            // Heh, unicode BULLET ;)
            color = 5;
            sprite = "*";
            attrs = Attrs.BOLD;
        }
        public override void Update( double dt ) {
            realpos = realpos + direction;
            pos = (Vector2)realpos;
            Dingo dog = World.GetDog( pos );
            if ( dog != null ) {
                dog.Kill();
                World.AddDynamicEntity( new Explosion( "*", pos.x, pos.y ) );
                Kill();
                return;
            }
            if ( !World.Passable( pos ) ) {
                World.AddDynamicEntity( new Explosion( "*", pos.x, pos.y ) );
                Kill();
                return;
            }
        }
        public void Kill() {
            World.Remove( this );
        }
    }
}
