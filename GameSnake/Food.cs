using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSnake
{
    public class Food
    {
        public int CountScore { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public String Name { get; set; }
        public Food(int x, int y, int countScore, String name)
        {
            Name = name;
            CountScore = countScore;
            X = x;
            Y = y;
        }
    }
}
