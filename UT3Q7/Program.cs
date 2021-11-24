using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT3Q7
{
    // Author:- Pruthviraj Solanki
    // Purpose:- Performing the tasks mentioned in question 7
    class Program
    {
        static void Main(string[] args)
        {
            List<Wizard> wizards = new List<Wizard>
            {
                new Wizard("Pruthviraj", 21),
                new Wizard("Akash", 21),
                new Wizard("Krishna", 19),
                new Wizard("nikita", 20),
                new Wizard("Vrunda", 23),
                new Wizard("Shivam", 21),
                new Wizard("Dhara", 19),
                new Wizard("Harshad", 21),
                new Wizard("Zeel", 19),
                new Wizard("Tom", 23),
            };
            Console.WriteLine("Before sorting:\n");
            foreach (var wizard in wizards)
            {
                Console.WriteLine("Name: {0}, Age: {1}", wizard.name, wizard.age);
            }
            wizards.Sort(delegate (Wizard x, Wizard y)
            {
                return x.CompareTo(y);
            });
            Console.WriteLine("After sorting:\n");
            foreach (var wizard in wizards)
            {
                Console.WriteLine("Name: {0}, Age: {1}", wizard.name, wizard.age);
            }
        }
    }
    class Wizard
    {
        public string name;
        public int age;
        public Wizard(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public int CompareTo(Wizard another)
        {
            if (this.age > another.age)
            {
                return 1;
            }
            else if (this.age == another.age)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
