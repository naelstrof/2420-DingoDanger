using System;
using System.Collections;
using CursesSharp;

namespace DingoDanger {
    public static class StateMachine {
        public static State currentState;
        public static void Switch( State state ) {
            if (currentState != null ) {
                currentState.TearDown();
            }
            currentState = state;
            currentState.SetUp();
        }
        public static void Update( double dt ) {
            currentState.Update( dt );
        }
        public static void Draw() {
            currentState.Draw();
        }
    }
}
