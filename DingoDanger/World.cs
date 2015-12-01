using System.Collections.Generic;
using System.IO;
using CursesSharp;

namespace DingoDanger {
    public static class World {
        // Initialize each row.
        public static int width;
        public static int height;
        public static Entity[][] grid;
        public static LinkedList<Entity> dyna = new LinkedList<Entity>();
        public static void Update( double dt ) {
            foreach( Entity ent in dyna ) {
                ent.Update( dt );
            }
        }
        public static void Load( string map ) {
            // Get the width and height of our new map.
            width = map.IndexOf('\n');
            height = map.Split('\n').Length;
            grid = new Entity[height][];
            int x = 0;
            int y = 0;
            // Allocate our first row.
            grid[y] = new Entity[width];
            // Not unicode-safe but I don't carEEE
            foreach( char sprite in map ) {
                // If we've reached a new line, we're on a new row!
                if ( sprite == '\n' ) {
                    y++;
                    grid[y] = new Entity[width];
                    x = 0;
                    continue;
                }
                if ( sprite == '@' ) {
                    dyna.AddLast( new Player( sprite.ToString(), x, y ) );
                    grid[y][x] = new Entity( " ", x, y );
                    x++;
                    continue;
                }
                // Got an actual sprite
                grid[y][x] = new Entity( sprite.ToString(), x, y );
                x++;
            }
        }
        public static bool Passable( int x, int y ) {
            return grid[y][x].sprite != "#";
        }
        public static bool Passable( Vector2 p ) {
            return grid[(int)p.y][(int)p.x].sprite != "#";
        }
        public static void LoadFile( string path ) {
            Load( File.ReadAllText( path ) );
        }
        public static void Draw() {
            // Loop through each column, then nestedly loop through each element in the column.
            // This will draw the "map".
            for (int x=0;x<width;x++ ) {
                for (int y=0;y<height;y++ ) {
                    Entity ent = grid[y][x];
                    if ( ent != null ) {
                        ent.Draw();
                    }
                }
            }
            // Now for everything that moves. They will draw over the map.
            foreach( Entity ent in dyna ) {
                ent.Draw();
            }
        }
    }
}
