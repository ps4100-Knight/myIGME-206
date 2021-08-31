using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            //int i = 0 missing semicolan also made it double to print decimal points in answers
            double i = 0;
            string allNumbers = null;
            // loop through the numbers 1 through 10
            //for (i = 1; i < 10; ++i) need " = " to run the loop 10th time
            for (i = 1; i <= 10; ++i)
            {
                // declare string to hold all numbers
                //string allNumbers = null; need allNumbers outside the for loop scope to print it

                // output explanation of calculation
                //Console.Write(i + "/" + i - 1 + " = "); syntax errors related to the parenthesis 
                Console.Write(i + "/(" + i + "- 1)" + " = ");

                // output the calculation based on the numbers
                // Console.WriteLine(i / (i - 1)); need to handle divide by zero with try and catch / can also be done by making i into double data type
                try
                {
                    Console.WriteLine(i / (i - 1));
                }
                catch
                {
                    Console.WriteLine("Infinity");
                }
                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                //i = i + 1; dont need extra increment 
            }

            // output all numbers which have been processed
           //Console.WriteLine("These numbers have been processed: " allNumbers); missing plus to add the allNumbers value in printing
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}
