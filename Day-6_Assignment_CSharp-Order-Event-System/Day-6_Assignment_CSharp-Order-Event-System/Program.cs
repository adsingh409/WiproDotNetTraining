using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6_Assignment_CSharp_Order_Event_System
{
    // Order Class
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double Amount { get; set; }
    }

    // Order Processor
    public class OrderProcessor
    {
        public delegate void OrderPlacedHandler(Order order);
        public event OrderPlacedHandler OnOrderPlaced;

        public void PlaceOrder(Order order)
        {
            Console.WriteLine("Order Placed: " + order.OrderId);
            OnOrderPlaced?.Invoke(order);
        }
    }

    // Email Service
    public class EmailService
    {
        public void SendEmail(Order order)
        {
            Console.WriteLine("Email sent to customer: " + order.CustomerName);
        }
    }

    // SMS Service
    public class SMSService
    {
        public void SendSMS(Order order)
        {
            Console.WriteLine("SMS sent to customer: " + order.CustomerName);
        }
    }

    // Logger Service
    public class LoggerService
    {
        public void LogOrder(Order order)
        {
            Console.WriteLine("Order logged successfully. Amount: ₹" + order.Amount);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            OrderProcessor processor = new OrderProcessor();

            EmailService email = new EmailService();
            SMSService sms = new SMSService();
            LoggerService logger = new LoggerService();

            processor.OnOrderPlaced += email.SendEmail;
            processor.OnOrderPlaced += sms.SendSMS;
            processor.OnOrderPlaced += logger.LogOrder;

            Order order = new Order
            {
                OrderId = 101,
                CustomerName = "Aditya",
                Amount = 2500
            };

            processor.PlaceOrder(order);

            Console.ReadLine();

        }
    }
}
