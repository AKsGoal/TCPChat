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
using System.IO;
using System.Threading;

namespace TCPChatClient
{
    public partial class Form1 : Form
    {
        private const int port = 8848;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private BinaryReader binReader;
        private BinaryWriter binWriter;
        private string log = "";
        private bool isConnected = false;
        private Thread thread;
        private string picDir;

        private delegate void UpdateComboBox(string userName);
        private UpdateComboBox updateComboBox;

        private delegate void ShowLog(string log);
        private ShowLog showLog;

        private delegate void UpdateImage(Image image);
        private UpdateImage updateImage;

        public Form1()
        {
            InitializeComponent();
            showLog = new ShowLog(SetLog);
            updateComboBox = new UpdateComboBox(SetComboBox);
            updateImage = new UpdateImage(SetImage);
        }

        private void SetComboBox(string userName)
        {
            string results = userName.Substring(userName.IndexOf('$') + 1);
            string[] namelist = results.Split('$');
            comboBox1.Items.Clear();
            for (int i = 0; i < namelist.Length; i++)
            {
                comboBox1.Items.Add(namelist[i]);
            }
            comboBox1.Items.Add("所有人");
        }

        private void SetLog(string log)
        {
            textBox_chatBox.AppendText(log);
        }

        private string EncodeMessage(string message, int code, string goalName)
        {
            switch (code)
            {
                case 1://汇报用户名
                    return "1$" + message;
                case 2://发送信息
                    return "2$" + message + "$" + goalName;
                case 3://下线请求
                    return "3$" + message;
                case 4://发送图片(二进制数据)
                    return "4$" + message + "$" + goalName;
                default:
                    return "-1$ERROR!";
            }
        }

        private void DecodeMessage(string message)
        {
            string[] results = message.Split('$');
            int code = int.Parse(results[0]);
            switch (code)
            {
                case 1://更新的是用户
                    comboBox1.Invoke(updateComboBox, message);
                    break;
                case 2://收到信息
                    string rev = message.Substring(message.IndexOf('$') + 1);
                    textBox_chatBox.Invoke(showLog, DateUtil.GetTime() + rev);
                    break;
            }
        }

        public void SendMessage(string message, int code, string goalName)
        {
            string sendMessage = EncodeMessage(message, code, goalName);
            try
            {
                binWriter.Write(sendMessage);
                binWriter.Flush();
                log = DateUtil.GetTime() + "发送信息:" + message;//日志
                if (code == 1)
                {
                    isConnected = true;
                }
                else
                {
                    if(code!=4) textBox_chatBox.AppendText(log);
                }
            }
            catch
            {
                log = DateUtil.GetTime() + "服务器已断开连接";
                return;
            }
        }

        public void ReceiveMessage()
        {
            while (isConnected)
            {
                try
                {
                    string rcvMsgStr = binReader.ReadString();
                    string[] results = rcvMsgStr.Split('$');
                    int code = int.Parse(results[0]);
                    if (code == 3)//接受图片
                    {
                        pic_show.Invoke(updateImage, SetByteToImage(binReader.ReadBytes(int.Parse(results[1]))));
                    }
                    else
                    {
                        DecodeMessage(rcvMsgStr);
                    }
                }
                catch
                {
                    log = DateUtil.GetTime() + "服务器已断开连接";
                    textBox_chatBox.Invoke(showLog, log);
                    return;
                }
            }
        }


        private void button_connect_Click(object sender, EventArgs e)
        {
            string inputIP = "http://10.253.0.9/";
            if (string.IsNullOrEmpty(textBox_ip.Text))
            {
                MessageBox.Show("请输入IP地址！");
                return;
            }

            if (string.IsNullOrEmpty(textBox_name.Text))
            {
                MessageBox.Show("请输入用户名！");
                return;
            }

            if (!Uri.TryCreate(inputIP, UriKind.Absolute, out Uri uri))
            {
                MessageBox.Show("请输入正确的网址");
                return;
            }

            if (!IPAddress.TryParse("10.253.0.9", out IPAddress ipAddress))
            {
                MessageBox.Show("请输入正确的网址");
                return;
            }

            if (IPAddress.IsLoopback(ipAddress) || IPAddress.Loopback.Equals(ipAddress))
            {
                // 输入为本机地址，可以继续操作
            }
            IPHostEntry remoteHost = Dns.GetHostEntry(textBox_ip.Text);
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(remoteHost.HostName, port);
            }
            catch
            {
                MessageBox.Show("服务器未开启！");
                tcpClient.Close();
            }
            try
            {
                if (tcpClient.Connected)
                {
                    string userName = textBox_name.Text;
                    log = DateUtil.GetTime() + "以用户名" + userName + "连接服务器";
                    textBox_chatBox.AppendText(log);
                    networkStream = tcpClient.GetStream();
                    binReader = new BinaryReader(networkStream);
                    binWriter = new BinaryWriter(networkStream);
                    SendMessage(userName, 1, "");//向服务器发送消息，告诉服务器自己的用户名

                    thread = new Thread(ReceiveMessage);
                    thread.Start();
                    thread.IsBackground = true;
                }
            }
            catch
            {
                MessageBox.Show("服务器连接失败，请重试!");
                log = DateUtil.GetTime() + "服务器连接失败，请重试!";
                textBox_chatBox.AppendText(log);
            }
           
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            SendMessage(textBox_name.Text, 3, "");
            log = DateUtil.GetTime() + "已发起下线请求";
            textBox_chatBox.Invoke(showLog, log);
            isConnected = false;
            binWriter?.Close();
            binReader?.Close();
            tcpClient?.Close();
            thread?.Abort();
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            SendMessage(textBox_sendBox.Text, 2, comboBox1.Text);
            textBox_sendBox.Clear();
        }

        private void button_pic_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "图片文件(*.jpg,*.gif,*.bmp,*.png)|*.jpg;*.gif;*.bmp;*.png";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                picDir = fileDialog.FileName;
                pic_show.Image = Image.FromFile(picDir);
            }
        }

        private void button_pic_send_Click(object sender, EventArgs e)
        {
            int length = SetImageToByteArray(picDir).Length;
            SendMessage(length + "", 4, comboBox1.Text);
            SendImage();
            pic_show.Image = null;
        }

        private void SendImage()
        {
            byte[] datas = SetImageToByteArray(picDir);
            binWriter.Write(datas, 0, datas.Length);
            binWriter.Flush();
        }

        private byte[] SetImageToByteArray(string fileName)
        {
            FileStream fs = new FileStream(fileName,FileMode.Open,System.IO.FileAccess.Read,FileShare.ReadWrite);
            byte[] byteData = new byte[fs.Length];
            fs.Read(byteData, 0, byteData.Length);
            fs.Close();
            return byteData;
        }

        private Image SetByteToImage(byte[] myByte)
        {
            MemoryStream ms = new MemoryStream(myByte);
            Image outputImg = Image.FromStream(ms);
            return outputImg;
        }

        private void SetImage(Image image)
        {
            pic_show.Image = image;
        }
    }
    
}
