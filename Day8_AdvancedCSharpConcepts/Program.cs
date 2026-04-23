using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_AdvancedCSharpConcepts
{
    //  US1: Reflection
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine("Student Details Method Called");
        }
    }

    //  US2: Generic Class
    public class Box<T>
    {
        public T Value;

        public void Display()
        {
            Console.WriteLine("Value: " + Value);
        }
    }

    internal class Program
    {
        // ===================== US3: Generic Method =====================
        public static void PrintData<T>(T data)
        {
            Console.WriteLine("Generic Method Output: " + data);
        }

        // ===================== US4: ref keyword =====================
        public static void UpdateValue(ref int num)
        {
            num = num + 10;
        }

        // US5: out keyword
        public static void GetValues(out int sum, out int product)
        {
            int a = 5, b = 3;
            sum = a + b;
            product = a * b;
        }

        static void Main(string[] args)
        {
            //  US1 Execution 
            Console.WriteLine("---- US1: Reflection ----");

            Type type = typeof(Student);

            Console.WriteLine("Class Name: " + type.Name);

            Console.WriteLine("Properties:");
            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine(prop.Name);
            }

            Console.WriteLine("Methods:");
            foreach (var method in type.GetMethods())
            {
                Console.WriteLine(method.Name);
            }

            // US2 Execution
            Console.WriteLine("\n---- US2: Generic Class ----");

            Box<int> intBox = new Box<int>();
            intBox.Value = 100;
            intBox.Display();

            Box<string> strBox = new Box<string>();
            strBox.Value = "Hello Generics";
            strBox.Display();

            // US3 Execution
            Console.WriteLine("\n---- US3: Generic Method ----");

            PrintData(500);
            PrintData("Aditya");
            PrintData(3.14);

            //  US4 Execution
            Console.WriteLine("\n---- US4: ref keyword ----");

            int number = 20;
            Console.WriteLine("Before: " + number);

            UpdateValue(ref number);

            Console.WriteLine("After: " + number);

            // US5 Execution
            Console.WriteLine("\n---- US5: out keyword ----");

            int sum, product;

            GetValues(out sum, out product);

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Product: " + product);

        }
    }
}
