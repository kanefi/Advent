using System;
using System.Collections.Generic;
using System.IO;


namespace Day1
{
    
    
    
    
    
    class Program
    {
        // CODING PROBLEM
        // Find the two entries that sum to 2020 and then multiply those two numbers together.

        //// declare the target int 2020
        //// declare a dictionary to hold the two ints we are checking
        //// iterate through the 'list', 2020 - i check equals current number
        //// need two numbers - the number you are checking and i (current position)
        //// also need to input the 'list' of numbers

        // changing from array to list as length unknown
        static void Main(string[] args)
        {
            string line;
            List<int> parsedNumbers = new List<int>();

            //Open the file handle
            System.IO.StreamReader file =
               new System.IO.StreamReader("Input1.txt");

            //Read in the next line, cancel if there is no next line
            while ((line = file.ReadLine()) != null)
            {
                int number = 0;
                if (int.TryParse(line, out number))
                    parsedNumbers.Add(number);
            }

            int[] result = parsedNumbers.ToArray();


            const int target = 2020;

            var numsToAdd = AddTwoNum(result, target);

            Console.WriteLine(value: numsToAdd == null ? "no result" : $"Two numbers that add up to to 2020 are: {numsToAdd[0]}, {numsToAdd[1]}");

            var threeNumsToAdd = AddThreeNum(result);
            //    Console.WriteLine(value: threeNumsToAdd == null ? "no result" : $"Three numbers that add up to 2020 are: {threeNumsToAdd[0]}, {threeNumsToAdd[1]}, {threeNumsToAdd[2]}");
            //
        }

        public static int[] AddTwoNum(int[] numbers, int target)
        {
            var test = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var key = target - numbers[i];             // key = 2020 - index
                if (test.ContainsKey(key))
                {
                    return new[] { test[key], i };
                }
                test.Add(numbers[i], i);
            }
            return null;

        }
        // PART 2
        // Using the above example again, the three entries that sum to 2020 are 979, 366, and 675.Multiplying them together produces the answer, 241861950.

        //In your expense report, what is the product of the three entries that sum to 2020 ?

        // removed int
        public static int[] AddThreeNum(int[]numbers)
        {

            int arr1 = numbers.Length;

            for (int num1 = 0; num1 < arr1; num1++)
            {
                int firstNum = Convert.ToInt32(numbers[num1]);//get first number
                for (int num2 = 0; num2 < arr1; num2++)
                {
                    int secondNum = Convert.ToInt32(numbers[num2]);//get second number
                    for (int num3 = 0; num3 < arr1; num3++)
                    {
                        int thirdNum = Convert.ToInt32(numbers[num3]); // get third number
                        if (firstNum + secondNum + thirdNum == 2020)
                        {
                            Console.WriteLine("Three numbers that add up to 2020 are: {0} + {1} + {2} = 2020", firstNum, secondNum, thirdNum);
                            Console.WriteLine("The multiple of those numbers is: {0} * {1} * {2} = {3}", firstNum, secondNum, thirdNum, firstNum * secondNum * thirdNum);
                            Console.WriteLine("\n");

                        }
                    }
                }
            }
            return null;


            //Console.WriteLine("Task complete");

        }
    }
}