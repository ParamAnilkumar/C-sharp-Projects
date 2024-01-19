using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class BookingManager
    {
        private int maxBooking;
        private int numOfBooking;
        private Booking[] bookingList;
        private CustomerManager cm;
        private FlightManager fm;
        

        public BookingManager(int max, CustomerManager cm, FlightManager fm)
        {
            this.maxBooking = max;
            this.numOfBooking = 0;
            this.bookingList = new Booking[max];
            this.cm = cm;
            this.fm = fm;
        }
        public void saveBookingsToDisk(string filename)
        {
            FileUtilities.saveBookings(filename,bookingList,numOfBooking);
        }
        public bool addBooking(int flightId, int customerId)
        {
            Flight f1 = fm.getFlightById(flightId);
            Customer c1 = cm.getCustomerById(customerId);
            if (numOfBooking < maxBooking)
            {
                if (c1!= null && f1 != null && f1.getNumOfPassenger() < f1.getMaxSeat())
                {
                   
                        bookingList[numOfBooking] = new Booking(c1,f1);
                       f1.setNumOfPassenger(f1.getNumOfPassenger() + 1);
                        if (c1 != null)
                        {
                            c1.setNumOfBooking(c1.getNumberOfBooking() + 1);
                        }
                    numOfBooking++;
                        Console.WriteLine("The Booking Has Been Made With The Booking Id of:" + bookingList[numOfBooking - 1].getBookingNumber());
                        return true;
                    
                }
            }
            return false;
        }
        public bool deleteBooking(int id)
        {
            for (int i = 0; i < numOfBooking; i++)
            {
                for (int j = i; j < numOfBooking - 1; j++)
                {
                    bookingList[j] = bookingList[j + 1];
                    Console.WriteLine("Flight with id=" + id + "has been deleted successfully");
                    return true;
                }
                

            }
            return false;
        }
        public string viewAllBooking()
        {
            string s = "";
            for (int i = 0; i < numOfBooking; i++)
            {
                s = s +  bookingList[i] + "\n";

            }
            return s;
         }
        public string viewBooking()
        {

            Console.WriteLine("1. View Booking by Id");
            Console.WriteLine("2. All Bookings by Perticular Customers");
            Console.WriteLine("3. All Bookings in Perticular Flight");
            Console.WriteLine("4. All Bookings of Perticular Date");
            Console.WriteLine("5. Back to manu");
            Console.WriteLine("\nEnter Option to do.");
            int opt = Convert.ToInt32(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    Console.WriteLine("Enter id to find.");
                    int id = Convert.ToInt32(Console.ReadLine());
                    return viewBookingById(id).ToString();



                case 2:

                    Console.WriteLine("Enter id to find get Bookings by Customer");
                    int Bid = Convert.ToInt32(Console.ReadLine());
                    return allBookingByCustomer(Bid).ToString();


                case 3:

                    Console.WriteLine("Enter flightNumber to get All Bookings in Flight");
                    int Fid = Convert.ToInt32(Console.ReadLine());
                    return allBookingOfFlight(Fid).ToString();


                case 4:

                    Console.WriteLine("Enter Date to get All Bookings of Date");
                    string date = Console.ReadLine();
                    return allBookingOfDate(date).ToString();


                default:

                    return "Enter Valid choice";
                   
            }
        }
        public string viewBookingById(int id)
        { 
            string s = "";
            for (int i = 0; i < numOfBooking; i++)
            {
                if (bookingList[i].getBookingNumber() == id)
                {
                    s = s + bookingList[i].ToString() + "\n";
                }
            }
            return s;
        }
        public string allBookingByCustomer(int id)
        {
            string s = "";
            for(int i = 0; i < numOfBooking;i++)
            {
                if (cm.getCustomerById(id) != null)
                {
                    if (bookingList[i].getCustomer() == cm.getCustomerById(id))
                    {
                        s = s + bookingList[i].ToString() + "\n";
                    }
                }
            }
            return s;
        }
        public string allBookingOfFlight(int fId)
        {
            string s = "";
            for(int i = 0; i<numOfBooking;i++)
            {
                if (fm.getFlightById(fId) != null)
                {
                    if (bookingList[i].getFlight() == fm.getFlightById(fId))
                    {
                        s = s + bookingList[i].ToString();
                    }
                }

            }
            return s;
        }
        public string allBookingOfDate(string date)
        {
            string s = "";
            for(int i = 0; i<numOfBooking;i++)
            {
                if (bookingList[i].getDateOfBooking().Equals(date))
                {
                    s = s + bookingList[i];  
                }
            }
            return s;
        }
        



    }
}
