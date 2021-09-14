using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___Q7
{
    //Author: Pruthviraj Solanki
    //Purpose: To reverse the characters in a string
    class program
    {
        //Author: Pruthviraj Solanki
        //Purpose: Reads the input string from user and reverses all the characters 
        static void Main(string[] args)
        {
            //variables
            string oString = null;
            string nString = null;
            int sLength = 0;
            // Reading input from user
            Console.Write("Enter the string: ");
            oString = Console.ReadLine();

            sLength = oString.Length - 1;
            //Inverting the string
            for (int i = sLength; i >= 0; i--)
            {
                nString += oString[i];
            }

            Console.WriteLine("Your reverse order string is:" + nString);
        }
    }
}