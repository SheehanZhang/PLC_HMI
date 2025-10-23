using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class RecipeItem : Form
    {
        public bool IsEditMode { get; set; }
        public int RecordId { get; set; }

        private int recipeDataNumber;

        private List<object> _originalRowData;   // 父页传来的原始行数据（含原配方名与各参数旧值）
        private int _originalParamStartIndex = 3; // rowData中参数起始索引：col3_Label1 从这里开始



        public RecipeItem()
        {
            InitializeComponent();
            this.Load += RecipeItem_Load;
            recipeDataNumber = Convert.ToInt32(SQLiteHelper.ExecuteQuery("SELECT RecipeDataNumber From Config").Tables[0].Rows[0]["RecipeDataNumber"].ToString());
            
        }

        private void RecipeItem_Load(object sender, EventArgs e)
        {
            string sql = $"SELECT label FROM RecipeData ORDER BY id LIMIT {recipeDataNumber}";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count >= recipeDataNumber)
            {
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < recipeDataNumber; i++)
                {
                    Label labelControl = this.Controls.Find("label_Label" + (i + 1), true).FirstOrDefault() as Label;
                    TextBox textControl = this.Controls.Find("txt_Value" + (i + 1), true).FirstOrDefault() as TextBox;

                    if (labelControl != null)
                    {
                        if (i < recipeDataNumber && i < dt.Rows.Count)
                        {
                            labelControl.Visible = true;
                            textControl.Visible = true;
                            labelControl.Text = dt.Rows[i]["label"].ToString();
                        }
                        else
                        {
                            labelControl.Visible = false;
                            textControl.Visible = false;
                        }

                    }
                }
            }
            
        }

        public void SetNewModeData(int recipeDataNumber)
        {
            if (!IsEditMode)
            {
                // 新增模式：查询 Recipe 表中记录数，设置 txt_No 为当前记录数+1
                string sqlCount = "SELECT COUNT(*) FROM Recipe";
                object countObj = SQLiteHelper.ExecuteScalar(sqlCount);
                int count = 0;
                if (countObj != null && int.TryParse(countObj.ToString(), out count))
                {
                    txt_No.Text = (count + 1).ToString();
                }
                else
                {
                    txt_No.Text = "1";
                }
            }
            for (int i = recipeDataNumber + 1; i <= 8; i++)
            {
                TextBox textControl = this.Controls.Find("txt_Value" + i, true)
                                                   .FirstOrDefault() as TextBox;
                if (textControl != null)
                {
                    textControl.Visible = false;
                }
            }

            for (int i = recipeDataNumber + 1; i <= 8; i++)
            {
                Label labelControl = this.Controls.Find("label_Label" + i, true)
                                                  .FirstOrDefault() as Label;
                if (labelControl != null)
                {
                    labelControl.Visible = false;
                }
            }

        }

        public void SetEditModeData(List<object> rowData, int recipeDataNumber)
        {
            _originalRowData = rowData; // 保存下来供保存时比对
            this.recipeDataNumber = recipeDataNumber;

            RecordId = Convert.ToInt32(rowData[0]);
            txt_No.Text = rowData[1]?.ToString();
            txt_RecipeName.Text = rowData[2]?.ToString();

            for (int i = 0; i < recipeDataNumber; i++)
            {
                int dataIndex = _originalParamStartIndex + i;

                TextBox textControl = this.Controls.Find("txt_Value" + (i + 1), true).FirstOrDefault() as TextBox;
                Label labelControl = this.Controls.Find("label_Label" + (i + 1), true).FirstOrDefault() as Label;
                if (textControl != null && dataIndex < rowData.Count)
                {
                    textControl.Text = rowData[dataIndex]?.ToString();
                    textControl.Visible = true;   // 显示可编辑
                }
                if (labelControl != null)
                {
                    labelControl.Visible = true; // 显示对应的标签
                }
            }

            for (int i = recipeDataNumber + 1; i <= 8; i++)
            {
                TextBox textControl = this.Controls.Find("txt_Value" + i, true)
                                                   .FirstOrDefault() as TextBox;
                if (textControl != null)
                {
                    textControl.Visible = false;
                }
            }

            for (int i = recipeDataNumber + 1; i <= 8; i++)
            {
                Label labelControl = this.Controls.Find("label_Label" + i, true)
                                                  .FirstOrDefault() as Label;
                if (labelControl != null)
                {
                    labelControl.Visible = false;
                }
            }
        }
        /*
        private void btn_SaveAndExit_Click(object sender, EventArgs e)
        {
            string recipeName = txt_RecipeName.Text?.Trim();
            string[] values = new string[8];
            for (int i = 1; i <= 8; i++) 
            {
                TextBox txtValue = this.Controls.Find("txt_Value" + i, true).FirstOrDefault() as TextBox;
                if (txtValue != null)
                {
                    if(i <= recipeDataNumber)
                    {
                        values[i - 1] = txtValue.Text?.Trim();
                    }
                    else
                    {
                        values[i - 1] = string.Empty;
                    }
                        
                }
                else
                {
                    values[i - 1] = string.Empty;
                }
            }

            var paramList = new List<System.Data.SQLite.SQLiteParameter>
            {
                new System.Data.SQLite.SQLiteParameter("@recipeName", recipeName),
                new System.Data.SQLite.SQLiteParameter("@value1", values[0]),
                new System.Data.SQLite.SQLiteParameter("@value2", values[1]),
                new System.Data.SQLite.SQLiteParameter("@value3", values[2]),
                new System.Data.SQLite.SQLiteParameter("@value4", values[3]),
                new System.Data.SQLite.SQLiteParameter("@value5", values[4]),
                new System.Data.SQLite.SQLiteParameter("@value6", values[5]),
                new System.Data.SQLite.SQLiteParameter("@value7", values[6]),
                new System.Data.SQLite.SQLiteParameter("@value8", values[7])
            };

           


            if (IsEditMode)
            {
                // Update
                // RecordId 是要更新的那条记录的主键
                string updateSql = @"
                        UPDATE Recipe 
                        SET recipeName = @recipeName,
                            value1 = @value1,
                            value2 = @value2,
                            value3 = @value3,
                            value4 = @value4,
                            value5 = @value5,
                            value6 = @value6,
                            value7 = @value7,
                            value8 = @value8
                        WHERE id = @id";

                paramList.Add(new System.Data.SQLite.SQLiteParameter("@id", RecordId));

                int result = SQLiteHelper.ExecuteNonQuery(updateSql, paramList.ToArray());
                if (result >= 0)
                {
                    MyMessageBox.Show("更新成功", "Update Successful", MyMessageBoxType.Info);
                    
                    // 写日志
                    LogHelper.WriteLog(GlobalUser.UserName,$"更新配方：{recipeName}");
                    // 刷新父窗体
                    if (this.Owner is Recipe mainForm)
                    {
                        mainForm.RefreshData();
                    }
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("更新失败！Update Failed!");
                }
            }
            else
            {
                // Insert
                // 新增时，不需要 @id
                // 注意：若表里有自增主键，id 通常是自动生成的
                string insertSql = @"
                    INSERT INTO Recipe 
                        (recipeName, value1, value2, value3, value4, value5, value6, value7, value8)
                    VALUES
                        (@recipeName, @value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8)";

                int result = SQLiteHelper.ExecuteNonQuery(insertSql, paramList.ToArray());
                if (result > 0)
                {
                    MyMessageBox.Show("新增成功", "Add Successful", MyMessageBoxType.Info);

                    
                    // 写日志
                    LogHelper.WriteLog(GlobalUser.UserName, 
                        $"新增配方：{recipeName}");
                    // 刷新父窗体
                    if (this.Owner is Recipe mainForm)
                    {
                        mainForm.RefreshData();
                    }
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("新增失败！Add Failed!");
                }
            }


        }

        */

        private void btn_SaveAndExit_Click(object sender, EventArgs e)
        {
            string recipeName = txt_RecipeName.Text?.Trim();

            // 收集新值（你原有代码保留）
            string[] values = new string[8];
            for (int i = 1; i <= 8; i++)
            {
                TextBox txtValue = this.Controls.Find("txt_Value" + i, true).FirstOrDefault() as TextBox;
                if (txtValue != null)
                {
                    values[i - 1] = (i <= recipeDataNumber) ? (txtValue.Text?.Trim() ?? "") : "";
                }
                else
                {
                    values[i - 1] = "";
                }
            }

            var paramList = new List<System.Data.SQLite.SQLiteParameter>
            {
                new System.Data.SQLite.SQLiteParameter("@recipeName", recipeName),
                new System.Data.SQLite.SQLiteParameter("@value1", values[0]),
                new System.Data.SQLite.SQLiteParameter("@value2", values[1]),
                new System.Data.SQLite.SQLiteParameter("@value3", values[2]),
                new System.Data.SQLite.SQLiteParameter("@value4", values[3]),
                new System.Data.SQLite.SQLiteParameter("@value5", values[4]),
                new System.Data.SQLite.SQLiteParameter("@value6", values[5]),
                new System.Data.SQLite.SQLiteParameter("@value7", values[6]),
                new System.Data.SQLite.SQLiteParameter("@value8", values[7])
            };

            if (IsEditMode)
            {
                // ====== 先做“旧值 vs 新值”的比对 ======
                string oldRecipeName = _originalRowData[2]?.ToString() ?? "";
                bool recipeNameChanged = !string.Equals(oldRecipeName, recipeName, StringComparison.Ordinal);

                // 收集改动的参数项：index 从 0 开始，对应 txt_Value1..N
                var changedParameters = new List<(int idx, string oldVal, string newVal, string symbol)>();
                for (int i = 0; i < recipeDataNumber; i++)
                {
                    string oldVal = (_originalParamStartIndex + i < _originalRowData.Count)
                        ? (_originalRowData[_originalParamStartIndex + i]?.ToString() ?? "")
                        : "";

                    string newVal = values[i] ?? "";

                    if (!string.Equals(oldVal, newVal, StringComparison.Ordinal))
                    {
                        // 取该参数的“代号 symbol”= label 的第一个非空片段
                        string symbol = $"T{i + 1}";
                        var labelCtrl = this.Controls.Find("label_Label" + (i + 1), true).FirstOrDefault() as Label;
                        if (labelCtrl != null)
                        {
                            var parts = (labelCtrl.Text ?? "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length > 0) symbol = parts[0];
                        }

                        changedParameters.Add((i, oldVal, newVal, symbol));
                    }
                }

                // ====== 执行 UPDATE ======
                string updateSql = @"
                    UPDATE Recipe 
                       SET recipeName = @recipeName,
                           value1 = @value1,
                           value2 = @value2,
                           value3 = @value3,
                           value4 = @value4,
                           value5 = @value5,
                           value6 = @value6,
                           value7 = @value7,
                           value8 = @value8
                     WHERE id = @id";
                paramList.Add(new System.Data.SQLite.SQLiteParameter("@id", RecordId));

                int result = SQLiteHelper.ExecuteNonQuery(updateSql, paramList.ToArray());
                if (result >= 0)
                {
                    MyMessageBox.Show("更新成功", "Update Successful", MyMessageBoxType.Info);

                    // ====== 按你的三种情况写日志 ======
                    if (recipeNameChanged && changedParameters.Count == 0)
                    {
                        // ① 只改了配方名
                        LogHelper.WriteLog(GlobalUser.UserName, $"配方名({oldRecipeName})修改为 {recipeName} Recipe name({oldRecipeName}) changed to {recipeName}");
                    }
                    else if (recipeNameChanged && changedParameters.Count > 0)
                    {
                        // ② 改了配方名 + 参数
                        LogHelper.WriteLog(GlobalUser.UserName, $"配方名（{oldRecipeName}）修改为 {recipeName} Recipe name({oldRecipeName}) changed to {recipeName}");
                        foreach (var p in changedParameters)
                        {
                            string chineseLog = $"配方({recipeName})的参数{p.symbol}由{p.oldVal}修改为{p.newVal}(已保存)";
                            string englishLog = $"Recipe ({recipeName}) parameter {p.symbol} changed from {p.oldVal} to {p.newVal} (saved)";
                            LogHelper.WriteLog(GlobalUser.UserName, chineseLog + " " + englishLog);
                        }
                    }
                    else if (!recipeNameChanged && changedParameters.Count > 0)
                    {
                        // ③ 未改配方名，仅改参数
                        foreach (var p in changedParameters)
                        {
                            string chineseLog = $"配方({recipeName})的参数{p.symbol}由{p.oldVal}修改为{p.newVal}(已保存)";
                            string englishLog = $"Recipe ({recipeName}) parameter {p.symbol} changed from {p.oldVal} to {p.newVal} (saved)";
                            LogHelper.WriteLog(GlobalUser.UserName, chineseLog + " " + englishLog);
                        }
                    }
                    // 如果都没变，就不写日志

                    // 刷新父窗体、关闭
                    if (this.Owner is Recipe mainForm) mainForm.RefreshData();
                    this.Close();
                }
            }
            else
            {
                // Insert
                // 新增时，不需要 @id
                // 注意：若表里有自增主键，id 通常是自动生成的
                string insertSql = @"
                    INSERT INTO Recipe 
                        (recipeName, value1, value2, value3, value4, value5, value6, value7, value8)
                    VALUES
                        (@recipeName, @value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8)";

                int result = SQLiteHelper.ExecuteNonQuery(insertSql, paramList.ToArray());

                if (result > 0)
                {
                    MyMessageBox.Show("新增成功", "Add Successful", MyMessageBoxType.Info);

                    // 写日志
                    LogHelper.WriteLog(GlobalUser.UserName, $"新增配方({recipeName}) Add recipe({recipeName})");

                    // 刷新父窗体
                    if (this.Owner is Recipe mainForm)
                    {
                        mainForm.RefreshData();
                    }

                    this.Close();
                }
                else
                {
                    // 新增失败提示（可选）
                    // MessageBox.Show("新增失败！Add Failed!");
                }
            }

        }


        private void btn_QuitAndExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
