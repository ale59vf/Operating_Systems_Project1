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
        public static void Run() {
            // create new object bank account with $1000
            bankAccount newAccount = new bankAccount(1000); // Initial balance $500

            // create three threads
            Thread t1 = new Thread(() => newAccount.Withdraw(500)) { Name = "Thread 1" };
            Thread t2 = new Thread(() => newAccount.Deposit(100)) { Name = "Thread 2" };
            Thread t3 = new Thread(() => newAccount.Withdraw(700)) { Name = "Thread 3" }; // Should fail due to insufficient funds

            // start threads
            t1.Start();
            t2.Start();
            t3.Start();

            // join the threads
            t1.Join();
            t2.Join();
            t3.Join();

            // print completion statement
            Console.WriteLine($"Final account balance: {newAccount.getBalance():C}");
        }

    }
}
