using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_algorithm_Day7
{
    internal class Program
    {
        // Linear Search Method
        static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }

        // Binary Search Method
        static int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == target)
                {
                    return mid;
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int[] arr = { 2, 4, 6, 8, 10, 12, 14, 16 };

            Console.WriteLine("Array: " + string.Join(", ", arr));

            Console.Write("Enter element to search: ");
            int target = Convert.ToInt32(Console.ReadLine());

            // Linear Search Call
            int linearResult = LinearSearch(arr, target);
            if (linearResult != -1)
            {
                Console.WriteLine("Linear Search: Element found at index " + linearResult);
            }
            else
            {
                Console.WriteLine("Linear Search: Element not found");
            }

            // Binary Search Call
            int binaryResult = BinarySearch(arr, target);
            if (binaryResult != -1)
            {
                Console.WriteLine("Binary Search: Element found at index " + binaryResult);
            }
            else
            {
                Console.WriteLine("Binary Search: Element not found");
            }

        }
    }
}
