using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class deadlockResolution_BankAccount
    {
        // variables
        private float balance;
        private float initialBalance;
        private float depositAmount;
        private float withdrawAmount;
        public int ID { get; }
        private object lockobj = new object();

        // bank account initial balance
        public deadlockResolution_BankAccount(int id, float initialBalance)
        {
            ID = id;
            balance = initialBalance;
        }

        // deposit function 
        public void Deposit(float depositAmount)
        {
            balance += depositAmount;
            Console.WriteLine($"Withdrawn {depositAmount}, Remaining Balance: {balance}");
        }

        // withdraw function
        public void Withdraw(float withdrawAmount)
        {
            if (balance >= withdrawAmount)
            {
                balance -= withdrawAmount;
                Console.WriteLine($"Withdrawn {withdrawAmount}, Remaining Balance: {balance}");
            }
            else { Console.WriteLine("Insufficient funds."); }
        }

            // view balance
        public float getBalance()
        {
            return balance;
        }

        // get lock function
        public object getLockObj() { return lockobj; }
    }

    // transaction class
    internal class Transaction
    {
        public static void transfer(deadlockResolution_BankAccount from, deadlockResolution_BankAccount to, int amount)
        {
            // Order locks by account ID to prevent deadlocks
            deadlockResolution_BankAccount first = from.ID < to.ID ? from : to;
            deadlockResolution_BankAccount second = from.ID < to.ID ? to : from;

            Console.WriteLine($"{Thread.CurrentThread.Name} attempting to transfer {amount:C} from Account {from.ID} to Account {to.ID}");

            bool lockAcquired = false;

            try
            {
                if (Monitor.TryEnter(first.getLockObj(), TimeSpan.FromSeconds(2))) // Try to acquire first lock
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} locked Account {first.ID}");

                    try
                    {
                        if (Monitor.TryEnter(second.getLockObj(), TimeSpan.FromSeconds(2))) // Try second lock
                        {
                            Console.WriteLine($"{Thread.CurrentThread.Name} locked Account {second.ID}");
                            lockAcquired = true;

                            if (from.getBalance() >= amount)
                            {
                                from.Withdraw(amount);
                                to.Deposit(amount);
                                Console.WriteLine($"{Thread.CurrentThread.Name} successfully transferred {amount:C}.");
                            }
                            else
                            {
                                Console.WriteLine($"{Thread.CurrentThread.Name} failed: Insufficient funds.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{Thread.CurrentThread.Name} failed to lock Account {second.ID}, transaction aborted.");
                        }
                    }
                    finally
                    {
                        if (lockAcquired)
                            Monitor.Exit(second.getLockObj());
                    }
                }
                else
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} failed to lock Account {first.ID}, transaction aborted.");
                }
            }
            finally
            {
                if (Monitor.IsEntered(first.getLockObj()))
                    Monitor.Exit(first.getLockObj());
            }
        }
    }
}