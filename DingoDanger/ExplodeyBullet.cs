using System;
using CursesSharp;

namespace DingoDanger {
    public class ExplodeyBullet : Entity {
        public Vector2 direction;
        public ExplodeyBullet( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            // Heh, unicode BULLET ;)
            color = 5;
            sprite = "*";
            attrs = Attrs.BOLD;
        }
        public override void Update( double dt ) {
            Dingo dog = World.GetDog( pos + direction );
            if ( dog != null ) {
                dog.Kill();
                World.AddDynamicEntity( new Explosion( "*", pos.x, pos.y ) );
                Kill();
                return;
            }
            if ( !World.Passable( pos + direction ) ) {
                World.AddDynamicEntity( new Explosion( "*", pos.x, pos.y ) );
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
