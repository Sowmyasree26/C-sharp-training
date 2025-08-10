using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Railway_Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********WELCOME TO RAILWAY RESERVATION SYSTEM************");

            while (true)
            {
                Console.WriteLine("\nWho you are \n 1.ADMIN \n 2.USER \n 3.EXIT  ");
                Console.Write("\nEnter your choice: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("\nPlease enter a valid number.");
                    continue;
                }

                if (choice == 1)
                {
                    Admin.AdminMenu();
                }
                else if (choice == 2)
                {
                    User.usermenu();
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
