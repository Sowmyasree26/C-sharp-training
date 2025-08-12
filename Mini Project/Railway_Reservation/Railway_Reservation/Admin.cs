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
            Console.WriteLine("\n************ Available Trains **************");
            User.ShowAllTrainss();
            Console.Write("\nEnter Train Number to Modify: ");
            if (!int.TryParse(Console.ReadLine(), out int trainNo))
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM trains WHERE train_no = @train_no AND isactive = 1", con);
                checkCmd.Parameters.AddWithValue("@train_no", trainNo);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists == 0)
                {
                    Console.WriteLine("Invalid train number.");
                    return;
                }

                Console.WriteLine("\nWhat do you want to update?");
                Console.WriteLine("1. Train Name\n2. Source\n3. Destination\n4. Price for 1AC\n5. Price for 2AC\n6. Price for Sleeper");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                string field = "", value = "";

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new Train Name: ");
                        field = "train_name";
                        value = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Enter new Source: ");
                        field = "source";
                        value = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Enter new Destination: ");
                        field = "destination";
                        value = Console.ReadLine();
                        break;
                    case "4":
                        Console.Write("Enter new Price for 1AC: ");
                        field = "ticket_price_1ac";
                        value = Console.ReadLine();
                        break;
                    case "5":
                        Console.Write("Enter new Price for 2AC: ");
                        field = "ticket_price_2ac";
                        value = Console.ReadLine();
                        break;
                    case "6":
                        Console.Write("Enter new Price for Sleeper: ");
                        field = "ticket_price_sleeper";
                        value = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }
                SqlCommand updateCmd = new SqlCommand($"UPDATE trains SET {field} = @value WHERE train_no = @train_no", con);
                updateCmd.Parameters.AddWithValue("@value", value);
                updateCmd.Parameters.AddWithValue("@train_no", trainNo);
                try
                {
                    updateCmd.ExecuteNonQuery();
                    Console.WriteLine("\nTrain detail updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
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
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM bookings WHERE train_no = @train_no AND status = 'booked' AND journey_date >= CAST(GETDATE() AS DATE)",
                    con);
                checkCmd.Parameters.AddWithValue("@train_no", trainID);
                int bookingCount = (int)checkCmd.ExecuteScalar();
                if (bookingCount > 0)
                {
                    Console.WriteLine($"\nThere are {bookingCount} future bookings for this train.");
                    Console.Write("All bookings will be cancelled. Do you want to continue? (y/n): ");
                    string confirm = Console.ReadLine().ToLower();

                    if (confirm != "y")
                    {
                        Console.WriteLine("Train deletion cancelled.");
                        return;
                    }
                }

                SqlCommand deleteCmd = new SqlCommand("sp_deletetrain", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                deleteCmd.Parameters.AddWithValue("@train_no", trainID);

                try
                {
                    deleteCmd.ExecuteNonQuery();
                    Console.WriteLine("\nTrain deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

    }
}
