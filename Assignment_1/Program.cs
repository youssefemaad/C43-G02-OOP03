using System;

namespace Assignment03OOP
{
    public enum SecurityPrivilege
    {
        Guest,
        Developer,
        Secretary,
        DBA
    }

    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public SecurityPrivilege SecurityLevel { get; private set; }
        public double Salary { get; private set; }
        public HiringDate HireDate { get; private set; }
        private char gender;

        public char Gender
        {
            get => gender;
            set
            {
                if (value != 'M' && value != 'F')
                {
                    throw new ArgumentException("Gender must be 'M' or 'F'.");
                }
                gender = value;
            }
        }

        public Employee(int id, string name, SecurityPrivilege securityLevel, double salary, HiringDate hireDate, char gender)
        {
            Id = id;
            Name = name;
            SecurityLevel = securityLevel;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Security Level: {SecurityLevel}, Salary: {String.Format("{0:C}", Salary)}, Hire Date: {HireDate}, Gender: {Gender}";
        }
    }

    public class HiringDate
    {
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }

        public HiringDate(int day, int month, int year)
        {
            if (day <= 0 || day > 31 || month <= 0 || month > 12 || year < 1)
            {
                throw new ArgumentException("Invalid date values.");
            }
            Day = day;
            Month = month;
            Year = year;
        }

        public int CompareTo(HiringDate other)
        {
            if (Year != other.Year)
                return Year - other.Year;
            if (Month != other.Month)
                return Month - other.Month;
            return Day - other.Day;
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }

    public class EmployeeManagement
    {
        private Employee[] employees;

        public EmployeeManagement()
        {
            employees = new Employee[3];
            employees[0] = new Employee(1, "John", SecurityPrivilege.DBA, 1000, new HiringDate(1, 1, 2021), 'M');
            employees[1] = new Employee(2, "Jane", SecurityPrivilege.Guest, 2000, new HiringDate(2, 2, 2021), 'F');
            employees[2] = new Employee(3, "Jack", SecurityPrivilege.Secretary, 3000, new HiringDate(3, 3, 2021), 'M');
        }

        public void SortEmployees()
        {
            Array.Sort(employees, (x, y) => x.HireDate.CompareTo(y.HireDate));
        }

        public void PrintEmployees()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }

    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}";
        }
    }

    public class EBook : Book
    {
        public double FileSize { get; private set; }

        public EBook(string title, string author, string isbn, double fileSize) : base(title, author, isbn)
        {
            FileSize = fileSize;
        }

        public override string ToString()
        {
            return base.ToString() + $", File Size: {FileSize} MB";
        }
    }

    public class PrintedBook : Book
    {
        public int PageCount { get; private set; }

        public PrintedBook(string title, string author, string isbn, int pageCount) : base(title, author, isbn)
        {
            PageCount = pageCount;
        }

        public override string ToString()
        {
            return base.ToString() + $", Page Count: {PageCount}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Design and implement a Class for the employees in a company.
            /*
            Notes:
            - Employee is identified by an ID, Name, security level, salary, hire date, and Gender.
            - Restrict the Gender field to M or F (Male or Female).
            - Assign the following security privileges to the employee (guest, Developer, secretary, and DBA) in a form of Enum.
            - Provide a string representation of Employee data (override ToString()).
            - Display employee salary in a currency format (use String.Format()).
            */
            
            EmployeeManagement employeeManagement = new EmployeeManagement();
            employeeManagement.PrintEmployees();
            #endregion

            #region Develop a Class to represent the Hiring Date Data.
            /*
            Notes:
            - Consists of fields to hold the day, month, and year.
            */

            HiringDate hireDate = new HiringDate(1, 1, 2021);
            Console.WriteLine($"Hire Date Example: {hireDate}");
            #endregion

            #region Create an array of Employees with size three and populate it with a DBA, Guest, and Security Officer with full permissions.
            /*
            Notes:
            - Include a DBA, Guest, and a security officer who has full permissions.
            - Implement all necessary member functions (Getters, Setters).
            - Define all necessary constructors for the class.
            - Allow no runtime errors if the user inputs invalid data.
            - Write necessary properties instead of setters and getters.
            */

            Employee[] employees = new Employee[3]

            employees[0] = new Employee(1, "John", SecurityPrivilege.DBA, 1000, new HiringDate(1, 1, 2021), 'M');
            employees[1] = new Employee(2, "Jane", SecurityPrivilege.Guest, 2000, new HiringDate(2, 2, 2021), 'F');
            employees[2] = new Employee(3, "Jack", SecurityPrivilege.Secretary, 3000, new HiringDate(3, 3, 2021), 'M');

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            #endregion

            #region Sort the employees based on their hire date and print the sorted array.
            /*
            Notes:
            - Count how many times Boxing and Unboxing process occurs while sorting.
            */

            employeeManagement.SortEmployees();
            Console.WriteLine("Sorted Employees by Hire Date:");
            employeeManagement.PrintEmployees();
            #endregion

            #region Design a program for a library management system.
            /*
            Notes:
            - Book is the base class with properties like Title, Author, and ISBN.
            - EBook and PrintedBook are derived classes with additional properties like FileSize for EBook and PageCount for PrintedBook.
            - Demonstrate how inheritance simplifies the design.
            */

            Book printedBook = new PrintedBook("C# in Depth", "Jon Skeet", "123-456", 900);
            Book eBook = new EBook("Learn Python", "Mark Lutz", "789-012", 1.5);

            Console.WriteLine($"Printed Book: {printedBook}");
            Console.WriteLine($"EBook: {eBook}");
            #endregion
        }
    }
}
