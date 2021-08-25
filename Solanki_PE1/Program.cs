using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solanki_PE1
{
    // Author : Pruthviraj Solanki (Knight)
    // Purpose: Hello world and a basic calculator just for fun
    class Program
    {
        // Author : Pruthviraj Solanki (Knight)
        // Purpose : Print hello world on the screen
        //           Ask user to enter a number then a basic math function then another number then perform the fuction and display output
        static void Main(string[] args)
        {
        // Author : Pruthviraj Solanki (Knight)
        // Purpose : Main method
        // Restraints : Division by zero not handled among other input errors that might occure 
        // Optimizations :  Could be much more efficiant with switch case or some other means rather than the else if
        //               :  Could use a seperate function that assignes value to a flag variable that can be checked at every step to ensure
        //                  everything is going right and prompt user back to start from the point an invalid input is there rather than checking
        //                  everything in "else"           
        TryAgain:
            int a = 0;
            int b = 0;
            int result = 0;
            string FirstNum = null;
            string SecondNum = null;
            string Operation = null;
            char Opt = 'n';
            Console.WriteLine("Hello World\n");
            Console.WriteLine("Welcome to the calculator\n");
            
            Console.WriteLine(" Enter a number:-\t");
            FirstNum = Console.ReadLine();
            a = Convert.ToInt32(FirstNum);
            // just to check if it was taking the value right
            // Console.WriteLine($"the first number is {a}");
            Console.WriteLine("Enter a basic function (+ , - , * , / )\n");
            Operation = Console.ReadLine();
            Opt = Convert.ToChar(Operation);
            Console.WriteLine("Enter the second number:-\t");
            SecondNum = Console.ReadLine();
            b = Convert.ToInt32(SecondNum);
            if (Opt == '+')
            {
                result = a + b;
            }
            else if (Opt == '-')
            {
                result = a - b;
            }
            else if (Opt == '*')
            {
                result = a * b; 
            }
            else if(Opt == '/')
            {
                result = a / b;
            }
            else
            {
                Console.WriteLine("Something went wrong please try again\n");
                goto TryAgain;
            }
            Console.WriteLine($"The Result is : \t {result}");



        }
    }
}
// PS :- I have pretty good handle on coding, its all matter of syntax to me, I am pretty good at developing solutions to problems
//       also I am good with C and C++ which are kinda like C#. I have tried to keep it simple and didn't go much into the optimized methods to
//       do the same thing, but I surly will put more efforts in making other codes I write more optimized once I get a better handle on C#
