using System;
using System.IO;
using CursesSharp;

namespace DingoDanger {
    public class LoseState : State {
        public string lose1;
        public string lose2;
        public double passedTime;
        public bool display;
        public override void SetUp() {
            lose1 = File.ReadAllText( "lose_01.txt" );
            lose2 = File.ReadAllText( "lose_02.txt" );
            DogSong.Lose();
        }
        public override void TearDown() {
            DogSong.Stop();
        }
        public override void Update( double dt ) {
            passedTime += dt;
            if ( passedTime > 250 ) {
                display = !display;
                passedTime = 0;
            }
            if ( Keyboard.KeyDown( 10 ) ) {
                StateMachine.Switch( new GameState() );
            }
        }
        public override void Draw() {
            if ( display ) {
                DrawBlock( lose1 );
                return;
            }
            DrawBlock( lose2 );
        }
        public void DrawBlock( string text ) {
            int y = 0;
            foreach( string line in text.Split('\n') ) {
                try {
                    Stdscr.Add( y, 0, line );
                } catch( Exception e ) {
                    // Don't error out just because you miss a few characters lmaoo
                }
                y++;
            }
        }
    }
}
