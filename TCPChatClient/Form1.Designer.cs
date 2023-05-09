namespace TCPChatClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_chatBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_sendBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_send = new System.Windows.Forms.Button();
            this.button_receive = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pic_show = new System.Windows.Forms.PictureBox();
            this.button_pic_send = new System.Windows.Forms.Button();
            this.button_pic_select = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_show)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_connect);
            this.groupBox1.Controls.Add(this.textBox_ip);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(255, 23);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(131, 47);
            this.button_connect.TabIndex = 5;
            this.button_connect.Text = "开始连接";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(69, 23);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(180, 21);
            this.textBox_ip.TabIndex = 4;
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(69, 51);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(180, 21);
            this.textBox_name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_chatBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 140);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "聊天框";
            // 
            // textBox_chatBox
            // 
            this.textBox_chatBox.Location = new System.Drawing.Point(6, 20);
            this.textBox_chatBox.Multiline = true;
            this.textBox_chatBox.Name = "textBox_chatBox";
            this.textBox_chatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_chatBox.Size = new System.Drawing.Size(380, 105);
            this.textBox_chatBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_sendBox);
            this.groupBox3.Location = new System.Drawing.Point(13, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 159);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送消息";
            // 
            // textBox_sendBox
            // 
            this.textBox_sendBox.Location = new System.Drawing.Point(11, 18);
            this.textBox_sendBox.Multiline = true;
            this.textBox_sendBox.Name = "textBox_sendBox";
            this.textBox_sendBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_sendBox.Size = new System.Drawing.Size(190, 132);
            this.textBox_sendBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_send);
            this.groupBox4.Controls.Add(this.button_receive);
            this.groupBox4.Controls.Add(this.button_stop);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(226, 243);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(179, 159);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "选择按钮";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(17, 118);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(146, 35);
            this.button_send.TabIndex = 6;
            this.button_send.Text = "发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_receive
            // 
            this.button_receive.Location = new System.Drawing.Point(17, 76);
            this.button_receive.Name = "button_receive";
            this.button_receive.Size = new System.Drawing.Size(146, 36);
            this.button_receive.TabIndex = 5;
            this.button_receive.Text = "接收";
            this.button_receive.UseVisualStyleBackColor = true;
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(17, 44);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(146, 30);
            this.button_stop.TabIndex = 4;
            this.button_stop.Text = "断开连接";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(77, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "选择用户";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pic_show);
            this.groupBox5.Controls.Add(this.button_pic_send);
            this.groupBox5.Controls.Add(this.button_pic_select);
            this.groupBox5.Location = new System.Drawing.Point(412, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(345, 380);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "图片接收发送区域";
            // 
            // pic_show
            // 
            this.pic_show.Location = new System.Drawing.Point(7, 21);
            this.pic_show.Name = "pic_show";
            this.pic_show.Size = new System.Drawing.Size(332, 312);
            this.pic_show.TabIndex = 2;
            this.pic_show.TabStop = false;
            // 
            // button_pic_send
            // 
            this.button_pic_send.Location = new System.Drawing.Point(211, 342);
            this.button_pic_send.Name = "button_pic_send";
            this.button_pic_send.Size = new System.Drawing.Size(128, 32);
            this.button_pic_send.TabIndex = 1;
            this.button_pic_send.Text = "发送图片";
            this.button_pic_send.UseVisualStyleBackColor = true;
            this.button_pic_send.Click += new System.EventHandler(this.button_pic_send_Click);
            // 
            // button_pic_select
            // 
            this.button_pic_select.Location = new System.Drawing.Point(6, 342);
            this.button_pic_select.Name = "button_pic_select";
            this.button_pic_select.Size = new System.Drawing.Size(137, 32);
            this.button_pic_select.TabIndex = 0;
            this.button_pic_select.Text = "选择图片";
            this.button_pic_select.UseVisualStyleBackColor = true;
            this.button_pic_select.Click += new System.EventHandler(this.button_pic_select_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 414);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_chatBox;
        private System.Windows.Forms.TextBox textBox_sendBox;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_receive;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pic_show;
        private System.Windows.Forms.Button button_pic_send;
        private System.Windows.Forms.Button button_pic_select;
    }
}

