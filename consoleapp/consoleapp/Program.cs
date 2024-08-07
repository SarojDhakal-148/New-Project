
using System;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Banking System!");
            BankAccount account = new BankAccount();

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter amount to deposit:");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());
                        account.Deposit(depositAmount);
                        break;
                    case 2:
                        Console.WriteLine("Enter amount to withdraw:");
                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        account.Withdraw(withdrawAmount);
                        break;
                    case 3:
                        Console.WriteLine("Your balance is: " + account.GetBalance());
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    public class BankAccount
    {
        private double balance;

        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine("Deposited: " + amount);
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Withdrew: " + amount);
            }
        }

        public double GetBalance()
        {
            return balance;
        }
    }
}