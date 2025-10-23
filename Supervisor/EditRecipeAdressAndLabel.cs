using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Supervisor;  // 引用包含 SQLiteHelper 的命名空间

namespace Supervisor
{
    public partial class EditRecipeAdressAndLabel : Form
    {
        // 保存数据库中 4 条记录的 id，用于后续更新操作
        private int[] recordIds = new int[8];
        private int recipeDataNumber;

        public EditRecipeAdressAndLabel()
        {
            InitializeComponent();
        }
        

        // 窗体加载函数
        private void EditRecipeAdressAndLabel_Load(object sender, EventArgs e)
        {
            LoadRecipeDataNumber();
            LoadPLCConnectionType();

        }

        private void LoadPLCConnectionType()
        {
            string sql = "Select plc_type from PLCConnection";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string plcType = ds.Tables[0].Rows[0]["plc_type"].ToString();
                if (plcType == "MelsecFxSerial")
                {
                    rbtn_Port.Checked = true;
                }
                else if (plcType == "SiemensS7Net")
                {
                    rbtn_Siemen.Checked = true;
                }
                
            }
            else
            {
                
            }
        }

        private void btn_SavePLCConnType_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否重启并切换PLC类型？", "确认操作", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dr == DialogResult.Yes)
            {
                string plcType = rbtn_Port.Checked ? "MelsecFxSerial" : (rbtn_Siemen.Checked ? "SiemensS7Net" : "");
                
                string updateSql = @"UPDATE PLCConnection SET plc_type = @plc_type";
                SQLiteParameter[] parameters = new SQLiteParameter[]
                {
                new SQLiteParameter("@plc_type", plcType)
                };
                int result = SQLiteHelper.ExecuteNonQuery(updateSql, parameters);
                if (result > 0)
                {
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("PLC类型切换失败");
                }
            }
            else
            {
            }
        }

        // 更新并保存配方数据数量
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("修改配方参数个数将会删除所有现有配方数据，是否继续？", "确认操作", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (dr == DialogResult.Yes)
            {
                string deletesql = "DELETE FROM Recipe;";
                SQLiteHelper.ExecuteNonQuery(deletesql);
                string updateSql = @"UPDATE Config SET RecipeDataNumber = @RecipeDataNumber";
                SQLiteParameter[] parameters = new SQLiteParameter[]
                {
                new SQLiteParameter("@RecipeDataNumber", cmb_RecipeDataNumber.Text)

                };
                int result = SQLiteHelper.ExecuteNonQuery(updateSql, parameters);
                LoadRecipeDataNumber();
                if (result > 0)
                {
                    MessageBox.Show("刷新成功");
                }
                else
                {
                    MessageBox.Show("刷新失败");
                }
            }
            else
            {
            }
        }

        // 加载配方数据数量对应修改, 第一次加载窗口时调用, 以及点击刷新按钮时调用
        private void LoadRecipeDataNumber()
        {
            recipeDataNumber = Convert.ToInt32(SQLiteHelper.ExecuteQuery("SELECT RecipeDataNumber From Config").Tables[0].Rows[0]["RecipeDataNumber"].ToString());
            for (int i = 1; i <= 8; i++)
            {
                bool enableGroup = (i <= recipeDataNumber);

                TextBox txtAddress = this.Controls.Find("txt_Address" + i, true).FirstOrDefault() as TextBox;
                TextBox txtLabel = this.Controls.Find("txt_Label" + i, true).FirstOrDefault() as TextBox;
                TextBox txtUnit = this.Controls.Find("txt_Unit" + i, true).FirstOrDefault() as TextBox;

                if (txtAddress != null) txtAddress.Enabled = enableGroup;
                if (txtLabel != null) txtLabel.Enabled = enableGroup;
                if (txtUnit != null) txtUnit.Enabled = enableGroup;
            }

            cmb_RecipeDataNumber.Items.Clear();
            for (int i = 3; i <= 8; i++)
            {
                cmb_RecipeDataNumber.Items.Add(i);
            }
            cmb_RecipeDataNumber.SelectedIndex = recipeDataNumber - 3;


            // 查询语句，按 id 排序取前 4 条记录
            string sql = $"SELECT id, address, label, unit FROM RecipeData ORDER BY id LIMIT {recipeDataNumber}";

            DataSet ds = SQLiteHelper.ExecuteQuery(sql);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == recipeDataNumber)
            {
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < recipeDataNumber; i++)
                {
                    DataRow row = dt.Rows[i];


                    recordIds[i] = Convert.ToInt32(row["id"]);

                    // 将对应数据填充到各行的文本框中

                    TextBox txtAddress = this.Controls.Find("txt_Address" + (i + 1), true).FirstOrDefault() as TextBox;
                    TextBox txtLabel = this.Controls.Find("txt_Label" + (i + 1), true).FirstOrDefault() as TextBox;
                    TextBox txtUnit = this.Controls.Find("txt_Unit" + (i + 1), true).FirstOrDefault() as TextBox;

                    if (txtAddress != null) txtAddress.Text = row["address"].ToString();
                    if (txtLabel != null) txtLabel.Text = row["label"].ToString();
                    if (txtUnit != null) txtUnit.Text = row["unit"].ToString();
                }
            }
            else
            {
                MessageBox.Show($"数据库中记录不足 {recipeDataNumber} 条，请检查数据。");
            }
        }



        // 点击“保存并退出”按钮时更新数据库中 4 条记录
        private void btn_SaveAndExit_Click(object sender, EventArgs e)
        {
            // 针对每一行记录执行更新操作
            for (int i = 0; i < recipeDataNumber; i++)
            {
                int id = recordIds[i];

                TextBox txtAddress = this.Controls.Find("txt_Address" + (i + 1), true).FirstOrDefault() as TextBox;
                TextBox txtLabel = this.Controls.Find("txt_Label" + (i + 1), true).FirstOrDefault() as TextBox;
                TextBox txtUnit = this.Controls.Find("txt_Unit" + (i + 1), true).FirstOrDefault() as TextBox;

                if (txtAddress == null || txtLabel == null || txtUnit == null)
                {
                    // 如果某个控件不存在，给出提示或跳过
                    MessageBox.Show($"第 {i + 1} 组文本框不存在，无法更新。");
                    return;
                }


                string address = txtAddress.Text;
                string label = txtLabel.Text;
                string unit = txtUnit.Text;





                // 定义更新所用的参数
                SQLiteParameter paramAddress = new SQLiteParameter("@address", address);
                SQLiteParameter paramLabel = new SQLiteParameter("@label", label);
                SQLiteParameter paramUnit = new SQLiteParameter("@unit", unit);
                SQLiteParameter paramId = new SQLiteParameter("@id", id);

                // 执行 UPDATE 语句更新数据（不会新增，只会更新现有的 4 条记录）
                string updateSql = "UPDATE RecipeData SET address = @address, label = @label, unit = @unit WHERE id = @id";
                int result = SQLiteHelper.ExecuteNonQuery(updateSql, paramAddress, paramLabel, paramUnit, paramId);
                if (result < 0)
                {
                    MessageBox.Show($"更新第 {i + 1} 条记录时出错！");
                    return;
                }
            }

            // 更新完成后关闭窗体
            this.Close();
        }

        
    }
}
