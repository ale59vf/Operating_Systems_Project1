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
                    writer.WriteLine("Message 1 from Producer"); // Send message to Consumer
                    writer.WriteLine("Message 2 from Producer"); // Send another message
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