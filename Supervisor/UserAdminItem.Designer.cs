namespace Supervisor
{
    partial class UserAdminItem
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_UserNo = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_UserPassword = new System.Windows.Forms.TextBox();
            this.cmb_Permission = new System.Windows.Forms.ComboBox();
            this.btn_SaveAndExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myMinimizeButton1 = new Supervisor.myMinimizeButton();
            this.myCloseButton1 = new Supervisor.myCloseButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.label1.Location = new System.Drawing.Point(147, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "序号       No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.label2.Location = new System.Drawing.Point(147, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名   Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.label3.Location = new System.Drawing.Point(147, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码       Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.label4.Location = new System.Drawing.Point(147, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "权限       Permission";
            // 
            // txt_UserNo
            // 
            this.txt_UserNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_UserNo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.txt_UserNo.Location = new System.Drawing.Point(360, 65);
            this.txt_UserNo.Name = "txt_UserNo";
            this.txt_UserNo.ReadOnly = true;
            this.txt_UserNo.Size = new System.Drawing.Size(210, 33);
            this.txt_UserNo.TabIndex = 4;
            this.txt_UserNo.TabStop = false;
            // 
            // txt_UserName
            // 
            this.txt_UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.txt_UserName.Location = new System.Drawing.Point(360, 114);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(210, 33);
            this.txt_UserName.TabIndex = 5;
            this.txt_UserName.TabStop = false;
            // 
            // txt_UserPassword
            // 
            this.txt_UserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_UserPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.txt_UserPassword.Location = new System.Drawing.Point(360, 167);
            this.txt_UserPassword.Name = "txt_UserPassword";
            this.txt_UserPassword.Size = new System.Drawing.Size(210, 33);
            this.txt_UserPassword.TabIndex = 6;
            this.txt_UserPassword.TabStop = false;
            // 
            // cmb_Permission
            // 
            this.cmb_Permission.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Permission.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.cmb_Permission.FormattingEnabled = true;
            this.cmb_Permission.Location = new System.Drawing.Point(360, 217);
            this.cmb_Permission.Name = "cmb_Permission";
            this.cmb_Permission.Size = new System.Drawing.Size(210, 35);
            this.cmb_Permission.TabIndex = 7;
            this.cmb_Permission.TabStop = false;
            // 
            // btn_SaveAndExit
            // 
            this.btn_SaveAndExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveAndExit.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.btn_SaveAndExit.Location = new System.Drawing.Point(176, 274);
            this.btn_SaveAndExit.Name = "btn_SaveAndExit";
            this.btn_SaveAndExit.Size = new System.Drawing.Size(296, 49);
            this.btn_SaveAndExit.TabIndex = 8;
            this.btn_SaveAndExit.TabStop = false;
            this.btn_SaveAndExit.Text = "保存并退出 Save and Exit";
            this.btn_SaveAndExit.UseVisualStyleBackColor = true;
            this.btn_SaveAndExit.Click += new System.EventHandler(this.btn_SaveAndExit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_SaveAndExit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb_Permission);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_UserPassword);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_UserName);
            this.panel1.Controls.Add(this.txt_UserNo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 374);
            this.panel1.TabIndex = 10;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.myMinimizeButton1);
            this.panel2.Controls.Add(this.myCloseButton1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 30);
            this.panel2.TabIndex = 10;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            // 
            // myMinimizeButton1
            // 
            this.myMinimizeButton1.BackColor = System.Drawing.Color.LightGray;
            this.myMinimizeButton1.Location = new System.Drawing.Point(550, 0);
            this.myMinimizeButton1.Name = "myMinimizeButton1";
            this.myMinimizeButton1.Size = new System.Drawing.Size(50, 30);
            this.myMinimizeButton1.TabIndex = 1;
            this.myMinimizeButton1.Click += new System.EventHandler(this.myMinimizeButton_Click);
            // 
            // myCloseButton1
            // 
            this.myCloseButton1.BackColor = System.Drawing.Color.LightGray;
            this.myCloseButton1.Location = new System.Drawing.Point(600, 0);
            this.myCloseButton1.Name = "myCloseButton1";
            this.myCloseButton1.Size = new System.Drawing.Size(50, 30);
            this.myCloseButton1.TabIndex = 0;
            this.myCloseButton1.Click += new System.EventHandler(this.btn_QuitAndExit_Click);
            // 
            // UserAdminItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(651, 375);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserAdminItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserAdminItem";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_UserNo;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_UserPassword;
        private System.Windows.Forms.ComboBox cmb_Permission;
        private System.Windows.Forms.Button btn_SaveAndExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private myMinimizeButton myMinimizeButton1;
        private myCloseButton myCloseButton1;
    }
}