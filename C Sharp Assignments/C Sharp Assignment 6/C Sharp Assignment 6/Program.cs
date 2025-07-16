using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C_Sharp_Assignment_6
{
    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }

    public class BookShelf
    {
        private Books[] bookArray = new Books[5];
        public Books this[int index]
        {
            get
            {
                if (index >= 0 && index < bookArray.Length)
                    return bookArray[index];
                else
                    throw new IndexOutOfRangeException("Invalid index");
            }
            set
            {
                if (index >= 0 && index < bookArray.Length)
                    bookArray[index] = value;
                else
                    throw new IndexOutOfRangeException("Invalid index");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program.RunBookShelf();
            Program.WriteUserInputToFile();
            Program.CountLinesInFile();
            Console.ReadLine();
        }
        static void RunBookShelf()
        {
            BookShelf shelf = new BookShelf();

            Console.WriteLine("Enter details for 5 books:");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter name of book {i + 1}: ");
                string bookName = Console.ReadLine();

                Console.Write($"Enter author of book {i + 1}: ");
                string authorName = Console.ReadLine();

                shelf[i] = new Books(bookName, authorName);
            }

            Console.WriteLine("\nBooks in the shelf:");
            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }
        }

        static void WriteUserInputToFile()
        {
            string filePath = "user_input.txt";
            List<string> lines = new List<string>();

            Console.Write("How many lines do you want to write to the file? ");
            if (int.TryParse(Console.ReadLine(), out int count))
            {
                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Enter line {i + 1}: ");
                    string input = Console.ReadLine();
                    lines.Add(input);
                }

                try
                {
                    
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine($"\n File '{filePath}' created and data written successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine(" Invalid number entered.");
            }

        }

        static void CountLinesInFile()
        {
            string filePath = "user_input.txt"; 

            try
            {
                if (File.Exists(filePath))
                {
                    int lineCount = File.ReadAllLines(filePath).Length;
                    Console.WriteLine($"\n The file '{filePath}' contains {lineCount} line(s).");
                }
                else
                {
                    Console.WriteLine("File does not exist. Please make sure 'user_input.txt' was created.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" An error occurred: " + ex.Message);
            }
        }
    }
}
