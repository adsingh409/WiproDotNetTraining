using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12_DigitalWallet_SOLID_Implementation
{
    // 1. Payment Interface (OCP, DIP)
    public interface IPayment
    {
        void Pay(decimal amount);
    }

    // 2. Payment Methods (LSP)
    public class UPIPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using UPI");
        }
    }

    public class CardPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Card");
        }
    }

    public class NetBankingPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Net Banking");
        }
    }

    // New Payment Method (T8 - OCP)
    public class WalletPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Wallet");
        }
    }

    // 3. Notification Interface (ISP)
    public interface INotification
    {
        void Send(string message);
    }

    // 4. Notification Implementation
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email Sent: {message}");
        }
    }

    // 5. Transaction Class (SRP)
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(decimal amount)
        {
            Amount = amount;
            Date = DateTime.Now;
        }
    }

    // 6. Wallet Service (DIP)
    public class WalletService
    {
        private readonly IPayment _payment;
        private readonly INotification _notification;

        public WalletService(IPayment payment, INotification notification)
        {
            _payment = payment;
            _notification = notification;
        }

        public void ProcessPayment(decimal amount)
        {
            _payment.Pay(amount);

            Transaction transaction = new Transaction(amount);

            _notification.Send($"Payment of {amount} successful on {transaction.Date}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Change payment method here (UPI / Card / NetBanking / Wallet)
            IPayment payment = new UPIPayment();

            // Notification
            INotification notification = new EmailNotification();

            // Dependency Injection
            WalletService wallet = new WalletService(payment, notification);

            // Process payment
            wallet.ProcessPayment(1000);

            Console.ReadLine();

        }
    }
}
