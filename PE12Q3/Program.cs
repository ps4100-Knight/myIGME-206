using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE12Q3
{
    //Author: Pruthviraj (knight)
    //Purpose: Derives a class from base class and calls one of its string
    public class MyClass
    {
        protected string myString;
        public string sString
        {
            set
            {
                myString = value;
            }
        }
        public virtual string GetString() => myString;
    }

    class MyDerivedClass : MyClass
    {
        public override string GetString() => base.GetString() + "output from derived class";

        //Author:- Pruthviraj (Knight)
        //Purpose:- calls one of the string from the parent class using an object of base class.
        public static void Main(string[] args)
        {
            MyDerivedClass obj1 = new MyDerivedClass();
            Console.WriteLine(obj1.GetString());
        }
    }
}
