using Garage_Nico_Priya.Vehicles;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Nico_Priya
{
 
    public class Garage<T> : IEnumerable<T> where T : Vehicle     
                                                                  
    {
        private string name;
        private string address;
        private int count;
        private int capacity;
        private T[] vehicleArray;

        public Garage(string name, string address, int capacity)
        {
            Capacity = capacity;
            Name = name;
            Address = address;
            vehicleArray = new T[capacity];
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count
        {
            get
            {
                count = vehicleArray.Count(veh => veh != null);
                return count;
            }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int FirstEmptyParkingPlace
        {
            get
            {
                return Array.FindIndex(vehicleArray, veh => veh == null);
            }

        }

        public bool ParkVehicle(T vehicle, int pp)
        {
            if (vehicleArray[pp] == null)
            {
                vehicleArray[pp] = vehicle;
                count++;
                return true;
            }
            else
                return false;

        }

        public bool UnparkVehicle(int parkingPlace)
        {
            if (vehicleArray[parkingPlace] != null)
            {
                vehicleArray[parkingPlace] = null;
                count--;
                return true;
            }
            else
                return false;
        }

        public string List()
        {
            string result = "";
            for (int i = 0; i < Capacity; i++)
                if (vehicleArray[i] != null)
                {
                    result += "Parking Place " + (i + 1) + "\n" + vehicleArray[i].GetType().Name + "\n" + vehicleArray[i] + "\n";

                }
            return result;
        }

        public List<int> ListPos(bool occupied)
        {
            List<int> empty = new List<int>();
            List<int> occup = new List<int>();
            for (int i = 0; i < Capacity; i++)
                if (vehicleArray[i] == null)
                    empty.Add(i);
                else
                    occup.Add(i);
            if (occupied) return occup;
            else return empty;
        }


        public string ListType()
        {
            string resultat = "";
            var vehtype = vehicleArray.Where(v => v != null).Select(v => v.GetType().Name);
            foreach (var veh in vehtype)
            {
                resultat += veh + "|";
            }

            return resultat;
        }

        public int FindIndex(string registrationNr)
        {
            return Array.FindIndex(vehicleArray, v => v != null && v.RegistrationNumber == registrationNr);
        }


    

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return vehicleArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)vehicleArray).GetEnumerator();
        }
    }
}