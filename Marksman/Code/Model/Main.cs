using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marksman
{
    internal class Main
    {
        public static Microsoft.Xna.Framework.Content.ContentManager Content { get; set; }
        public static int Level;
        public static GameState State = GameState.SplashScreen;
        public readonly static int WindowWidth = 1920;
        public readonly static int WindowHeight = 1080;
        public readonly static int CenterX = WindowWidth / 2;
    }
}
