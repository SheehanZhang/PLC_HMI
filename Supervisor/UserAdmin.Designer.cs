namespace Supervisor
{
    partial class UserAdmin
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3_Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4_Permission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.btn_EditUser = new System.Windows.Forms.Button();
            this.btn_DeleteUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myMinimizeButton1 = new Supervisor.myMinimizeButton();
            this.myCloseButton1 = new Supervisor.myCloseButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col0,
            this.col1_Id,
            this.col2_UserName,
            this.col3_Password,
            this.col4_Permission});
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(12, 122);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(992, 398);
            this.dataGridView1.TabIndex = 0;
            // 
            // col0
            // 
            this.col0.HeaderText = "id";
            this.col0.MinimumWidth = 8;
            this.col0.Name = "col0";
            this.col0.ReadOnly = true;
            this.col0.Visible = false;
            // 
            // col1_Id
            // 
            this.col1_Id.HeaderText = "序号 No.";
            this.col1_Id.MinimumWidth = 8;
            this.col1_Id.Name = "col1_Id";
            this.col1_Id.ReadOnly = true;
            // 
            // col2_UserName
            // 
            this.col2_UserName.HeaderText = "用户名 Username";
            this.col2_UserName.MinimumWidth = 8;
            this.col2_UserName.Name = "col2_UserName";
            this.col2_UserName.ReadOnly = true;
            // 
            // col3_Password
            // 
            this.col3_Password.HeaderText = "密码 Password";
            this.col3_Password.MinimumWidth = 8;
            this.col3_Password.Name = "col3_Password";
            this.col3_Password.ReadOnly = true;
            // 
            // col4_Permission
            // 
            this.col4_Permission.HeaderText = "权限 Permission";
            this.col4_Permission.MinimumWidth = 8;
            this.col4_Permission.Name = "col4_Permission";
            this.col4_Permission.ReadOnly = true;
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddUser.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.btn_AddUser.Location = new System.Drawing.Point(12, 36);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(154, 80);
            this.btn_AddUser.TabIndex = 1;
            this.btn_AddUser.Text = "新增用户\r\nAdd User";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // btn_EditUser
            // 
            this.btn_EditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditUser.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.btn_EditUser.Location = new System.Drawing.Point(176, 36);
            this.btn_EditUser.Name = "btn_EditUser";
            this.btn_EditUser.Size = new System.Drawing.Size(154, 80);
            this.btn_EditUser.TabIndex = 2;
            this.btn_EditUser.Text = "修改用户\r\nEdit User";
            this.btn_EditUser.UseVisualStyleBackColor = true;
            this.btn_EditUser.Click += new System.EventHandler(this.btn_EditUser_Click);
            // 
            // btn_DeleteUser
            // 
            this.btn_DeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteUser.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.btn_DeleteUser.Location = new System.Drawing.Point(340, 36);
            this.btn_DeleteUser.Name = "btn_DeleteUser";
            this.btn_DeleteUser.Size = new System.Drawing.Size(154, 80);
            this.btn_DeleteUser.TabIndex = 3;
            this.btn_DeleteUser.Text = "删除用户\r\nDelete User";
            this.btn_DeleteUser.UseVisualStyleBackColor = true;
            this.btn_DeleteUser.Click += new System.EventHandler(this.btn_DeleteUser_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btn_AddUser);
            this.panel1.Controls.Add(this.btn_DeleteUser);
            this.panel1.Controls.Add(this.btn_EditUser);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 536);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.myMinimizeButton1);
            this.panel2.Controls.Add(this.myCloseButton1);
            this.panel2.Location = new System.Drawing.Point(-2, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 30);
            this.panel2.TabIndex = 4;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            // 
            // myMinimizeButton1
            // 
            this.myMinimizeButton1.BackColor = System.Drawing.Color.LightGray;
            this.myMinimizeButton1.Location = new System.Drawing.Point(922, 0);
            this.myMinimizeButton1.Name = "myMinimizeButton1";
            this.myMinimizeButton1.Size = new System.Drawing.Size(50, 30);
            this.myMinimizeButton1.TabIndex = 1;
            this.myMinimizeButton1.Click += new System.EventHandler(this.myMinimizeButton_Click);
            // 
            // myCloseButton1
            // 
            this.myCloseButton1.BackColor = System.Drawing.Color.LightGray;
            this.myCloseButton1.Location = new System.Drawing.Point(974, 0);
            this.myCloseButton1.Name = "myCloseButton1";
            this.myCloseButton1.Size = new System.Drawing.Size(50, 30);
            this.myCloseButton1.TabIndex = 0;
            this.myCloseButton1.Click += new System.EventHandler(this.myCloseButton_Click);
            // 
            // UserAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1028, 538);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.Button btn_EditUser;
        private System.Windows.Forms.Button btn_DeleteUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private myMinimizeButton myMinimizeButton1;
        private myCloseButton myCloseButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col0;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2_UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3_Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4_Permission;
    }
}