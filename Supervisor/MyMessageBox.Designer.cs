namespace Supervisor
{
    partial class MyMessageBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.myMinimizeButton1 = new Supervisor.myMinimizeButton();
            this.myCloseButton1 = new Supervisor.myCloseButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_Message_EN = new System.Windows.Forms.Label();
            this.label_Message_CN = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.myCloseButton = new Supervisor.myCloseButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.myMinimizeButton1);
            this.panel1.Controls.Add(this.myCloseButton1);
            this.panel1.Location = new System.Drawing.Point(-188, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 10;
            // 
            // myMinimizeButton1
            // 
            this.myMinimizeButton1.BackColor = System.Drawing.Color.LightGray;
            this.myMinimizeButton1.Location = new System.Drawing.Point(874, -2);
            this.myMinimizeButton1.Name = "myMinimizeButton1";
            this.myMinimizeButton1.Size = new System.Drawing.Size(50, 30);
            this.myMinimizeButton1.TabIndex = 1;
            // 
            // myCloseButton1
            // 
            this.myCloseButton1.BackColor = System.Drawing.Color.LightGray;
            this.myCloseButton1.Location = new System.Drawing.Point(926, -2);
            this.myCloseButton1.Name = "myCloseButton1";
            this.myCloseButton1.Size = new System.Drawing.Size(50, 30);
            this.myCloseButton1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label_Message_EN);
            this.panel2.Controls.Add(this.label_Message_CN);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 449);
            this.panel2.TabIndex = 11;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMessageBox_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMessageBox_MouseMove);
            // 
            // label_Message_EN
            // 
            this.label_Message_EN.AutoSize = true;
            this.label_Message_EN.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F);
            this.label_Message_EN.Location = new System.Drawing.Point(212, 224);
            this.label_Message_EN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Message_EN.Name = "label_Message_EN";
            this.label_Message_EN.Size = new System.Drawing.Size(111, 41);
            this.label_Message_EN.TabIndex = 22;
            this.label_Message_EN.Text = "label1";
            // 
            // label_Message_CN
            // 
            this.label_Message_CN.AutoSize = true;
            this.label_Message_CN.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F);
            this.label_Message_CN.Location = new System.Drawing.Point(212, 129);
            this.label_Message_CN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Message_CN.Name = "label_Message_CN";
            this.label_Message_CN.Size = new System.Drawing.Size(111, 41);
            this.label_Message_CN.TabIndex = 21;
            this.label_Message_CN.Text = "label1";
            // 
            // btn_OK
            // 
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.btn_OK.Location = new System.Drawing.Point(192, 334);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(147, 44);
            this.btn_OK.TabIndex = 20;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.myCloseButton);
            this.panel3.Location = new System.Drawing.Point(-2, -2);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 36);
            this.panel3.TabIndex = 0;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMessageBox_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMessageBox_MouseMove);
            // 
            // myCloseButton
            // 
            this.myCloseButton.BackColor = System.Drawing.Color.LightGray;
            this.myCloseButton.Location = new System.Drawing.Point(500, -1);
            this.myCloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.myCloseButton.Name = "myCloseButton";
            this.myCloseButton.Size = new System.Drawing.Size(49, 38);
            this.myCloseButton.TabIndex = 1;
            // 
            // MyMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyMessageBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyMessageBox";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private myMinimizeButton myMinimizeButton1;
        private myCloseButton myCloseButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private myCloseButton myCloseButton;
        private System.Windows.Forms.Label label_Message_CN;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label_Message_EN;
    }
}