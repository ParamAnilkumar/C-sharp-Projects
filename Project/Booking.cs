using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Booking
    {
        private string dateOfBooking;
        private int bNumber;
        private Flight flight;
        private Customer customer;
        private static int idGenerator = 0;
        
        public Booking(Customer customer,Flight flight)
        {
            this.flight = flight;
            this.customer = customer;
            this.dateOfBooking = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            this.bNumber = ++idGenerator;
        }
        public string getDateOfBooking() { return dateOfBooking; }
        public int getBookingNumber() { return bNumber; }
        public Flight getFlight() { return flight; }
        public Customer getCustomer() { return customer;}
        

        public override string ToString()
        {
            string s = " ";
            s = s + "\nBooking id : " + bNumber;
            s = s + "\nBooking Date : " + dateOfBooking;
            s = s + "\nFlight information"+flight.ToString()+"\nCustomer Information";
            s = s + customer.ToString();
            return s;

        }

    }
}
