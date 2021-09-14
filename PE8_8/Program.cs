using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_8
{
    // Author :- Pruthviraj Solanki
    // Purpose :- A program that manipulates a string
    class Program
    {
        // Author :- Pruthviraj solanki
        // Purpose :- A method that replaces all 'no' of the string to 'yes'
        static void Main(string[] args)
        {
            //the string user enters
            string uString = null;
            //to store resulting string (to keep users input intact and unmodified)
            string rString = null;
            Console.WriteLine("Enter a string which includes word 'no' in it\n the result string will have 'no' replaced by 'yes'\n");
            uString = Console.ReadLine();
            //converting to lower case
            rString = uString.ToLower();
            //replacing and printing 'no' with 'yes'
            Console.WriteLine("The resulting string is :\n " + rString.Replace("no", "yes"));

        }
    }
}
