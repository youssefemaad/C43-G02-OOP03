// Assignment 2 OOP
using System;

namespace Assignment02OOP
{
    class Program
    {
        public struct Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }
        }

        public struct Rectangle
        {
            private double width;
            private double height;

            public double Width
            {
                get { return width; }
                set { width = value; }
            }

            public double Height
            {
                get { return height; }
                set { height = value; }
            }

            public double Area()
            {
                return width * height;
            }

            public void Display()
            {
                Console.WriteLine($"Width: {width}, Height: {height}, Area: {Area()}");
            }
        }

        static void Main(string[] args)
        {
            #region 1. Define a struct "Person" with properties "Name" and "Age". Create an array of three "Person" objects and populate it with data. Then, write a C# program to display the details of all the persons in the array.
            Person[] persons = new Person[3];
            for (int i = 0; i < persons.Length; i++)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter age: ");
                int age = int.Parse(Console.ReadLine());
                persons[i] = new Person { Name = name, Age = age };
            }

            foreach (Person person in persons)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }
            
            #endregion

            #region 2. Create a struct called "Point" to represent a 2D point with properties "X" and "Y". Write a C# program that takes two points as input from the user and calculates the distance between them.
            Point point1 = new Point();
            Point point2 = new Point();

            Console.Write("Enter X1: ");
            point1.X = double.Parse(Console.ReadLine());
            Console.Write("Enter Y1: ");
            point1.Y = double.Parse(Console.ReadLine());

            Console.Write("Enter X2: ");
            point2.X = double.Parse(Console.ReadLine());
            Console.Write("Enter Y2: ");
            point2.Y = double.Parse(Console.ReadLine());

            double distance = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
            Console.WriteLine($"Distance between the two points: {distance}");
            
            #endregion

            #region 3. Create a struct called "Person" with properties "Name" and "Age". Write a C# program that takes details of 3 persons as input from the user and displays the name and age of the oldest person.
            Person person1 = new Person();
            Person person2 = new Person();
            Person person3 = new Person();

            Console.Write("Enter name of person 1: ");
            person1.Name = Console.ReadLine();
            Console.Write("Enter age of person 1: ");
            person1.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter name of person 2: ");
            person2.Name = Console.ReadLine();
            Console.Write("Enter age of person 2: ");
            person2.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter name of person 3: ");
            person3.Name = Console.ReadLine();
            Console.Write("Enter age of person 3: ");
            person3.Age = int.Parse(Console.ReadLine());

            Person oldestPerson = person1;

            if (person2.Age > oldestPerson.Age)
            {
                oldestPerson = person2;
            }

            if (person3.Age > oldestPerson.Age)
            {
                oldestPerson = person3;
            }

            Console.WriteLine($"The oldest person is {oldestPerson.Name} with age {oldestPerson.Age}");
            
            #endregion

            #region 4. Create a struct named Rectangle that represents a rectangle with encapsulated fields "width" and "height". Implement properties and methods to calculate area and display details.
            Rectangle rectangle = new Rectangle();
            Console.Write("Enter width: ");
            rectangle.Width = double.Parse(Console.ReadLine());
            Console.Write("Enter height: ");
            rectangle.Height = double.Parse(Console.ReadLine());

            double area = rectangle.Area();
            Console.WriteLine($"Area of the rectangle: {area}");

            rectangle.Display();
            
            #endregion
        }
    }
}
