using System;
using System.Collections;
using CursesSharp;

namespace DingoDanger {
    public static class StateMachine {
        public static State currentState;
        public static State switchTo;
        public static void Switch( State state ) {
            switchTo = state;
        }
        public static void Update( double dt ) {
            if ( switchTo != null ) {
                if (currentState != null ) {
                    currentState.TearDown();
                }
                currentState = switchTo;
                currentState.SetUp();
                switchTo = null;
            }
            currentState.Update( dt );
        }
        public static void Draw() {
            currentState.Draw();
        }
    }
}
