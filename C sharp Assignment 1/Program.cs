using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.problem1();
            Program.problem2();
            Program.problem3();
            Program.problem4();
            Program.problem5();
        }
        static void problem1()
        {
            int a, b;
            Console.WriteLine("Enter a number:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter another number:");
            b = Convert.ToInt32(Console.ReadLine());
            if (a == b)
                Console.WriteLine(a + " and " + b + "are equal");
            else
                Console.WriteLine(a + " and " + b + "are not equal");
        }
        static void problem2()
        {
            int a;
            Console.WriteLine("Enter a number to check wether positive or negative:");
            a = Convert.ToInt32(Console.ReadLine());
            if (a > 0)
                Console.WriteLine(a + " is Positive");
            else if (a < 0)
                Console.WriteLine(a + " is Negative");
            else
                Console.WriteLine("Entered number is Zero");
        }
        static void problem3()
        {
            int a, b, temporary;
            char symbol;
            Console.WriteLine("Enter 1st operand:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd operand:");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter operator:");
            symbol = Convert.ToChar(Console.ReadLine());
            if (a < b)
            {
                temporary = a;
                a = b;
                b = temporary;
            }

            if (symbol == '+')
            {
                Console.WriteLine("sum of " + a + " and " + b + " is " + (a + b));
            }
            else if (symbol == '-')
            {
                Console.WriteLine("Difference of " + a + " and " + b + " is " + (a - b));
            }
            else if (symbol == '*')
            {
                Console.WriteLine("Product of " + a + " and " + b + " is " + (a * b));
            }
            else if (symbol == '/')
            {
                Console.WriteLine("Division of " + a + " and " + b + " is " + (a / b));
            }
            else
            {
                Console.WriteLine("Invalid operator");
            }
        }
        static void problem4()
        {
            Console.WriteLine("Enter a number:");
            int a = Convert.ToInt32(Console.ReadLine());
            for (int b = 0; b <= 10; b++)
            {
                Console.WriteLine(a + " * " + b + " = " + a * b);
            }
        }
        static void problem5()
        {
            int a, b;
            Console.WriteLine("Enter a number:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter another number:");
            b = Convert.ToInt32(Console.ReadLine());
            if (a == b)
                Console.WriteLine("Triple of sum of the two numbers is " + 3 * (a + b));
            Console.ReadLine();
        }
    }
}
