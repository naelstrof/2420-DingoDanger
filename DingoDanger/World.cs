using System.IO;
using CursesSharp;

namespace DingoDanger {
    public class World {
        // Initialize each row.
        public int width;
        public int height;
        public Entity[][] grid;
        public World(string path) {
            LoadFile(path);
        }
        public void Load( string map ) {
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
                // Got an actual sprite
                grid[y][x] = new Entity( sprite.ToString(), x, y );
                x++;
            }
        }
        public void LoadFile( string path ) {
            Load( File.ReadAllText( path ) );
        }
        public void Draw() {
            // Loop through each column, then nestedly loop through each element in the column.
            for (int x=0;x<width;x++ ) {
                for (int y=0;y<height;y++ ) {
                    Entity ent = grid[y][x];
                    if ( ent != null ) {
                        AddStr( y, x, ent.sprite );
                    }
                }
            }
        }
        private static void AddStr(int y, int x, string str)
        {
            if (x >= 0 && x < Curses.Cols && y >= 0 && y < Curses.Lines)
                Stdscr.Add(y, x, str);
        }
    }
}
