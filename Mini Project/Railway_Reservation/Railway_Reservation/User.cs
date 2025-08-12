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

        public static string LastBookedPassenger = "";
        public static void BookTicket()
        {
            Console.WriteLine("********* Available Trains *********");
            ShowAllTrainss();

            Console.WriteLine("\n********* Enter Booking Details *********");

            int trainNo;
            Console.Write("\nEnter Train Number: ");
            while (!int.TryParse(Console.ReadLine(), out trainNo))
                Console.WriteLine("Please enter a valid train number.");

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

            List<string> passengerNames = new List<string>();
            for (int i = 1; i <= berthsBooked; i++)
            {
                Console.Write($"\nEnter name of passenger {i}: ");
                string name = Console.ReadLine();
                passengerNames.Add(name);
            }

            string mainPassenger = passengerNames[0]; 
            LastBookedPassenger = mainPassenger;

            DateTime journeyDate;
            Console.Write("\nEnter Journey Date (yyyy-mm-dd): ");
            while (!DateTime.TryParse(Console.ReadLine(), out journeyDate) || journeyDate < DateTime.Today)
                Console.WriteLine("Please enter a valid future date in yyyy-mm-dd format.");

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_bookticket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@train_no", trainNo);
                cmd.Parameters.AddWithValue("@passenger_name", mainPassenger);
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
                        ShowLatestTicket(); 
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
                        Console.WriteLine($"\nCancellation successful... Refunded 50% amount: Rs{refund}");
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
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"{"Booking ID",-12} | {"Train No",-8} | {"Passenger",-20} | {"Class",-8} | {"Berths",-6} | {"Journey Date",-15} | {"Status",-10}");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------");

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["booking_id"],-12} | {reader["train_no"],-8} | {reader["passenger_name"],-20} | {reader["class"],-8} | " +
                                              $"{reader["berths_booked"],-6} | {Convert.ToDateTime(reader["journey_date"]).ToString("yyyy-MM-dd"),-15} | {reader["status"],-10}");
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
                Console.WriteLine($"{"TrainNo",-8} | {"TrainName",-15} | {"Source",-10} | {"Destination",-12} | {"1st_AC",-8} | {"Price_1AC",-10} | {"2nd_AC",-8} | {"Price_2AC",-10} | {"Sleeper",-8} | {"Price_Sleeper",-13}");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["train_no"],-8} | {reader["train_name"],-15} | {reader["source"],-10} | {reader["destination"],-12} | " +
                                      $"{reader["available_1ac"],-8} | Rs{reader["ticket_price_1ac"],-9} | {reader["available_2ac"],-8} | Rs{reader["ticket_price_2ac"],-9} | " +
                                      $"{reader["available_sleeper"],-8} | Rs{reader["ticket_price_sleeper"],-12}");
                }

            }
        }

        public static void ShowLatestTicket()
        {
            if (string.IsNullOrEmpty(LastBookedPassenger))
            {
                Console.WriteLine("\nNo recent booking found.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM bookings WHERE passenger_name = @name ORDER BY booking_id DESC", con);
                cmd.Parameters.AddWithValue("@name", LastBookedPassenger);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("\n********** TICKET DETAILS **********");
                    Console.WriteLine($"Booking ID     : {reader["booking_id"]}");
                    Console.WriteLine($"Train No       : {reader["train_no"]}");
                    Console.WriteLine($"Passenger Name : {reader["passenger_name"]}");
                    Console.WriteLine($"Class          : {reader["class"]}");
                    Console.WriteLine($"Berths Booked  : {reader["berths_booked"]}");
                    Console.WriteLine($"Journey Date   : {Convert.ToDateTime(reader["journey_date"]).ToShortDateString()}");
                    Console.WriteLine($"Status         : {reader["status"]}");
                    Console.WriteLine($"Total Cost     : Rs{reader["total_cost"]}");
                    Console.WriteLine("************************************");
                }
                else
                {
                    Console.WriteLine("\nNo ticket found for this passenger.");
                }
            }
        }


    }
}
