using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Nico_Priya.Vehicles
{   /// <summary>
    /// Subclass that inherites from the vehicle and add a new properity.
    /// </summary>
    public class Bus : Vehicle
    {

        private int numberOfSeats;

        public int NumberOfSeats
        {
            get { return numberOfSeats; }
            set { numberOfSeats = value; }
        }
        //Creating a default constructor
        public Bus() { }

        public Bus(string regNr, string color, int numberOfWheels, int numofs) : base(regNr, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return "Registration number " + RegistrationNumber + "\nThe color: " + Color +
                "\nIt has" + NumberOfWheels + " wheels" + "\nand: " + NumberOfSeats + " seats" + ".";
        }
    }
}