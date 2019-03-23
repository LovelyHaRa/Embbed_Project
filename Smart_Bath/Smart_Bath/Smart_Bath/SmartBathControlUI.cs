using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading; //Thread 사용

namespace Smart_Bath
{
    public partial class SmartBathControlUI : Form
    {
        private NetworkStream clientStream;
        private BinaryReader reader;
        private BinaryWriter writer;
        private Thread clientThread; // Thread
        private string message = null;
        private string serverIPAdress;
        private bool isDisconnected = true;

        public SmartBathControlUI()
        {
            InitializeComponent();
        }

        public void RunClient()
        {
            TcpClient client;
            // init tcpClient
            try
            {
                // 1. Create client and connect to server- give
                client = new TcpClient();
                // give IP address and port to talk to
                try
                {
                    client.Connect(serverIPAdress, 5000);
                }
                catch (SocketException se)
                {
                    MessageBox.Show("서버에 연결할 수 없습니다.(" + se.GetType() + ")", "서버 연결 오류", MessageBoxButtons.OK);
                    btnConnect.Enabled = true;
                    return;
                }
                // get network stream
                clientStream = client.GetStream();
                // create read and write objects
                writer = new BinaryWriter(clientStream);
                reader = new BinaryReader(clientStream);
                lstRxdData.Items.Add("connecting to server");
                buttonApply.Enabled = true;
                buttonOn.Enabled = true;
                buttonOff.Enabled = true;
                btnDisconnect.Enabled = true;
                isDisconnected = false;
                // we will ignore cross-thread errors in form load, 
                do
                    try
                    {
                        // read message from server until QUIT received
                        message = reader.ReadString();
                        if (message != "quit" && message !="Message from Server: connected OK")
                        {
                            string[] msgtok = message.Split(new char[1] { '#' });                     
                            textBoxGT.Text = msgtok[0];
                            textBoxTS.Text = msgtok[1];
                            textBoxWS.Text = msgtok[2];
                        }
                        lstRxdData.Items.Add(message);
                    } // try
                    catch (Exception error)
                    {
                        MessageBox.Show("Error reading from server " + error.ToString());
                        break;
                    } // catch
                while (message != "quit");
                // close connection
                lstRxdData.Items.Add("Closing connection");
                writer.Close();
                reader.Close();
                clientStream.Close();
                client.Close();
                buttonApply.Enabled = false;
                buttonOn.Enabled = false;
                buttonOff.Enabled = false;
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true; // re-enable connect button
            } // end try
            catch (Exception error)
            {
                MessageBox.Show("Error creating connection " + error.ToString());
            }
        }

        private void SmartBathControlUI_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            serverIPAdress = textBoxIP.Text;
            clientThread = new Thread(new ThreadStart(RunClient));
            clientThread.Start();
            btnConnect.Enabled = false;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            writer.Write("quit");
            isDisconnected = true;
        }

        private void SmartBathControlUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isDisconnected)
                writer.Write("quit");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (clientThread != null)
            {
                try
                {
                    writer.Write("quit");
                    clientThread.Abort();
                }
                catch (ObjectDisposedException) { }
                finally
                {
                    Application.Exit();
                }
            }
            else
                Application.Exit();
        }

        private void buttonOn_Click(object sender, EventArgs e)
        {
            if (!isDisconnected)
                writer.Write("s");
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            if (!isDisconnected)
                writer.Write("e");
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = Convert.ToInt32(textBoxST.Text);
                if (temp >= 0 && temp <= 50)
                    writer.Write(textBoxST.Text);
                else
                    throw new FormatException();
                MessageBox.Show("정상적으로 적용되었습니다.", "SmartBath");
            }
            catch (FormatException)
            {
                MessageBox.Show("값이 유효하지 않습니다, ", "SmartBath");
            }
        }
    }
}
