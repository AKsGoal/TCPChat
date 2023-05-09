using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TCPChatServer
{
    public partial class Form1 : Form
    {
        private IPAddress localAddress;
        private const int port = 8848;
        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private BinaryReader binReader;
        private BinaryWriter binWriter;
        private string log = "";
        private int count = 0;
        private bool isConnected = false;

        public delegate void ShowLog(string log);
        public ShowLog showLog;
        public delegate void ShowNumber();
        public ShowNumber showNumber;

        private List<Client> clientList;
        private MyListener listener;
        public byte[] temp;
        public Form1()
        {
            InitializeComponent();
            localAddress = new IPAddress(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].GetHashCode());
            showLog = new ShowLog(SetLog);
            showNumber = new ShowNumber(SetNumber);
            clientList = new List<Client>();
            listener = new MyListener(this);
        }

        private void SetNumber()
        {
            label_status.Text = "已上线" + count + "人";
        }

        private void SetLog(string log)
        {
            textBox_log.AppendText(log);
        }

        public static string GetTime()
        {
            return "\r\n" + DateTime.Now.ToString() + "\r\n";
        }

        private void StartServer()
        {
            log = GetTime() + "开始启动服务器。。。。";
            textBox_log.Invoke(showLog, log);
            tcpListener = new TcpListener(localAddress, port);
            tcpListener.Start();
            isConnected = true;
            log = GetTime() + "IP:" + localAddress + "端口号:" + port + "已启用监听";
            textBox_log.Invoke(showLog, log);
            while (true)
            {
                try
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    networkStream = tcpClient.GetStream();
                    binReader = new BinaryReader(networkStream);
                    binWriter = new BinaryWriter(networkStream);
                    string accountName = binReader.ReadString();
                    accountName = DecodeUserName(accountName);
                    log = GetTime() + "用户" + accountName + "已上线";
                    count++;
                    label_status.Invoke(showNumber);
                    textBox_log.Invoke(showLog, log);
                    clientList.Add(new Client(accountName, tcpClient, listener));
                    NotifyUpdateUserList();
                }
                catch
                {
                    log = GetTime() + "已终止监听";
                    textBox_log.Invoke(showLog, log);
                    return;
                }
            }
        }

        private void NotifyUpdateUserList()
        {
            string message = "1" + GetCurUserName();
            foreach(Client client in clientList)
            {
                client.SendMessage(message);
            }
        }

        private string GetCurUserName()
        {
            string name = "";
            foreach(Client client in clientList)
            {
                name = name + "$" + client.userName;
            }
            return name;
        }

        public string DecodeUserName(string words)
        {
            return words.Split('$')[1];
        }

        public void SendMessageToClient(string content, string goalName, string userName,bool byte_flag, bool sys_flag)
        {
            bool flag = false;
            if (goalName.Equals("所有人"))
            {
                flag = true;
            }
            foreach (Client client in clientList)
            {
                if (flag)
                {
                    client.SendMessage("2$广播：" + userName + "说: " + content);
                }
                else
                {
                    if (client.userName.Equals(goalName))
                    {
                        if (byte_flag)
                        {
                            client.binWriter.Write(temp, 0, temp.Length);
                            client.binWriter.Flush();
                        }
                        else
                        {
                            if (sys_flag)
                            {
                                client.SendMessage(content);
                            }
                            else
                            {
                                client.SendMessage("2$" + userName + "说: " + content);
                            }

                        }
                        return;
                    }
                }
            }
        }

        public void StopClientByName(string name)
        {
            foreach (Client client in clientList)
            {
                if (client.userName.Equals(name))
                {
                    client.Stop();
                    count--;
                    label_status.Invoke(showNumber);
                    textBox_log.Invoke(showLog,GetTime()+name+"已下线");
                    clientList.Remove(client);
                }
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            CloseAllClients();
            binWriter?.Close();
            binReader?.Close();
            tcpClient?.Close();
            tcpListener?.Stop();
            log = GetTime() + "已停止服务";
            textBox_log.Invoke(showLog, log);
            count = 0;
            isConnected = false;
        }

        public void CloseAllClients()
        {
            foreach(Client client in clientList)
            {
                client.Stop();
            }
            clientList.Clear();
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                MessageBox.Show("服务器已启动！");
                return;
            }
            Thread thread = new Thread(StartServer);
            thread.Start();
            thread.IsBackground = true;
        }
    }

    public class MyListener : Client.ReceiveMessageListener
    {
        public Form1 form;
        public MyListener(Form1 f)
        {
            form = f;
        }

        public void GetMessage(string accountName, string message, BinaryReader binReader, BinaryWriter binWriter)
        {
            string[] results = message.Split('$');
            if (int.Parse(results[0]) == 2)//发送信息
            {
                string content = results[1];
                string goalName = results[2];
                form.SendMessageToClient(content, goalName, accountName,false,false);
            }
            else if (int.Parse(results[0]) == 3)//终止连接
            {
                string content = results[1];
                form.StopClientByName(content);
            }
            else if (int.Parse(results[0]) == 4)
            {
                int length = int.Parse(results[1]);
                string goalName = results[2];
                form.temp = binReader.ReadBytes(length);
                form.SendMessageToClient("3$" + length, goalName, accountName, false, true);
                form.SendMessageToClient("我发送了一条广播图片,但是程序员太菜不会实现:(", goalName, accountName, true, false);
            }
            {
                return;
            }
        }
    }


}
