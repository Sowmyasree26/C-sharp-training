using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Code_Challenge_3
{
    class CricketTeam
    {
        public (int Count, int Sum, double Average) Pointscalculation(int no_of_matches)
        {
            List<int> scores = new List<int>();
            int sum = 0;
            for (int i = 0; i < no_of_matches; i++)
            {
                int score;
                while (true)
                {
                    Console.Write($"Please enter Match {i + 1} score: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out score) && score >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a non-negative integer score only.");
                    }
                }

                scores.Add(score);
                sum += score;
            }
            double average = no_of_matches > 0 ? (double)sum / no_of_matches : 0;
            return (no_of_matches, sum, average);
        }
    }

    class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public Box() { }
        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        public static Box Add(Box b1, Box b2)
        {
            return new Box(b1.Length + b2.Length, b1.Breadth + b2.Breadth);
        }
        public void Display()
        {
            Console.WriteLine($"Length is {Length} and Breadth is {Breadth}");
        }
    }
    class Test
    {
        public void Run()
        {
            Box box1 = ReadBoxDetails("Box 1");
            Box box2 = ReadBoxDetails("Box 2");
            Box box3 = Box.Add(box1, box2);
            Console.WriteLine("\nDetails of Box 3 which is Sum of Box 1 and Box 2:");
            box3.Display();
        }
        private Box ReadBoxDetails(string boxName)
        {
            double length, breadth;
            Console.WriteLine($"\nEnter details for {boxName}:");
            while (true)
            {
                Console.Write("Length: ");
                string lengthInput = Console.ReadLine();
                if (double.TryParse(lengthInput, out length) && length >= 0)
                    break;
                Console.WriteLine("Invalid input. Please enter a non-negative number only for length.");
            }
            while (true)
            {
                Console.Write("Breadth: ");
                string breadthInput = Console.ReadLine();
                if (double.TryParse(breadthInput, out breadth) && breadth >= 0)
                    break;
                Console.WriteLine("Invalid input. Please enter a non-negative number only for breadth.");
            }
            return new Box(length, breadth);
        }
    }

    class Calculator
    {

        public delegate double Operation(double a, double b);
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;

    }
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************Question 1************\n");
            Program.CricketScore();
            Console.WriteLine("*************Question 2************\n");
            Test test = new Test();
            test.Run();
            Console.WriteLine("*************Question 3************\n");
            Program.FileHandling();
            Console.WriteLine("*************Question 4************\n");
            Program.CalculateMenu();
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
        static void CricketScore()
        {
            int matches;
            while (true)
            {
                Console.Write("Enter the number of matches played: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out matches) && matches > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive number of matches.");
                }
            }
            CricketTeam team = new CricketTeam();
            var result = team.Pointscalculation(matches);
            Console.WriteLine($"\nTotal Matches: {result.Count}");
            Console.WriteLine($"Sum of Scores: {result.Sum}");
            Console.WriteLine($"Average Score: {result.Average:F2}");
        }
        static void FileHandling()
        {

            string filePath = "sample.txt";
            Console.Write("Enter some text to add to the file: ");
            string userInput = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(userInput);
                }
                Console.WriteLine("Text successfully appended to the file. To see the file open sample.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void CalculateMenu()
        {

            while (true)
            {
                Console.WriteLine("\n--- Calculator Menu ---");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option (1-4): ");
                string choice = Console.ReadLine();

                Calculator.Operation operation = null;

                switch (choice)
                {
                    case "1":
                        operation = Calculator.Add;
                        break;
                    case "2":
                        operation = Calculator.Subtract;
                        break;
                    case "3":
                        operation = Calculator.Multiply;
                        break;
                    case "4":
                        Console.WriteLine("Exiting from calculator.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option between 1 to 4.");
                        continue;
                }

                double num1 = ReadDouble("Enter first number: ");
                double num2 = ReadDouble("Enter second number: ");

                double result = operation(num1, num2);
                Console.WriteLine($"Result: {result}");
            }
        }
        static double ReadDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out value))
                    return value;
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

        }
    }
}
