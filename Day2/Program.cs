using System;
using System.Linq;
using System.Collections.Generic;
using Day2;

namespace Day2
{

    class PasswordPolicy
    {
        //1-13 r: gqdrspndrpsrjfjx
        public int max { get; set; }
        public int min { get; set; }
        public char character { get; set; }
        public string password { get; set; }
    }

    class Program
    {
        public static int Part1()
        {

            string[] passwords = System.IO.File.ReadAllLines("Input2.txt");
            char[] separator = { ' ' };
            int counter = 0;

            foreach (string p in passwords)
            {
                string[] str = p.Split(separator);

                PasswordPolicy pp = new PasswordPolicy();

                string[] quantity = str[0].Split("-");
                pp.min = Convert.ToInt32(quantity[0]);
                pp.max = Convert.ToInt32(quantity[1]);
                pp.character = str[1][0];
                pp.password = str[2];

                // count occurrence of char in string
                int count = pp.password.Count(x => x == pp.character);

                if (count >= pp.min && count <= pp.max)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static int Part2()
        {
            string[] passwords = System.IO.File.ReadAllLines("Input2.txt");
            char[] separator = { ' ' };
            int counter = 0;

            foreach (string p in passwords)
            {
                string[] str = p.Split(separator);
                PasswordPolicy pp = new PasswordPolicy();

                string[] quantity = str[0].Split("-");
                pp.min = Convert.ToInt32(quantity[0]);
                pp.max = Convert.ToInt32(quantity[1]);
                pp.character = str[1][0];
                pp.password = str[2];

                char firstChar = pp.password[pp.min - 1];
                char secondChar = pp.password[pp.max - 1];

                if (firstChar != secondChar && firstChar == pp.character || secondChar != firstChar && secondChar == pp.character)
                {
                    counter++;
                }
            }
            return counter;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("There are {0} passwords matching the policy.", Part1());
            Console.WriteLine("There are {0} passwords matching the new policy.", Part2());
        }
    }
}
