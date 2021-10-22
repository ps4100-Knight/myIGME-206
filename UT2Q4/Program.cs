﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2Q4
{
    
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber;

        public abstract void Connect();

        public abstract void Disconnect();
    }

    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    public class RotaryPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }

        public void MakeCall()
        {

        }

        public void HangUp()
        {

        }

        public override void Connect()
        {

        }

        public override void Disconnect()
        {

        }
    }

    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }

        public void MakeCall()
        {

        }

        public void HangUp()
        {

        }

        public override void Connect()
        {

        }

        public override void Disconnect()
        {

        }
    }

    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        public byte WhichDrWho
        {
            get;
        }

        public string FemaleSideKick
        {
            get;
        }

        public void TimeTravel()
        {

        }
        public static bool operator ==(Tardis t1, Tardis t2)
        {
            bool status = false;
            if (t1.whichDrWho == t2.whichDrWho)
            {

                status = true;
            }
            return status;
        }
        public static bool operator !=(Tardis t1, Tardis t2)
        {
            bool status = false;
            if (t1.whichDrWho != t2.whichDrWho)
            {

                status = true;
            }
            return status;
        }
        public static bool operator <(Tardis t1, Tardis t2)
        {
            bool status = false;
            if (t1.whichDrWho == 10)
            {
                status = false;
            }
            else if (t2.whichDrWho == 10)
            {
                status = true;
            }
            else if (t1.whichDrWho < t2.whichDrWho)
            {
                status = true;
            }
            return status;
        }
        public static bool operator >(Tardis t1, Tardis t2)
        {
            bool status = false;
            if(t1.whichDrWho == 10)
            {
                status = true;
            }
            else if (t2.whichDrWho == 10)
            {
                status = false;
            }
            else if (t1.whichDrWho > t2.whichDrWho)
            {
                status = true;
            }
            return status;
        }
        public static bool operator <=(Tardis t1, Tardis t2)
        {
            bool status = false;
            if (t1.whichDrWho == 10)
            {
                status = false;
            }
            else if (t2.whichDrWho == 10)
            {
                status = true;
            }
            else if (t1.whichDrWho <= t2.whichDrWho)
            {
                status = true;
            }
            return status;
        }
        public static bool operator >=(Tardis t1, Tardis t2)
        {
            bool status = false;
            if (t1.whichDrWho == 10)
            {
                status = true;
            }
            else if (t2.whichDrWho == 10)
            {
                status = false;
            }
            else if (t1.whichDrWho >= t2.whichDrWho)
            {
                status = true;
            }
            return status;
        }
    }

    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneCall;

        public void OpenDoor()
        {

        }

        public void CloseDoor()
        {

        }
    }
}