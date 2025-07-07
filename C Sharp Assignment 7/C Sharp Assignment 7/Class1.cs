using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_7
{
    public class Class1
    {

        public string CalculateConcession(int age, double totalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double concessionFare = totalFare * 0.7;
                return $"Senior Citizen - Fare after concession: {concessionFare}";
            }
            else
            {
                return $"Ticket Booked for Fare: {totalFare}";
            }
        }
    }
}
