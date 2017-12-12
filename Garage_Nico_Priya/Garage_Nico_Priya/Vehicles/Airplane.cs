using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Nico_Priya.Vehicles
{
    /// <summary>
    ///  Subclass that inherites from the vehicle and add a new properity.
    /// </summary>
    public class Airplane : Vehicle
    {
        private int numberOfEngines;

        public int NumberOfEngines
        {
            get { return numberOfEngines; }
            set { numberOfEngines = value; }
        }
        //Creating a default constructor
        public Airplane() { }

        public Airplane(string regNr, string color, int numberOfWheels, int numberOfEngines) : base(regNr, color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }

        /*

           Polymorphism is the concepts of OOPS which includes method overriding and method overloading. 
           Virtual and Override keyword are used for method overriding and new keyword is used for method hiding.
           */

        public override string ToString()
        {
            return "Registration number " + RegistrationNumber + "\nIts color: " + Color +
                 "\nIt has" + NumberOfWheels + " wheels" + "\nand: " + NumberOfEngines + " engines" + ".";
        }
    }
}