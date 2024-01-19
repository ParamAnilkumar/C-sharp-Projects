using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class CustomerManager
    {
        private int removedId;
        private Customer[] customerList;
        private int numOfCustomer;
        private int maxCustomer;

        public CustomerManager(int maxC)
        {
            maxCustomer = maxC;
            numOfCustomer = 0;
            customerList = new Customer[maxCustomer];
        }
        public void saveToDisk(string loc)
        {
        FileUtilities.saveCustomers(loc, customerList,numOfCustomer);
        }
       
        public bool addCustomer(string fname, string lname , string phn)
        {
            if (numOfCustomer < maxCustomer)
            {
                if (getCustomerbyFirstName(fname) == null && getCustomerByLastName(lname) == null && getCustomerByPhnNum(phn) == null)
                {
                    customerList[numOfCustomer] = new Customer(fname,lname,phn);

                    numOfCustomer++;

                    Console.WriteLine("The Customer is successfully added with id : "+ customerList[numOfCustomer-1].getId() );
                    return true;
                }
                else
                {
                    Console.WriteLine("The Customer is already Existed!");
                    return false;
                }

            }
            else
            {
                Console.WriteLine("No space to add!");

                return false;
            }


            
        }
      

        public int search(int id)
        {

            for (int i = 0; i < numOfCustomer; i++)
            {
                if (id == customerList[i].getId())
                {
                    return i;
                }
            }
            return -1;
        }
           
        
        public string viewCustomer()
        {
            
            Console.WriteLine("1. View All Customers by firstName");
            Console.WriteLine("2. View All Customers by lastName");
            Console.WriteLine("3. View All Customers by PhoneNumber");
            Console.WriteLine("4. View Perticular Customer by Id");
            
            Console.WriteLine("Enter a choice : ");
            int i = Convert.ToInt32(Console.ReadLine());

            switch(i)
            {
                case 1:
                    Console.WriteLine("Enter First Name : ");
                    string fname = Console.ReadLine();
                   return getAllCustomersWithFName(fname).ToString();
                    

                case 2:
                    Console.WriteLine("Enter Last Name : ");
                    string lname = Console.ReadLine();
                    return getAllCustomersWithLName(lname).ToString();
                    
                case 3:
                    Console.WriteLine("Enter PhoneNumber : ");
                    string phn = Console.ReadLine();
                    return getAllCustomersByPhnNum(phn).ToString();                  
                case 4:
                    Console.WriteLine("Enter id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    return getCustomerById(id).ToString();
                   

                default:
                    return "Enter Valid Choice.";
                   

            }

            
        }
        public Customer getCustomerById(int id)
        {
            int found = search(id);
            if(found != -1)
            {
                return customerList[found];
            }
            return null;
        }
        public Customer getCustomerbyFirstName(string fname)
        {
            for (int i = 0; i < numOfCustomer; i++)
            {
                if (customerList[i].getFname().Equals(fname))
                {
                    return customerList[i];
                }
            }
            return null;
        }
        public string getAllCustomersWithFName(string fname)
        {
            string s = "All Customers With Same Fisrt Name\n";
            for(int i = 0; i < numOfCustomer;i++)
            {
                if (customerList[i].getFname().Equals(fname))
                {
                    s =s + customerList[i].ToString() + "\n";
                }
            }
            return s;
        }
        public Customer getCustomerByLastName(string lname)
        {
            for (int i = 0; i < numOfCustomer; i++)
            {
                if (customerList[i].getLname().Equals(lname))
                {
                    return customerList[i];
                }
            }
            return null;
        }
        public string getAllCustomersWithLName(string lname)
        {
            string s = "All Customers with Same Last Name.\n";
            for(int i = 0; i<numOfCustomer; i++)
            {
                if (customerList[i].getLname().Equals(lname))
                {
                    s = s + customerList[i].ToString() + "\n";
                }
            }
            return s;
               
        }
        public Customer getCustomerByPhnNum(string phnNum)
        {
            for (int i = 0; i < numOfCustomer; i++)
            {
                if (customerList[i].getPhn().Equals(phnNum))
                {
                    return customerList[i];
                }
            }

            return null;
        }
        public string getAllCustomersByPhnNum(string phn)
        {
            string s = "All Customers Registered with Same PhoneNumber";
            for(int i = 0; i < numOfCustomer; i++)
            {
                if (customerList[i].getPhn().Equals(phn))
                {
                    s = s + customerList[i].ToString() + "\n";
                }
                
            }
            return s;
        }

        
        public bool deleteCustomer(int id)
        {
            if (getCustomerById(id).getNumberOfBooking()==0)
            {
                for (int i = 0; i < numOfCustomer; i++)
                {
                    if (id == customerList[i].getId())
                    {

                        for (int j = i; j < numOfCustomer - 1; j++)
                        {
                            customerList[j] = customerList[j + 1];
                        }

                        numOfCustomer--;
                        Console.WriteLine("The Customer with ID " + id + " has been deleted.");
                        setRemovedId(id);
                        return true;
                    }

                }
            }
            
            return false;
        }
        public void setRemovedId(int id)
        {
            removedId= id;
        }
        public string viewAllCustomers()
        {
            string s = "-----Customers-----";
            for (int i = 0; i < numOfCustomer; i++)
            {
                s = s + customerList[i].ToString() + "\n\n";

            }
            return s;
        }

        public override string ToString()
        {
            string s = "";
            s = s + "\nMax Customer : " + maxCustomer;
            s = s + "Number of Customer : " + numOfCustomer;

            return s;
        }


    }
}