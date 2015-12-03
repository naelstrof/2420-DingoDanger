using System;
using CursesSharp;

namespace DingoDanger {
    public class GameState : State {
        public override void SetUp() {
            int rand = World.Rand(1,3);
            World.LoadFile( "map_0" + rand + ".txt" );
            DogSong.Play();
        }
        public override void TearDown() {
            World.Clear();
            Stdscr.Clear();
            DogSong.Stop();
        }
        public override void Update( double dt ) {
			AI.GeneratePaths ();
            World.Update( dt );
        }
        public override void Draw() {
            World.Draw();
        }
    }
}
