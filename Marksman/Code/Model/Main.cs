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
        public static GameState state = GameState.SplashScreen;
        public static int Level = 0;
    }
}
