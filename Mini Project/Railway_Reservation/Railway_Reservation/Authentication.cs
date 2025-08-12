using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace Railway_Reservation
{
    public class Authentication
    {
        static string connect = "Data Source=ICS-LT-84F3D64\\SQLEXPRESS;Initial Catalog=trainreservation;user id=sa;password=Smiley@262004";

        public static bool AdminLogin()
        {
            Console.Write("\nEnter Admin Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_validateadmin", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                string status = cmd.ExecuteScalar()?.ToString();
                if (status == "valid")
                {
                    Console.WriteLine("\nLogin successful!");
                    return true;
                }
                else
                {
                    Console.WriteLine("\nInvalid credentials.");
                    return false;
                }
            }
        }

        public static bool UserLogin()
        {
            Console.Write("\nEnter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_validateuser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                string status = cmd.ExecuteScalar()?.ToString();
                if (status == "valid")
                {
                    Console.WriteLine("\nLogin successful!");
                    return true;
                }
                else
                {
                    Console.WriteLine("\nInvalid credentials.");
                    return false;
                }
            }
        }


        public static void UserRegistration()
        {
            Console.Write("\nEnter New Username: ");
            string username = Console.ReadLine();

            string password;
            while (true)
            {
                Console.Write("Enter Password (must contain letters and numbers): ");
                password = Console.ReadLine();
                if (Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$"))
                    break;
                Console.WriteLine("Invalid password. It must contain at least one letter and one number.");
            }

            string email;
            while (true)
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
                if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    break;
                Console.WriteLine("Invalid email format.");
            }

            string phone;
            while (true)
            {
                Console.Write("Enter Phone Number (10 digits): ");
                phone = Console.ReadLine();
                if (Regex.IsMatch(phone, @"^\d{10}$"))
                    break;
                Console.WriteLine("Phone number must be exactly 10 digits.");
            }

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_registeruser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("\nRegistration successful!");
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("duplicate") || ex.Message.Contains("unique"))
                        Console.WriteLine("\nUser already registered. Please login.");
                    else
                        Console.WriteLine($"\nError: {ex.Message}");
                }
            }
        }
    }
}
