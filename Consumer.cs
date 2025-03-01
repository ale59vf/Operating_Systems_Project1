using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class Consumer
    {
        // This class reads messages from the pipe and processes them

        public void Consume()
        {
            Console.WriteLine("[Consumer] Waiting for input...");
            string input;

            // Read input from Producer via standard input (pipe)
            while ((input = Console.ReadLine()) != null)
            {
                if (input.ToLower() == "exit") // Exit condition
                    break;

                Console.WriteLine($"[Consumer] Processed: {input.ToUpper()}"); // Process and return data
            }

            Console.WriteLine("[Consumer] Exiting...");
        }
    }
}
