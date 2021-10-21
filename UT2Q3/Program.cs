using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2Q3
{
    //Author :- Pruthviaj Solanki (Knight)
    //Purpose 
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0;
            double y = 0;
            double w = -2;
            SortedList<(double, double, double), double> sortedlist = new SortedList<(double, double, double), double>();
            //sortedlist[(0, 0, 0)] = 5;
            //Console.WriteLine(sortedlist[(0,0,0)]);
            for (w = -2; w<=0; Math.Round(w+=0.2,1))
            {
                for (y = -1; y <= 1; Math.Round(y += 0.1, 1))
                {
                    for (x = 0; x<=4; Math.Round(x += 0.1,1))
                    {
                        sortedlist[(w,x,y)] = Math.Round(( (4* Math.Pow(y,3)) + (2* Math.Pow(x,2)) - (8*w) + 7 ),3);
              //          Console.WriteLine(sortedlist[(w, x, y)]);

                    }
                }
            }


        }
    }
}
