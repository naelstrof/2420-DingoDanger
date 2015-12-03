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
            List<char> charList = new List<char>();
            foreach (char character in text.ToCharArray()) {
                if (character != '\n') { 
                charList.Add(character);
                }
            }
            for (int i = 1; i < 24; i++) {
                int remover = i * 80;
                charList.RemoveAt(remover);
            }
            foreach( char line in charList ) {
                try {
                    Stdscr.Add(y, x, line);
                }
                catch { }
                x++;
                if (x == 80) {
                    y++;
                    x = 0;
                }
            }
        }
    }
}
