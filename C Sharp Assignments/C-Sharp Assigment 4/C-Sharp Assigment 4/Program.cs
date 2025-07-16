using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assigment_4
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    public class MobilePhone
    {
        public delegate void RingEventHandler();
        public event RingEventHandler OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call...");
            OnRing?.Invoke();
        }
    }

    public class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }

    public class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }

    public class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }

    class Program
    {
        static List<Employee> employee = new List<Employee>();
        static void Main(string[] args)
        {
            int choice = 1;
            do
            {
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                        Program.AddEmployee();
                    else if (choice == 2)
                        Program.ViewEmployee();
                    else if (choice == 3)
                        Program.SearchEmployee();
                    else if (choice == 4)
                        Program.UpdateEmployee();
                    else if (choice == 5)
                        Program.DeleteEmployee();
                    else if (choice == 6)
                        Console.WriteLine("Exiting");
                    else
                        Console.WriteLine("Invalid choice");
                }

                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }


            } while (choice != 6);
            Console.WriteLine("********* Question 2 ***********");

            MobilePhone phone = new MobilePhone();

            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();

            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowCallerInfo;
            phone.OnRing += vibration.Vibrate;

            phone.ReceiveCall();
            Console.ReadLine();
        }
        static void AddEmployee()
        {
            Employee emp = new Employee();
            Console.Write("Enter Employee ID: ");
            emp.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();
            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();
            Console.Write("Enter Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());
            Console.WriteLine("Employee details added succesfully.");
            employee.Add(emp);
        }
        static void ViewEmployee()
        {
            foreach (var emp in employee)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: {emp.Salary}");
            }

        }

        static void SearchEmployee()
        {
            Console.Write("Enter Employee ID to search: ");
            int id = int.Parse(Console.ReadLine());
            Employee emp = null;
            foreach (var e in employee)
            {
                if (e.Id == id)
                {
                    emp = e;
                    break;
                }
            }

            if (emp != null)
            {
                Console.WriteLine($"Details of {id} are:");
                Console.WriteLine($"Name : {emp.Name} Department: {emp.Department} Salary: {emp.Salary} ");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Employee emp = null;
            foreach (var e in employee)
            {
                if (e.Id == id)
                {
                    emp = e;
                    break;
                }
            }
            if (emp != null)
            {
                Console.WriteLine("Enter new name");
                emp.Name = Console.ReadLine();
                Console.WriteLine("Enter new department");
                emp.Department = Console.ReadLine();
                Console.WriteLine("Enter new salary");
                emp.Salary = double.Parse(Console.ReadLine());
            }
            else
                Console.WriteLine("Invalid id enter a valid one.");
        }
        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Employee emp = null;
            foreach (var e in employee)
            {
                if (e.Id == id)
                {
                    emp = e;
                    break;
                }
            }
            if (emp != null)
            {
                employee.Remove(emp);
            }
            else
                Console.WriteLine("Invalid id. Enter a valid one.");
    
        }
    }
}
