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
    public class Car : Vehicle
    {

        private string fueltype;

        public string FuelType
        {
            get { return fueltype; }
            set { fueltype = value; }
        }


        //Creating a default constructor
        public Car() { }

        public Car(string regNr, string color, int numberOfWheels, string fuel) : base(regNr, color, numberOfWheels)
        {
            FuelType = fuel;
        }
        public override string ToString()
        {
            return "Registration number " + RegistrationNumber + "\nThe color is: " + Color +
                 "\nand it has" + NumberOfWheels + " Wheels" + "\nIt functions with: " + FuelType + " as fuel type" + ".";
        }

    }
}