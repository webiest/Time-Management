using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recorder;

namespace RecorderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RecorderServer server = new RecorderServer("test.db");
            server.Start();
            Console.WriteLine("Hit a key to stop");
            Console.ReadKey();
            server.Stop();
        }
    }
}
