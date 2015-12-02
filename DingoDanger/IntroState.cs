using System.IO;
using CursesSharp;

namespace DingoDanger {
    public class IntroState : State {
        public string intro1;
        public string intro2;
        public double passedTime;
        public bool display;
        public override void SetUp() {
            intro1 = File.ReadAllText( "intro_01.txt" );
            intro2 = File.ReadAllText( "intro_02.txt" );
        }
        public override void TearDown() {
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
                DrawBlock( intro1 );
                return;
            }
            DrawBlock( intro2 );
        }
        public void DrawBlock( string text ) {
            int y = 0;
            foreach( string line in text.Split('\n') ) {
                Stdscr.Add( y, 0, line );
                y++;
            }
        }
    }
}
