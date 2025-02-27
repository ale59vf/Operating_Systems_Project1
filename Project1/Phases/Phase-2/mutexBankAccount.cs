using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
     internal class mutexBankAccount
 {
     // variables
     private float balance;
     private float initialBalance;
     private float totalBalance;
     private float depositAmount;
     private float withdrawAmount;
     // create mutex
     private Mutex mutex = new Mutex();

     // bank account initial balance
     public mutexBankAccount(float initialBalance)
     {
         balance = initialBalance;
     }

     // deposit function 
     public void Deposit(float depositAmount) { 
         // lock the mutex
         mutex.WaitOne();
         try
         {
             Console.WriteLine($"{Thread.CurrentThread.Name} is depositing {depositAmount:C}");
             totalBalance = balance + depositAmount;
             Thread.Sleep(1000); // processing time
             balance = totalBalance;
             Console.WriteLine($"{Thread.CurrentThread.Name} new balance: {balance:C}");
         }
         finally
         {
             mutex.ReleaseMutex(); // Release the lock
         }
     }

     // withdraw function
     public void Withdraw(float withdrawAmount)
     {
         // lock the mutex
         mutex.WaitOne();
         try
         {
             if (balance >= withdrawAmount)
             {
                 Console.WriteLine($"{Thread.CurrentThread.Name} is withdrawing {withdrawAmount:C}");
                 totalBalance = balance - withdrawAmount;
                 Thread.Sleep(1000); // processing time
                 balance = totalBalance;
                 Console.WriteLine($"{Thread.CurrentThread.Name} new balance: {balance:C}");
             }
             else
             {
                 Console.WriteLine($"{Thread.CurrentThread.Name} attempted to withdraw {withdrawAmount:C}, but insufficient funds.");
             }
         }
         finally
         {
             mutex.ReleaseMutex(); // Release the lock
         }
     }

     // view balance
     public float getBalance() { 
         return balance;
     }
 }
}
