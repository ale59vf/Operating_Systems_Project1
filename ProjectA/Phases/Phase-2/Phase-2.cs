using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Phases
{
    // Phase 2: Resource Protection
    internal class Phase2
    { 
        // create a function to run
        public void Run() {
            // create new object bank account with $1000
            mutexBankAccount newAccount = new mutexBankAccount(1000); // Initial balance $500

            // create three threads
            Thread t1 = new Thread(() => newAccount.Withdraw(500)) { Name = "Thread 1" };
            Thread t2 = new Thread(() => newAccount.Deposit(100)) { Name = "Thread 2" };
            // start threads
            t1.Start();
            t2.Start();

            // join the threads
            t1.Join();
            t2.Join();

            // print completion statement
            Console.WriteLine($"Final account balance: {newAccount.getBalance():C}");
        }

    }
}
