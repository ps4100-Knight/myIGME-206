using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8__Q9
{
    //Author: Pruthviraj Solanki
    //Purpose: Adds double quoats around all words
    class Program
    {
        //Author: Pruthviraj Solanki
        //Purpose: Prints all the words with double quoats around them
        static void Main(string[] args)
        {
            string uString;
            Console.Write("Enter a string: ");
            uString = Console.ReadLine();

            String[] str = uString.Split(' ');

            foreach (string word in str)
            {
                Console.Write("\"" + word + "\"");
            }
        }
    }
}