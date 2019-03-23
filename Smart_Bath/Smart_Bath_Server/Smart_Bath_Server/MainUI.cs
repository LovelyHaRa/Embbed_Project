using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.IO.Ports;

namespace Smart_Bath_Server
{
    public partial class MainUI : Form
    {
        private TcpListener server;
        private Socket connection;
        private NetworkStream socketStream;
        private BinaryReader reader;
        private BinaryWriter writer;
        private Thread serverThread;
        private Thread sendThread;
        private string[] portName;
        private string msg;

        public void RunServer()
        {
            try // and catch (Exception error)
            {
                // listener 생성
                Int32 port = 5000;
                //IPAddress localAddr = IPAddress.Parse(＂127.0.0.1＂);
                server = new TcpListener(IPAddress.Any, port);
                // defined in System.Net.Sockets
                server.Start(); // listening 시작
                                // 요청시 연결 확립 (Socket )
                do
                {
                    connection = server.AcceptSocket();
                    // 소켓에 대한 NetworkStream 생성
                    socketStream = new NetworkStream(connection);
                    // Stream을 통해 data를 송수신하기 위해 read와 write objects 생성
                    writer = new BinaryWriter(socketStream);
                    reader = new BinaryReader(socketStream);
                    // listBox에 수신 내용을 표시 : cross thread error 야기 가능성
                    lstRxdData.Items.Add("connection made");
                    // client에 통지 메시지
                    writer.Write("Message from Server: connected OK");
                    // 수신 데이터를 읽어서, 표시
                    string msgFromClient = null;
                    sendThread = new Thread(new ThreadStart(RunSend));
                    sendThread.Start();
                    do
                    {
                        try
                        {
                            // read the string sent by client and terminate if QUIT
                            msgFromClient = reader.ReadString();
                            if (msgFromClient.Equals("quit"))
                                writer.Write(msgFromClient);
                            else
                            {
                                sendThread.Suspend();
                                msg = "";
                                if(msgFromClient.Equals("s"))
                                {
                                    serialPort1.Write(msgFromClient + '\r');
                                }
                                else if (msgFromClient.Equals("e"))
                                {
                                    serialPort1.Write(msgFromClient + '\r');
                                }
                                sendThread.Resume();
                            }
                            lstRxdData.Items.Add(msgFromClient);
                            
                            try
                            {
                                int inputData = Convert.ToInt32(msgFromClient);
                                if (inputData >= 0 && inputData <= 255)
                                    serialPort1.Write(msgFromClient + '\r');
                            }
                            catch(Exception)
                            {
                            }                            
                            // won't hang because it'll be in a thread
                            // and echo data
                            //writer.Write(msgFromClient);
                        } // end try
                        catch (Exception)
                        {
                            break;
                        } // catch
                    }
                    while (msgFromClient != "quit"); // close if QUIT received
                    lstRxdData.Items.Add("Client disconnected");
                    // and close connection
                    sendThread.Abort();
                    sendThread = null;
                    reader.Close();
                    writer.Close();
                    socketStream.Close();
                    connection.Close();
                    serialPort1.Close();
                }
                while (true);
                //Application.Exit(); // and close - this will
            } // end try
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            } // catch
        } // end RunServer

        public void RunSend()
        {
            while (true)
            {
                msg = serialPort1.ReadTo("\r\n");
                writer.Write(msg);
                msg = "";
                Thread.Sleep(1000);
            }
        }

        public MainUI()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            serverThread = new Thread(new ThreadStart(RunServer));
            serverThread.Start();
            btnListen.Enabled = false;
            btnDisconnect.Enabled = true;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            serverDisConnect();
        }

        private void serverDisConnect()
        {
            try
            {
                if (connection.Connected)
                {
                    reader.Close();
                    writer.Close();
                    socketStream.Close();
                    connection.Close();
                    sendThread.Abort();
                    sendThread = null;
                    server.Stop();
                    serverThread.Abort();
                    btnDisconnect.Enabled = false;
                    
                    btnListen.Enabled = true;
                }
                else
                {
                    sendThread.Abort();
                    server.Stop();
                    btnDisconnect.Enabled = false;
                    serverThread.Abort();                    
                    btnListen.Enabled = true;
                }
            } // try
            catch (Exception error)
            {
                if(sendThread != null)
                    sendThread.Abort();
                if(server!=null)
                    server.Stop();
                btnDisconnect.Enabled = false;
                if(serverThread!=null)
                    serverThread.Abort();                
                btnListen.Enabled = true;
                error.GetType();
                //MessageBox.Show(error.ToString());
            } // catch
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CheckForIllegalCrossThreadCalls = false;
            initSerialPortInfo();
        }

        private void initSerialPortInfo()
        {
            portName = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < portName.Length; i++)
                comboBox1.Items.Add(portName[i]);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if ((string)comboBox1.SelectedItem != null)
            {
                serialPort1.Close();
                serialPortOpen();
                MessageBox.Show("Connect Success!", "Port Connect", MessageBoxButtons.OK);
                if (serverThread == null)
                    btnListen.Enabled = true;                
            }
            else
                MessageBox.Show("You Must Select Port!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void serialPortOpen()
        {
            serialPort1.PortName = (string)comboBox1.SelectedItem;
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverDisConnect();            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
        }
    }
}
