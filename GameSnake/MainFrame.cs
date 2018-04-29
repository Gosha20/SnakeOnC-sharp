using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace GameSnake
{
    public partial class MainFrame : Form
    {
        Game game;
        Image back = Image.FromFile(@"C:\Users\gosha\Desktop\projects\GameSnake\SnakeOnC-sharp\GameSnake\sprt\field.png");
        Image snakeBody = Image.FromFile(@"C:\Users\gosha\Desktop\projects\GameSnake\SnakeOnC-sharp\GameSnake\sprt\snakebody.png");
        Timer timer = new Timer();
        int time = 0;
        int dotSize = 30;
        public MainFrame()
        {
            game = new Game(new Point(3,3), 10, 10);
            SetClientSizeCore(game.Height*dotSize, game.Width * dotSize);
            Text = "BIG PYTHON";
            timer.Interval = 500;
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            timer.Tick += Timer_Tick;
            timer.Start();
            KeyDown += MainFrame_KeyDown;
            Paint += MainFrame_Paint;
        }

        private void MainFrame_Paint(object sender, PaintEventArgs e)
        {
            DrawBackground(e.Graphics);
            DrawSnake(e.Graphics);
            DrawFood(e.Graphics);
        }
        private void DrawFood(Graphics g)
        {
            Image food = Image.FromFile(@"C:\Users\gosha\Desktop\projects\GameSnake\SnakeOnC-sharp\GameSnake\sprt\" + game.Food.Name + ".png"); 
            g.DrawImage(food, game.Food.X*dotSize, game.Food.Y * dotSize);
        }
        private void DrawBackground(Graphics g)
        {   

            for (int i = 0; i < game.Height; i++)
                for (int j = 0; j < game.Width; j++)
                    g.DrawImage(back, j * dotSize, i * dotSize);
        }
        private void DrawSnakeHead(Graphics g)
        {
            Image head = Image.FromFile(@"C:\Users\gosha\Desktop\projects\GameSnake\SnakeOnC-sharp\GameSnake\sprt\" + game.Snake.DirectionHead.X + "" + game.Snake.DirectionHead.Y + ".png");
            g.DrawImage(head, game.Snake.Body[0].X * dotSize, game.Snake.Body[0].Y * dotSize);
        }
        private void DrawSnake(Graphics g)
        {
            DrawSnakeHead(g);
            for (int i = 1; (i < game.Snake.Body.Count); i++)
            {
                    g.DrawImage(snakeBody,game.Snake.Body[i].X * dotSize,game.Snake.Body[i].Y * dotSize);
            }
        }
        private void MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down: game.Snake.DirectionHead = Direction.Down; break;
                case Keys.Up: game.Snake.DirectionHead = Direction.Up; break;
                case Keys.Left: game.Snake.DirectionHead = Direction.Left; break;
                case Keys.Right: game.Snake.DirectionHead = Direction.Right; break;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time++;
            game.RefreshField();
            Invalidate();
        }
    }
}
