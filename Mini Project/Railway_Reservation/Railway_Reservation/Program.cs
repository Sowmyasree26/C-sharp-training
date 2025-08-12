using System;

namespace Railway_Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********** WELCOME TO RAILWAY RESERVATION SYSTEM ************");

            while (true)
            {
                Console.WriteLine("\nWho are you?\n 1. ADMIN\n 2. USER\n 3. EXIT");
                Console.Write("\nEnter your choice: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("\nPlease enter a valid number.");
                    continue;
                }

                if (choice == 1)
                {
                    if (Authentication.AdminLogin())
                    {
                        Admin.AdminMenu();
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\n1. Login\n2. Register");
                    Console.Write("Enter your choice: ");
                    string userChoice = Console.ReadLine();

                    if (userChoice == "1")
                    {
                        if (Authentication.UserLogin())
                        {
                            User.usermenu();
                        }
                    }
                    else if (userChoice == "2")
                    {
                        Authentication.UserRegistration();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("\nExiting from railway reservation system...");
                    break;
                }
                else
                {
                    Console.WriteLine("\nEnter a valid option.");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.Read();
        }
    }
}
