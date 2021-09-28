using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Class1
    {
        public abstract class Vehicle
        {
        }
        public abstract class Car : Vehicle
        {
        }
        public abstract class Train : Vehicle
        {
        }
        public interface IPassengerCarrier
        {
            public virtual void LoadPassenger() { }
        }
        public interface IHeavyLoadCarrier
        {
        }
        public class SUV : Car, IPassengerCarrier
        {
        }
        public class Pickup : Car, IPassengerCarrier, IHeavyLoadCarrier
        {
        }
        public class Compact : Car, IPassengerCarrier
        {
        }
        public class PassengerTrain : Train, IPassengerCarrier
        {
        }
        public class FreightTrain : Train, IHeavyLoadCarrier
        {
        }
        public class T424DoubleBogey : Train, IHeavyLoadCarrier
        {
        }
    }
}
