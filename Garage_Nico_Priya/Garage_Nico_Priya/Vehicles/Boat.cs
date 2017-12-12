using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Nico_Priya.Vehicles
{
    /// <summary>
    /// Subclass that inherites from the vehicle and add a new properity.
    /// </summary>
    public class Boat : Vehicle
    {
        private int length;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }


        //Creating a default constructor
        public Boat() { }

        public Boat(string regNr, string color, int numberOfWheels, int length) : base(regNr, color, numberOfWheels)
        {
            Length = length;
        }
        public override string ToString()
        {
            return "Registration number " + RegistrationNumber + "\nThe color: " + Color +
                 "\nIt has" + NumberOfWheels + " wheels." + "\nIts length is: " + Length + " m" + ".";
        }
    }
}