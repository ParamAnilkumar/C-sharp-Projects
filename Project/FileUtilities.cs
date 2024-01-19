using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class FileUtilities
    {
        public static void saveCustomers(string location, Customer[] customers, int num)
        {
            StreamWriter outputStream = new StreamWriter(location);

            outputStream.Write("No. of customers : " + num + "\n");
            for (int i = 0; i < num; i++)
            {
                outputStream.WriteLine(customers[i].ToString());

            }
            outputStream.Close();
        }
        public static void saveFlights(string location, Flight[] flights, int num)
        {
            StreamWriter outputStream = new StreamWriter(location);
            outputStream.Write("No. of Flights : " + num + "\n");
            for (int i = 0; i < num; i++)
            {
                outputStream.WriteLine(flights[i].ToString());
            }
            outputStream.Close();
        }
        public static void saveBookings(string location, Booking[] bookings, int num)
        {
            StreamWriter outputStream = new StreamWriter(location);
            outputStream.Write("No. of booking : " + num + "\n");
            for (int i = 0; i < num; i++)
            {
                outputStream.WriteLine(bookings[i].ToString());
            }
            outputStream.Close();
        }

     

    }
}
