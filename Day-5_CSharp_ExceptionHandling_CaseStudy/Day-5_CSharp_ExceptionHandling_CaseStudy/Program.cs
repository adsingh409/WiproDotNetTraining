using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5_CSharp_ExceptionHandling_CaseStudy
{
    // Custom Exception: Invalid Amount
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message) { }
    }

    // Custom Exception: Insufficient Balance
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    // BankAccount Class
    public class BankAccount
    {
        public string AccountHolderName { get; set; }
        public double Balance { get; set; }

        // Constructor
        public BankAccount(string name, double balance)
        {
            AccountHolderName = name;
            Balance = balance;
        }

        // Deposit Method (US1, US4)
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException("Deposit amount must be greater than 0.");
            }

            Balance += amount;
            Console.WriteLine("Amount Deposited Successfully!");
        }

        // Withdraw Method (US2, US3)
        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds current balance.");
            }

            if (Balance - amount < 1000)
            {
                throw new InsufficientBalanceException("Minimum balance of ₹1000 must be maintained.");
            }

            Balance -= amount;
            Console.WriteLine("Amount Withdrawn Successfully!");
        }

        // Check Balance
        public void CheckBalance()
        {
            Console.WriteLine("Current Balance: ₹" + Balance);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("Aditya", 5000);

            try
            {
                Console.WriteLine("Initial Balance:");
                account.CheckBalance();

                Console.WriteLine("\nDepositing ₹2000...");
                account.Deposit(2000);

                Console.WriteLine("\nWithdrawing ₹7000...");
                account.Withdraw(7000);  // Exception scenario

                Console.WriteLine("\nWithdrawing ₹500...");
                account.Withdraw(500);

                Console.WriteLine("\nFinal Balance:");
                account.CheckBalance();
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine("Invalid Amount Error: " + ex.Message);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Balance Error: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument Error: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Operation Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nTransaction process completed.");

            }
        }
    }
}

