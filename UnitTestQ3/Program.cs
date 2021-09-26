using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQ3
{ 
    //Author: Pruthviraj Solanki(Knight)
    //Purpose: Declares a delegate function that impersonates ReadLine function
    class Program
    {
        delegate string readLineFunctionDelegate();

        //Author : Pruthviraj Solanki(Knight)
        //Purpose: Uses the delegate that impersonates ReadLine and takes input form user.
        static void Main(string[] args)
        {
            readLineFunctionDelegate Rline = new readLineFunctionDelegate(Console.ReadLine);
            Console.Write("Please enter a string: ");
            string newString = Rline();
            Console.WriteLine("String that you entered was :\n " + newString);
        }
    }
}