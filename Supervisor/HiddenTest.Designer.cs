namespace Supervisor
{
    partial class HiddenTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_ReadResult = new System.Windows.Forms.Label();
            this.label_Unit = new System.Windows.Forms.Label();
            this.btn_Config = new System.Windows.Forms.Button();
            this.label_Label2 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.label_Label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myMinimizeButton1 = new Supervisor.myMinimizeButton();
            this.myCloseButton1 = new Supervisor.myCloseButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btn_Config);
            this.panel1.Controls.Add(this.label_Label2);
            this.panel1.Controls.Add(this.btn_Start);
            this.panel1.Controls.Add(this.label_Label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 280);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 240);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Automatic Pulse Width Calculation at Current Product Speed";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label_Unit);
            this.panel3.Location = new System.Drawing.Point(76, 107);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(471, 80);
            this.panel3.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label_ReadResult);
            this.panel4.Location = new System.Drawing.Point(13, 19);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(331, 39);
            this.panel4.TabIndex = 5;
            // 
            // label_ReadResult
            // 
            this.label_ReadResult.AutoSize = true;
            this.label_ReadResult.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ReadResult.Location = new System.Drawing.Point(7, 8);
            this.label_ReadResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ReadResult.Name = "label_ReadResult";
            this.label_ReadResult.Size = new System.Drawing.Size(0, 21);
            this.label_ReadResult.TabIndex = 3;
            // 
            // label_Unit
            // 
            this.label_Unit.AutoSize = true;
            this.label_Unit.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label_Unit.Location = new System.Drawing.Point(377, 27);
            this.label_Unit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Unit.Name = "label_Unit";
            this.label_Unit.Size = new System.Drawing.Size(55, 21);
            this.label_Unit.TabIndex = 4;
            this.label_Unit.Text = "label3";
            // 
            // btn_Config
            // 
            this.btn_Config.BackColor = System.Drawing.Color.Red;
            this.btn_Config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Config.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_Config.Location = new System.Drawing.Point(581, 247);
            this.btn_Config.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Config.Name = "btn_Config";
            this.btn_Config.Size = new System.Drawing.Size(44, 23);
            this.btn_Config.TabIndex = 6;
            this.btn_Config.Text = "配置";
            this.btn_Config.UseVisualStyleBackColor = false;
            this.btn_Config.Click += new System.EventHandler(this.btn_Config_Click);
            // 
            // label_Label2
            // 
            this.label_Label2.AutoSize = true;
            this.label_Label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Label2.Location = new System.Drawing.Point(29, 213);
            this.label_Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Label2.Name = "label_Label2";
            this.label_Label2.Size = new System.Drawing.Size(258, 20);
            this.label_Label2.TabIndex = 5;
            this.label_Label2.Text = "产品运行在当前速度下光电开ON时间";
            // 
            // btn_Start
            // 
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.btn_Start.Location = new System.Drawing.Point(563, 125);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(73, 51);
            this.btn_Start.TabIndex = 2;
            this.btn_Start.Text = "启动测试\r\nStart Test";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Start_MouseDown);
            this.btn_Start.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Start_MouseUp);
            // 
            // label_Label1
            // 
            this.label_Label1.AutoSize = true;
            this.label_Label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Label1.Location = new System.Drawing.Point(35, 61);
            this.label_Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Label1.Name = "label_Label1";
            this.label_Label1.Size = new System.Drawing.Size(167, 30);
            this.label_Label1.TabIndex = 1;
            this.label_Label1.Text = "输送线产品测试";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.myMinimizeButton1);
            this.panel2.Controls.Add(this.myCloseButton1);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 25);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            // 
            // myMinimizeButton1
            // 
            this.myMinimizeButton1.BackColor = System.Drawing.Color.LightGray;
            this.myMinimizeButton1.Location = new System.Drawing.Point(587, -1);
            this.myMinimizeButton1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.myMinimizeButton1.Name = "myMinimizeButton1";
            this.myMinimizeButton1.Size = new System.Drawing.Size(37, 24);
            this.myMinimizeButton1.TabIndex = 1;
            this.myMinimizeButton1.Click += new System.EventHandler(this.myMinimizeButton_Click);
            // 
            // myCloseButton1
            // 
            this.myCloseButton1.BackColor = System.Drawing.Color.LightGray;
            this.myCloseButton1.Location = new System.Drawing.Point(624, -1);
            this.myCloseButton1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.myCloseButton1.Name = "myCloseButton1";
            this.myCloseButton1.Size = new System.Drawing.Size(37, 24);
            this.myCloseButton1.TabIndex = 0;
            this.myCloseButton1.Click += new System.EventHandler(this.myCloseButton_Click);
            // 
            // HiddenTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 280);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "HiddenTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HiddenTest";
            this.Load += new System.EventHandler(this.HiddenTest_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private myCloseButton myCloseButton1;
        private myMinimizeButton myMinimizeButton1;
        private System.Windows.Forms.Button btn_Config;
        private System.Windows.Forms.Label label_Label2;
        private System.Windows.Forms.Label label_Unit;
        private System.Windows.Forms.Label label_ReadResult;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label label_Label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
    }
}