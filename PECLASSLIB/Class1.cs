using System;

namespace PECLASSLIB
{
    public interface Interface1
    {
        public void method();
       
    }
    public class Class1 : Interface1
    {
        public void method()
        {
            Console.WriteLine("Method inside Class 1\n");
        }
    }
    public class Class2 : Interface1
    {
        public void method()
        {
            Console.WriteLine("Method inside Class 1\n");
        }
    }
}
