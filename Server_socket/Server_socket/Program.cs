using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Server_socket
{
    class Program
    {
        static Socket sck;
        static byte[] buffer { get; set; }
        static void Main(string[] args)
        {   //pour recuperer l address ip actuelle
            IPHostEntry ipHostEntry = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostEntry.AddressList[0];
            Console.WriteLine("IP=" + ipAddress.ToString());
            //Console.Read();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(ipAddress, 1234));//pour 
            sck.Listen(100);

            Socket Client = null;
           // Socket Client1 = null;
            while (true)
            {
                Client = sck.Accept();


                buffer = new byte[Client.SendBufferSize];
                int bytesRead = Client.Receive(buffer);
                byte[] formatted = new byte[bytesRead];

                for (int i = 0; i < bytesRead; i++)
                {
                    formatted[i] = buffer[i];
                }
                string strdata = Encoding.ASCII.GetString(formatted);
                Console.WriteLine(strdata);
            }
        }
    }
}
