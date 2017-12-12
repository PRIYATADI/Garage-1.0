using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Nico_Priya
{
    public class GarageHandler<T> where T : Vehicle
    {
        public void SetName(Garage<T> garage, string name)
        {
            garage.Name = name;
        }

        public string GetName(Garage<T> garage)
        {
            return garage.Name;
        }

        public void SetAddress(Garage<T> garage, string address)
        {
            garage.Address = address;
        }

        public string GetAddress(Garage<T> garage)
        {
            return garage.Address;
        }

        public void SetCapacity(Garage<T> garage, int capacity)
        {
            garage.Capacity = capacity;
        }

        public int GetCapacity(Garage<T> garage)
        {
            return garage.Capacity;
        }

        public int GetCount(Garage<T> garage)
        {
            return garage.Count;
        }

        public Garage<T> CreateAGarage(string name, string address, int capacity)
        {
            Garage<T> garage = new Garage<T>(name, address, capacity);
            return garage;
        }

        public string ParkVehicle(Garage<T> garage, T vehicle, int pp)
        {
            string message = "";
            if (pp < 0 || pp > garage.Capacity)
            {
                message = "The parking place you want to park doesn't exist";
                return message;
            }
            else
            {
                if (pp == 0)
                {
                    pp = garage.FirstEmptyParkingPlace + 1;
                }
                if (pp == 0)
                {
                    message = "The garage is full";
                    return message;
                }
                if (garage.ParkVehicle(vehicle, pp - 1))
                    message = "You parked successfully at parking place number  " + pp + "\n" + this.DisplayTheGarage(garage);
                else
                    message = "The parking place you want to park is occupied.";
                return message;
            }

        }

        public string UnParkVehicle(Garage<T> garage, string regNr, int pp)
        {
            string message = "";

            if (pp < 0 || pp > garage.Capacity)
            {
                message = "This parking place does not exist in this garage!";
                return message;
            }
            else
            {
                if (pp == 0)
                {
                    pp = garage.FindIndex(regNr) + 1;
                }
                if (pp == 0)
                {
                    message = "The vehicle with the registration number not found";
                    return message;
                }
                if (garage.UnparkVehicle(pp - 1))
                    message = "You checked out successfully from parking place number " + pp + "\n" + this.DisplayTheGarage(garage);
                else
                    message = "The parking place is now available.";
                return message;
            }

        }

        public string DisplayTheGarage(Garage<T> garage)
        {
            return "Name: " + garage.Name +
                "\nAdress: " + garage.Address +
                "\nMaximum capacity: " + garage.Capacity +
                "\nNumber of ocuppied parking places: " + garage.Count +
                "\nNumber of empty parking places: " + (garage.Capacity - garage.Count);
        }

        public string ShowVehicleList(Garage<Vehicle> garage)
        {
            return garage.List();
        }

        public string ShowVehicleListType(Garage<Vehicle> garage)
        {
            string result = "";
            var vehlist = garage.OfType<Vehicle>().Where(x => x != null).GroupBy(x => x.GetType().Name).Select(gar => new
            {
                type = gar.Key,
                count = gar.Count()
            });
            foreach (var veh in vehlist)
            {
                result += veh.type + ": " + veh.count + "\n";

            }
            return result;
        }

        

        public void FindVehicleByRegistrationNumber(Garage<Vehicle> garage, string regNr)
        {
            var vehlist = garage.OfType<Vehicle>().Select((veh, i) => new { vehicle = veh, Index = i }).Where(x => x.vehicle != null && x.vehicle.RegistrationNumber.Contains(regNr)).ToDictionary(x => x.Index, x => x.vehicle);
            if (vehlist.Count == 0)
                Console.WriteLine("The vehicle with registration number {0} is not found", regNr);
            else
            {
                foreach (var veh in vehlist)
                {
                    Console.WriteLine("Parking place: " + (veh.Key + 1) + "\n" + veh.Value);
                }
            }
        }

        public void FindVehicleByWheels(Garage<Vehicle> garage, int numberOfWheels)
        {
            var vehlist = garage.OfType<Vehicle>().Select((veh, i) => new { vehicle = veh, Index = i }).Where(x => x.vehicle != null && x.vehicle.NumberOfWheels == numberOfWheels).ToDictionary(x => x.Index, x => x.vehicle);
            if (vehlist.Count == 0)
                Console.WriteLine("Not find any vehicle with {0} wheels ", numberOfWheels);
            else
            {
                foreach (var veh in vehlist)
                {
                    Console.WriteLine("Parking Place: " + (veh.Key + 1) + "\n" + veh.Value);
                }
            }
        }

        public void FindVehicleByColor(Garage<Vehicle> garage, string color)
        {
            var vehlist = garage.OfType<Vehicle>().Select((v, i) => new { vehicle = v, Index = i }).Where(x => x.vehicle != null && x.vehicle.Color == color).ToDictionary(x => x.Index, x => x.vehicle);
            if (vehlist.Count == 0)
                Console.WriteLine("Not find any vehicle with {0} color ", color);
            else
            {
                foreach (var veh in vehlist)
                {
                    Console.WriteLine("Parking place: " + (veh.Key + 1) + "\n" + veh.Value);
                }
            }
        }

        public void FindVehicleByType(Garage<Vehicle> garage, string type)
        {
            var vehlist = garage.OfType<Vehicle>().Where(v => v.GetType().Name.Equals(type, StringComparison.InvariantCultureIgnoreCase));
            if (vehlist.Count() == 0)
                Console.WriteLine("The type {0} was not found", type);
            else
                foreach (var veh in vehlist)
                    Console.WriteLine(veh);
        }

        public string TypeVehicle(Garage<Vehicle> garage)
        {
            return garage.ListType();
        }
    }
}