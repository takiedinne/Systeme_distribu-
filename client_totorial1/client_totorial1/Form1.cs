using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace client_totorial1
{
    public partial class Form1 : Form
    {
        Socket sck;
        string serverIp="localhost";
        int port=8080;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                sck.Connect(localEndPoint);
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("unable de connect ...");
                Console.Read();
            }
            byte[] data = Encoding.ASCII.GetBytes(textBox1.Text);

            sck.Send(data);
            sck.Close();
        
        }
    }
}
