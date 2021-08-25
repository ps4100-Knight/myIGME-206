using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavoriteColourAndNumber
{
    // Class: Program
    // Authore: Pruthviraj Solanki
    // Purpose: Console Read/Write and Exception-handling exercise
    // Restrictions: none
    class Program
    {
        // Method: Main
        // Purpose: Prompt the user for their favorite color and number
        //          Output their favourite color (in limited text colors) Their favorite number of times
        // Restrictions: none
        static void Main(string[] args)
        {
            // string to hold their favorite color
            string color = null;

            // int to hold thier favorite number
            int favnum = 0;

            // flag to indicae if they entered a valid number string
            bool bValid = false;

            // loop counter
            int i = 0;

            Console.Write("Enter your favorite color:\t");

            color = Console.ReadLine();
        }
    }
}
