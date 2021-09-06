using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            string sStartimagCoord = "null";
            string sStartrealCoord = "null";
            string sEndimagCoord = "null";
            string sEndrealCoord = "null";
            double dStartimagCoord = 0;
            double dStartrealCoord = 0;
            double dEndimagCoord = 0;
            double dEndrealCoord = 0;
            double dDiffimag = 0;
            double dDiffreal = 0;

            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;



            Console.WriteLine("Enter the values for the start and end of imaginary and real coordinates as prompted\n");
            Console.WriteLine("Remember that imagcord must start at higher value than it ends \n");
            Console.WriteLine("Remember that real cord must start at lower value than it ends \n");
            while (true)
            {
                Console.WriteLine("Enter the value for start of imagcoord\n");
                sStartimagCoord = Console.ReadLine();
                dStartimagCoord = Convert.ToDouble(sStartimagCoord);
                Console.WriteLine("Enter the value for end of imagcoord\n");
                sEndimagCoord = Console.ReadLine();
                dEndimagCoord = Convert.ToDouble(sEndimagCoord);
                if( dStartimagCoord > dEndimagCoord)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid values, imagcoord must start at a higer value than it ends\n");
                }
                
            }
            while (true)
            {
                Console.WriteLine("Enter the value for start of realcoord\n");
                sStartrealCoord = Console.ReadLine();
                dStartrealCoord = Convert.ToDouble(sStartrealCoord);
                Console.WriteLine("Enter the value for end of realcoord\n");
                sEndrealCoord = Console.ReadLine();
                dEndrealCoord = Convert.ToDouble(sEndrealCoord);
                if (dStartrealCoord < dEndrealCoord)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid values, realcoord must start at a lower value than it ends\n");
                }

            }
            dDiffimag = (dStartimagCoord - dEndimagCoord) / 48;
            // Console.WriteLine(dDiffimag); just to check if the mechanism is working
            dDiffreal = (dEndrealCoord - dStartrealCoord) / 80;
            for (imagCoord = dStartimagCoord; imagCoord >= dEndimagCoord; imagCoord -= dDiffimag)
            {
                for (realCoord = dStartrealCoord; realCoord <= dEndrealCoord; realCoord += dDiffreal)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}
