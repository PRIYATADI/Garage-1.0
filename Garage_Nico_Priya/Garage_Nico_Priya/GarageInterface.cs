using Garage_Nico_Priya.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Nico_Priya
{
    public class GarageInterface
    {
        public void GarageMenu()
        {
          
            Garage<Vehicle> garage = new Garage<Vehicle>("test", "address", 100);

            Interface GarageMenu = new Interface();
            GarageMenu.Description = "PRIYA-NICO GARAGE OPTIONS:\n";
            GarageMenu.AddOptions("1", "Select 1  to CREATE A NEW GARAGE", new Action(() => { garage = CreateAGarage(); }));
            GarageMenu.AddOptions("2", "Select 2  to PARK A VEHICLE", new Action(() => { ParkVehicle(garage); }));
            GarageMenu.AddOptions("3", "Select 3  to CHECK OUT A VEHICLE", new Action(() => { UnparkVehicle(garage); }));
            GarageMenu.AddOptions("4", "Select 4  to LIST INFORMATION ABOUT THE PARKED VEHICLES", new Action(() => { VehicleList(garage); }));
            GarageMenu.AddOptions("5", "Select 5  to SEARCH A VEHICLE", new Action(() => { Search(garage); }));
            GarageMenu.AddOptions("0", "Select 0 to EXIT", new Action(() => { Close(); }));
            GarageMenu.Color = "White";
            GarageMenu.ShowMenu();
        }

        #region SubMenu
        private static void Search(Garage<Vehicle> garage)
        {
            Interface SearchMenu = new Interface();
            SearchMenu.Description = "SEARCH MENU:";
            SearchMenu.AddOptions("1", "Enter 1 if you want to search vehicle by registration number", new Action(() => { SearchAVehicle(garage, 1); }));
            SearchMenu.AddOptions("2", "Enter 2 if you want to search vehicle by type", new Action(() => { SearchAVehicle(garage, 2); }));
            SearchMenu.AddOptions("3", "Enter 3 if you want to search vehicle by number of wheel", new Action(() => { SearchAVehicle(garage, 3); }));
            SearchMenu.AddOptions("4", "Enter 4 if you want to search vehicle by color", new Action(() => { SearchAVehicle(garage, 4); }));
            SearchMenu.AddOptions("0", "Enter 0 if you want to come back the main menu", new Action(() => { }));
            SearchMenu.Color = "Yellow";
            SearchMenu.ShowMenu();
        }
        #endregion
        #region VehicleList
        private static void VehicleList(Garage<Vehicle> garage)
        {
            Interface ListMenu = new Interface();
            ListMenu.Description = "LIST MENU:";
            ListMenu.AddOptions("1", "Enter 1 if you want to list all parked vehicles", new Action(() => { DisplayVehicleList(garage, 1); }));
            ListMenu.AddOptions("2", "Enter 2 if you want to list all types currently parked vehicle", new Action(() => { DisplayVehicleList(garage, 2); }));
            ListMenu.AddOptions("3", "Enter 3 if you want to list all available slots", new Action(() => { DisplayVehicleList(garage, 3); }));
            ListMenu.AddOptions("4", "Enter 4 if you want to list all occupied slot", new Action(() => { DisplayVehicleList(garage, 4); }));
            ListMenu.AddOptions("0", "Enter 0 if you want to come back the main menu", new Action(() => { }));
            ListMenu.Color = "White";
            ListMenu.ShowMenu();
        }
        #endregion
        #region ParkVehicle

        private static void ParkVehicle(Garage<Vehicle> garage)
        {
            Console.Clear();
            GarageHandler<Vehicle> handler = new GarageHandler<Vehicle>();
            Console.WriteLine("                       PARKERING YOUR VEHICLE");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("What type of vehicle you want to park? \nPlease, choosing one of the following options:" +
                "\n1) AIRPLANE" + "\n2) BOAT" + "\n3) BUS"+"\n4) CAR" + "\n5) MOTORCYCLE");
            string userinput = Console.ReadLine();
            Console.WriteLine("Please answer the next questions...\n");
            Console.Write("What is the registration number of your vehicle? ");
            string regNr = Console.ReadLine();
            Console.Write("What is the color of the vehicle? ");
            string color = Console.ReadLine();
            string numberOfWheels= Console.ReadLine();
            int number;
            Console.WriteLine("How many wheels does your vehicle have? ");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Invalid number! Please try again. ");
            }
            
            
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Invalid number! Please try again. ");
            }
            if (userinput == "1")
            {
                userinput = "Airplane";
                string numof = Console.ReadLine();
                Console.WriteLine("How many engines does your airplane have? ");
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("Invalid number! Please try again. ");
                }
                Airplane a = new Airplane(regNr, color, number, number);
                handler.ParkVehicle(garage, a, 0);
            }
            else if (userinput == "2")
            {
                userinput = "Boat";
                Console.WriteLine("What is the length of your boat? ");
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Invalid number! Please try again. ");
                }
                Boat a = new Boat(regNr, color, number, number);
                handler.ParkVehicle(garage, a, 0);
            }
            else if (userinput == "3")
            {
                userinput = "Car";
                Console.WriteLine("Which fuel type does your car have? ");
                string fuel = Console.ReadLine();
                Car a = new Car(regNr,color,  number, fuel);
                handler.ParkVehicle(garage, a, 0);
            }
            else if (userinput == "4")
            {
                userinput = "Motorcycle";
                Console.WriteLine("How much cylinder volume does your motorcycle have? ");
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Invalid input! Please try again. ");
                }
                Motorcycle a = new Motorcycle(regNr, color, number, number);
                handler.ParkVehicle(garage, a, 0);
            }
            Console.WriteLine("\n--------------Parked vehicle---------------");
            Console.WriteLine(handler.ShowVehicleList(garage));
            Console.ReadLine();
        }
        #endregion
        #region UnparkVehicle
        private static void UnparkVehicle(Garage<Vehicle> garage)
        {

            Console.Clear();
            List<string> parkedvehiclesList = new List<string>();
            Console.WriteLine("                       PARKED VEHICLES:");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Please first find your vehicle to unpark it... ");
            Console.Write("What is the registration number of your vehicle? ");
            string userunpark = Console.ReadLine();
            GarageHandler<Vehicle> unpark = new GarageHandler<Vehicle>();
            Console.WriteLine(unpark.UnParkVehicle(garage, userunpark, 0));
            Console.WriteLine("\n--------------Unparked vehicle---------------");
            Console.WriteLine(unpark.ShowVehicleList(garage));
            Console.ReadLine();
        }
        #endregion

        #region CreateAGarage
        private static Garage<Vehicle> CreateAGarage()
        {
            Console.Clear();
            Console.WriteLine("                       CREATE A NEW GARAGE");
            Console.WriteLine("\n----------------------------------------------------------------------");
            Console.Write("Please, type the name of garage: ");
            string name = Console.ReadLine();
            while (String.IsNullOrEmpty(name))
            {
                Console.Write("Sorry, it can not be an empty! Please type again. ");
                name = Console.ReadLine();
            }

            Console.Write("Please type the address of garage: ");
            string address = Console.ReadLine();

            Console.Write("Please type the capacity of garage: ");
            int capacity;
            while (!int.TryParse(Console.ReadLine(), out capacity))
            {
                Console.Write("Invalid capacity.Please input again: ");
            }

            GarageHandler<Vehicle> handler = new GarageHandler<Vehicle>();
            Garage<Vehicle> garage = handler.CreateAGarage(name, address, capacity);
            Console.WriteLine("\n--------------THE NEW GARAGE---------------\n");
            Console.WriteLine(handler.DisplayTheGarage(garage));
            Console.ReadLine();
            return garage;
        }
        #endregion

        #region DisplayVehicleList
        private static void DisplayVehicleList(Garage<Vehicle> garage, int choice)
        {
            GarageHandler<Vehicle> handler = new GarageHandler<Vehicle>();
            Console.Clear();

            if (choice == 1)
            {
                Console.WriteLine("LIST OF ALL THE VEHICLES  PARKED IN THE GARAGE");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine(handler.ShowVehicleList(garage));
            }
            if (choice == 2)
            {
                Console.WriteLine("LIST OF VEHICLE TYPES");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine(handler.ShowVehicleListType(garage));
            }
      
        }
        #endregion

        #region SearchAVehicle
        private static void SearchAVehicle(Garage<Vehicle> garage, int choice)
        {
            GarageHandler<Vehicle> handler = new GarageHandler<Vehicle>();
            Console.Clear();
            Console.WriteLine("SEARCH A VEHICLE");
            Console.WriteLine("----------------------------------------------------------------------");
            if (choice == 1)
            {
                Console.Write("Enter the registration number of the vehicle: ");
                string regNr = Console.ReadLine();
                while (String.IsNullOrEmpty(regNr))
                {
                    Console.Write("registration number can not be null.Please input again: ");
                    regNr = Console.ReadLine();
                }
                handler.FindVehicleByRegistrationNumber(garage, regNr);
            }
            if (choice == 2)
            {
                Console.Write("Enter the type of the vehicle: ");
                string type = Console.ReadLine();
                while (String.IsNullOrEmpty(type))
                {
                    Console.Write("Vehicle type can not be null.Please input again: ");
                    type = Console.ReadLine();
                }
                handler.FindVehicleByType(garage, type);
            }
            if (choice == 3)
            {
                Console.Write("Enter the number of the wheels: ");
                int wheels;
                while (!int.TryParse(Console.ReadLine(), out wheels))
                {
                    Console.Write("Invalid number of the wheels.Please input again: ");
                }
                handler.FindVehicleByWheels(garage, wheels);

            }
            if (choice == 4)
            {
                Console.Write("Enter the color of the vehicle: ");
                string color = Console.ReadLine();
                while (String.IsNullOrEmpty(color))
                {
                    Console.Write("Vehicle color can not be null.Please input again: ");
                    color = Console.ReadLine();
                }
                handler.FindVehicleByColor(garage, color);
            }
            Console.ReadLine();
        }


        private static void Close()
        {
            Console.WriteLine("Thank you and good bye");
            System.Threading.Thread.Sleep(500);
            return;
        }

    }
}
#endregion