using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q5___PE3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number : ");  
            // To get a string value from user and covert it into an integer and store it in a float
            // there could be use of a method called "Tryparse" to check if the entered string is a number or not
            // but I dont fully understand it yet so not going to use it
            float num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number : "); //instruction
            float num2 = Convert.ToInt32(Console.ReadLine());//getting value
            Console.WriteLine("Enter the third number : ");  //instruction
            float num3 = Convert.ToInt32(Console.ReadLine());//getting value
            Console.WriteLine("Enter the forth number : ");  //instruction
            float num4 = Convert.ToInt32(Console.ReadLine());//getting value
            //calculating the answer
            float ans = num1 * num2 * num3 * num4;
            Console.Out.WriteLine("50 plus 25 is " + 50 + 25);
            Console.WriteLine("The product of all 4 numbers is : " + ans);//printing the answer
        }
    }
}