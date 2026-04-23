using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7_StudentActivityEvaluationSystem
{
    // Student class

    public class Student
    {

        public string Name { get; set; }
        public int Marks { get; set; }
        public int Attendance { get; set; }
        public int Participation { get; set; }
    }

    internal class Program
    {
        // Delegate for evaluation
        public delegate void StudentEvaluation(Student s);

        static void Main(string[] args)
        {
            // Sample student list
            List<Student> students = new List<Student>()
            {
                new Student { Name = "Aditya", Marks = 80, Attendance = 90, Participation = 85 },
                new Student { Name = "Rahul", Marks = 45, Attendance = 70, Participation = 60 },
                new Student { Name = "Priya", Marks = 65, Attendance = 85, Participation = 75 },
                new Student { Name = "Neha", Marks = 30, Attendance = 60, Participation = 50 }
            };

            // Delegate instance using ANONYMOUS METHOD
            StudentEvaluation evaluate = delegate (Student s)
            {
                int total = s.Marks + s.Attendance + s.Participation;

                Console.WriteLine("\nStudent: " + s.Name);
                Console.WriteLine("Total Score: " + total);

                if (total >= 200)
                    Console.WriteLine("Performance: Excellent");
                else if (total >= 150)
                    Console.WriteLine("Performance: Good");
                else
                    Console.WriteLine("Performance: Average");
            };

            // Execute evaluation
            Console.WriteLine("---- Student Evaluation ----");
            foreach (var s in students)
            {
                evaluate(s);
            }

            // LAMBDA: Check eligibility (marks > 50)
            Predicate<Student> isEligible = s => s.Marks > 50;

            Console.WriteLine("\n---- Eligible Students (Marks > 50) ----");
            foreach (var s in students)
            {
                if (isEligible(s))
                {
                    Console.WriteLine(s.Name + " is Eligible");
                }
            }

            // LAMBDA: Filter top performers (marks > 75)
            List<Student> topPerformers = students.FindAll(s => s.Marks > 75);

            Console.WriteLine("\n---- Top Performers (Marks > 75) ----");
            foreach (var s in topPerformers)
            {
                Console.WriteLine(s.Name);
            }


        }
    }
}
