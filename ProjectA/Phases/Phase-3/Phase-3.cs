using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Phases
{
    // Phase 3: 
    internal class Phase3
    {
        // create a function to run
        public static void Run()
        {

            // create two new object bank account (1 & 2) with $1000 each
            transactionBankAccount newAccount1 = new transactionBankAccount(1, 1000);
            transactionBankAccount newAccount2 = new transactionBankAccount(2, 1000);


            // create three threads 
            Thread t1 = new Thread(() => { Transaction.transfer(newAccount1, newAccount2, 100); }) { Name = "Thread 1" }; ;
            Thread t2 = new Thread(() => { Transaction.transfer(newAccount2, newAccount2, 100); }) { Name = "Thread 2" };

            // start threads 
            t1.Start();
            t2.Start();

            // joining threads 
            t1.Join();
            t2.Join();

            // print completion statement
            Console.WriteLine($"Final Balances: Account A: {newAccount1.getBalance():C}, Account B: {newAccount2.getBalance():C}");
        }

    }
}
