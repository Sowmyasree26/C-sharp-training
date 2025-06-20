using System;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.SwapNumbers();
            Program.NumberPattern();
            Program.DisplayWeek();
            Program.Arrays();
            Program.marks();
            Program.CopyArrayElements();
            Program.strings();
            Console.ReadLine();
        }
        static void SwapNumbers()
        {
            int a, b, c;
            Console.Write("Enter a number:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter another number:");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Before swapping a and b are " + a + " " + b);
            c = a;
            a = b;
            b = c;
            Console.WriteLine("After swapping a and b are " + a + " " + b);
        }
        static void NumberPattern()
        {
            int a;
            Console.WriteLine("Enter a number");
            a = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Console.Write(a + " ");
                }
                Console.WriteLine();
            }
        }
        static void DisplayWeek()
        {
            int a;
            Console.Write("Enter a number");
            a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("Entered day is Monday");
                    break;
                case 2:
                    Console.WriteLine("Entered day is Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Entered day is Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Entered day is Thursday");
                    break;
                case 5:
                    Console.WriteLine("Entered day is Friday");
                    break;
                case 6:
                    Console.WriteLine("Entered day is Saturday");
                    break;
                case 7:
                    Console.WriteLine("Entered day is Sunday");
                    break;
                default:
                    Console.WriteLine("Entered number must be between 1 and 7");
                    break;
            }
        }
        static void Arrays()
        {
            int n, sum = 0,min,max;
            Console.Write("Enter size of array:");
            n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            Console.Write("Enter array elements:");
            for(int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
                sum = sum + arr[i];
            }
            min = max = arr[0];
            foreach(int i in arr)
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
            }
            Console.WriteLine("Average of the array elements is " + (sum / n) +
                " Minimum value is " + min + " and Maximum value is " + max);
        }
        static void marks()
        {
            int total=0, min, max,temporary;
            int[] arr = new int[10];
            Console.Write("Enter 10 elements");
            for (int i = 0; i< 10; i++)
            {
                arr[i]=Convert.ToInt32(Console.ReadLine());
                total = total + arr[i];
            }
            Console.WriteLine("Total marks of 10 subjects is:" + total);
            min = max = arr[0];
            foreach (int i in arr)
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
            }
            Console.WriteLine("Minimum marks of 10 subjects is:" + min+" Maximum is "+max);
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 10; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        temporary = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temporary;
                    }
                }
            }
            Console.WriteLine("Ascending order of 10 subjects is:");
            foreach (int i in arr)
            {
                Console.Write(arr[i]+" ");
            }
            Console.WriteLine();
            Array.Sort(arr);
            Array.Reverse(arr);
            Console.Write("Descending order of 10 subjects is:");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void CopyArrayElements()
        {
            int n;
            Console.Write("Enter size of array");
            n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            int[] arr2 = new int[n];
            Console.Write("Enter array1 elements");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                arr2[i] = arr[i];
            }
            Console.Write("Elements of copied array are:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr2[i]+" ");
            }
            Console.WriteLine();
        }
        static void strings()
        {
            string str1, str2, Reverse;
            Reverse = "";
            Console.Write("Enter string 1:");
            str1 = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter string 2:");
            str2 = Console.ReadLine();
            Console.WriteLine("Length of string 1 is :" + str1.Length);
            for(int i= str1.Length - 1; i >= 0; i--)
            {
                Reverse = Reverse + str1[i];
            }
            Console.WriteLine("Reversed string of string 1 is"+ Reverse);
            if (str1 == str2)
            {
                Console.WriteLine("Two strings are equal");
            }
            else
                Console.WriteLine("Strings are not equal");
        }
    }
}
