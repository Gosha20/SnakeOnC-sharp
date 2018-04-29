using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Drawing;
namespace GameSnake
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void Test1()
        {
            var game = new Game(new Point(3,3));
            Assert.AreEqual(false, game.GameOver);
        }
        [Test]

        public void Test2()
        {
            var game = new Game(new Point(3,3));
            game.Snake.Body[0] = new Point(2,3);
            
            Assert.AreEqual(true, game.CheckOnEatSelf());
        }
        [Test]

        public void Test3()
        {
            var snake = new Snake(3, new Point(3,3));
            var prevsize = snake.Body.Count;
            snake.UpLengthBody(2);
            foreach (var item in snake.Body)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
            Assert.AreEqual(prevsize + 2,snake.Body.Count);
        }
    }
}
