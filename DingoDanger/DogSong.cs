using System;
using System.Media;
using System.IO;

namespace DingoDanger {
    public static class DogSong {
		public static SoundPlayer player;
        public static void Play() {
			int rand = World.Rand (0, 5);
			var file = new FileStream (rand + ".wav", FileMode.Open, FileAccess.Read, FileShare.Read);
            player = new SoundPlayer(file);
            player.PlayLooping();
        }
        public static void Stop() {
            player.Stop();
        }
    }
}
