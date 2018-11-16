using System;

namespace UDP
{
    class Program
    {

        private const int PORT = 7;
        static void Main(string[] args)
        {
            UDPreceiver receviver = new UDPreceiver(PORT);
            receviver.Start();

            Console.ReadLine();
        }
    }
}
