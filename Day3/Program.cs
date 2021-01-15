using System;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        //slide down a hill and counting trees by map
        static int Part1(int xMove = 3, int yMove = 1)
        {
            string[] map = File.ReadAllLines("Input3.txt");

            int x = 0, y = 0, trees = 0;

            while (y < map.Length)
            {
                if (map[y][x] == '#')
                {
                    trees++;
                }

                x = x + xMove;

                y = y + yMove;

                if (x > 30)
                {
                    x = x - 31;
                }
            }
            return trees;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("You hit {0} trees!", Part1());

            // PART 2
            Int64 total = Part1(1, 1);
            total = total * Part1(3, 1);
            total = total * Part1(5, 1);
            total = total * Part1(7, 1);
            total = total * Part1(1, 2);

            Console.WriteLine("You hit {0} trees.", total);
        }
    }
}



// What do you get if you multiply together the number of trees encountered on each of the listed slopes?
// Right 1, down 1.
//Right 3, down 1. (This is the slope you already checked.)
//Right 5, down 1.
//Right 7, down 1.
//Right 1, down 2.


// ALTERNATIVE SOLUTION
//namespace Day3
//{
//    class Program
//    {
//        //char Tree = '#';
//        public static int GiveMeTheAnswer() => File.ReadAllLines("Input3.txt").Skip(1).Select((row, i) => row[(i + 1) * 3 % row.Length].Equals('#') ? 1 : 0).Sum();


//        static void Main(string[] args)
//        {
//            Console.WriteLine("There are {0} trees.", GiveMeTheAnswer());
//        }
//    }
//}



