using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Cordinator
    {
        private CustomerManager cusotmerManager;
        private FlightManager flightManager;
        private BookingManager bookingManager;

        public Cordinator(int maxC, int fmax, int bmax)
        {
            cusotmerManager = new CustomerManager(maxC);
            flightManager = new FlightManager(fmax);
            bookingManager = new BookingManager(bmax,cusotmerManager,flightManager);

        }
        public bool addCustomer(string fname, string lname, string phn)
        {
            return cusotmerManager.addCustomer(fname, lname, phn);
        }
        public bool deleteCustomer(int id) 
        {
            return cusotmerManager.deleteCustomer(id);
        }
        public string viewAllCustomers()
        {
            return cusotmerManager.viewAllCustomers();
        }
        public string viewCustomer()
        {
            return cusotmerManager.viewCustomer();
        }
        

        public bool addFlight(int number, string from, string to, int maxSeats, string fdate)
        {
            return flightManager.addFlight(number,from,to,maxSeats,fdate);
        }
        public bool deleteFlight(int number)
        {
            return flightManager.deleteFlight(number);
        }
        public string viewAllFlight()
        {
            return flightManager.viewAllFlight();
        }
        public string viewFlight()
        {
            return flightManager.viewFlight();
        }


        public bool addBooking(int cid, int fid)
        {
            return bookingManager.addBooking(cid, fid);
        }
        public bool deleteBooking(int bid)
        {
            return bookingManager.deleteBooking(bid);
        }
        public string viewAllBooking()
        {
           
            return bookingManager.viewAllBooking();
        }
        public string viewBooking()
        {
            return bookingManager.viewBooking();
        }
             
        public void saveToDisk(string filename)
        {
            cusotmerManager.saveToDisk(filename);
        }
        public void saveFlightsToDisk(string filename)
        {
            flightManager.saveFlightsToDisk(filename);
        }
        public void saveBookingsToDisk(string filename)
        {
            bookingManager.saveBookingsToDisk(filename);
        }
       
    }
}
