using System;
using System.Collections.Generic;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Enhanced Banking System!");
            BankAccount account = new BankAccount();

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Transaction History");
                Console.WriteLine("5. Exit");

                int choice = GetValidChoice();

                switch (choice)
                {
                    case 1:
                        account.Deposit(GetValidAmount("Enter amount to deposit:"));
                        break;
                    case 2:
                        account.Withdraw(GetValidAmount("Enter amount to withdraw:"));
                        break;
                    case 3:
                        Console.WriteLine("Your balance is: " + account.GetBalance());
                        break;
                    case 4:
                        account.PrintTransactionHistory();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static int GetValidChoice()
        {
            int choice;
            while (true)
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }
            return choice;
        }

        static double GetValidAmount(string message)
        {
            double amount;
            while (true)
            {
                try
                {
                    Console.WriteLine(message);
                    amount = Convert.ToDouble(Console.ReadLine());
                    if (amount < 0)
                    {
                        throw new Exception("Amount cannot be negative.");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return amount;
        }
    }

    public class BankAccount
    {
        private double balance;
        private List<string> transactionHistory = new List<string>();

        public void Deposit(double amount)
        {
            balance += amount;
            transactionHistory.Add($"Deposited: {amount} on {DateTime.Now}");
            Console.WriteLine("Deposited: " + amount);
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
                transactionHistory.Add($"Failed withdrawal attempt of {amount} on {DateTime.Now} - Insufficient funds.");
            }
            else
            {
                balance -= amount;
                transactionHistory.Add($"Withdrew: {amount} on {DateTime.Now}");
                Console.WriteLine("Withdrew: " + amount);
            }
        }

        public double GetBalance()
        {
            return balance;
        }

        public void PrintTransactionHistory()
        {
            Console.WriteLine("\nTransaction History:");
            foreach (var transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}