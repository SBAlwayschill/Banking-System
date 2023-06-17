using System;
using System.Collections.Generic;

namespace BankingSystem
{
    public class Account
    {
        public string AccountNumber { get; }
        public string Owner { get; }
        public decimal Balance { get; private set; }

        public Account(string accountNumber, string owner, decimal initialDeposit)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = initialDeposit;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Successfully deposited {amount:C}. New balance: {Balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Successfully withdrew {amount:C}. New balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Owner: {Owner}");
            Console.WriteLine($"Balance: {Balance:C}");
        }
    }

    public class Program
    {
        private static List<Account> accounts = new List<Account>();

        static void Main(string[] args)
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print Account Info");
                Console.WriteLine("5. Exit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        Deposit();
                        break;
                    case "3":
                        Withdraw();
                        break;
                    case "4":
                        PrintAccountInfo();
                        break;
                    case "5":
                        exitProgram = true;
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void CreateAccount()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter account owner: ");
            string owner = Console.ReadLine();

            Console.Write("Enter initial deposit amount: ");
            decimal initialDeposit = decimal.Parse(Console.ReadLine());

            Account account = new Account(accountNumber, owner, initialDeposit);
            accounts.Add(account);

            Console.WriteLine("Account created successfully!");
        }

        private static void Deposit()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            Account account = FindAccount(accountNumber);

            if (account != null)
            {
                Console.Write("Enter deposit amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                account.Deposit(amount);
            }
        }

        private static void Withdraw()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            Account account = FindAccount(accountNumber);

            if (account != null)
            {
                Console.Write("Enter withdrawal amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                account.Withdraw(amount);
            }
        }

        private static void PrintAccountInfo()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            Account account = FindAccount(accountNumber);

            if (account != null)
            {
                account.PrintAccountInfo();
            }
        }

        private static Account FindAccount(string accountNumber)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }

            Console.WriteLine("Account not found!");
            return null;
        }
    }
}
