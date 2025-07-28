using System;
using System.Collections.Generic;
using System.Linq;

namespace ADO_Assignment_1
{
    class Program
    {
        static List<Employee> empList = new List<Employee>();

        static void Main(string[] args)
        {

            DataEntry();
            Console.WriteLine();
            Employees_JoinedBefore_2015();
            Console.WriteLine();
            Employees_DOB_After_1990();
            Console.WriteLine();
            Consultants_Associates();
            Console.WriteLine();
            Total_Employees();
            Console.WriteLine();
            Employees_Chennai();
            Console.WriteLine();
            Highest_Employee();
            Console.WriteLine();
            Joined_After_2015();
            Console.WriteLine();
            Employees_NotAssociates();
            Console.WriteLine();
            Employees_By_City();
            Console.WriteLine();
            Employees_By_City_Title();
            Console.WriteLine();
            Youngest_Employee();

            Console.ReadLine();
        }

        static void DataEntry()
        {
            empList = new List<Employee>
            {
                new Employee{EmployeeID=1001, FirstName="Malcolm", LastName="Daruwalla", Title="Manager", DOB=new DateTime(1984,11,16), DOJ=new DateTime(2011,6,8), City="Mumbai"},
                new Employee{EmployeeID=1002, FirstName="Asdin", LastName="Dhalla", Title="AsstManager", DOB=new DateTime(1984,8,20), DOJ=new DateTime(2012,7,7), City="Mumbai"},
                new Employee{EmployeeID=1003, FirstName="Madhavi", LastName="Oza", Title="Consultant", DOB=new DateTime(1987,11,14), DOJ=new DateTime(2015,4,12), City="Pune"},
                new Employee{EmployeeID=1004, FirstName="Saba", LastName="Shaikh", Title="SE", DOB=new DateTime(1990,6,3), DOJ=new DateTime(2016,2,2), City="Pune"},
                new Employee{EmployeeID=1005, FirstName="Nazia", LastName="Shaikh", Title="SE", DOB=new DateTime(1991,3,8), DOJ=new DateTime(2016,2,2), City="Mumbai"},
                new Employee{EmployeeID=1006, FirstName="Amit", LastName="Pathak", Title="Consultant", DOB=new DateTime(1989,11,7), DOJ=new DateTime(2014,8,8), City="Chennai"},
                new Employee{EmployeeID=1007, FirstName="Vijay", LastName="Natrajan", Title="Consultant", DOB=new DateTime(1989,12,2), DOJ=new DateTime(2015,6,1), City="Mumbai"},
                new Employee{EmployeeID=1008, FirstName="Rahul", LastName="Dubey", Title="Associate", DOB=new DateTime(1993,11,11), DOJ=new DateTime(2014,11,6), City="Chennai"},
                new Employee{EmployeeID=1009, FirstName="Suresh", LastName="Mistry", Title="Associate", DOB=new DateTime(1992,8,12), DOJ=new DateTime(2014,12,3), City="Chennai"},
                new Employee{EmployeeID=1010, FirstName="Sumit", LastName="Shah", Title="Manager", DOB=new DateTime(1991,4,12), DOJ=new DateTime(2016,1,2), City="Pune"}
            };
        }

        static void Employees_JoinedBefore_2015()
        {
            var result = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1)).ToList();
            Console.WriteLine("1. Employees who joined before 1/1/2015:");
            foreach (var emp in result)
                PrintEmployee(emp);
        }

        static void Employees_DOB_After_1990()
        {
            var result = empList.Where(e => e.DOB > new DateTime(1990, 1, 1)).ToList();
            Console.WriteLine("2. Employees whose DOB is after 1/1/1990:");
            foreach (var emp in result)
                PrintEmployee(emp);
        }

        static void Consultants_Associates()
        {
            var result = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate").ToList();
            Console.WriteLine("3. Employees with designation Consultant or Associate:");
            foreach (var emp in result)
                PrintEmployee(emp);
        }

        static void Total_Employees()
        {
            var result = empList.Count();
            Console.WriteLine($"4. Total number of employees: {result}");
        }

        static void Employees_Chennai()
        {
            var result = empList.Count(e => e.City == "Chennai");
            Console.WriteLine($"5. Total number of employees in Chennai: {result}");
        }

        static void Highest_Employee()
        {
            var result = empList.Max(e => e.EmployeeID);
            Console.WriteLine($"6. Highest Employee ID: {result}");
        }

        static void Joined_After_2015()
        {
            var result = empList.Count(e => e.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"7. Employees who joined after 1/1/2015: {result}");
        }

        static void Employees_NotAssociates()
        {
            var result = empList.Count(e => e.Title != "Associate");
            Console.WriteLine($"8. Employees whose designation is not Associate: {result}");
        }

        static void Employees_By_City()
        {
            var result = empList.GroupBy(e => e.City).Select(g => new { City = g.Key, Count = g.Count() }).ToList();
            Console.WriteLine("9. Total number of employees based on City:");
            foreach (var group in result)
                Console.WriteLine($"{group.City}: {group.Count}");
        }

        static void Employees_By_City_Title()
        {
            var result = empList.GroupBy(e => new { e.City, e.Title })
                                .Select(g => new { g.Key.City, g.Key.Title, Count = g.Count() }).ToList();
            Console.WriteLine("10. Total number of employees based on City and Title:");
            foreach (var group in result)
                Console.WriteLine($"{group.City} : {group.Title}: {group.Count}");
        }

        static void Youngest_Employee()
        {
            var result = empList.OrderByDescending(e => e.DOB).FirstOrDefault();
            Console.WriteLine("11. Youngest Employee:");
            if (result != null)
                Console.WriteLine($"{result.EmployeeID} , {result.FirstName} {result.LastName}, DOB: {result.DOB.ToShortDateString()}");
        }

        static void PrintEmployee(Employee emp)
        {
            Console.WriteLine($"{emp.EmployeeID} , {emp.FirstName} {emp.LastName}, {emp.Title}, DOB: {emp.DOB.ToShortDateString()}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
        }

    }

    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
}
