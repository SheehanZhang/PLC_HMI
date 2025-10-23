using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class UserAdmin : Form
    {
        public UserAdmin()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            // 查询 User 表中的 id, name, password, permission 字段, 0是超级管理员，1是管理员，2是操作员
            string sql = "SELECT id, name, password, permission FROM [User]";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (GlobalUser.Permission != 0)//当前用户不是超级管理员
                {
                    int seq = 1; // 从1开始的连续序号
                    dataGridView1.Rows.Clear();  // 清空现有行（如果使用非绑定方式）
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        // 解析 permission 字段，若为 0 则不显示
                        int permission = 0;
                        int.TryParse(row["permission"].ToString(), out permission);
                        if (permission == 0)
                            continue;
                        // 根据 permission 值显示文本
                        string permText = permission == 1 ? "管理员 Admin" : (permission == 2 ? "操作员 Operator" : "未知");
                        // 添加行：col0 显示 id，col1 显示 seq，col2 显示 name，col3 显示 password，col4 显示权限文字
                        dataGridView1.Rows.Add(row["id"].ToString(), seq.ToString(), row["name"].ToString(), row["password"].ToString(), permText);
                        seq++;
                    }
                } 
                
                else if (GlobalUser.Permission == 0)
                {
                    int seq = 1; // 从1开始的连续序号
                    dataGridView1.Rows.Clear();  // 清空现有行（如果使用非绑定方式）
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        // 解析 permission 字段，若为 0 则不显示
                        int permission = 0;
                        int.TryParse(row["permission"].ToString(), out permission);
                        
                        // 根据 permission 值显示文本
                        string permText = permission == 1 ? "管理员 Admin" : (permission == 2 ? "操作员 Operator" : "超级管理员");
                        // 添加行：col0 显示 id，col1 显示 seq，col2 显示 name，col3 显示 password，col4 显示权限文字
                        dataGridView1.Rows.Add(row["id"].ToString(), seq.ToString(), row["name"].ToString(), row["password"].ToString(), permText);
                        seq++;
                    }
                }

                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft YaHei UI", 9);
                dataGridView1.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 9);


            }
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            // nextSeq 只用来显示在 txt_UserNo，数据库ID 是自增的，不用传
            int nextSeq = dataGridView1.Rows.Count + 1;

            // 传参：isEditMode = false, dbUserId=0（无意义），seqNo=nextSeq
            //       userName="", password="", permission=1(默认)
            UserAdminItem addForm = new UserAdminItem(
                isEditMode: false,
                dbUserId: 0,
                seqNo: nextSeq,
                userName: string.Empty,
                password: string.Empty,
                permission: 1  // 可以默认设成1，也就是“管理员”
            );

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserData();
            }
        }


        private void btn_EditUser_Click(object sender, EventArgs e)
        {
            // 1) 先确定是否选中了一行
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MyMessageBox.Show("请先选中一行用户再点击修改", "Please choose one record", MyMessageBoxType.Info);
                return;
            }

            // 2) 获取选中行
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // 3) 读取列值（注意列名对应）
            //    col0: 真实数据库ID, col1_Id: 序号, col2_UserName: 用户名, col3_Password: 密码, col4_Permission: 权限(管理员/操作员等)
            int dbUserId = int.Parse(selectedRow.Cells["col0"].Value.ToString());
            int seqNo = int.Parse(selectedRow.Cells["col1_Id"].Value.ToString());
            string name = selectedRow.Cells["col2_UserName"].Value.ToString();
            string pwd = selectedRow.Cells["col3_Password"].Value.ToString();
            string permText = selectedRow.Cells["col4_Permission"].Value.ToString();

            // 4) 把权限的文字映射成数字1/2
            int permValue = 0;

            if (permText == "管理员 Admin") permValue = 1;
            else if (permText == "操作员 Operator") permValue = 2;
            else permValue = 0; // 理论上不会出现0，因为之前你过滤了permission=0的不显示

            // 5) 使用“编辑模式”构造函数，弹框让用户修改
            UserAdminItem editForm = new UserAdminItem(
                isEditMode: true,       // 告诉对话框是编辑模式
                dbUserId: dbUserId,     // 数据库真实ID
                seqNo: seqNo,           // 自然序号，只用来显示
                userName: name,
                password: pwd,
                permission: permValue
            );

            // 6) ShowDialog() 如果返回OK，表示更新成功，需要刷新表格
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserData();
            }
        }


        private void btn_DeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MyMessageBox.Show("请先选中一行用户再点击删除", "Please choose one record", MyMessageBoxType.Info);
                
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // col0 是数据库真实ID
            int dbUserId = int.Parse(selectedRow.Cells["col0"].Value.ToString());
            string userName = selectedRow.Cells["col2_UserName"].Value.ToString();

            // 如果要删的就是当前用户本身，则禁止
            if (dbUserId == GlobalUser.UserId)
            {
                MyMessageBox.Show("无法删除当前登录的用户", "Cannot delete the currently logged-in User", MyMessageBoxType.Info);

                
                return;
            }

            // 二次确认
            

            DialogResult dr = MyMessageBox.Show($"确定要删除用户 “{userName}” 吗", $"Confirm delete user {userName}", MyMessageBoxType.Confirm);

            if (dr == DialogResult.OK)
            {
                try
                {
                    string sql = "DELETE FROM [User] WHERE id = @id";
                    SQLiteHelper.ExecuteNonQuery(sql,
                        new SQLiteParameter("@id", dbUserId));
                    MyMessageBox.Show("用户删除成功", "Delete Successful", MyMessageBoxType.Info);

                    
                    LoadUserData(); // 刷新DataGridView
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("删除失败，错误信息：" + ex.Message);
                }
            }
        }


        private void myCloseButton_Click(object sender, EventArgs e)
        {
            //LogHelper.WriteLog(GlobalUser.UserName, "退出系统", $"用户{GlobalUser.UserName}退出系统");
            this.Close();
        }

        private void myMinimizeButton_Click(object sender, EventArgs e)
        {

            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }

        private Point mPoint;

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {


            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

    }
}
