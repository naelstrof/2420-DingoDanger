using System;

namespace DingoDanger {
    public class Vector2f {
        public double x,y;
        public Vector2f( double ix, double iy ) {
            x = ix;
            y = iy;
        }
        public static Vector2f operator+( Vector2f a, Vector2f b ) {
            return new Vector2f( a.x+b.x, a.y+b.y );
        }
        public static Vector2f operator-( Vector2f a, Vector2f b ) {
            return new Vector2f( a.x-b.x, a.y-b.y );
        }
        public static double operator*( Vector2f a, Vector2f b ) {
            return a.x * b.x + a.y * b.y;
        }
        public static Vector2f operator*( Vector2f a, double b ) {
            return new Vector2f( a.x*b, a.y*b );
        }
        public static bool operator==(Vector2f a, Vector2f b ) {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator!=(Vector2f a, Vector2f b ) {
            return a.x != b.x || a.y != b.y;
        }
        public static Vector2f operator/( Vector2f a, double b ) {
            return new Vector2f( a.x/b, a.y/b );
        }
        public double Distance( Vector2f b ) {
            double dx = x-b.x;
            double dy = y-b.y;
            return Math.Sqrt( dx*dx + dy*dy );
        }
        public Vector2f Normalize() {
            double mag = Math.Sqrt( x*x + y*y );
            return new Vector2f( x/mag, y/mag );
        }
        public static explicit operator Vector2( Vector2f foo ) {
            return new Vector2( (int)foo.x, (int)foo.y );
        }
    }
}
