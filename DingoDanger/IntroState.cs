using System;
using System.IO;
using CursesSharp;
using System.Collections.Generic;

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
            Stdscr.Clear();
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
            int x = 0;
            // This actually removes all new lines
            string[] lines = text.Split( '\n' );
            foreach( string line in lines ) {
                foreach( char c in line.ToCharArray() ) {
                    if ( x >= 80 ) {
                        continue;
                    }
                    if ( y >= 24 ) {
                        break;
                    }
                    try {
                        Stdscr.Add(y, x, c);
                    } catch { }
                    x++;
                }
                x = 0;
                y++;
            }
        }
    }
}
