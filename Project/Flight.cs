using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    public class Flight
    {
        private static int idGenerator;
        public int id;
        private int flightNumber;
        private string from;
        private string to;
        private int maxSeat;
        private int numOfPassenger;
        private DateTime FDate;

        public Flight(int flightNumber, string from, string to, int maxSeat, string fDate)
        {
            this.id = ++idGenerator;
            this.flightNumber = flightNumber;
            this.from = from;
            this.to = to;
            this.maxSeat = maxSeat;
            this.numOfPassenger = 0;
            this.FDate = DateTime.ParseExact(fDate, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
        }
        public int getFlightNumber()
        {
            return flightNumber;
        }
        public string getFrom() { return from; }
        public string getTo() { return to; }
        public int getNumOfPassenger() { return numOfPassenger; }
        public void setNumOfPassenger(int num) { numOfPassenger = num; }
        public DateTime getFlightDate() { return FDate; }
        public int getMaxSeat()
        {
            return maxSeat;
        }
        public int getFlightId() { return id; }
        public override string ToString()
        {
            string s = "";
            s = s + "\nFlight id : " + id;
            s = s + "\nFlight Number : " + flightNumber;
            s = s + "\nOrigin : " + from;
            s = s + "\nDestination : " + to;
            s = s + "\nmax Seat : " + maxSeat;
            s = s + "\nNumber of Booking : " + numOfPassenger;
            s = s + "\nDate and Time : " + FDate;
            return s;
        }

    }
}