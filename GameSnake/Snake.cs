using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSnake
{
    class Snake
    {
        public Point GetHeadSnake => Body[0];
        public List<Point> Body { get; set; }
        private Point directionHead;
        public Point DirectionHead
        {
            get => directionHead;
            set
            {
                if (directionHead.X + value.X != 0 || directionHead.Y + value.Y != 0)
                    directionHead = value;
            }
        }
        public Snake(int len, Point startPlace)
        {
            Body = new List<Point>();
            for (int i = 0; i < len; i++)
            {
                Body.Add(new Point(startPlace.X - i, startPlace.Y));
            }
            directionHead = Direction.Right;
        }
        public void Step()
        {
            var prev = Body[0];
            var currend = Body[0];
            int x  = Body[0].X + DirectionHead.X;
            int y = Body[0].Y + DirectionHead.Y;
            Body[0] = new Point(x, y);
            for (var i = 1; i < Body.Count; i++)
            {
                currend = Body[i];
                Body[i] = prev;
                prev = currend;
            }
        }
        public void UpLengthBody(int countToUp)
        {
            for (int i = 0; i < countToUp; i++)
            {
                Body.Add(new Point(-1, -1));
            }
        }

    }
}
