namespace Supervisor
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.cmb_Username = new System.Windows.Forms.ComboBox();
            this.label_CompanyName = new System.Windows.Forms.Label();
            this.label_ApplicationName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myMinimizeButton1 = new Supervisor.myMinimizeButton();
            this.myCloseButton1 = new Supervisor.myCloseButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(127, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "账户  Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(127, 229);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码  Password";
            // 
            // txt_Password
            // 
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Password.Location = new System.Drawing.Point(342, 228);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(191, 38);
            this.txt_Password.TabIndex = 3;
            this.txt_Password.TabStop = false;
            // 
            // btn_Login
            // 
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Location = new System.Drawing.Point(144, 291);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(372, 53);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.TabStop = false;
            this.btn_Login.Text = "登录 Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // cmb_Username
            // 
            this.cmb_Username.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Username.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Username.FormattingEnabled = true;
            this.cmb_Username.Location = new System.Drawing.Point(342, 167);
            this.cmb_Username.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_Username.Name = "cmb_Username";
            this.cmb_Username.Size = new System.Drawing.Size(192, 39);
            this.cmb_Username.TabIndex = 5;
            this.cmb_Username.TabStop = false;
            // 
            // label_CompanyName
            // 
            this.label_CompanyName.AutoSize = true;
            this.label_CompanyName.Font = new System.Drawing.Font("Microsoft YaHei UI", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CompanyName.Location = new System.Drawing.Point(229, 40);
            this.label_CompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CompanyName.Name = "label_CompanyName";
            this.label_CompanyName.Size = new System.Drawing.Size(120, 46);
            this.label_CompanyName.TabIndex = 7;
            this.label_CompanyName.Text = "label3";
            this.label_CompanyName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_ApplicationName
            // 
            this.label_ApplicationName.AutoSize = true;
            this.label_ApplicationName.Font = new System.Drawing.Font("Microsoft YaHei UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ApplicationName.Location = new System.Drawing.Point(271, 95);
            this.label_ApplicationName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ApplicationName.Name = "label_ApplicationName";
            this.label_ApplicationName.Size = new System.Drawing.Size(104, 39);
            this.label_ApplicationName.TabIndex = 8;
            this.label_ApplicationName.Text = "label4";
            this.label_ApplicationName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.myMinimizeButton1);
            this.panel1.Controls.Add(this.myCloseButton1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 21);
            this.panel1.TabIndex = 9;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            // 
            // myMinimizeButton1
            // 
            this.myMinimizeButton1.BackColor = System.Drawing.Color.LightGray;
            this.myMinimizeButton1.Location = new System.Drawing.Point(583, -1);
            this.myMinimizeButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.myMinimizeButton1.Name = "myMinimizeButton1";
            this.myMinimizeButton1.Size = new System.Drawing.Size(33, 20);
            this.myMinimizeButton1.TabIndex = 1;
            this.myMinimizeButton1.Click += new System.EventHandler(this.myMinimizeButton_Click);
            // 
            // myCloseButton1
            // 
            this.myCloseButton1.BackColor = System.Drawing.Color.LightGray;
            this.myCloseButton1.Location = new System.Drawing.Point(617, -1);
            this.myCloseButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.myCloseButton1.Name = "myCloseButton1";
            this.myCloseButton1.Size = new System.Drawing.Size(33, 20);
            this.myCloseButton1.TabIndex = 0;
            this.myCloseButton1.Click += new System.EventHandler(this.myCloseButton_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label_ApplicationName);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label_CompanyName);
            this.panel2.Controls.Add(this.txt_Password);
            this.panel2.Controls.Add(this.cmb_Username);
            this.panel2.Controls.Add(this.btn_Login);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 403);
            this.panel2.TabIndex = 10;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 403);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.ComboBox cmb_Username;
        private System.Windows.Forms.Label label_CompanyName;
        private System.Windows.Forms.Label label_ApplicationName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private myMinimizeButton myMinimizeButton1;
        private myCloseButton myCloseButton1;
    }
}

