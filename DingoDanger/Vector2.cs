using System;

namespace DingoDanger {
    public class Vector2 {
        public double x,y;
        public Vector2( double ix, double iy ) {
            x = ix;
            y = iy;
        }
        public static Vector2 operator+( Vector2 a, Vector2 b ) {
            return new Vector2( a.x+b.x, a.y+b.y );
        }
        public static Vector2 operator-( Vector2 a, Vector2 b ) {
            return new Vector2( a.x-b.x, a.y-b.y );
        }
        public static double operator*( Vector2 a, Vector2 b ) {
            return a.x * b.x + a.y * b.y;
        }
        public static Vector2 operator/( Vector2 a, double b ) {
            return new Vector2( a.x/b, a.y/b );
        }
        public double Distance( Vector2 b ) {
            double dx = x-b.x;
            double dy = y-b.y;
            return Math.Sqrt( dx*dx + dy*dy );
        }
    }
}
