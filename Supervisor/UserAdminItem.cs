using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class UserAdminItem : Form
    {
        private bool _isEditMode = false;   // 是否为编辑模式
        private int _dbUserId = 0;          // 数据库真实 ID
        private int _seqNo = 0;            // 显示在 txt_UserNo 的自然序号

        /// <summary>
        /// 既可用于新增，也可用于编辑。
        /// isEditMode = false 时：仅 seqNo 有效，dbUserId无意义；
        /// isEditMode = true  时：dbUserId、seqNo、userName、password、permission 都用于回填。
        /// </summary>
        public UserAdminItem(
            bool isEditMode,
            int dbUserId,
            int seqNo,
            string userName,
            string password,
            int permission)
        {
            InitializeComponent();

            _isEditMode = isEditMode;
            _dbUserId = dbUserId;    // 数据库里真实的ID
            _seqNo = seqNo;          // 自然序号(仅用来显示在txt_UserNo)

            // 初始化权限下拉框（简单添加 1 和 2 两种可选项）
            if (GlobalUser.Permission != 0)
            {
                cmb_Permission.Items.Add("操作员 Operator");  // 管理员
                cmb_Permission.Items.Add("管理员 Admin");  // 操作员
            }
            else if (GlobalUser.Permission == 0)
            {
                cmb_Permission.Items.Add("超级管理员");  // 操作员
                cmb_Permission.Items.Add("操作员 Operator");  // 操作员
                cmb_Permission.Items.Add("管理员 Admin");  // 管理员
                
            }

            // 如果是“编辑模式”，回填传入的参数到控件
            if (_isEditMode)
            {
                if (GlobalUser.Permission == 0)
                {
                    txt_UserNo.Text = seqNo.ToString(); // 显示该用户行的自然序号
                    txt_UserName.Text = userName;
                    txt_UserPassword.Text = password;
                    if(permission == 0)
                    {
                        cmb_Permission.SelectedIndex = 0; // 

                    }else if (permission == 1)
                    {
                        cmb_Permission.SelectedIndex = 2; // 

                    }else if (permission == 2)
                    {
                        cmb_Permission.SelectedIndex = 1; // 

                    }

                }
                else{
                    txt_UserNo.Text = seqNo.ToString(); // 显示该用户行的自然序号
                    txt_UserName.Text = userName;
                    txt_UserPassword.Text = password;

                    // 把数据库中的 permission 映射到下拉框选项
                    if (permission == 1)
                    {
                        cmb_Permission.SelectedIndex = 1; // 选中“1”
                    }
                    else if (permission == 2)
                    {
                        cmb_Permission.SelectedIndex = 0; // 选中“2”
                    }
                 
                }
            }
            else
            {
                // “新增模式”
                txt_UserNo.Text = seqNo.ToString();
                // 可以给一些默认值，例如默认选中第一项
                cmb_Permission.SelectedIndex = 0;
            }
        }

        private void btn_SaveAndExit_Click(object sender, EventArgs e)
        {
            // 1) 简单校验输入
            if (string.IsNullOrWhiteSpace(txt_UserName.Text))
            {
                MyMessageBox.Show("用户名不能为空", "Username cannot be empty", MyMessageBoxType.Info);
                
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_UserPassword.Text))
            {
                MyMessageBox.Show("密码不能为空", "Password cannot be empty", MyMessageBoxType.Info);

                return;
            }
            int perm = -1;

            if (GlobalUser.Permission != 0)
            {
                if(cmb_Permission.SelectedItem.ToString() == "管理员 Admin")
                {
                    perm = 1;
                }
                else if (cmb_Permission.SelectedItem.ToString() == "操作员 Operator")
                {
                    perm = 2;
                }
               
            }else if (GlobalUser.Permission == 0)
            {
                if(cmb_Permission.SelectedItem.ToString() == "管理员 Admin")
                {
                    perm = 1;
                }
                else if (cmb_Permission.SelectedItem.ToString() == "操作员 Operator")
                {
                    perm = 2;
                }
                else if (cmb_Permission.SelectedItem.ToString() == "超级管理员")
                {
                    perm = 0;
                }
               
            }

            try
            {
                if (_isEditMode)
                {
                    // 编辑模式：执行 UPDATE
                    string sql = @"UPDATE [User]
                                   SET name = @name,
                                       password = @password,
                                       permission = @permission
                                   WHERE id = @id";

                    SQLiteHelper.ExecuteNonQuery(sql,
                        new System.Data.SQLite.SQLiteParameter("@name", txt_UserName.Text),
                        new System.Data.SQLite.SQLiteParameter("@password", txt_UserPassword.Text),
                        new System.Data.SQLite.SQLiteParameter("@permission", perm),
                        new System.Data.SQLite.SQLiteParameter("@id", _dbUserId)
                    );
                    MyMessageBox.Show("用户信息更新成功", "Update Successful", MyMessageBoxType.Info);

                }
                else
                {
                    // 新增模式：执行 INSERT
                    string sql = @"INSERT INTO [User](name, password, permission)
                                   VALUES(@name, @password, @permission)";

                    SQLiteHelper.ExecuteNonQuery(sql,
                        new System.Data.SQLite.SQLiteParameter("@name", txt_UserName.Text),
                        new System.Data.SQLite.SQLiteParameter("@password", txt_UserPassword.Text),
                        new System.Data.SQLite.SQLiteParameter("@permission", perm)
                    );
                    MyMessageBox.Show("新增用户成功", "Add Successful", MyMessageBoxType.Info);
                }

                // 2) 都成功后，关闭对话框并设置DialogResult = OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("保存失败，错误信息：" + ex.Message);
            }
        }

        private void btn_QuitAndExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private Point mPoint = new Point();
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


        private void myMinimizeButton_Click(object sender, EventArgs e)
        {

            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }


    }
}
