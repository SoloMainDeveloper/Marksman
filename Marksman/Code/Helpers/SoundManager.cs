using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;

namespace Marksman
{
    internal class SoundManager
    {
        private static Song[] music = new[]
        {
            Textures.MainMusic, Textures.Metallica, Textures.SoaD, 
        };
        private static bool IsPlaying = false;
        private static int currentSongIndex;

        public static void PlayNextSong()
        {
            IsPlaying = !IsPlaying;
            if (IsPlaying)
            {
                currentSongIndex = (currentSongIndex + 1) % music.Length;
                MediaPlayer.Play(music[currentSongIndex]);
            }
            else
                MediaPlayer.Stop();
        }
    }
}
