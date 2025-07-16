using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_7
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Program.ListSquares();
            Program.StartsAndEnds();
            Program.EmployeeDetails();
            Program.FairVisit();
            Console.ReadLine();
        }
        static void ListSquares()
        {

            Console.Write("Enter how many numbers you want to input: ");
            int count = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            Console.WriteLine("Enter the numbers one by one:");
            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());
                numbers.Add(num);
            }

            Console.WriteLine("Numbers and their squares (only if square > 20):");
            foreach (int num in numbers)
            {
                int square = num * num;
                if (square > 20)
                    Console.WriteLine($"{num} - {square}");
            }
        }
        static void StartsAndEnds()
        {

            Console.Write("Enter how many words you want to input: ");
            int count = int.Parse(Console.ReadLine());

            List<string> words = new List<string>();

            Console.WriteLine("Enter the words one by one:");
            for (int i = 0; i < count; i++)
            {
                string word = Console.ReadLine();
                words.Add(word);
            }

            Console.WriteLine("Words starting with 'a' and ending with 'm':");
            foreach (string word in words)
            {
                if (word.StartsWith("a", StringComparison.OrdinalIgnoreCase) &&
                word.EndsWith("m", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(word);
                }
            }
        }
        static void EmployeeDetails()
        {

            List<Employee> employees = new List<Employee>();

            Console.Write("Enter the number of employees: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}:");

                Console.Write("EmpId: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("EmpName: ");
                string name = Console.ReadLine();

                Console.Write("EmpCity: ");
                string city = Console.ReadLine();

                Console.Write("EmpSalary: ");
                double salary = double.Parse(Console.ReadLine());

                employees.Add(new Employee
                {
                    EmpId = id,
                    EmpName = name,
                    EmpCity = city,
                    EmpSalary = salary
                });
            }

            Console.WriteLine("\nAll Employees:");
            DisplayEmployees(employees);
            Console.WriteLine("\nEmployees with salary > 45000:");
            DisplayEmployees(employees.Where(e => e.EmpSalary > 45000).ToList());
            Console.WriteLine("\nEmployees from Bangalore:");
            DisplayEmployees(employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase)).ToList());
            Console.WriteLine("\nEmployees sorted by name (ascending):");
            DisplayEmployees(employees.OrderBy(e => e.EmpName).ToList());
        }

        static void DisplayEmployees(List<Employee> list)
        {
            foreach (var emp in list)
            {
                Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }
        }
        static void FairVisit()
        {
            const double TotalFare = 500;
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Class1 calculator = new Class1();
            string result = calculator.CalculateConcession(age, TotalFare);
            Console.WriteLine($"\nHello {name}, {result}");
        }
    }
}
    



