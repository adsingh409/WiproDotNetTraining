using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delgates_demo_day6
{
    internal class Program
    {
        public delegate int MathOperation(int a, int b);

        // 2a. Add method
        public static int Add(int a, int b)
        {
            return a + b;
        }

        // 2b. Subtract method
        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        // 2c. Multiply method
        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        static void Main(string[] args)
        {
            // 3. Assign delegate to Add method
            MathOperation operation = Add;

            // 4. Invoke delegate
            int result1 = operation(10, 5);
            Console.WriteLine("Addition Result: " + result1);

            // 5. Change delegate to Subtract method
            operation = Subtract;
            int result2 = operation(10, 5);
            Console.WriteLine("Subtraction Result: " + result2);

            // (Extra) Multiply usage
            operation = Multiply;
            int result3 = operation(10, 5);
            Console.WriteLine("Multiplication Result: " + result3);

        }
    }
}
