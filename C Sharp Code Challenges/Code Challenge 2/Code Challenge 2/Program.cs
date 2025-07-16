using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_2
{

    abstract class Student
    {
        public string Name { get; set; }
        public string StudentId { get; set; }
        public double Grade { get; set; }

        public Student(string name, string studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        public abstract bool IsPassed(double grade);
    }

    class Undergraduate : Student
    {
        public Undergraduate(string name, string studentId, double grade)
        : base(name, studentId, grade) { }

        public override bool IsPassed(double grade)
        {
            return Grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public Graduate(string name, string studentId, double grade)
        : base(name, studentId, grade) { }

        public override bool IsPassed(double grade)
        {
            return Grade > 80.0;
        }
    }
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Product(int productId, string productName, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }
        public void Display()
        {
            Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Price: {Price}");
        }
    }

    class Number
    {
        public static void CheckNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number is negative.");
            }
            Console.WriteLine($"You entered: {number} is positive");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {

            string type;
            while (true)
            {
                Console.Write("Enter student type (Undergraduate/Graduate): ");
                type = Console.ReadLine().Trim().ToLower();

                if (type == "undergraduate" || type == "graduate")
                    break;

                Console.WriteLine("Invalid student type. Please enter 'Undergraduate' or 'Graduate'.");
            }

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student ID: ");
            string studentId = Console.ReadLine();

            Console.Write("Enter grade: ");
            double grade = Convert.ToDouble(Console.ReadLine());

            Student student;

            if (type == "undergraduate")
            {
                student = new Undergraduate(name, studentId, grade);
            }

            else
            {
                student = new Graduate(name, studentId, grade);
            }

            bool passed = student.IsPassed(grade);
            string result = passed ? "Pass" : "Fail";

            Console.WriteLine($"Name : {student.Name} ID: {student.StudentId} Result: {result}");
            
            Console.WriteLine("**********Question 2********");

            List<Product> products = new List<Product>();
            Console.WriteLine("Enter details for 10 products:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\nProduct {i + 1}:");
                Console.Write("Enter Product ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Product Name: ");
                string pname = Console.ReadLine();
                Console.Write("Enter Product Price: ");
                double price = double.Parse(Console.ReadLine());
                products.Add(new Product(id, pname, price));
            }
            var sortedProducts = products.OrderBy(p => p.Price).ToList();
            Console.WriteLine("\nProducts sorted by price (ascending):");
            foreach (var product in sortedProducts)
            {
                product.Display();
            }

            Console.WriteLine("*************Question 3**********");

            Console.WriteLine("Enter an integer: ");
            try
            {
                int input = int.Parse(Console.ReadLine());
                Number.CheckNumber(input); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid integer.");
            }
            
            Console.ReadLine();
        }
    }
}
