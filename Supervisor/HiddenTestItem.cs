using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class HiddenTestItem : Form
    {
        public HiddenTestItem()
        {
            InitializeComponent();
            
        }

        private void HiddenTestItem_Load(object sender, EventArgs e)
        {
            string sql = "Select * from HiddenTestConfig Limit 1";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txt_Label1.Text = row["label1"].ToString();
                
                txt_Label2.Text = row["label2"].ToString();
                txt_WriteAddress.Text = row["data16BitAddr"].ToString();
                txt_Unit.Text = row["unit"].ToString();
                txt_StartButtonWriteAddress.Text = row["startBtnWriteAddr"].ToString();
                txt_StartButtonReadAddress.Text = row["startBtnReadAddr"].ToString();
                txt_LoadWriteAddress.Text = row["windowLoadWriteAddr"].ToString();
            }
        }



        private void btn_Save_Click(object sender, EventArgs e)
        {
            // 更新 id=1 的记录
            string updateSql = @"
                UPDATE HiddenTestConfig
                SET label1 = @label1,
                    label2 = @label2,
                    data16BitAddr = @data16BitAddr,
                    unit = @unit,
                    startBtnWriteAddr = @startBtnWriteAddr,
                    startBtnReadAddr = @startBtnReadAddr,
                    windowLoadWriteAddr = @windowLoadWriteAddr
                WHERE id = 1
            ";

            // 参数化，避免 SQL 注入并处理特殊字符
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@label1",              txt_Label1.Text),
                new SQLiteParameter("@label2",              txt_Label2.Text),
                new SQLiteParameter("@data16BitAddr",       txt_WriteAddress.Text),
                new SQLiteParameter("@unit",                txt_Unit.Text),
                new SQLiteParameter("@startBtnWriteAddr",   txt_StartButtonWriteAddress.Text),
                new SQLiteParameter("@startBtnReadAddr",    txt_StartButtonReadAddress.Text),
                new SQLiteParameter("@windowLoadWriteAddr", txt_LoadWriteAddress.Text)
            };

            int result = SQLiteHelper.ExecuteNonQuery(updateSql, parameters);
            if (result > 0)
            {
                MessageBox.Show("更新成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("更新失败或无记录被修改。");
            }
        }

    }
}
