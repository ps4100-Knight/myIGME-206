using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string uString = null;
            string rString = null;
            Console.WriteLine("Enter a string which includes word 'no' in it\n the result string will have 'no' replaced by 'yes'\n");
            uString = Console.ReadLine();
            rString = uString.ToLower();
            
            Console.WriteLine("The resulting string is :\n " + rString.Replace("no", "yes");

        }
    }
}
