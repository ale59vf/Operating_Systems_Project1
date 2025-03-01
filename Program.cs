using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        // Set up the process start information for the Consumer process
        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = "run --project ConsumerProcess", // Replace with actual consumer executable
            RedirectStandardInput = true, // Redirect Consumer's input
            RedirectStandardOutput = true, // Redirect Consumer's output
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process consumer = new Process { StartInfo = psi })
        {
            consumer.Start(); // Start the Consumer process

            using (StreamWriter writer = consumer.StandardInput)
            {
                if (writer.BaseStream.CanWrite)
                {
                    Console.WriteLine("[Producer] Sending messages to Consumer...");
                    
                    // Data Integrity Test: Sending JSON formatted data
                    var data = new { Id = 1, Message = "Hello from Producer" };
                    string jsonData = JsonSerializer.Serialize(data);
                    writer.WriteLine(jsonData);

                    // Performance Benchmarking: Measuring time to send a large file
                    var stopwatch = Stopwatch.StartNew();
                    writer.WriteLine(File.ReadAllText("largefile.txt"));
                    stopwatch.Stop();
                    Console.WriteLine($"[Producer] Time taken to send data: {stopwatch.ElapsedMilliseconds} ms");
                    
                    writer.WriteLine("exit"); // Signal Consumer to exit
                }
            }

            // Read and display output from Consumer
            string output;
            while ((output = consumer.StandardOutput.ReadLine()) != null)
            {
                Console.WriteLine($"[Producer] Received from Consumer: {output}");
            }

            consumer.WaitForExit(); // Wait for Consumer process to finish
        }
    }
}
