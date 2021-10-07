using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PECLASSLIB;

namespace PE14Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1Obj = new Class1();
            Class2 Class2Obj = new Class2();
            MyMethod(class1Obj);
            MyMethod(Class2Obj);
        }
        public static void MyMethod(Interface1 myObject)
        {

            myObject.method();
        }
    }
}
