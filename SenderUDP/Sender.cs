using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SenderUDP
{
    internal class Sender
    {
        private int PORT;

        public Sender(int port)
        {
            this.PORT= port;
        }

        public void Start()
        {
            string navn = "Martin";

            byte[] data = Encoding.ASCII.GetBytes(navn);
            IPEndPoint receiver = new IPEndPoint(IPAddress.Loopback, PORT);

            using (UdpClient senderSock = new UdpClient()) // ingen port = lytter IKKE
            {
                senderSock.Send(data, data.Length, receiver);

                IPEndPoint FromreceiverEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] inData = senderSock.Receive(ref FromreceiverEP);

                string inStr = Encoding.ASCII.GetString(inData);

                Console.WriteLine("Modtaget = " + inStr);
            }

        }
    }
}

