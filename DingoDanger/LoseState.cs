using System;
using System.IO;
using CursesSharp;
using System.Collections.Generic;

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
            Stdscr.Clear();
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
        public void DrawBlock(string text) {
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
            foreach (char line in charList) {
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
