using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Nico_Priya.Vehicles
{
    class Moped:Vehicle
    {
        private int cylinderVolume;

        public int CylinderVolume
        {
            get { return cylinderVolume; }
            set { cylinderVolume = value; }
        }
        //Creating a default constructor
        public Moped() { }

        public Moped(string regNr, string color, int numberOfWheels, int cylinderVolume) : base(regNr, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }
        public override string ToString()
        {
            return "Registration number " + RegistrationNumber + "\nThe color is: " + Color +
                 "\nIt has" + NumberOfWheels + " wheels" + "\nThe cylinder volume is: " + CylinderVolume + ".";
        }
    }
}
