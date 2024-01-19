using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    public class FlightManager
    {
        private int maxFlights;
        private int numOfFlight;
        private Flight[] flightList;

        public FlightManager(int max)
        {
            maxFlights = max;
            numOfFlight = 0;
            flightList = new Flight[maxFlights];
        }
        public void saveFlightsToDisk(string fileName)
        {
            FileUtilities.saveFlights(fileName, flightList,numOfFlight);
        }

        public bool addFlight(int number ,string from, string to, int maxSeats, string fdate)
        {
            if (numOfFlight < maxFlights)
            {
                if (getFlightByNumber(number) == null)
                {
                    flightList[numOfFlight] = new Flight(number, from, to, maxSeats, fdate);
                    numOfFlight++;
                    Console.WriteLine("The Flight is added successfully with the id : "+ flightList[numOfFlight-1].getFlightId());
                    return true;
                }
                else
                {
                    Console.WriteLine("The Flight is already there with the same FlightNumber");
                }

            }
            else
            {
                Console.WriteLine("No Space to add Flight.");
                return false;
            }
            return false;
        }
     
        public Flight getFlightById(int id)
        {
            for (int i = 0; i < numOfFlight; i++)
            {
                if (flightList[i].getFlightId() == id)
                {
                    return flightList[i];
                }
            }
            return null;
        }
        public Flight getFlightByNumber(int number)
        {
            for (int i = 0; i < numOfFlight; i++)
            {
                if (flightList[i].getFlightNumber() == number)
                {
                    return flightList[i];
                }

            }
            return null;
        }

        public bool deleteFlight(int flightNumber)
        {
            Flight f1 = getFlightByNumber(flightNumber);
            if(f1 != null && f1.getNumOfPassenger() == 0)
            for (int i = 0; i < numOfFlight; i++)
            {
                for (int j = i; j < numOfFlight - 1; j++)
                {
                    flightList[j] = flightList[j + 1];
                    Console.WriteLine("Flight with id=" + flightNumber + "has been deleted successfully");
                    return true;
                }

            }
            return false;
        }
        public string viewFlight()
        {
            string s = " ";
            Console.WriteLine("1. View Flight by Id");
            Console.WriteLine("2. View Flight by Number");
            Console.WriteLine("\nEnter Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 1)
            {
                Console.WriteLine("Enter Id to find : ");
                int id = Convert.ToInt32(Console.ReadLine());
                s = s + getFlightById(id).ToString();
            }
            else if(choice == 2)
            {
                Console.WriteLine("Enter Number to find : ");
                int num = Convert.ToInt32(Console.ReadLine());
                s = s + getFlightByNumber(num).ToString();
            }
            return s;
        }
        public string viewAllFlight()
        {
            string s = "All Flights";
            for (int i = 0; i < numOfFlight; i++)
            {
                s = s + flightList[i].ToString() + "\n\n";
            }
            return s;
        }



    }
}