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
    public partial class HiddenTest : Form
    {

        private Timer timerStartButtonStatus;
        private Timer timer16BitReader;

        private string read16BitAddress;
        private string startButtonWriteAddress;
        private string startButtonReadAddress;
        private string loadWriteAddress;


        public HiddenTest()
        {
            InitializeComponent();
        }



        private void HiddenTest_Load(object sender, EventArgs e)
        {
            string sql = "Select * from HiddenTestConfig where id = 1 Limit 1";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                label_Label1.Text = row["label1"].ToString();
                label_Label2.Text = row["label2"].ToString();
                label_Unit.Text = row["unit"].ToString();

                read16BitAddress = row["data16BitAddr"].ToString();
                startButtonWriteAddress = row["startBtnWriteAddr"].ToString();
                startButtonReadAddress = row["startBtnReadAddr"].ToString();
                loadWriteAddress = row["windowLoadWriteAddr"].ToString();
            }
            PLCConnect.AutoConnectPLC();
            // 1. 检查PLC连接是否正常
            if (!PLCConnect.ReadBool("M0").IsSuccess)
            {

                var result = PLCConnect.Write(loadWriteAddress, true);
                return;

            }

            timerStartButtonStatus = new Timer();
            timerStartButtonStatus.Interval = 10000; // 1 秒
            timerStartButtonStatus.Tick += TimerStartButtonStatus_Tick;
            timerStartButtonStatus.Start();

            timer16BitReader = new Timer();
            timer16BitReader.Interval = 2000; // 2 秒
            timer16BitReader.Tick += Timer16BitReader_Tick;
            timer16BitReader.Start();

            if (GlobalUser.Permission != 0)
            {
                btn_Config.Visible = false;
            }


        }


        private void TimerStartButtonStatus_Tick(object sender, EventArgs e)
        {
            
            // 1. 检查PLC连接是否正常
            if (!PLCConnect.ReadBool("M0").IsSuccess)
            {

                btn_Start.BackColor = ColorTranslator.FromHtml("#AFFFAF");
                return;
             
            }

            // 读取启动状态
            var resultStart = PLCConnect.ReadBool(startButtonReadAddress);

            if (resultStart.IsSuccess && resultStart.Content)
            {
                btn_Start.BackColor = ColorTranslator.FromHtml("#008A00");
                //myLamp_Start.IsOn = true;
            }
            else if (resultStart.IsSuccess && !resultStart.Content)
            {
                btn_Start.BackColor = ColorTranslator.FromHtml("#AFFFAF");
            }
        }


        private void Timer16BitReader_Tick(object sender, EventArgs e)
        {
            
            // 1. 检查PLC连接是否正常
            if (!PLCConnect.ReadBool("M0").IsSuccess)
            {

                btn_Start.BackColor = ColorTranslator.FromHtml("#AFFFAF");
                return;
            }


            // 假设你想读取一个 Int16
            var result16 = PLCConnect.ReadInt16(read16BitAddress);
            if (result16.IsSuccess)
            {
                // 显示读取结果
                label_ReadResult.Text = result16.Content.ToString();
            }
            else
            {
                //label_ReadResult.Text = "读取失败: " + result16.Message;
            }
        }



        // 启动按钮：按下写 1，松开写 0
        private void btn_Start_MouseDown(object sender, MouseEventArgs e)
        {
            
            var result = PLCConnect.Write(startButtonWriteAddress, true);
            if (!result.IsSuccess)
            {
                //MessageBox.Show("启动写入失败: " + result.Message);
            }
        }
        private void btn_Start_MouseUp(object sender, MouseEventArgs e)
        {
            
            var result = PLCConnect.Write(startButtonWriteAddress, false);
            if (!result.IsSuccess)
            {
                //MessageBox.Show("启动释放写入失败: " + result.Message);
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
            
            var result = PLCConnect.Write(loadWriteAddress, false);
            



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

        private void btn_Config_Click(object sender, EventArgs e)
        {
            HiddenTestItem hiddenTestItemForm = new HiddenTestItem();
            hiddenTestItemForm.Owner = this;
            hiddenTestItemForm.ShowDialog();
        }
    }
}
