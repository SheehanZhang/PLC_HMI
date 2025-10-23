using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Profinet.Melsec;
using HslCommunication.Profinet.Siemens;
using Supervisor;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Supervisor
{
    public partial class Main : Form
    {
        private Point mPoint;
        private Timer timer;
        private Timer timerPLCStatus;
        
        private Timer pressTimer;
        private Timer pressTimer2;
        
        
        private bool isPressed = false;
        private bool isPressed2 = false;
        private const int pressDuration = 3000;









        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {


            PLCConnect.AutoConnectPLC();


            TimerInit();
            UserPermissionInit();
            LoadConfig();
            PLCConnect.AutoConnectPLC();          
            LoadRecipeData();
            LoadLastRecipe();

            string countSql = "SELECT COUNT(*) FROM Log";
            object result = SQLiteHelper.ExecuteScalar(countSql);

            if (result != null && Convert.ToInt32(result) > 1000000)
            {
                // 如果日志数量超过10000条，则清空日志
                string deleteSql = "DELETE FROM Log";
                int deleteResult = SQLiteHelper.ExecuteNonQuery(deleteSql);

            }






        }



        private void UserPermissionInit()
        {
            label_User.Text = $"{GlobalUser.UserName} ";
            if (GlobalUser.Permission == 0)
            {
                btn_Log.Visible = true;
                txt_ApplicationName.ReadOnly = false;
                txt_CompanyName.ReadOnly = false;
                txt_ApplicationName.Visible = true;
                txt_CompanyName.Visible = true;
                txt_button.Visible = true;
                txt_top.Visible = true;
                
                btn_SaveConfig.Enabled = true;
                btn_SaveTip.Enabled = true;
                label_CompanyName.Visible = false;
                label_CompanyName_CN.Visible = false;
                label_ApplicationName.Visible = false;

            }
            else if (GlobalUser.Permission == 1)
            {
                btn_Log.Visible = true;
                txt_ApplicationName.Visible = false;
                txt_CompanyName.Visible = false;
                txt_ApplicationName.ReadOnly = true;
                txt_CompanyName.ReadOnly = true;
                txt_CompanyName_CN.Visible=false;
                txt_button.Visible = false;
                txt_top.Visible = false;
                btn_SaveConfig.Enabled = false;
                btn_SaveConfig.Visible = false;
                btn_SaveTip.Visible = false;
                btn_EditRecipeAddressAndLabel.Visible = false;
                btn_ConfigPLCConnect.Visible = false;
                btn_UserAdmin.Visible = true;
            }
            else
            {
                btn_Log.Visible = true;
                btn_Log.Enabled = true;
                btn_SaveTip.Visible = false;

                txt_ApplicationName.Visible = false;
                txt_CompanyName.Visible = false;
                txt_CompanyName_CN.Visible = false;
                txt_ApplicationName.ReadOnly = true;
                txt_CompanyName.ReadOnly = true;
                txt_button.Visible = false;
                txt_top.Visible = false;
                btn_SaveConfig.Enabled = false;
                btn_SaveConfig.Visible = false;
                btn_EditRecipeAddressAndLabel.Visible = false;
                btn_ConfigPLCConnect.Visible = false;
                btn_UserAdmin.Enabled = false;
            }
        }

        private void TimerInit()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            timerPLCStatus = new Timer();
            timerPLCStatus.Interval = 10000;
            timerPLCStatus.Tick += TimerPLCStatus_Tick;
            TimerPLCStatus_Tick(this, EventArgs.Empty);
            timerPLCStatus.Start();

            pressTimer = new Timer();
            pressTimer.Interval = pressDuration;
            pressTimer.Tick += PressTimer_Tick;

            pressTimer2 = new Timer();
            pressTimer2.Interval = pressDuration;
            pressTimer2.Tick += pressTimer2_Tick;

            panel2.MouseDown += Pressing_MouseDown;
            panel2.MouseUp += Pressing_MouseUp;
            panel2.MouseLeave += Pressing_MouseLeave;

            label_PLCConnectStatus.MouseDown += Pressing_MouseDown;
            label_PLCConnectStatus.MouseUp += Pressing_MouseUp;
            label_PLCConnectStatus.MouseLeave += Pressing_MouseLeave;

            panel1.MouseDown += Pressing2_MouseDown;
            panel1.MouseUp += Pressing2_MouseUp;
            panel1.MouseLeave += Pressing2_MouseLeave;

            label_Date.MouseDown += Pressing2_MouseDown;
            label_Date.MouseUp += Pressing2_MouseUp;
            label_Date.MouseLeave += Pressing2_MouseLeave;


            label_Time.MouseDown += Pressing2_MouseDown;
            label_Time.MouseUp += Pressing2_MouseUp;
            label_Time.MouseLeave += Pressing2_MouseLeave;


         

        }

      

        private void Pressing_MouseLeave(object sender, EventArgs e)
        {
            isPressed = false;
            pressTimer.Stop();
        }

        private void Pressing_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
            pressTimer.Stop();
        }

        private void Pressing_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            pressTimer.Start();
        }

        private void PressTimer_Tick(object sender, EventArgs e)
        {
            if (isPressed)
            {
                pressTimer.Stop();
                PLCConnect pLCConnect = new PLCConnect();
                pLCConnect.Owner = this;
                pLCConnect.ShowDialog();
            }
        }

        

        private void Pressing2_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed2 = true;
            pressTimer2.Start();
        }

        private void Pressing2_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed2 = false;
            pressTimer2.Stop();
        }

        private void Pressing2_MouseLeave(object sender, EventArgs e)
        {
            isPressed2 = false;
            pressTimer2.Stop();
        }

        private void pressTimer2_Tick(object sender, EventArgs e)
        {
            if (isPressed2)
            {
                pressTimer2.Stop();
                HiddenTest frm = new HiddenTest();
                frm.Owner = this;
                frm.ShowDialog();
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // 更新当前日期和时间
            label_Date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label_Time.Text = DateTime.Now.ToString("HH:mm:ss");

            label_Date.Left = (panel1.ClientSize.Width - label_Date.Width) / 2;
            label_Time.Left = (panel1.ClientSize.Width - label_Time.Width) / 2;

           
            int totalHeight = label_Date.Height + label_Time.Height;
            int startY = (panel1.ClientSize.Height - totalHeight) / 2;

            // 设置两个Label的垂直位置
            label_Date.Top = startY - 8; // 可调整微调间距
            label_Time.Top = startY + label_CompanyName.Height + 5;


        }

        private void TimerPLCStatus_Tick(object sender, EventArgs e)
        {
            //PLCConnect.AutoConnectPLC();

            var testConnect = PLCConnect.ReadBool("M0");

            if (testConnect.IsSuccess)
            {
                label_PLCConnectStatus.Text = "Connection Status: PLC Connected";
                label_PLCConnectStatus.ForeColor = Color.Black;
                panel2.BackColor = Color.LightGreen;
                //label_PLCConnectStatus.BackColor = Color.Green;
            }
            else
            {
                label_PLCConnectStatus.Text = "Connection Status: PLC Not Connected";
                label_PLCConnectStatus.ForeColor = Color.Black;
                //label_PLCConnectStatus.BackColor = Color.Green;
                panel2.BackColor = Color.LightCoral;

                PLCConnect.AutoConnectPLC();
            }
        }

      

        





        private void LoadConfig()
        {
            

            if (GlobalUser.Permission == 0)
            {
                string sql = "select companyName, applicationName, companyName_CN, top, button From Config LIMIT 1";
                DataSet ds = SQLiteHelper.ExecuteQuery(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_CompanyName_CN.Text = ds.Tables[0].Rows[0]["companyName_CN"].ToString();
                    txt_CompanyName.Text = ds.Tables[0].Rows[0]["companyName"].ToString();
                    txt_top.Text = ds.Tables[0].Rows[0]["top"].ToString();
                    txt_button.Text = ds.Tables[0].Rows[0]["button"].ToString();
                    txt_ApplicationName.Text = ds.Tables[0].Rows[0]["applicationName"].ToString();
                }
                else
                {
                    txt_CompanyName_CN.Text = "";
                    txt_CompanyName.Text = "";
                    txt_ApplicationName.Text = "";
                    txt_top.Text = "";
                    txt_button.Text = "";
                }
            }
            else
            {
                string sql = "select companyName, applicationName,companyName_CN, top, button From Config LIMIT 1";
                DataSet ds = SQLiteHelper.ExecuteQuery(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    label_CompanyName_CN.Text = ds.Tables[0].Rows[0]["companyName_CN"].ToString();
                    label_CompanyName.Text = ds.Tables[0].Rows[0]["companyName"].ToString();
                    label_ApplicationName.Text = ds.Tables[0].Rows[0]["applicationName"].ToString();
                    label_top.Text = ds.Tables[0].Rows[0]["top"].ToString();
                    label_button.Text = ds.Tables[0].Rows[0]["button"].ToString();
                }
                else
                {
                    label_CompanyName_CN.Text = "";
                    label_CompanyName.Text = "";
                    label_CompanyName.Text = "";
                    label_top.Text = "";
                    label_button.Text = "";
                }
                // 计算两个Label整体的宽度，使它们在panel3中水平居中
                label_CompanyName_CN.Left = (panel3.ClientSize.Width - label_CompanyName_CN.Width) / 2;
                label_CompanyName.Left = (panel3.ClientSize.Width - label_CompanyName.Width) / 2;
                label_ApplicationName.Left = (panel3.ClientSize.Width - label_ApplicationName.Width) / 2;

                // 计算两个Label整体的高度，使它们在panel3中垂直居中
                int totalHeight = label_CompanyName.Height + label_ApplicationName.Height;
                int startY = (panel3.ClientSize.Height - totalHeight) / 2;


                
                
            }


        }


        // 从数据库中加载配方标签，不涉及和PLC通信
        private void LoadRecipeData()
        {
            DataSet dsNum = SQLiteHelper.ExecuteQuery("SELECT RecipeDataNumber FROM Config LIMIT 1");
            int recipeDataNumber = 4; // 默认
            if (dsNum != null && dsNum.Tables.Count > 0 && dsNum.Tables[0].Rows.Count > 0)
            {
                recipeDataNumber = Convert.ToInt32(dsNum.Tables[0].Rows[0]["RecipeDataNumber"]);
                if (recipeDataNumber < 3) recipeDataNumber = 3;
                if (recipeDataNumber > 8) recipeDataNumber = 8;
            }
            // 设置默认单元格样式（数据单元格）
            dataGridView1.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 13F);
            //dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;


            DataTable dt = new DataTable();
            dt.Columns.Add("LabelLeft", typeof(string));
            dt.Columns.Add("EmptyColumn", typeof(string));
            dt.Columns.Add("Unit", typeof(string));


            string sql = $"SELECT label, unit FROM RecipeData ORDER BY id LIMIT {recipeDataNumber}";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);

            int actualRowCount = 0;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable data = ds.Tables[0];
                // 遍历查询到的记录，将 label 填充到 DataTable 中
                actualRowCount = data.Rows.Count;
                foreach (DataRow row in data.Rows)
                {
                    string label = row["label"].ToString();
                    string unit = row["unit"].ToString();
                    dt.Rows.Add(label, string.Empty, unit);
                }
            }
            else
            {
                //MessageBox.Show("数据库中没有足够的记录！");
            }

            

            // 将 DataTable 绑定到 DataGridView
            

            dataGridView1.DataSource = dt;

            

            // 设置列宽
            dataGridView1.Columns["LabelLeft"].Width = 948-280;
            dataGridView1.Columns["EmptyColumn"].Width = 140;
            dataGridView1.Columns["Unit"].Width = 140;

            int totalHeight = dataGridView1.ClientSize.Height;
            if (dataGridView1.ColumnHeadersVisible)
            {
                totalHeight -= dataGridView1.ColumnHeadersHeight;
            }

            // 平均分给每一行
            int rowHeight = totalHeight / actualRowCount;
            int count = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                if (count < actualRowCount)
                {
                    row.Height = rowHeight;
                    count++;
                }else
                {
                    row.Height = rowHeight - 1;
                    
                }
                
            }
            // 将 DataTable 绑定到 DataGridView后，设置所有列为只读
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.ReadOnly = true;
            }

            dataGridView1.ClearSelection();
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        
        // 加最后一次退出时的配方
        private void LoadLastRecipe()
        {
            string sqlConfig = "SELECT LastLoadRecipeId FROM Config LIMIT 1";
            DataSet dsConfig = SQLiteHelper.ExecuteQuery(sqlConfig);
            if (dsConfig == null || dsConfig.Tables.Count == 0 || dsConfig.Tables[0].Rows.Count == 0)
            {
                return;
            }
            string lastRecipeId = dsConfig.Tables[0].Rows[0]["LastLoadRecipeId"].ToString();
            if (string.IsNullOrEmpty(lastRecipeId))
            {
                return;
            }

            // 根据真实 id 查询 Recipe 表
            string sqlRecipe = "SELECT * FROM Recipe WHERE id = @id LIMIT 1";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@id", lastRecipeId)
            };
            DataSet dsRecipe = SQLiteHelper.ExecuteQuery(sqlRecipe, parameters);
            if (dsRecipe == null || dsRecipe.Tables.Count == 0 || dsRecipe.Tables[0].Rows.Count == 0)
            {
                return;
            }
            DataRow row = dsRecipe.Tables[0].Rows[0];

            SelectedRecipe.RecipeId = row["id"].ToString();
            SelectedRecipe.RecipeName = row["recipeName"].ToString();
            SelectedRecipe.Value1 = row["value1"].ToString();
            SelectedRecipe.Value2 = row["value2"].ToString();
            SelectedRecipe.Value3 = row["value3"].ToString();
            SelectedRecipe.Value4 = row["value4"].ToString();
            SelectedRecipe.Value5 = row["value5"].ToString();
            SelectedRecipe.Value6 = row["value6"].ToString();
            SelectedRecipe.Value7 = row["value7"].ToString();
            SelectedRecipe.Value8 = row["value8"].ToString();


            // 修改这里：计算显示的连续序号（recipeNo）  
            // 查询所有 Recipe 的 id 按 id 升序排列，然后找到当前记录的位置（从 1 开始）
            string sqlAll = "SELECT id FROM Recipe ORDER BY id";
            DataSet dsAll = SQLiteHelper.ExecuteQuery(sqlAll);
            int seqNo = 0;
            foreach (DataRow r in dsAll.Tables[0].Rows)
            {
                seqNo++;
                if (r["id"].ToString() == SelectedRecipe.RecipeId)
                {
                    break;
                }
            }
            SelectedRecipe.RecipeNo = seqNo.ToString();

            int recipeDataNumber = 3; // 默认
            DataSet dsNum = SQLiteHelper.ExecuteQuery("SELECT RecipeDataNumber FROM Config LIMIT 1");
            if (dsNum != null && dsNum.Tables.Count > 0 && dsNum.Tables[0].Rows.Count > 0)
            {
                recipeDataNumber = Convert.ToInt32(dsNum.Tables[0].Rows[0]["RecipeDataNumber"]);
                if (recipeDataNumber < 3) recipeDataNumber = 3;
                if (recipeDataNumber > 8) recipeDataNumber = 8;
            }

            DataTable dt = dataGridView1.DataSource as DataTable;
            
            if (dt == null)
            {
                //MessageBox.Show("DataGridView 未绑定到 DataTable，无法填充配方数据！");
                return;
            }

            string[] recipeValues = new string[8]
            {
                SelectedRecipe.Value1,
                SelectedRecipe.Value2,
                SelectedRecipe.Value3,
                SelectedRecipe.Value4,
                SelectedRecipe.Value5,
                SelectedRecipe.Value6,
                SelectedRecipe.Value7,
                SelectedRecipe.Value8
            };
            for (int i = 0; i < recipeDataNumber; i++)
            {
                
                dt.Rows[i]["EmptyColumn"] = recipeValues[i];
            }

            label_SelectedRecipeName.Text = SelectedRecipe.RecipeName;
            label_SelectedRecipeNo.Text = SelectedRecipe.RecipeNo;
            label_SelectedRecipeNo.Left = (panel8.ClientSize.Width - label_SelectedRecipeNo.Width) / 2;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.ReadOnly = (col.Name != "EmptyColumn");
            }
            dataGridView1.Refresh();

            LoadRecipe();
            LogHelper.WriteLog(GlobalUser.UserName, $"登录并加载配方({SelectedRecipe.RecipeName}) Login and load Recipe({SelectedRecipe.RecipeName})");
        }


     

        

        











        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog(GlobalUser.UserName, "退出登录 Exit");
            Login login = new Login();
            login.Show();

            this.Close();
        }

        private void btn_SaveTip_Click(object sender, EventArgs e)
        {
            string sql = "Update Config set top = @top, button = @button";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@top", txt_top.Text),
                new SQLiteParameter("@button", txt_button.Text)
            };
            int rowsAffected = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (rowsAffected > 0)
            {
                MyMessageBox.Show("保存提示信息成功", "Save Successful", MyMessageBoxType.Info);

            }
            else
            {
                //MessageBox.Show("保存失败，请重试！");
            }
        }


        private void btn_SaveConfig_Click(object sender, EventArgs e)
        {
            string sql = "Update Config set companyName = @companyName, applicationName = @applicationName, companyName_CN = @companyName_CN";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {  
                new SQLiteParameter("@companyName", txt_CompanyName.Text),
                new SQLiteParameter("@applicationName", txt_ApplicationName.Text),
                new SQLiteParameter("@companyName_CN", txt_CompanyName_CN.Text),
            };
            int rowsAffected = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (rowsAffected > 0)
            {
                MyMessageBox.Show("配置保存成功", "Save Successful", MyMessageBoxType.Info);
                
            }
            else
            {
                //MessageBox.Show("保存失败，请重试！");
            }
        }


        private void btn_EditRecipeAddressAndLabel_Click(object sender, EventArgs e)
        {
            EditRecipeAdressAndLabel frmEdit = new EditRecipeAdressAndLabel();
            frmEdit.Owner = this;
            frmEdit.ShowDialog();
            LoadRecipeData();


        }

        private void btn_ChooseRecipe_Click(object sender, EventArgs e)
        {
            Recipe recipeForm = new Recipe();
            recipeForm.Owner = this;
            //recipeForm.ShowDialog();
            if (recipeForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            int recipeDataNumber = 3; // 假设默认值
            DataSet dsNum = SQLiteHelper.ExecuteQuery("SELECT RecipeDataNumber FROM Config LIMIT 1");
            if (dsNum != null && dsNum.Tables.Count > 0 && dsNum.Tables[0].Rows.Count > 0)
            {
                recipeDataNumber = Convert.ToInt32(dsNum.Tables[0].Rows[0]["RecipeDataNumber"]);
                if (recipeDataNumber < 3) recipeDataNumber = 3;
                if (recipeDataNumber > 8) recipeDataNumber = 8;
            }

            DataTable dt = dataGridView1.DataSource as DataTable;

            string[] recipeValues = new string[8]
            {
                SelectedRecipe.Value1,
                SelectedRecipe.Value2,
                SelectedRecipe.Value3,
                SelectedRecipe.Value4,
                SelectedRecipe.Value5,
                SelectedRecipe.Value6,
                SelectedRecipe.Value7,
                SelectedRecipe.Value8
            };

            for (int i = 0; i < recipeDataNumber; i++)
            {
                dt.Rows[i]["EmptyColumn"] = recipeValues[i];
            }
            

            label_SelectedRecipeName.Text = SelectedRecipe.RecipeName;
            label_SelectedRecipeNo.Text = SelectedRecipe.RecipeNo;
            label_SelectedRecipeNo.Left = (panel8.ClientSize.Width - label_SelectedRecipeNo.Width) / 2;


            



            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name == "EmptyColumn")
                    col.ReadOnly = false;
                else
                    col.ReadOnly = true;
            }

            // 刷新 DataGridView 显示更新后的数据
            dataGridView1.Refresh();
            UpdateLastLoadRecipeId(SelectedRecipe.RecipeId);
            LoadRecipe();
            



        }
        private void UpdateLastLoadRecipeId(string recipeId)
        {
            // 假设 Config 表中只有一条记录，并且 LastLoadRecipeId 字段用来保存最后加载的 recipe 的 id
            string sql = "UPDATE Config SET LastLoadRecipeId = @lastLoadRecipeId";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
        new SQLiteParameter("@lastLoadRecipeId", recipeId)
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            // 可选：你可以根据 result 判断是否更新成功并作出提示
            if (result <= 0)
            {
                //MessageBox.Show("更新最后加载的 Recipe Id 失败！");
            }
        }

        private void btn_SaveRecipeChanges_Click(object sender, EventArgs e)
        {
            int recipeDataNumber = 3; // 假设默认值
            DataSet dsNum = SQLiteHelper.ExecuteQuery("SELECT RecipeDataNumber FROM Config LIMIT 1");
            if (dsNum != null && dsNum.Tables.Count > 0 && dsNum.Tables[0].Rows.Count > 0)
            {
                recipeDataNumber = Convert.ToInt32(dsNum.Tables[0].Rows[0]["RecipeDataNumber"]);
                if (recipeDataNumber < 3) recipeDataNumber = 3;
                if (recipeDataNumber > 8) recipeDataNumber = 8;
            }

            DataTable dt = dataGridView1.DataSource as DataTable;

            List<string> newValues = new List<string>();

            for (int i = 0; i < recipeDataNumber; i++)
            {
                if (i < dt.Rows.Count)
                {
                    newValues.Add(dt.Rows[i]["EmptyColumn"].ToString());
                }
                else
                {
                    newValues.Add("");
                }
            }
            for (int i = recipeDataNumber; i < 8; i++)
            {
                newValues.Add("");
            }

            string recipeId = SelectedRecipe.RecipeId;


            string updateSql = @"
                UPDATE Recipe
                SET value1 = @v1,
                    value2 = @v2,
                    value3 = @v3,
                    value4 = @v4,
                    value5 = @v5,
                    value6 = @v6,
                    value7 = @v7,
                    value8 = @v8
                WHERE id = @id
            ";



            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@v1", newValues[0]),
                new SQLiteParameter("@v2", newValues[1]),
                new SQLiteParameter("@v3", newValues[2]),
                new SQLiteParameter("@v4", newValues[3]),
                new SQLiteParameter("@v5", newValues[4]),
                new SQLiteParameter("@v6", newValues[5]),
                new SQLiteParameter("@v7", newValues[6]),
                new SQLiteParameter("@v8", newValues[7]),
                new SQLiteParameter("@id", recipeId)
            };

            int result = SQLiteHelper.ExecuteNonQuery(updateSql, parameters);
            if (result > 0)
            {
                MyMessageBox.Show("保存修改成功", "Save Successful", MyMessageBoxType.Info);
                
                LogHelper.WriteLog(GlobalUser.UserName,$"{SelectedRecipe.RecipeName}参数保存成功 {SelectedRecipe.RecipeName} parameter saved");
            }
            else
            {
                //MessageBox.Show("保存修改失败，请重试！");
            }


        }

        private void btn_ConfigPLCConnect_Click(object sender, EventArgs e)
        {
            PLCConnect pLCConnect = new PLCConnect();
            pLCConnect.Owner = this;
            pLCConnect.ShowDialog();
        }

        
        // 加载配方
        private void LoadRecipe()
        {
            

            try
            {
                int recipeDataNumber = 3; // 假设默认值
                DataSet dsNum = SQLiteHelper.ExecuteQuery("SELECT RecipeDataNumber FROM Config LIMIT 1");
                if (dsNum != null && dsNum.Tables.Count > 0 && dsNum.Tables[0].Rows.Count > 0)
                {
                    recipeDataNumber = Convert.ToInt32(dsNum.Tables[0].Rows[0]["RecipeDataNumber"]);
                    if (recipeDataNumber < 3) recipeDataNumber = 3;
                    if (recipeDataNumber > 8) recipeDataNumber = 8;
                }

                // 2. 从 RecipeData 表中读取 address 列数据，假设返回4行记录
                string sql = $"SELECT address FROM RecipeData ORDER BY id LIMIT {recipeDataNumber}";
                DataSet ds = SQLiteHelper.ExecuteQuery(sql);
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count < recipeDataNumber)
                {
                    //MessageBox.Show("未能获取到足够的PLC写入地址");
                    return;
                }

                List<string> recipeValues = new List<string>();
                if (recipeDataNumber >= 1) recipeValues.Add(SelectedRecipe.Value1);
                if (recipeDataNumber >= 2) recipeValues.Add(SelectedRecipe.Value2);
                if (recipeDataNumber >= 3) recipeValues.Add(SelectedRecipe.Value3);
                if (recipeDataNumber >= 4) recipeValues.Add(SelectedRecipe.Value4);
                if (recipeDataNumber >= 5) recipeValues.Add(SelectedRecipe.Value5);
                if (recipeDataNumber >= 6) recipeValues.Add(SelectedRecipe.Value6);
                if (recipeDataNumber >= 7) recipeValues.Add(SelectedRecipe.Value7);
                if (recipeDataNumber >= 8) recipeValues.Add(SelectedRecipe.Value8);

                

                bool allSuccess = true;
                DataTable addressTable = ds.Tables[0];
                for (int i = 0; i < recipeDataNumber; i++)
                {
                    string address = addressTable.Rows[i]["address"].ToString();
                    
                    if (!short.TryParse(recipeValues[i], out short val))
                    {
                        allSuccess = false;
                        break;
                    }
                    var writeResult = PLCConnect.Write(address, val);
                    if (!writeResult.IsSuccess)
                    {
                        allSuccess = false;
                        break;
                    }
                }

                // 4. 根据写入结果显示消息
                if (allSuccess)
                {
                    LogHelper.WriteLog(GlobalUser.UserName, $"加载配方({SelectedRecipe.RecipeName}) Load recipe({SelectedRecipe.RecipeName})");
                }
                else
                {
                    //MessageBox.Show("加载配方失败");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("发生异常：" + ex.Message);
            }
        }

        // 1) 在类中定义一个字典，用来存放 (行,列) -> 旧值
        private Dictionary<(int row, int col), object> oldValues = new Dictionary<(int row, int col), object>();

        // --------------------------------------------------------
        // 2) CellBeginEdit：开始编辑单元格时，保存旧值
        // --------------------------------------------------------
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // 如果不是我们允许编辑的列，可以不处理，或自行判断
            if (dataGridView1.Columns[e.ColumnIndex].Name != "EmptyColumn") return;

            // 当前单元格的旧值
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            oldValues[(e.RowIndex, e.ColumnIndex)] = cell.Value; // 记下来
        }

        // --------------------------------------------------------
        // 3) CellEndEdit：编辑完成后判断新值并写入PLC或还原
        // --------------------------------------------------------
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // 只处理我们关心的列，例如 "EmptyColumn"
            if (dataGridView1.Columns[e.ColumnIndex].Name != "EmptyColumn") return;

            // 拿到旧值（如果没记录过，就默认为 null）
            object oldVal = null;
            if (oldValues.ContainsKey((e.RowIndex, e.ColumnIndex)))
            {
                oldVal = oldValues[(e.RowIndex, e.ColumnIndex)];
            }

            // 取当前单元格的新值
            var newValObj = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string newValStr = (newValObj == null) ? string.Empty : newValObj.ToString().Trim();

            // 如果用户把内容删空了，就还原成旧值，并且不写PLC
            if (string.IsNullOrWhiteSpace(newValStr))
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldVal;
                return;
            }

            // 尝试转换为 short
            short newValue;
            if (!short.TryParse(newValStr, out newValue))
            {
                MyMessageBox.Show("请输入有效的数字", "Please enter valid number", MyMessageBoxType.Info);
                
                // 还原成旧值
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldVal;
                return;
            }

            // 如果 oldVal 不为 null，进行比较
            if (oldVal != null)
            {
                if (oldVal is string oldValStr)
                {
                    // 如果旧值是字符串，尝试转换为 short
                    if (short.TryParse(oldValStr, out short oldValShort) && oldValShort == newValue)
                    {
                        return; // 如果旧值和新值相同，不进行 PLC 写入
                    }
                }
                else if (oldVal is short oldValShort)
                {
                    // 如果旧值已经是 short 类型，直接比较
                    if (oldValShort == newValue)
                    {
                        return; // 如果旧值和新值相同，不进行 PLC 写入
                    }
                }
            }

            // 如果没有返回，说明值已改变，可以继续写 PLC


            // 如果走到这里，说明是合法数值 -> 直接写入PLC
            // --------------------------------------------------------------
            // 下面是你原先的地址查询+写PLC代码(为了演示，直接内联在此) 
            // --------------------------------------------------------------

            int recipeDataNumber = 3; // 假设默认值
            DataSet dsNum = SQLiteHelper.ExecuteQuery("SELECT RecipeDataNumber FROM Config LIMIT 1");
            if (dsNum != null && dsNum.Tables.Count > 0 && dsNum.Tables[0].Rows.Count > 0)
            {
                recipeDataNumber = Convert.ToInt32(dsNum.Tables[0].Rows[0]["RecipeDataNumber"]);
                if (recipeDataNumber < 3) recipeDataNumber = 3;
                if (recipeDataNumber > 8) recipeDataNumber = 8;
            }
            string sql = $"SELECT address FROM RecipeData ORDER BY id LIMIT {recipeDataNumber}";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count < recipeDataNumber)
            {
                //MessageBox.Show("未能获取到足够的PLC写入地址");
                return;
            }
            // 行号 e.RowIndex 就对应第几条地址
            string address = ds.Tables[0].Rows[e.RowIndex]["address"].ToString();



            var plcStatus = PLCConnect.ReadBool("M0");
            if (!plcStatus.IsSuccess)  // 注意取反
            {
                MyMessageBox.Show("PLC未连接", "PLC not connected", MyMessageBoxType.Info);
                return;
            }




            var writeResult = PLCConnect.Write(address, newValue);
            if (writeResult.IsSuccess)
            {
                // 写入成功提示，你也可以省略弹窗
                MyMessageBox.Show("修改成功", "Edit Successful", MyMessageBoxType.Info);

                // 获取 "LabelLeft" 列的值
                string labelLeftValue = dataGridView1.Rows[e.RowIndex].Cells["LabelLeft"].Value.ToString();

                // 拆分字符串，根据空格分隔，去除多余的空格
                string[] parts = labelLeftValue.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // 获取第一个部分作为代号
                string symbol = parts[0];  // symbol 应该是代号，如 "T67"


                // 获取中文和英文描述
               
                string chineseLog = $"配方({SelectedRecipe.RecipeName})的参数{symbol}由{oldVal}修改为{newValue}(未保存)";
                string englishLog = $"Recipe ({SelectedRecipe.RecipeName}) parameter {symbol} changed from {oldVal} to {newValue} (unsaved)";

                // 写入日志
                LogHelper.WriteLog(GlobalUser.UserName, chineseLog + " " + englishLog);


                //LogHelper.WriteLog(GlobalUser.UserName,$"配方({SelectedRecipe.RecipeName})的参数{symbol}由{oldVal}修改为{newValue}(未保存)");
            }
            else
            {
                // 写入失败提示
                //MessageBox.Show($"地址 {address} 写入失败, address {address} write failed");
            }
        }

        private void btn_UserAdmin_Click(object sender, EventArgs e)
        {
            UserAdmin userAdmin = new UserAdmin();
            userAdmin.Owner = this;
            userAdmin.ShowDialog();
        }

        private void btn_Log_Click(object sender, EventArgs e)
        {
            Log logForm = new Log();
            logForm.Owner = this;
            logForm.ShowDialog();

        }



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

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void myCloseButton_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog(GlobalUser.UserName, $"退出登录 Exit");
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
    }
}
