using System;
using CursesSharp;

namespace DingoDanger {
    public class Explosion : Entity {
        public Vector2 direction;
        public Explosion( string spr, int x, int y ) {
            pos = new Vector2( x, y );
            sprite = "•";
            attrs = Attrs.BOLD;
        }
        public int curFrame = 0;
        public static string[] frames = {"•", "*", "`.'\n.%`\n'.`", "*';\n%OX\n+*•" };
        public static int[] killDistance = { 0, 0, 1, 2 };
        public override void Update( double dt ) {
            foreach( Dingo dog in World.DingoCollides( pos, killDistance[curFrame] ) ) {
                dog.Kill();
            }
            sprite = frames[curFrame++];
            color = World.Rand(0,7);
            if (curFrame == frames.Length ) {
                Kill();
            }
        }
        public void Kill() {
            World.Remove( this );
        }
    }
}
