using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marksman
{
    internal class GunsInfo
    {
        public readonly static Dictionary<(int, int), double> offsetXWind308 = new()
        {
            { (2, 50), 0.5 },
            { (2, 100), 1 },
            { (2, 150), 2.5 },
            { (2, 200), 4 },
            { (2, 250), 7 },
            { (2, 300), 10 },
            { (2, 350), 15 },
            { (2, 400), 20 },

            { (4, 50), 1 },
            { (4, 100), 2 },
            { (4, 150), 5 },
            { (4, 200), 8 },
            { (4, 250), 14 },
            { (4, 300), 20 },
            { (4, 350), 30 },
            { (4, 400), 40 },

            { (8, 50), 2 },
            { (8, 100), 4 },
            { (8, 150), 11 },
            { (8, 200), 18 },
            { (8, 250), 29 },
            { (8, 300), 40 },
            { (8, 350), 62 },
            { (8, 400), 84 },
        };

        public readonly static Dictionary<int, double> offsetY150m308 = new()
        {
            { 50, 1.8 },
            { 100, 4 },
            { 150, 0 },
            { 200, -7.4 },
            { 250, -22.1 },
            { 300, -43.9 },
            { 350, -80 },
            { 400, -160 },
        };
    }
}
