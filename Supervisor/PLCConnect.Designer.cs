namespace Supervisor
{
    partial class PLCConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_PLCCurrentConnectConfig = new System.Windows.Forms.Label();
            this.cmb_BaudRate = new System.Windows.Forms.ComboBox();
            this.cmb_DataBit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.cmb_StopBit = new System.Windows.Forms.ComboBox();
            this.cmb_Parity = new System.Windows.Forms.ComboBox();
            this.cmb_PortName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_IPAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myMinimizeButton1 = new Supervisor.myMinimizeButton();
            this.myCloseButton1 = new Supervisor.myCloseButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_PLCCurrentConnectConfig
            // 
            this.label_PLCCurrentConnectConfig.AutoSize = true;
            this.label_PLCCurrentConnectConfig.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label_PLCCurrentConnectConfig.Location = new System.Drawing.Point(51, 74);
            this.label_PLCCurrentConnectConfig.Name = "label_PLCCurrentConnectConfig";
            this.label_PLCCurrentConnectConfig.Size = new System.Drawing.Size(380, 31);
            this.label_PLCCurrentConnectConfig.TabIndex = 0;
            this.label_PLCCurrentConnectConfig.Text = "label_PLCCurrentConnectConfig";
            // 
            // cmb_BaudRate
            // 
            this.cmb_BaudRate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_BaudRate.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.cmb_BaudRate.FormattingEnabled = true;
            this.cmb_BaudRate.Location = new System.Drawing.Point(728, 158);
            this.cmb_BaudRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_BaudRate.Name = "cmb_BaudRate";
            this.cmb_BaudRate.Size = new System.Drawing.Size(150, 39);
            this.cmb_BaudRate.TabIndex = 22;
            // 
            // cmb_DataBit
            // 
            this.cmb_DataBit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_DataBit.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.cmb_DataBit.FormattingEnabled = true;
            this.cmb_DataBit.Location = new System.Drawing.Point(296, 340);
            this.cmb_DataBit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_DataBit.Name = "cmb_DataBit";
            this.cmb_DataBit.Size = new System.Drawing.Size(150, 39);
            this.cmb_DataBit.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label5.Location = new System.Drawing.Point(51, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 31);
            this.label5.TabIndex = 20;
            this.label5.Text = "数据位 Data Bit";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_Connect
            // 
            this.btn_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Connect.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.btn_Connect.Location = new System.Drawing.Point(494, 328);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(386, 56);
            this.btn_Connect.TabIndex = 19;
            this.btn_Connect.Text = "保存配置 Save and Exit";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // cmb_StopBit
            // 
            this.cmb_StopBit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_StopBit.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.cmb_StopBit.FormattingEnabled = true;
            this.cmb_StopBit.Location = new System.Drawing.Point(728, 248);
            this.cmb_StopBit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_StopBit.Name = "cmb_StopBit";
            this.cmb_StopBit.Size = new System.Drawing.Size(150, 39);
            this.cmb_StopBit.TabIndex = 18;
            // 
            // cmb_Parity
            // 
            this.cmb_Parity.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Parity.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.cmb_Parity.FormattingEnabled = true;
            this.cmb_Parity.Location = new System.Drawing.Point(296, 248);
            this.cmb_Parity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_Parity.Name = "cmb_Parity";
            this.cmb_Parity.Size = new System.Drawing.Size(150, 39);
            this.cmb_Parity.TabIndex = 17;
            // 
            // cmb_PortName
            // 
            this.cmb_PortName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_PortName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.cmb_PortName.FormattingEnabled = true;
            this.cmb_PortName.Location = new System.Drawing.Point(296, 158);
            this.cmb_PortName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_PortName.Name = "cmb_PortName";
            this.cmb_PortName.Size = new System.Drawing.Size(146, 39);
            this.cmb_PortName.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label4.Location = new System.Drawing.Point(482, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 31);
            this.label4.TabIndex = 15;
            this.label4.Text = "波特率 Baud Rate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label3.Location = new System.Drawing.Point(482, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 31);
            this.label3.TabIndex = 14;
            this.label3.Text = "停止位 Stop Bit";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label2.Location = new System.Drawing.Point(51, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 31);
            this.label2.TabIndex = 13;
            this.label2.Text = "校验位 Baud Rate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(51, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "端口号 Port Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txt_IPAddress);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label_PLCCurrentConnectConfig);
            this.panel1.Controls.Add(this.cmb_BaudRate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmb_DataBit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_Connect);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmb_StopBit);
            this.panel1.Controls.Add(this.cmb_PortName);
            this.panel1.Controls.Add(this.cmb_Parity);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 446);
            this.panel1.TabIndex = 23;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            // 
            // txt_IPAddress
            // 
            this.txt_IPAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_IPAddress.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txt_IPAddress.Location = new System.Drawing.Point(296, 297);
            this.txt_IPAddress.Name = "txt_IPAddress";
            this.txt_IPAddress.Size = new System.Drawing.Size(263, 38);
            this.txt_IPAddress.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label6.Location = new System.Drawing.Point(51, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 31);
            this.label6.TabIndex = 24;
            this.label6.Text = "IP 地址 IP Address";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.myMinimizeButton1);
            this.panel2.Controls.Add(this.myCloseButton1);
            this.panel2.Location = new System.Drawing.Point(-2, -2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 36);
            this.panel2.TabIndex = 23;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            // 
            // myMinimizeButton1
            // 
            this.myMinimizeButton1.BackColor = System.Drawing.Color.LightGray;
            this.myMinimizeButton1.Location = new System.Drawing.Point(812, 0);
            this.myMinimizeButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myMinimizeButton1.Name = "myMinimizeButton1";
            this.myMinimizeButton1.Size = new System.Drawing.Size(56, 36);
            this.myMinimizeButton1.TabIndex = 1;
            this.myMinimizeButton1.Click += new System.EventHandler(this.myMinimizeButton_Click);
            // 
            // myCloseButton1
            // 
            this.myCloseButton1.BackColor = System.Drawing.Color.LightGray;
            this.myCloseButton1.Location = new System.Drawing.Point(868, 0);
            this.myCloseButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myCloseButton1.Name = "myCloseButton1";
            this.myCloseButton1.Size = new System.Drawing.Size(56, 36);
            this.myCloseButton1.TabIndex = 0;
            this.myCloseButton1.Click += new System.EventHandler(this.myCloseButton_Click);
            // 
            // PLCConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 447);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PLCConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLCConnect";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_PLCCurrentConnectConfig;
        private System.Windows.Forms.ComboBox cmb_BaudRate;
        private System.Windows.Forms.ComboBox cmb_DataBit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.ComboBox cmb_StopBit;
        private System.Windows.Forms.ComboBox cmb_Parity;
        private System.Windows.Forms.ComboBox cmb_PortName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private myMinimizeButton myMinimizeButton1;
        private myCloseButton myCloseButton1;
        private System.Windows.Forms.TextBox txt_IPAddress;
        private System.Windows.Forms.Label label6;
    }
}