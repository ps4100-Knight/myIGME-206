using System;

namespace UT1_BugSquash
{
    //Author:- Pruthviraj Solanki (Knight)
    //Purpose:-Bugsquash from unit test 1
    class Program
    {

        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //int nY syntax error missing ';'
            int nY;
            int nAnswer;

            //Console.WriteLine(This program calculates x ^ y.);
            //syntax error missing quoats 
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //Console.ReadLine();
                //Runtime error/logical error Console.Readline() is not stored anywhere
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
                //} while (int.TryParse(sNumber, out nX)); 
                // Logical error number is stored in nX while it should be in nY
                // also there need to be a '!' in front in order to be able to get out of the loop 
                // logical error
            } while (!int.TryParse(sNumber, out nY));

            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);

            // Console.WriteLine("{nX}^{nY} = {nAnswer}"); this does not print the answer on the screen Syntax/logical error
            Console.WriteLine(nX + "^" + nY + "= " + nAnswer);
        }


        //int Power(int nBase, int nExponent) syntax error, Power nees to be static to be able to referenced without an object of the class
        static int Power(int nBase, int nExponent) 
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //returnVal = 0; logical error, if we return zero, eventually all the reursions end up on nExponent at zero which essentially makes all answer zero
                //and even 0 power of any number is 1 so mathematically it would be wrong
                return 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                 nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //returnVal; syntax error, there should be a key word "return" to return the returnVal variable since method returns an integer
            return returnVal;
        }
    }
}
