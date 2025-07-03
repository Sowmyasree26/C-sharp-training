using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_5
{
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    class Accounts
    {
        private int AccountNo, Amount, Balance;
        private string CustomerName, AccountType;
        private char Transaction;
        public Accounts(int accountNo, string customerName, string accountType, char transaction, int amount, int balance)
        {
            AccountNo = accountNo;
            CustomerName = customerName;
            AccountType = accountType;
            Transaction = transaction;
            Amount = amount;
            Balance = balance;

            try
            {
                if (Transaction == 'D')
                {
                    Credit(amount);
                }
                else if (Transaction == 'W')
                {
                    Debit(amount);
                }
                else
                {
                    Console.WriteLine("Invalid transaction type.");
                }
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Transaction failed: " + ex.Message);
            }
        }

        public void Credit(int amt)
        {
            Balance += amt;
        }

        public void Debit(int amt)
        {
            if (amt <= Balance)
            {
                Balance -= amt;
            }
            else
            {
                throw new InsufficientBalanceException("Insufficient balance.");
            }
        }

        public void ShowData()
        {
            Console.WriteLine("Account Number: " + AccountNo);
            Console.WriteLine("Customer Name: " + CustomerName);
            Console.WriteLine("Account Type: " + AccountType);
            Console.WriteLine("Transaction Type: " + Transaction);
            Console.WriteLine("Transaction Amount: " + Amount);
            Console.WriteLine("Balance: " + Balance);
        }
    }


    public class Scholarship
    {
        public class InvalidMarksException : Exception
        {
            public InvalidMarksException(string message) : base(message) { }
        }

        public double Merit(int marks, double fees)
        {
            double scholarshipAmount;

            if (marks >90)
            {
                scholarshipAmount = fees * 0.50;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = fees * 0.30;
            }
            else if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = fees * 0.20;
            }
            else
            {
                throw new InvalidMarksException("Scholarship not applicable.");
            }

            return scholarshipAmount;
        }
    }

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
            Console.WriteLine("************Question 1**************");
            try
            {
                Console.WriteLine("Enter Account Number:");
                int AccountNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Customer Name:");
                string CustomerName = Console.ReadLine();
                Console.WriteLine("Enter Account type:");
                string AccountType = Console.ReadLine();
                Console.WriteLine("Enter Transaction type (D/W):");
                char Transaction = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.WriteLine("Enter Amount:");
                int Amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Balance:");
                int Balance = Convert.ToInt32(Console.ReadLine());
                Accounts accounts = new Accounts(AccountNo, CustomerName, AccountType, Transaction, Amount, Balance);
                accounts.ShowData();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input format error: " + ex.Message);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }

            Console.WriteLine("************Question 2*********");

            Scholarship s = new Scholarship();

            try
            {
                Console.Write("Enter marks: ");
                int marks = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter fees: ");
                double fees = Convert.ToDouble(Console.ReadLine());

                double amount = s.Merit(marks, fees);
                Console.WriteLine("Scholarship Amount: " + amount);
            }
            catch (Scholarship.InvalidMarksException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numeric values.");
            }

            Console.WriteLine("***********Question 3***********");

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

            Console.ReadLine();
        }
    }
}
