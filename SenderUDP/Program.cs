using System;

namespace SenderUDP
{
    class Program
    {
        private const int PORT = 7;
        static void Main(string[] args)
        {
            Sender receiver = new Sender(PORT);
            receiver.Start();

            Console.ReadLine();
        }
    }
}
