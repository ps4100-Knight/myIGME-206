using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Author:- Pruthviraj Solanki (Knight)
            // Purpose:- Number guessing game.
            Random rand = new Random();
            int num = 0; //to store the randome number
            int flag = 0;
            int guessedNum = 0;
            // generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(0, 101);
            num = randomNumber;
       //     Console.WriteLine("Number to be guessed:-" + num); //To print the number thats been generated useful only for testing
            while (flag <= 8)//loop for 8 guessing attempts
            {
                if(flag == 8)
                {
                    Console.WriteLine("You have used maximum number of attempts to guess the number\n");
                    break; //breaking the loop when 8 attempts are done and printing the message.
                }
                while (true) //for valid input only
                {
                    Console.WriteLine("Guess the number which is between 0 to 100\n");
                    guessedNum = Convert.ToInt32(Console.ReadLine());
                    if (guessedNum >= 0 && guessedNum <= 100)
                    {
                        Console.WrtieLine("Invalid Guess\n");
                        break;
                    }
                }
                if(guessedNum == num) //guessed number is correct 
                {
                    Console.Write("Congratualtions you gussed the number\n");
                    break;
                }
                else if (guessedNum <= num) //guessed number is less than the correct number
                {
                    Console.Write("Go higher\n");
                    flag++;
                }
                else //guessed number is greater than the correct number
                {
                    Console.Write("Go Lower\n");
                    flag++;
                }
                
            }
            flag++;//flag it to be incremented before printing as the flag in loop starts from 0 
            Console.WriteLine("You used " + flag + "attempts\n");
        }
    }
}
