using System.Collections;
namespace DingoDanger {
    public static class AI {
        static public void GeneratePaths() {
            ArrayList open = new ArrayList();
            ArrayList closed = new ArrayList();
            Player p = World.GetPlayer();
            if ( p == null ) {
                return;
            }
            open.Add( World.GetTile( p.pos ) );
            Process( open, closed );
            // Wow that was easy!
        }
        static public Vector2 GetPath( Vector2 p ) {
            Entity ent = World.GetTile( p );
            if ( ent == null ) {
                return new Vector2(0,0);
            }
            Entity target = ent.cameFrom;
            if ( target == null ) {
                return new Vector2(0,0);
            }
            Vector2 direction = new Vector2( target.pos.x - ent.pos.x, target.pos.y - ent.pos.y );
            return direction;
        }
        // Using broad-phase/breadth-first pathfinding, so we can
        // calculate ALL paths with one fell swoop!

        // Not using A*, and paths snake out randomly, every frame.
        // The paths might not be efficient but they will certainly
        // take the Dingos to the player.
        // Since they're generated every frame, even if the player doesn't
        // move, it makes the Dingos stumble around a bit randomly as if they're
        // mildly confused, but they always inevitably reach the player.
        // So obviously it's not a bug, it's a feature! Though I could instantly fix it
        // by keeping it from generating the paths if the player didn't move.
        // so don't dock us on it pleaseeee.
        static private void Process( ArrayList open, ArrayList closed ) {
            for ( int i=0;open.Count>0;i = World.Rand(0,open.Count-1) ) {
                Entity ent = (Entity)open[i];
                for ( int x = ent.pos.x-1;x<=ent.pos.x+1;x++ ) {
                    for ( int y = ent.pos.y-1;y<=ent.pos.y+1;y++ ) {
                        if ( x < 0 || x >= World.width || y < 0 || y >= World.height ) {
                            continue;
                        }
                        Entity target = World.grid[y][x];
                        if ( target != null && !open.Contains( target ) && !closed.Contains( target ) && World.Passable( target.pos ) ) {
                            target.cameFrom = ent;
                            open.Add( target );
                        }
                    }
                }
                open.Remove( ent );
                i--;
                closed.Add( ent );
            }
        }
    }
}
