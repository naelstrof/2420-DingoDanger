using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DingoDanger {
    public static class World {
        // Initialize each row.
        public static int width;
        public static int height;
        public static Random rng = new Random();
        public static Entity[][] grid;
        private static LinkedList<Entity> dyna = new LinkedList<Entity>();
        public static LinkedList<Entity> merge = new LinkedList<Entity>();
        public static LinkedList<LinkedListNode<Entity>> removeQueue = new LinkedList<LinkedListNode<Entity>>();
        public static int Rand(int min, int max) {
            return rng.Next (min, max+1);
        }
        public static void Update( double dt ) {
            // We can't modify the list while enumerating, so I
            // do this merge mumbo jumbo as a work-around.
            foreach( LinkedListNode<Entity> node in removeQueue ) {
                dyna.Remove( node );
            }
            removeQueue = new LinkedList<LinkedListNode<Entity>>();
            dyna = new LinkedList<Entity>(dyna.Concat(merge));
            merge = new LinkedList<Entity>();
            foreach( Entity ent in dyna ) {
                ent.Update( dt );
            }
        }
        public static void AddDynamicEntity( Entity ent ) {
            merge.AddLast( ent );
        }
        public static void Clear() {
            dyna = new LinkedList<Entity>();
            merge = new LinkedList<Entity>();
            grid = null;
            width = 0;
            height = 0;
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
                if ( sprite == 'd' ) {
                    dyna.AddLast( new DingoSpawner( " ", x, y ) );
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
            if ( x >= width || x < 0 ) {
                return false;
            }
            if ( y >= height || y < 0 ) {
                return false;
            }
            return grid[y][x].sprite == " ";
        }
        public static bool Passable( Vector2 p ) {
            return Passable( p.x, p.y );
        }
        public static bool TouchingDog( Vector2 p ) {
            foreach( Entity dog in dyna ) {
                if ( !(dog is Dingo) ) {
                    continue;
                }
                if ( dog.pos == p ) {
                    return true;
                }
            }
            return false;
        }
        public static void Remove( Entity ent ) {
            LinkedListNode<Entity> node = dyna.Find( ent );
            if ( node != null && !removeQueue.Contains( node ) ) {
                removeQueue.AddFirst( node );
            }
        }
        public static Dingo GetDog( Vector2 p ) {
            foreach( Entity dog in dyna ) {
                if ( !(dog is Dingo) ) {
                    continue;
                }
                if ( dog.pos == p ) {
                    return (Dingo)dog;
                }
            }
            return null;
        }
        public static Entity GetTile( Vector2 p ) {
            if ( p.x >= width || p.x < 0 ) {
                return null;
            }
            if ( p.y >= height || p.y < 0 ) {
                return null;
            }
            return grid[p.y][p.x];
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
