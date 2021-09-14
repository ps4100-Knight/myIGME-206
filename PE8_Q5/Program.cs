using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___Q5
{
    //Author: Pruthviraj Solanki
    //Purpose: A code that solves the formula : z = 3y2 + 2x - 1 
    class Program
    {
        //Author : Pruthviraj Solanki
        //Purpose: Decalres variables to hole values for x,y,z in a 3D double data type array.

        static void Main(string[] args)
        {
            double x = 0;
            double y = 0;
            double z = 0;

            int nX = 0;
            int nY = 0;

            double[,,] zFun = new double[30, 40, 3];

            // loop through each value of x
            for (x = -1; x <= 1; x += 0.1, ++nX)
            {
                x = Math.Round(x, 1);

                nY = 0;

                // loop through each value of y
                for (y = 1; y <= 4; y += 0.1, ++nY)
                {
                    y = Math.Round(y, 1);

                    z = 3 * Math.Pow(y, 2) + 2 * x + 1;

                    z = Math.Round(z, 3);

                    // store x, y and z for this (x,y) value
                    zFun[nX, nY, 0] = x;
                    zFun[nX, nY, 1] = y;
                    zFun[nX, nY, 2] = z;
                }
            }
        }
    }
}
