﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Marksman
{
    internal class SplashScreen
    {
        public static Texture2D Background { get; set; }
        public static SpriteFont Font { get; set; }

        public static Color color;
        public static int timeCounter;
        public static int diff;
    }
}
