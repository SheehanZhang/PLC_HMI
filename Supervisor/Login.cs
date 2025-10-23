using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using HslCommunication.Profinet.Siemens;

namespace Supervisor
{
    public partial class Login : Form
    {
        /// <summary>
        /// 移动窗口
        /// </summary>
        private Point mPoint;

        private void myCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void myMinimizeButton_Click(object sender, EventArgs e)
        {

            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }


        public Login()
        {
            InitializeComponent();
            //初始化用户名下拉框
            InitUsernameParam();

            

        }

        private void Login_Load(object sender, EventArgs e)
        {
            


            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            string sql = "select companyName, applicationName From Config LIMIT 1";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                label_CompanyName.Text = ds.Tables[0].Rows[0]["companyName"].ToString();
                label_ApplicationName.Text = ds.Tables[0].Rows[0]["applicationName"].ToString();
            }
            else
            {
                label_CompanyName.Text = "";
                label_CompanyName.Text = "";
            }
            label_CompanyName.Left = (this.panel2.Width - label_CompanyName.Width) / 2;
            label_ApplicationName.Left = (this.panel2.Width - label_ApplicationName.Width) / 2;
            int totalHeight = label_CompanyName.Height + label_ApplicationName.Height;
            int startY = (this.panel2.Height - totalHeight) / 2 - 105;
            label_CompanyName.Top = startY-10;
            label_ApplicationName.Top = startY + label_CompanyName.Height;

        }

        /// <summary>
        /// “登录”按钮点击事件
        /// </summary>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = cmb_Username.Text;
            string password = txt_Password.Text;

            if (string.IsNullOrEmpty(username))
            {
                MyMessageBox.Show("请输入账户", "Please Enter Username", MyMessageBoxType.Info);
                
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MyMessageBox.Show("请输入密码", "Please Enter Password", MyMessageBoxType.Info);
                return;
            }

            // ValidateUser返回: success(是否验证通过), userId(数据库ID), permission(权限)
            var (success, userId, permission) = ValidateUser(username, password);
            if (!success)
            {
                MyMessageBox.Show("账户或密码错误", "Incorrect username or Password", MyMessageBoxType.Info);

         
                return;
            }
            else
            {
                MyMessageBox.Show("登录成功", "Login Successful", MyMessageBoxType.Info);

                

                // 将用户信息保存到全局静态类
                GlobalUser.UserId = userId;
                GlobalUser.UserName = username;
                GlobalUser.Permission = permission;
                //LogHelper.WriteLog(GlobalUser.UserName, " ");

                // 打开主界面
                Main main = new Main();
                main.Show();
                this.Hide();
            }
        }

        /// <summary>
        /// 初始化用户名下拉框
        /// </summary>
        private void InitUsernameParam()
        {
            // 只加载 permission != 0 的用户
            string sql = "SELECT name FROM [User] WHERE permission <> 0";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            cmb_Username.Items.Clear();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cmb_Username.Items.Add(row["name"].ToString());
                }
                // 可根据需要设定默认选中索引
                cmb_Username.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 校验用户名密码
        /// 返回 (bool成功标记, int用户ID, int用户权限)
        /// </summary>
        private (bool success, int userId, int permission) ValidateUser(string username, string password)
        {
            // 一次性获取 用户id, permission
            // 在SQLite里，User 是关键字范围，最好用 [User] 包裹
            string sql = @"
                SELECT id, permission
                FROM [User]
                WHERE name = @username AND password = @password
            ";

            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@username", username),
                new SQLiteParameter("@password", password)
            };

            // 用 DataSet 或者 ExecuteReader 皆可，这里示例用 DataSet
            DataSet ds = SQLiteHelper.ExecuteQuery(sql, parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int userId = Convert.ToInt32(row["id"]);
                int perm = Convert.ToInt32(row["permission"]);
                return (true, userId, perm);
            }
            else
            {
                // 没查到
                return (false, -1, -1);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            

            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        



    }
}
