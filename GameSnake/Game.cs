using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameSnake
{
    class Game
    {
        public int Score { get; private set; }
        public Snake Snake { get; private set; }
        public bool GameOver { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public Food Food { get; private set; }
        private Random rnd = new Random();
        public Game(Point startPlace, int h = 4, int w = 4)
        {
            Snake = new Snake(3, startPlace);
            Height = h;
            Width = w;
            Food = new Food(1,1,5, "apple");
        }

        public void RefreshField()
        {
            if (!GameOver)
            {
                Snake.Step();
                GameOver = CheckOnEatSelf() || CheckOnWall();
                if (IsEatFood())
                {
                    EatFood();
                    RespawnFood();
                }
            }
        }

        public bool CheckOnEatSelf()
        {
            var head = Snake.GetHeadSnake;
            var index = Snake.Body.FindLastIndex(point => head.X == point.X && head.Y == point.Y);
            return index != 0;
        }
        public bool CheckOnWall() => Snake.GetHeadSnake.X > Width || Snake.GetHeadSnake.X < 0 || Snake.GetHeadSnake.Y > Height || Snake.GetHeadSnake.Y < 0;
        public void EatFood()
        {
            Score += Food.CountScore;
            Snake.UpLengthBody(Food.CountScore);
        }
        public void RespawnFood() => Food = new Food(rnd.Next(0, Width - 1), rnd.Next(0, Height - 1), rnd.Next(5), "apple");
        public bool IsEatFood() => Snake.GetHeadSnake.X == Food.X && Snake.GetHeadSnake.Y == Food.Y;
    }
}
