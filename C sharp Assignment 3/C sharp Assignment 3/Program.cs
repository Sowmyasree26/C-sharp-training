using System;

namespace C_sharp_Assignment_3
{

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
                Console.WriteLine("Insufficient balance for withdrawal.");
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

    class Student
    {
        public int RollNo, Semester, Class,c;
        public string Name, Branch, Result;
        public int[] Marks = new int[5];
        public Student(int rollNo, string name, int Studentclass, int semester, string branch)
        {
            RollNo = rollNo;
            Name = name;
            Class = Studentclass;
            Semester = semester;
            Branch = branch;

        }
        public void GetMarks()
        {
            Console.WriteLine("Enter marks for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Marks[i] = Convert.ToInt32(Console.ReadLine());
                
            }
        }
        public void CalculateResult()
        {
            int total = 0;
            float average;
            foreach (int i in Marks)
            {
                total += i;
            }
            average = total / 5;
            foreach(int i in Marks)
            {
                if (i < 35)
                {
                    c = 0;
                    break;
                }
                else if (i >= 35)
                    c = 1;
            }
            if (c == 1 && average >= 50)
                Result = "Passed";
            else
                Result = "Failed";
        } 
        public void DisplayData()
        {
            Console.WriteLine("Student Details:");
            Console.WriteLine("Roll No: " + RollNo);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Class: " + Class);
            Console.WriteLine("Semester: " + Semester);
            Console.WriteLine("Branch: " + Branch);
            Console.WriteLine("Marks:");
            foreach (int i in Marks)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine("Result is:"+Result);
        }
    }


    class Saledetails
    {
        int Salesno;
        int Productno;
        double Price;
        string Dateofsale;
        int Qty;
        double TotalAmount;

        public Saledetails(int salesno, int productno, double price, int qty, string dateofsale)
        {
            Salesno = salesno;
            Productno = productno;
            Price = price;
            Qty = qty;
            Dateofsale = dateofsale;
            Sales();
        }

        public void Sales()
        {
            TotalAmount = Qty * Price;
        }

        public static void ShowData(Saledetails sale)
        {
            Console.WriteLine("Sales No: " + sale.Salesno);
            Console.WriteLine("Product No: " + sale.Productno);
            Console.WriteLine("Price: " + sale.Price);
            Console.WriteLine("Quantity: " + sale.Qty);
            Console.WriteLine("Date of Sale: " + sale.Dateofsale);
            Console.WriteLine("Total Amount: " + sale.TotalAmount);
        }
    }

        class Program
        {
            static void Main(string[] args)
            {
                int AccountNo, Amount, Balance;
                string CustomerName, AccountType;
                char Transaction;
                Console.WriteLine("Enter Account Number:");
                AccountNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Customer Name:");
                CustomerName = Console.ReadLine();
                Console.WriteLine("Enter Account type:");
                AccountType = Console.ReadLine();
                Console.WriteLine("Enter Transaction type:");
                Transaction = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter Amount:");
                Amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Balance:");
                Balance = Convert.ToInt32(Console.ReadLine());
                Accounts accounts = new Accounts(AccountNo, CustomerName, AccountType, Transaction, Amount, Balance);
                accounts.ShowData();

                Console.WriteLine("***********Question 2************");
                int RollNo, Semester, Class;
                string Name, Branch;
                int[] Marks = new int[5];
                Console.WriteLine("Enter Roll Number of the student:");
                RollNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("EnterSemester number of the student:");
                Semester = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter name of the student:");
                Name = Console.ReadLine();
                Console.WriteLine("Enter Class of the student:");
                Class = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Branch of the student:");
                Branch = Console.ReadLine();
                Student student1 = new Student(RollNo, Name, Class, Semester, Branch);
                student1.GetMarks();
                student1.CalculateResult();
                student1.DisplayData();

                Console.WriteLine("***********Question 3************");
                int salesno, productno, qty;
                double price;
                string dateofsale;
                Console.Write("Enter Sales No: ");
                salesno = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Product No: ");
                productno = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Quantity: ");
                qty = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Date of Sale (dd-mm-yyyy): ");
                dateofsale = Console.ReadLine();
                Saledetails sale = new Saledetails(salesno, productno, price, qty, dateofsale);
                Saledetails.ShowData(sale);
                Console.ReadLine();
            }
        }
    }
