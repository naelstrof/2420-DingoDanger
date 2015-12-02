using System;

namespace DingoDanger {
    public class Vector2 {
        public int x,y;
        public Vector2( int ix, int iy ) {
            x = ix;
            y = iy;
        }
        public static Vector2 operator+( Vector2 a, Vector2 b ) {
            return new Vector2( a.x+b.x, a.y+b.y );
        }
        public static Vector2 operator-( Vector2 a, Vector2 b ) {
            return new Vector2( a.x-b.x, a.y-b.y );
        }
        public static int operator*( Vector2 a, Vector2 b ) {
            return a.x * b.x + a.y * b.y;
        }
        public static Vector2 operator*( Vector2 a, int b ) {
            return new Vector2( a.x*b, a.y*b );
        }
        public static bool operator==(Vector2 a, Vector2 b ) {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator!=(Vector2 a, Vector2 b ) {
            return a.x != b.x || a.y != b.y;
        }
        public static Vector2 operator/( Vector2 a, int b ) {
            return new Vector2( a.x/b, a.y/b );
        }
        public double Distance( Vector2 b ) {
            double dx = x-b.x;
            double dy = y-b.y;
            return Math.Sqrt( dx*dx + dy*dy );
        }
    }
}
