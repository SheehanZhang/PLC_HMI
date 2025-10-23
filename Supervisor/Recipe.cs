using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using Supervisor; // 引用 SQLiteHelper

namespace Supervisor
{
    public partial class Recipe : Form
    {
        private int _permission;

        private int recipeDataNumber;
        public Recipe()
        {
            InitializeComponent();
            // 绑定窗体加载事件
            this.Load += RecipeLabel_Load;
            this.Load += Recipe_Load;
            _permission = GlobalUser.Permission;
            recipeDataNumber = Convert.ToInt32(SQLiteHelper.ExecuteQuery("SELECT RecipeDataNumber From Config").Tables[0].Rows[0]["RecipeDataNumber"].ToString());
            for (int i = 0; i < 8; i++)
            {
                string columnName = $"col{3+i}_Label{i + 1}";
                if (dataGridView1.Columns.Contains(columnName))
                {
                    dataGridView1.Columns[columnName].Visible = (i < recipeDataNumber);
                }
            }


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // 设置单元格内容居中对齐
                }
            }

        }

        private void Recipe_Load(object sender, EventArgs e)
        {
            string sql = "Select * from Recipe";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            if(ds != null && ds.Tables.Count > 0)
            {
                int seq = 1;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row["id"],
                        seq,
                        row["recipeName"],
                        row["value1"],
                        row["value2"],
                        row["value3"],
                        row["value4"],
                        row["value5"],
                        row["value6"],
                        row["value7"],
                        row["value8"]);

                    seq++;
                }
            }
            if(_permission == 0 || _permission == 1)
            {
                btn_AddRecipe.Visible = true;
                btn_DeleteRecipe.Visible = true;
                btn_EditRecipe.Visible = true;
            }
            else
            {
                btn_AddRecipe.Visible = false;
                btn_DeleteRecipe.Visible = false;
                btn_EditRecipe.Visible = false;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // 设置单元格内容居中对齐
                }
            }
        }

        private void RecipeLabel_Load(object sender, EventArgs e)
        {
            // 设置整个 grid 的列宽自动填充模式
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft YaHei UI", 9);
            dataGridView1.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 9);
            //dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            //dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 1. 第一列为序号，设置为固定宽度（窄）
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[0].Width = 40; // 根据需要调整宽度
                dataGridView1.Columns[0].FillWeight = 10; // 填充权重较低
            }

            // 2. 后面几列平均填充宽度（这里用 FillWeight 来控制比例）
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[i].FillWeight = 45; // 根据需要调整
            }

            // 3. 查询 RecipeData 表中的 label 数据（只取前 4 行）
            string sql = $"SELECT label FROM RecipeData ORDER BY id LIMIT {recipeDataNumber}";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == recipeDataNumber)
            {
                DataTable dt = ds.Tables[0];

                for (int i = 0; i < recipeDataNumber; i++)
                {
                    string columnName = $"col{3 + i}_Label{i + 1}";

                    if (dataGridView1.Columns.Contains(columnName))
                    {
                        if (i < dt.Rows.Count)
                        {
                            dataGridView1.Columns[columnName].HeaderText = dt.Rows[i]["label"].ToString();
                        }
                           
                    }
                }

                
            }
            else
            {
                //MessageBox.Show("数据库中没有足够的 RecipeData 记录！");
            }
            
            dataGridView1.Columns["col1_No"].Width = 60;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // 设置单元格内容居中对齐
                }
            }


        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_AddRecipe_Click(object sender, EventArgs e)
        {
            RecipeItem childForm = new RecipeItem();
            childForm.Owner = this;
            childForm.IsEditMode = false;
            childForm.SetNewModeData(recipeDataNumber);
            childForm.Show();




            
        }

        private void btn_DeleteRecipe_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                var idObj = selectedRow.Cells["col0"].Value;
                var logName = selectedRow.Cells["col2_RecipeName"].Value;
                if (idObj == null)
                {
                    //Console.Write(idObj);
                    //MessageBox.Show("未选中有效记录!");
                    return;
                }
                int recordId = Convert.ToInt32(idObj);

                // 弹出确认删除对话框

                DialogResult dr = MyMessageBox.Show("确定要删除该记录吗", "Are you sure you want to delete?", MyMessageBoxType.Confirm);

                if (dr == DialogResult.OK)
                {
                    var para = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@id", recordId)
                    };
                    string deletedRecipeName = SQLiteHelper.ExecuteQuery("Select recipeName from Recipe where id = @id", para).ToString();

                    // 执行删除语句
                    string deleteSql = "DELETE FROM Recipe WHERE id = @id";
                    var parameters = new System.Data.SQLite.SQLiteParameter[]
                    {
                new System.Data.SQLite.SQLiteParameter("@id", recordId)
                    };
                    int result = SQLiteHelper.ExecuteNonQuery(deleteSql, parameters);

                    if (result > 0)
                    {
                        MyMessageBox.Show("删除成功", "Delete Successful", MyMessageBoxType.Info);
                        LogHelper.WriteLog(GlobalUser.UserName, $"删除配方({deletedRecipeName}) Delete recipe({deletedRecipeName})" );
                        // 删除后刷新数据
                        RefreshData();
                    }
                    else
                    {
                        //MyMessageBox.Show("删除", "Delete Successful", MyMessageBoxType.Info);
                    }
                }
            }
            else
            {
                MyMessageBox.Show("请选择一条记录", "Please choose one record", MyMessageBoxType.Info);
            }
        }

        private void btn_EditRecipe_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0) {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                List<object> rowData = new List<object>();
                rowData.Add(selectedRow.Cells["col0"].Value);
                rowData.Add(selectedRow.Cells["col1_No"].Value);
                rowData.Add(selectedRow.Cells["col2_RecipeName"].Value);

                for (int i = 0; i < recipeDataNumber; i++)
                {
                    string columnName = $"col{3 + i}_Label{i + 1}";
                    if (dataGridView1.Columns.Contains(columnName))
                    {
                        rowData.Add(selectedRow.Cells[columnName].Value);
                    }
                }


                RecipeItem childForm = new RecipeItem();
                childForm.Owner = this;
                childForm.IsEditMode = true;
                //childForm.SetEditModeData(data0,data1, data2, data3, data4, data5, data6);
                childForm.SetEditModeData(rowData, recipeDataNumber);
                childForm.ShowDialog();
                //Console.WriteLine(rowData.ToString());
            }
        }

        private void btn_LoadRecipe_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                SelectedRecipe.RecipeNo = selectedRow.Cells["col1_No"].Value.ToString();
                SelectedRecipe.RecipeId = selectedRow.Cells["col0"].Value.ToString();
                SelectedRecipe.RecipeName = selectedRow.Cells["col2_RecipeName"].Value.ToString();
                SelectedRecipe.Value1 = selectedRow.Cells["col3_Label1"].Value.ToString();
                SelectedRecipe.Value2 = selectedRow.Cells["col4_Label2"].Value.ToString();
                SelectedRecipe.Value3 = selectedRow.Cells["col5_Label3"].Value.ToString();
                SelectedRecipe.Value4 = selectedRow.Cells["col6_Label4"].Value.ToString();
                SelectedRecipe.Value5 = selectedRow.Cells["col7_Label5"].Value.ToString();
                SelectedRecipe.Value6 = selectedRow.Cells["col8_Label6"].Value.ToString();
                SelectedRecipe.Value7 = selectedRow.Cells["col9_Label7"].Value.ToString();
                SelectedRecipe.Value8 = selectedRow.Cells["col10_Label8"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // 设置单元格内容居中对齐
                }                                      
            }
        }



        public void RefreshData()
        {
            // 清空现有行
            dataGridView1.Rows.Clear();

            // 从数据库中查询所有记录
            string sql = "SELECT * FROM Recipe";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                int seq = 1;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(
                        row["id"],            // 隐藏的真实 id 列（例如 col0）
                        seq,                  // 显示的序号（例如 col1_No）
                        row["recipeName"],    // 例如 col2_RecipeName
                        row["value1"],        // 例如 col3_Label1
                        row["value2"],        // 例如 col4_Label2
                        row["value3"],        // 例如 col5_Label3
                        row["value4"],         // 例如 col6_Label4
                        row["value5"],
                        row["value6"],
                        row["value7"],
                        row["value8"]
                        
                    );
                    seq++;
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // 设置单元格内容居中对齐
                }
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



        private void myCloseButton_Click(object sender, EventArgs e)
        {
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



    }
}
