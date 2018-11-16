using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP
{
    internal class UDPreceiver
    {
        private readonly int PORT;

        public UDPreceiver(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            using (UdpClient receiverSock = new UdpClient(PORT)) //lytter på port 7
            {
                while (true)
                {
                 HandleOneRequest(receiverSock, remoteEP);
                }
            }
        }

        private static void HandleOneRequest(UdpClient receiverSock, IPEndPoint remoteEP)
        {
            byte[] data = receiverSock.Receive(ref remoteEP);
            string inStr = Encoding.ASCII.GetString(data);

            Console.WriteLine("modtaget" + inStr);
            Console.WriteLine("sender ip" + remoteEP.Address + " port=" + remoteEP.Port);

            byte[] outData = Encoding.ASCII.GetBytes(inStr.ToUpper());
            receiverSock.Send(outData, outData.Length, remoteEP);
        }
    }
}
