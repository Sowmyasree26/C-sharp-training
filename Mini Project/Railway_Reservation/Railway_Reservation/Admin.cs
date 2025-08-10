using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation
{
    class Admin
    {
       static string connect = "Data Source=ICS-LT-84F3D64\\SQLEXPRESS;Initial Catalog=trainreservation;" +
                            "user id=sa; password=Smiley@262004";
        public static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n                            **************Admin Menu:*****************");
                Console.Write("\nSelect an  Option from below: ");
                Console.WriteLine("\n1. Add Train\n2. Modify Train\n3. Delete Train\n4. Display All Trains\n5. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddTrain();
                        break;
                    case 2:
                        ModifyTrain();
                        break;
                    case 3:
                        DeleteTrain();
                        break;
                    case 4:
                        User.ShowAllTrainss();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("\nInvalid Option!");
                        break;
                }
            }
        }

        static void AddTrain()
        {
            Console.WriteLine("\n**************Enter train details****************");

            int trainno;
            Console.WriteLine("\nEnter train number:");
            while (!int.TryParse(Console.ReadLine(), out trainno))
            {
                Console.WriteLine("Please enter a valid train number.");
            }

            Console.Write("\nEnter Train Name: ");
            string name = Console.ReadLine();

            int first_ac_seats, first_ac_cost, second_ac_seats, second_ac_cost, sleeper_seats, sleeper_cost;

            Console.WriteLine("\nEnter total seats in First AC:");
            while (!int.TryParse(Console.ReadLine(), out first_ac_seats))
                Console.WriteLine("Please enter a valid number.");

            Console.WriteLine("\nEnter ticket price in First AC:");
            while (!int.TryParse(Console.ReadLine(), out first_ac_cost))
                Console.WriteLine("Please enter a valid number.");

            Console.WriteLine("\nEnter total seats in Second AC:");
            while (!int.TryParse(Console.ReadLine(), out second_ac_seats))
                Console.WriteLine("Please enter a valid number.");

            Console.WriteLine("\nEnter ticket price in Second AC:");
            while (!int.TryParse(Console.ReadLine(), out second_ac_cost))
                Console.WriteLine("Please enter a valid number.");

            Console.WriteLine("\nEnter total seats in Sleeper class:");
            while (!int.TryParse(Console.ReadLine(), out sleeper_seats))
                Console.WriteLine("Please enter a valid number.");

            Console.WriteLine("\nEnter ticket price in Sleeper class:");
            while (!int.TryParse(Console.ReadLine(), out sleeper_cost))
                Console.WriteLine("Please enter a valid number.");

            Console.Write("\nEnter Source: ");
            string source = Console.ReadLine();

            Console.Write("\nEnter Destination: ");
            string destination = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_addtrain", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@train_no", trainno);
                cmd.Parameters.AddWithValue("@train_name", name);
                cmd.Parameters.AddWithValue("@total_1ac", first_ac_seats);
                cmd.Parameters.AddWithValue("@total_2ac", second_ac_seats);
                cmd.Parameters.AddWithValue("@total_sleeper", sleeper_seats);
                cmd.Parameters.AddWithValue("@source", source);
                cmd.Parameters.AddWithValue("@destination", destination);
                cmd.Parameters.AddWithValue("@ticket_price_1ac", first_ac_cost);
                cmd.Parameters.AddWithValue("@ticket_price_2ac", second_ac_cost);
                cmd.Parameters.AddWithValue("@ticket_price_sleeper", sleeper_cost);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("\nTrain added successfully...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }


        static void ModifyTrain()
        {
            Console.WriteLine("\n************Available Trains**************");
            User.ShowAllTrainss();

            int trainno;
            Console.WriteLine("\nEnter train number from the above trains to modify:");
            while (!int.TryParse(Console.ReadLine(), out trainno))
                Console.WriteLine("Please enter a valid train number.");

            Console.Write("\nEnter new Train Name: ");
            string name = Console.ReadLine();

            Console.Write("\nEnter new Source: ");
            string source = Console.ReadLine();

            Console.Write("\nEnter new Destination: ");
            string destination = Console.ReadLine();

            int first_ac_cost, second_ac_cost, sleeper_cost;

            Console.WriteLine("\nEnter new ticket price in First AC:");
            while (!int.TryParse(Console.ReadLine(), out first_ac_cost))
                Console.WriteLine("Please enter a valid number.");

            Console.WriteLine("\nEnter new ticket price in Second AC:");
            while (!int.TryParse(Console.ReadLine(), out second_ac_cost))
                Console.WriteLine("Please enter a valid number.");

            Console.WriteLine("\nEnter new ticket price in Sleeper class:");
            while (!int.TryParse(Console.ReadLine(), out sleeper_cost))
                Console.WriteLine("Please enter a valid number.");

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_modifytrain", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@train_no", trainno);
                cmd.Parameters.AddWithValue("@train_name", name);
                cmd.Parameters.AddWithValue("@source", source);
                cmd.Parameters.AddWithValue("@destination", destination);
                cmd.Parameters.AddWithValue("@ticket_price_1ac", first_ac_cost);
                cmd.Parameters.AddWithValue("@ticket_price_2ac", second_ac_cost);
                cmd.Parameters.AddWithValue("@ticket_price_sleeper", sleeper_cost);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("\nTrain details updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }


        static void DeleteTrain()
        {
            int trainID;
            Console.Write("\nEnter Train Number to Delete: ");
            while (!int.TryParse(Console.ReadLine(), out trainID))
                Console.WriteLine("Please enter a valid train number.");

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_deletetrain", con)
                { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@train_no", trainID);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("\nTrain deleted successfully...");
                    else
                        Console.WriteLine("\nTrain not found.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }



    }
}
