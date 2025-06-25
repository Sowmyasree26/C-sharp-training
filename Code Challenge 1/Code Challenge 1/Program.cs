using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Question1();
            Program.Question2();
            Program.Question3();
            Console.ReadLine();
        }
        static void Question1()
        {
            string s,result;
            int position;
            Console.WriteLine("Enter a string");
            s = Console.ReadLine();
            result = s;
            Console.WriteLine("Enter a position to remove the charector from the string");
            position = Convert.ToInt32(Console.ReadLine());
            if (position >= 0 && position <= (s.Length))
            {
                result = s.Remove(position, 1);
            }
            else
                Console.WriteLine("Invalid Position");
            Console.WriteLine("After removing the charector the result is:" + result);
        }
        static void Question2()
        {
            string str;
            Console.WriteLine("Enter a string");
            str = Console.ReadLine();
            char[] chararray = str.ToCharArray();
            char temp = chararray[0];
            chararray[0] = chararray[chararray.Length - 1];
            chararray[chararray.Length - 1] = temp;
            string result = new string(chararray);
            Console.WriteLine("Result String after swapping is: " + result);
        }
        static void Question3()
        {
            int number1, number2, number3, Maximum;
            Console.Write("Enter first number: ");
            number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            number2 = int.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            number3 = int.Parse(Console.ReadLine());
            if (number1 >= number2 && number1 >= number3)
            {
                Maximum = number1;
            }
            else if (number2 >= number1 && number2 >= number3)
            {
                Maximum = number2;
            }
            else
            {
                 Maximum= number3;
            }
            Console.WriteLine("Largest number is: " + Maximum);
        }
    }
}
