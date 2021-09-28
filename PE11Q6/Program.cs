using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    class Program
    {
        static void Main(string[] args)
        {
            AddPassenger(new Class1.Compact());
            AddPassenger(new Class1.SUV());
      
        }
        static void AddPassenger(Class1.IPassengerCarrier Vehicle)
        {
            
            Console.WriteLine(Vehicle.ToString());
        }
    }
}