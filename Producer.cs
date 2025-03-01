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

        public void Produce(StreamWriter writer)
        {
            if (writer.BaseStream.CanWrite)
            {
                Console.WriteLine("[Producer] Sending messages...");
                writer.WriteLine("Data 1 from Producer");
                writer.WriteLine("Data 2 from Producer");
                writer.WriteLine("exit"); // End signal
            }
        }
    }
}
