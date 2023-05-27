using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Marksman
{
    internal class Shop
    {
        public static List<Button> Options { get; set; }

        public static bool HasSand { get; set; } = false;
        public static bool HasForest { get; set; } = false;
    }
}
