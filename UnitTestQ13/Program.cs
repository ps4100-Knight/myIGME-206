using System;

namespace UnitTestQ13
{
    // Author :- Pruthviraj Solanki (Knight)
    /* Purpose :- The function increases the salary by $19,999.99 if name = your name and return true
                  Otherwise it returns false.
    The main program should congratulate the user if they got a raise, and display their new salary.*/

    struct employee
    {
        // Using structure to do the same thing as Qestion12
        public string sName;  //variable needs to be public so that they can be accessed
        public double dSalary;
    };

    class Program
    {
        // Author :- Pruthviraj Solanki (Knight)
        // Purpose:- Using structure to do the same thing as Question12

        static void Main(string[] args)
        {
            employee e1;
            e1.dSalary = 30000;
            // initialising variables 
            Console.WriteLine("Enter Your Name");
            e1.sName = Console.ReadLine();
            if (GiveRaise(e1) == true) // passing struct object to give raise method
            {
                Console.WriteLine("Congratulations, your salary got increase");
                e1.dSalary += 19999.99;
                Console.WriteLine("This is your New Salary " + e1.dSalary);
            }
            else
            {
                Console.WriteLine("This is your  Salary " + e1.dSalary);
            }
        }

        static bool GiveRaise(employee e)
        // Function to increase Salary
        {
            if (e.sName.ToLower() == "pruthviraj")
            {
                return true;
            }
            else return false;
        }


    }
}