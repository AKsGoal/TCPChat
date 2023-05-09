using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TCPChatServer
{
    internal class Client
    {
        public string userName;
        public TcpClient tcpClient;
        public BinaryReader binReader;
        public BinaryWriter binWriter;
        public ReceiveMessageListener listener;
        public bool flag = false;

        public Client(string userName,TcpClient client,ReceiveMessageListener receiveMessageListener) 
        { 
            this.userName = userName;
            this.tcpClient = client;    
            this.listener = receiveMessageListener;
            NetworkStream networkStream = tcpClient.GetStream();
            binReader = new BinaryReader(networkStream);
            binWriter = new BinaryWriter(networkStream);
            Thread thread = new Thread(ReceiveMessage);
            thread.Start();
            flag = true;
            thread.IsBackground = true;
        }

        public override bool Equals(object obj)
        {
            return obj is Client client && userName == client.userName;
        }

        public bool SendMessage(string ecodeMessage)
        {
            try
            {
                binWriter.Write(ecodeMessage);
                binWriter.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    string temp = binReader.ReadString();
                    listener.GetMessage(userName, temp,binReader,binWriter);
                }
                catch
                {
                    return;
                }
            }
        }

        public void Stop()
        {
            flag = false;
            binWriter?.Close();
            binReader?.Close();
            tcpClient?.Close();
        }

        public interface ReceiveMessageListener
        {
            void GetMessage(string accountName, string message,BinaryReader binReader,BinaryWriter binWriter);
        }
    }
}
