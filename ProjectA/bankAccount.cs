using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA
{
    internal class bankAccount
    {
        // variables
        private float balance;
        private float initialBalance;
        private float depositAmount;
        private float withdrawAmount;

        // bank account initial balance
        public bankAccount(float initialBalance)
        {
            balance = initialBalance;
        }

        // deposit function 
        public void Deposit(float depositAmount) { 
            balance += depositAmount;
            Console.WriteLine($"Withdrawn {depositAmount}, Remaining Balance: {balance}");
        }

        // withdraw function
        public void Withdraw(float withdrawAmount)
        {
            if (balance >= withdrawAmount){
                balance -= withdrawAmount;
                Console.WriteLine($"Withdrawn {withdrawAmount}, Remaining Balance: {balance}");
            }
            else{Console.WriteLine("Insufficient funds.");}
        }

        // view balance
        public float getBalance() { 
            return balance;
        }
    }
}
