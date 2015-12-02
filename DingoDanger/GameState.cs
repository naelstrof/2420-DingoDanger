using System;

namespace DingoDanger {
    public class GameState : State {
        public override void SetUp() {
            World.LoadFile( "map_01.txt" );
            DogSong.Play();
        }
        public override void TearDown() {
            DogSong.Stop();
        }
        public override void Update( double dt ) {
            World.Update( dt );
        }
        public override void Draw() {
            World.Draw();
        }
    }
}
