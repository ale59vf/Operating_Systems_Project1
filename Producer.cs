using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    internal class Producer
    {
        // This class simulates a producer that writes messages to a pipe

        public void producer(StreamWriter writer)
        {
            try
            {
                if (writer.BaseStream.CanWrite)
                {
                    Console.WriteLine("[Producer] Sending messages...");
                    var data = new { Id = 1, Message = "Structured Data" };
                    writer.WriteLine(JsonSerializer.Serialize(data));
                    writer.WriteLine("exit"); // End signal
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"[Producer] Error: {ex.Message}"); // Error Handling Test
            }
        }
    }
}
