using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{

    public class Customer
    {
        private static int idGenrator ;


        private int customerId;
        private string customer_first_name;
        private string customer_last_name;
        private string phonenumber;
        private int numOfBooking;




        public Customer(string fname, string lname, string phn)
        {
            customer_first_name = fname;
            customer_last_name = lname;
            phonenumber = phn;
            this.customerId = ++idGenrator;
            
        }
        public string getFname()
        {
            return customer_first_name;
        }
        public string getLname()
        {
            return customer_last_name;
        }
        public string getPhn()
        {
            return phonenumber;
        }
        public int getId()
        {
            return customerId;
        }
        public int getNumberOfBooking()
        { return numOfBooking; }
        public void setNumOfBooking(int num)
        {
            numOfBooking= num;
        }
        

        public override string ToString()
        {
            string s = "";
            s = s + "\nId : " + customerId;
            s = s + "\nCustomer name : " + customer_first_name + " " + customer_last_name;
            s = s + "\nphoneNumber : " + phonenumber;
            s = s + "\nNumber of Booking : " + numOfBooking;
            return s;
        }
    }
}