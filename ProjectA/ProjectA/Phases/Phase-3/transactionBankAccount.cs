using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA
{
    internal class transactionBankAccount
    {
        // variables
        private float balance;
        private float initialBalance;
        private float depositAmount;
        private float withdrawAmount;
        public int ID { get; }
        private object lockobj = new object();

        // bank account initial balance
        public transactionBankAccount(int id, float initialBalance)
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
        public static void transfer(transactionBankAccount from, transactionBankAccount to, float amount) {
            Console.WriteLine($"{Thread.CurrentThread.Name} attempting to transfer {amount:C} from Account {from.ID} to Account {to.ID}");
            // Lock both accounts (Deadlock possible)
            lock (from.getLockObj())
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} locked Account {from.ID}");
                Thread.Sleep(1000); // Simulate processing delay

                lock (to.getLockObj())
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} locked Account {to.ID}");

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
                } // Unlock `to`
            } // Unlock `from`
        }
    }
}