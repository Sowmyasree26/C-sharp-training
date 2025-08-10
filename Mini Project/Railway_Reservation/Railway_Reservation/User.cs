using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Railway_Reservation
{
    class User
    {
        static string connect = "Data Source=ICS-LT-84F3D64\\SQLEXPRESS;Initial Catalog=trainreservation;" +
                            "user id=sa; password=Smiley@262004";

        public static void usermenu()
        {
            while (true)
            {
                Console.WriteLine("\n                       *****************User Menu******************");
                Console.WriteLine("\n1. Book Ticket\n2. Cancel Ticket\n3. Show All Trains\n4.bookings & Cancellations \n5. Exit");
                Console.Write("\nSelect an Option: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    BookTicket();
                }
                else if (choice == 2)
                {
                    CancelTicket();
                }
                else if (choice == 3)
                {
                    ShowAllTrainss();
                }
                else if (choice == 4)
                {
                    ShowBookings();
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Exiting from user menu...");
                    break;
                }
                else
                {
                    Console.WriteLine("enter valid option");
                }

            }
        }

        public static void BookTicket()
        {
            Console.WriteLine("*********Available Trains*********");
            ShowAllTrainss();

            Console.WriteLine("\n*********Enter Booking Details*********");

            int trainNo;
            Console.Write("\nEnter Train Number: ");
            while (!int.TryParse(Console.ReadLine(), out trainNo))
                Console.WriteLine("Please enter a valid train number.");

            Console.Write("\nEnter Passenger Name: ");
            string passengerName = Console.ReadLine();

            string travelClass;
            while (true)
            {
                Console.Write("\nEnter Class (1ac / 2ac / sleeper): ");
                travelClass = Console.ReadLine().ToLower();
                if (travelClass == "1ac" || travelClass == "2ac" || travelClass == "sleeper")
                    break;
                Console.WriteLine("Invalid class. Please enter 1ac, 2ac, or sleeper.");
            }

            int berthsBooked;
            Console.Write("\nEnter Number of Berths to Book: ");
            while (!int.TryParse(Console.ReadLine(), out berthsBooked) || berthsBooked <= 0)
                Console.WriteLine("Please enter a valid number of berths.");

            DateTime journeyDate;
            Console.Write("\nEnter Journey Date (yyyy-mm-dd): ");
            while (!DateTime.TryParse(Console.ReadLine(), out journeyDate))
                Console.WriteLine("Please enter a valid date in yyyy-mm-dd format.");

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_bookticket", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@train_no", trainNo);
                cmd.Parameters.AddWithValue("@passenger_name", passengerName);
                cmd.Parameters.AddWithValue("@class", travelClass);
                cmd.Parameters.AddWithValue("@berths_booked", berthsBooked);
                cmd.Parameters.AddWithValue("@journey_date", journeyDate);

                SqlParameter costParam = new SqlParameter("@total_cost", SqlDbType.Float)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(costParam);

                try
                {
                    cmd.ExecuteNonQuery();

                    if (costParam.Value != DBNull.Value && Convert.ToDouble(costParam.Value) > 0)
                    {
                        Console.WriteLine($"\nBooking successful! Total cost: Rs{costParam.Value}");
                    }
                    else
                    {
                        Console.WriteLine("\nBooking failed. Please enter valid details or check available berths and try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static void CancelTicket()
        {
            Console.WriteLine("\n**************Cancel Ticket*****************");

            int bookingId;
            Console.Write("\nEnter Booking ID to cancel: ");
            while (!int.TryParse(Console.ReadLine(), out bookingId))
                Console.WriteLine("Please enter a valid booking ID.");

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_cancelticket", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@booking_id", bookingId);

                SqlParameter refundParam = new SqlParameter("@refund_amount", SqlDbType.Float)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(refundParam);

                try
                {
                    cmd.ExecuteNonQuery();
                    float refund = Convert.ToSingle(refundParam.Value);

                    if (refund > 0)
                    {
                        Console.WriteLine($"\nCancellation successful... Refund amount: Rs{refund}");
                    }
                    else
                    {
                        Console.WriteLine("\nCancellation failed. Booking not found or already cancelled.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void ShowBookings()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_showallbookings", connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\nBooking Details:");
                        Console.WriteLine("\n----------------------------------------------------------------------");

                        while (reader.Read())
                        {
                            Console.WriteLine($"\nBooking ID: {reader["booking_id"]}");
                            Console.WriteLine($"Train No: {reader["train_no"]},\t Passenger: {reader["passenger_name"]},\t Class: {reader["class"]}");
                            Console.WriteLine($"Berths Booked: {reader["berths_booked"]},\t Journey Date: {reader["journey_date"]},\t Status: {reader["status"]}");
                            Console.WriteLine("----------------------------------------------------------------------");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError while fetching bookings: {ex.Message}");
            }
        }

        public static void ShowAllTrainss()
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_showalltrains", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\nAvailable Trains:");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("TrainNo | TrainName | Source | Destination | 1st_AC \t| Price_1AC | 2nd_AC\t | Price_2AC | Sleeper\t | Price_Sleeper");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["train_no"]}   | {reader["train_name"]}  | {reader["source"]}  | {reader["destination"]}  | " +
                                      $"{reader["available_1ac"]}   | Rs{reader["ticket_price_1ac"]}   | {reader["available_2ac"]}   | Rs{reader["ticket_price_2ac"]}   | " +
                                      $"{reader["available_sleeper"]}   | Rs{reader["ticket_price_sleeper"]}  ");
                }
            }
        }

    }
}
