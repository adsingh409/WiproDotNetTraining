using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Day 4-Assignment - ALL 5 Scenarios Implemented

namespace Day_4_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Scenario 1 ----");
            Scenario1();
            

            Console.WriteLine("\n---- Scenario 2 ----");
            Scenario2();

            Console.WriteLine("\n---- Scenario 3 ----");
            Scenario3();

            Console.WriteLine("\n---- Scenario 4 ----");
            Scenario4();

            Console.WriteLine("\n---- Scenario 5 ----");
            Scenario5();

        }
        //  Scenario 1: E-Commerce Order Management System.
        static void Scenario1()
        {
            List<string> orders = new List<string>();
            Dictionary<int, string> customers = new Dictionary<int, string>();
            HashSet<string> categories = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            Stack<string> status = new Stack<string>();

            orders.Add("Laptop");
            customers[1] = "Aditya";
            categories.Add("Electronics");

            queue.Enqueue("Laptop");

            while (queue.Count > 0)
            {
                Console.WriteLine("Processing: " + queue.Dequeue());
            }

            status.Push("Order Placed");
            status.Push("Shipped");

            Console.WriteLine("Latest Status: " + status.Peek());
        }


        //// Scenario 2: Social Media Platform (User Engagement System)
        static void Scenario2()
        {
            List<string> posts = new List<string>();
            Dictionary<string, int> likes = new Dictionary<string, int>();
            HashSet<int> users = new HashSet<int>();
            Stack<string> actions = new Stack<string>();
            Queue<string> notifications = new Queue<string>();

            posts.Add("Hello World");
            likes["Hello World"] = 10;
            users.Add(1);

            actions.Push("Post Created");
            actions.Push("Post Liked");

            Console.WriteLine("Undo: " + actions.Pop());

            notifications.Enqueue("New Like");
            Console.WriteLine("Notification: " + notifications.Dequeue());
        }

        //// Scenario 3: Banking Transaction System
        static void Scenario3()
        {
            List<string> history = new List<string>();
            Dictionary<string, double> accounts = new Dictionary<string, double>();
            Queue<string> pending = new Queue<string>();
            Stack<string> rollback = new Stack<string>();
            HashSet<string> ids = new HashSet<string>();

            string t1 = "T1";

            if (ids.Add(t1))
            {
                pending.Enqueue(t1);
            }

            while (pending.Count > 0)
            {
                string t = pending.Dequeue();
                history.Add(t);
                rollback.Push(t);
                Console.WriteLine("Processed: " + t);
            }
        }

        //// Scenario 4: Music Playlist Manager (Advanced Collections).
        static void Scenario4()
        {
            LinkedList<string> playlist = new LinkedList<string>();
            SortedList<int, string> ratings = new SortedList<int, string>();
            SortedDictionary<string, string> artist = new SortedDictionary<string, string>();

            playlist.AddLast("Song1");
            playlist.AddLast("Song2");

            ratings.Add(5, "Song1");
            ratings.Add(4, "Song2");

            artist["Arijit"] = "Song1";

            foreach (var song in playlist)
            {
                Console.WriteLine(song);
            }
        }

        //// Scenario 5: Task Scheduler System.
        static void Scenario5()
        {
            Queue<string> tasks = new Queue<string>();
            Stack<string> undo = new Stack<string>();
            List<string> all = new List<string>();
            SortedDictionary<int, string> priority = new SortedDictionary<int, string>();
            HashSet<string> unique = new HashSet<string>();

            if (unique.Add("Task1"))
            {
                tasks.Enqueue("Task1");
                all.Add("Task1");
                priority[1] = "Task1";
            }

            string done = tasks.Dequeue();
            undo.Push(done);

            Console.WriteLine("Executed: " + done);
            Console.WriteLine("Undo: " + undo.Pop());
        }
    }



}

