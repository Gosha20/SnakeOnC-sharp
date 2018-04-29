using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameSnake
{
    class Direction
    {
        public static Point Up = new Point(0,-1);
        public static Point Down = new Point(0, 1);
        public static Point Right = new Point(1, 0);
        public static Point Left = new Point(-1, 0);
    }
}
