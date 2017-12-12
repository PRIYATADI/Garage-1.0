using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Nico_Priya.Vehicles
{
    class Van:Vehicle
    {
        private bool withSpecialPlacesForChildren;
        public bool WithSpecialPlacesForChildren { set { withSpecialPlacesForChildren = value; } get { return withSpecialPlacesForChildren; } }

        public Van()
        {

        }

        public Van(string regNr, string color, int numberOfWheels, bool withSpecialPlacesForChildren) : base(regNr, color, numberOfWheels)

        {
            WithSpecialPlacesForChildren = withSpecialPlacesForChildren;
        }

        public override string ToString()
        {
            return "Registration number: " + RegistrationNumber + "\nThe color is: " + Color +
                 "\nNumber of wheels: " + NumberOfWheels + " wheels" + "\nWith Special Places For Children: "  + WithSpecialPlacesForChildren;
        }

    }
}
