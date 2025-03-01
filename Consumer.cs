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
        public void consumer()
        {
            Console.WriteLine("[Consumer] Waiting for input...");
            string input;

            var stopwatch = Stopwatch.StartNew(); // Performance Benchmarking Start
            while ((input = Console.ReadLine()) != null)
            {
                if (input.ToLower() == "exit") // Exit condition
                break;

                try
                {
                    var receivedObject = JsonSerializer.Deserialize<dynamic>(input); // Data Integrity Test
                    Console.WriteLine($"[Consumer] Processed JSON Data: {receivedObject}");
                }
                catch (JsonException)
                {
                    Console.WriteLine($"[Consumer] Received raw data: {input.ToUpper()}");
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"[Consumer] Data received in {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine("[Consumer] Exiting...");
        }
    }
}
