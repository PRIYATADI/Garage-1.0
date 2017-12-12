using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Nico_Priya.Vehicles
{
    public class Helicopter : Vehicle
    {
        private int numberOfWings;
        private float width;

        public int NumberOfWings { set { numberOfWings = value; } get { return numberOfWings; } }
        public float Width { set { width = value; } get { return width; } }

        public Helicopter()
        {

        }

        public Helicopter(string regNr, string color, int numberOfWheels, float width, int numberOfWings) : base(regNr, color, numberOfWheels)
        {
            NumberOfWings = numberOfWings;
            Width = width;
        }

        public override string ToString()
        {
            return "Registration number: " + RegistrationNumber + "\nThe color is: " + Color +
                 "\nNumber of wheels: " + NumberOfWheels + " wheels" + "\nNumber Of Wings: " + NumberOfWings + "\nwidth" + Width;
        }
    }
}
