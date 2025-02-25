using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Phases
{
    // Phase 1: Basic threads
    internal class Phase1
    {
        // create a function to run
        public static void Run() {

            // create a new object bank account with $1000
            bankAccount newAccount = new bankAccount(1000);

            // create three threads 
            Thread t1 = new Thread(() => { newAccount.Deposit(500); });
            Thread t2 = new Thread(() => { newAccount.Withdraw(1500); });
            Thread t3 = new Thread(() => { newAccount.Deposit(20); });

            // start threads 
            t1.Start();
            t2.Start();
            t3.Start();

            // joining threads 
            t1.Join();
            t2.Join();
            t3.Join();

            // print completion statement 
            Console.WriteLine("Phase 1 is complete!");
        }

    }
}
