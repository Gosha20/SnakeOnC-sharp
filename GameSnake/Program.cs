using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            //var snake = new Snake(3, new Point(3, 3));
            //var prevsize = snake.Body.Count;
            //snake.UpLengthBody(2);
            //foreach (var item in snake.Body)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.ReadLine();
            //snake.Step();
            //snake.Body.ForEach(x => Console.Write(x));
            //Console.ReadLine();
            var form = new MainFrame();
            Application.Run(form);

        }
    }
}
