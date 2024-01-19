namespace Project
{
    public class Program
    {
       static Cordinator cr = new Cordinator(200, 20, 2000);
        static void showCustomerMenu()
        {
            Console.WriteLine("1. Add Customer ");
            Console.WriteLine("2. Delete Customer");
            Console.WriteLine("3. View Perticular Customer");
            Console.WriteLine("4. View All Customers.");
            Console.WriteLine("5. Back to main menu");
        }
        static void showFlightMenu()
        {
            Console.WriteLine("1. Add Flight ");
            Console.WriteLine("2. Delete Flight");
            Console.WriteLine("3. View Perticular Flight");
            Console.WriteLine("4. View All Flights");
            Console.WriteLine("5. Back to main menu");

        }
        static void showBookingMenu()
        {
            Console.WriteLine("1. Add Booking ");
            Console.WriteLine("2. Delete Booking");
            Console.WriteLine("3. View Booking");
            Console.WriteLine("4. View all booking");
            Console.WriteLine("5. Back to main menu");
        }
        public static void data()
        {
           
            cr.addCustomer("Zoe", "Phillips", "1234567890");
            cr.addCustomer("Sophia", "Jones", "7777777777");
            cr.addCustomer("Emma", "Taylor", "3456789011");
            cr.addCustomer("James", "Clark", "5678901232");
            cr.addCustomer("Ava", "Anderson", "7890123453");
            cr.addCustomer("Logan", "Moore", "9012345674");
            cr.addCustomer("Mia", "Parker", "1234567895");
            cr.addCustomer("Benjamin", "Wright", "2345678906");
            cr.addCustomer("Chloe", "Turner", "4567890127");
            cr.addCustomer("Henry", "Baker", "6789012348");
            cr.addCustomer("Grace", "White", "8901234569");
            cr.addCustomer("Liam", "Evans", "0123456789");

            cr.saveToDisk("c:\\t177 SEM 3\\OOP\\CustomerData.txt");
            cr.addFlight(253, "JFK", "LAX", 250, "2023-12-15 15:30:00");
            cr.addFlight(456, "LHR", "CDG", 220, "2023-12-18 14:10:00");
            cr.addFlight(754, "SFO", "ORD", 300, "2023-12-16 10:45:00");
            cr.addFlight(128, "ATL", "DFW", 200, "2023-12-17 08:15:00");
            cr.addFlight(512, "LGA", "MIA", 320, "2023-12-18 12:00:00");
            cr.addFlight(633, "DEN", "SEA", 280, "2023-12-19 16:20:00");
            cr.addFlight(945, "LAS", "MCO", 270, "2023-12-20 14:30:00");
            cr.addFlight(321, "PHX", "BOS", 330, "2023-12-21 09:55:00");
            cr.addFlight(876, "ORD", "IAH", 290, "2023-12-22 11:10:00");
            cr.addFlight(444, "DCA", "TPA", 310, "2023-12-23 17:45:00");
            cr.addFlight(567, "MSP", "FLL", 280, "2023-12-24 13:25:00");
            cr.addFlight(789, "BWI", "SAN", 260, "2023-12-25 18:00:00");

            cr.saveFlightsToDisk("c:\\t177 SEM 3\\OOP\\FlightData.txt");
           
            Console.Clear();
        }
        static void Main(string[] args)
        {
            data();
           while (true)
            {
                Console.Clear();
                Console.WriteLine("AirIndia Limited !");
                Console.WriteLine("Select a choice from menu.");
                Console.WriteLine("1.Customers ");
                Console.WriteLine("2.Flights");
                Console.WriteLine("3.Bookings");
                Console.WriteLine("4.Exit");

                Console.WriteLine("Enter your choice : ");
                int opt = Convert.ToInt32(Console.ReadLine());

                if (opt == 1)
                {
                    Console.Clear();
                    
                    while (true)
                    {
                        showCustomerMenu();

                        Console.WriteLine("Enter an operation to do : ");
                        int OPT = Convert.ToInt32(Console.ReadLine());
                        if (OPT == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter First Name : ");
                            string fname = Console.ReadLine();

                            Console.WriteLine("Enter Last Name : ");
                            string lname = Console.ReadLine();

                            Console.WriteLine("Enter Phone Number : ");
                            string phn = Console.ReadLine();
                            
                            cr.addCustomer(fname,lname,phn);
                            cr.saveToDisk("c:\\t177 SEM 3\\OOP\\CustomerData.txt");
                            Console.ReadKey();
                            Console.WriteLine("\n");

                        }
                        else if(OPT == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter id To delete");
                            int id = Convert.ToInt32(Console.ReadLine());
                           cr.deleteCustomer(id);
                           
                        }
                        else if (OPT == 3)
                        {
                            Console.Clear();
                            

                           Console.WriteLine(cr.viewCustomer());
                            Console.WriteLine("\n");
                        }
                        else if (OPT == 4)
                        {
                            Console.Clear();
                            Console.WriteLine(cr.viewAllCustomers());
                           
                        }
                        else if (OPT == 5)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid number : ");
                            break;
                        }
                    }

                }
                else if (opt == 2)
                {
                    Console.Clear();
                    
                    while (true)
                    {
                        Console.Clear();
                        showFlightMenu();
                        Console.WriteLine("Enter Operation to do : ");
                        int optf = Convert.ToInt32(Console.ReadLine());
                        if(optf==1)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Number : ");
                            int flnum = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Origin of the flight : ");
                            string from = Console.ReadLine();
                            Console.WriteLine("Destination of the flight : ");
                            string to = Console.ReadLine() ;
                            Console.WriteLine("Maximum Capacity of Flight : ");
                            int maxSeat = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("FlightDate (yyyy-MM-dd HH:mm:ss) : ");
                            string fdate = Console.ReadLine();  
                            cr.addFlight(flnum,from,to,maxSeat,fdate);
                            cr.saveBookingsToDisk("c:\\t177 SEM 3\\OOP\\ProjectData.txt");
                            Console.ReadKey();
                        }
                        else if(optf==2)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter FlightNumber to Delete : ");
                            int deleteFlight = Convert.ToInt32(Console.ReadLine());
                            cr.deleteFlight(deleteFlight);
                            Console.ReadKey();
                        }
                        else if(optf==3)
                        {
                            Console.Clear();
                            Console.WriteLine(cr.viewFlight());
                            Console.ReadKey();
                        }
                        else if(optf==4)
                        {
                            Console.Clear();
                            Console.WriteLine(cr.viewAllFlight());
                            Console.ReadKey();
                        }
                        else if(optf==5)
                        {
                            
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter Valid Choice");
                            break;
                        }
                    }
                }
                else if (opt == 3)
                {
                    Console.Clear();
                    while (true)
                    {
                        showBookingMenu();

                        Console.WriteLine("Enter Operation to do : ");
                        int optb = Convert.ToInt32(Console.ReadLine());
                        if (optb == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Details to make a booking.");
                            Console.WriteLine("Enter Customer id : ");
                            int cid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Flight id : ");
                            int fid = Convert.ToInt32(Console.ReadLine());
                            cr.addBooking(cid, fid);
                            cr.saveBookingsToDisk("c:\\t177 SEM 3\\OOP\\BookingData.txt");
                            Console.ReadKey();

                        }
                        else if (optb == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Id to delete Booking");
                            int delete = Convert.ToInt32(Console.ReadLine());
                            cr.deleteBooking(delete);
                            Console.ReadKey();
                        }
                        else if (optb == 3)
                        {
                            Console.Clear();
                            Console.WriteLine(cr.viewBooking());
                            Console.ReadKey();
                        }
                        else if (optb == 4)
                        {
                            Console.Clear();
                            
                            Console.WriteLine(cr.viewAllBooking());
                        }
                        else if (optb == 5)
                        {
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Enter valid choice.");
                            break;
                        }
                    }
                }
                else if (opt == 4)
                {
                    break;
                }
                else
                {
                    
                    Console.WriteLine("Enter a valid Choice.");
                    Console.ReadKey();
                }

                //cr.saveBookingsToDisk("c:\\t177 SEM 3\\OOP\\ProjectData.txt");
            }
            
        }
    }
}