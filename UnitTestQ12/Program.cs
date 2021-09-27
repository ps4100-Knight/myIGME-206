
using System;

namespace UnitTestQ12
{

    // Author :- Pruthviraj Solanki (Knight)
    /* Purpose :- The function increases the salary by $19,999.99 if name = your name and return true
                  Otherwise it returns false.
    The main program congratulates the user if they got a raise, and displays their new salary.*/

    class Program
    {
        // Author :- Pruthviraj Solanki (Knight)
        // Purpose :- A Console application for salary raise for a specific name

        static bool GiveRaise(string name, ref double salary)
        // Function to increase Salary
        {
            if (name.ToLower () == "pruthviraj")
            {
                salary = salary + 19999.99;  // if condition = true increase salary
                return true;
            }

            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;

            Console.WriteLine("Enter Your Name");
            sName = Console.ReadLine();

            if (GiveRaise(sName, ref dSalary) == true)   // checking bool condition, if its true increase salary
            {
                Console.WriteLine("Congratulations, you got salary increase");
                Console.WriteLine("This is your New Salary " + dSalary);
            }
            else // checking bool condition, if its false default salary
            {
                Console.WriteLine("This is your  Salary " + dSalary);
            }

        }
    }
}

