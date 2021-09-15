using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE9___Q3
{
    //Author: Pruthviraj Solanki(knight)
    //Purpose: Declares a delegate function that impersonates ReadLine function
    class Program
    {
        delegate string readlinefunctionDelegate();

        //Author : Pruthviraj Solanki(Knight)
        //Purpose: Uses the delegate that impersonates ReadLine and takes input form user.
        static void Main(string[] args)
        {
            readlinefunctionDelegate Rline = new readlinefunctionDelegate(Console.ReadLine);
            Console.Write("Please enter a string: ");
            string newString = Rline();
            Console.WriteLine("String that you entered was :\n " + newString);
        }
    }
}
