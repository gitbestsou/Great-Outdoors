﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.PresentationLayer
{
    class PresentationLayer
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Great Outdoors..");
            int choice = 0;
            do
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Login as Admin");
                Console.WriteLine("2. Login as Salesperson");
                Console.WriteLine("3. Login as Retailer");
                Console.WriteLine("4. Register as a Retailer");
                Console.WriteLine("5. Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("--Admin Login--");
                        Console.WriteLine("Enter Username");
                        String usernameAdmin = Console.ReadLine();

                        Console.WriteLine("Enter Password");
                        String passwordAdmin = Console.ReadLine();
                        if (!Admin.Authenticate(usernameAdmin, passwordAdmin))
                        {
                            Console.WriteLine("Invalid Credentials");
                        }
                        else
                        {

                            Console.WriteLine("Login Successful");
                            char choiceAdmin;
                            do
                            {
                                Console.WriteLine("Enter your choice:");
                                Console.WriteLine("a. View Sales Report");
                                Console.WriteLine("b. View Retailer Report");
                                Console.WriteLine("c. View Overall Report");
                                Console.WriteLine("d. Update Bonus");
                                Console.WriteLine("e. Log out");
                                choiceAdmin = Convert.ToChar(Console.ReadLine());
                                switch (choiceAdmin)
                                {
                                    case 'a':
                                        //code'for sales report
                                        break;
                                    case 'b':
                                        //code'for retailer report
                                        break;
                                    case 'c':
                                        //code for overall report
                                        break;
                                    case 'd':
                                        //code for update bonus
                                        break;
                                    case 'e':
                                        //code for log out

                                        break;
                                    default:
                                        Console.WriteLine("Invalid Option");
                                        break;

                                }//end of switch case for adminChoice

                            } while (choiceAdmin != 'e');

                        }
                        break;

                    case 2:
                        Console.WriteLine("--Salesperson Login--");
                        Console.WriteLine("Enter Username");
                        String usernameSalesperson = Console.ReadLine();

                        Console.WriteLine("Enter Password");
                        String passwordSalesperson = Console.ReadLine();
                        if (!Salesperson.authenticateSalesperson(usernameSalesperson, passwordSalesperson))
                        {
                            Console.WriteLine("Invalid Credentials");
                        }
                        else
                        {

                            Console.WriteLine("Login Successful");
                            char choiceSalesperson;
                            do
                            {
                                Console.WriteLine("Enter your choice:");
                                Console.WriteLine("a. View your Sales history");
                                Console.WriteLine("b. Upload Offline Order");
                                Console.WriteLine("c. Accept Offline Order");
                                Console.WriteLine("d. Log out");

                                choiceSalesperson = Convert.ToChar(Console.ReadLine());
                                switch (choiceSalesperson)
                                {
                                    case 'a':
                                        //code'for sales history
                                        break;
                                    case 'b':
                                        //code'for offline order
                                        break;
                                    case 'c':
                                        //code for accept offline order
                                        break;
                                    case 'd':
                                        //code for log out
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Option");
                                        break;

                                }//end of switch case for adminChoice

                            } while (choiceSalesperson != 'd');

                        }
                        break;

                    case 3:
                        Console.WriteLine("--Retailer Login--");
                        Console.WriteLine("Enter Username");
                        String usernameRetailer = Console.ReadLine();

                        Console.WriteLine("Enter Password");
                        String passwordRetailer = Console.ReadLine();
                        if (!Retailer.authenticateAdmin(usernameRetailer, passwordRetailer))
                        {
                            Console.WriteLine("Invalid Credentials");
                        }
                        else
                        {

                            Console.WriteLine("Login Successful");
                            char choiceRetailer;
                            do
                            {
                                Console.WriteLine("Enter your choice:");
                                Console.WriteLine("a. Initiate Order");
                                Console.WriteLine("b. View Order History");
                                Console.WriteLine("c. Return Order");
                                Console.WriteLine("d. Cancel Order");
                                Console.WriteLine("e. Log out");
                                choiceRetailer = Convert.ToChar(Console.ReadLine());
                                switch (choiceRetailer)
                                {
                                    case 'a':
                                        //code for initiate order
                                        //Order.placeOrder(usernameRetailer);
                                        //Order.placeOrder(usernameRetailer);

                                        break;
                                    case 'b':
                                        //code for viewing order history
                                        break;
                                    case 'c':
                                        //code for return order
                                        break;
                                    case 'd':
                                        //code for cancel order
                                        break;
                                    case 'e':
                                        //code for log out
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Option");
                                        break;

                                }//end of switch case for adminChoice

                            } while (choiceRetailer != 'd');

                        }
                        break;

                    case 4:
                        Console.WriteLine("--Register as a Retailer--");
                        // Code for Registering as a retailer
                        break;

                }

            } while (choice != 5);

        }
    }
}
