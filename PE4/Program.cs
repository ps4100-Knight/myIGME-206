using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4
{
    // Problem statement :- Write a console application that includes the logic from Exercise 1, that obtains two numbers from the user
    //                      and displays them, but rejects any input where both numbers are greater than 10 and asks for two new numbers.
    class Program
    {
        // Author:- Pruthviraj solanki (Knight)
        // Purpose:- To create the solution asked in problem statement.
        static void Main(string[] args)
        {
            int num1 = 0; //to store number 1
            int num2 = 0; //to store number 2
            string snum1 = "null"; //to read number 1
            string snum2 = "null"; //to read number 2
            bool result = false; //for the ex-or
            //message to the user
            Console.WriteLine("Enter two integers when asked, this program mimics the EX-OR gate, if both your entered numbers are greater than 10 you will be asked to enter again\n");
            //keep the loop running till a valid input
            while (true)
            {
                Console.WriteLine("Enter the first number\n"); //message to user
                snum1 = Console.ReadLine(); //read number 1
                Console.WriteLine("Enter the second number\n"); //messasge to user
                snum2 = Console.ReadLine(); //read number 2
                num1 = Convert.ToInt32(snum1); //assign the string to int
                num2 = Convert.ToInt32(snum2); //assign the string to int
                result = (num1 > 10) ^ (num2 > 10); //EX-OR function for the result boolean 
                if (result) //if the result is true in case any one of the number is greater than 10
                {
                    Console.WriteLine("One of the number you entered is greater than 10\n" + result);
                    break; //break the loop as its a valid input if this is the result
                }
                // the Ex-Or returns false in two cases if both the arguments are false or both the arguments are true, to check if both the arguments are true its easy to check manually 
                else if (num1 > 10 && num2 > 10) // if both numbers are greater than 10 display the message to inform user and let the loop continue 
                {
                    Console.WriteLine("Both numbers are greater than 10, please enter numbers again\n" + result); 
                }
                else // the only case left to check after if and else if is that of both flase arguments which is handled here and loop is broken 
                {
                    Console.WriteLine("Both numbers are less than 10\n" + result);
                    break;
                }
            }
        }
    }
}
