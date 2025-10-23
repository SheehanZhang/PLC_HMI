using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Profinet.Melsec;
using HslCommunication.Profinet.Siemens;
using Newtonsoft.Json.Linq;

namespace Supervisor
{
    public partial class PLCConnect : Form
    {
        public static MelsecFxSerial FxSerial { get; set; }
        public static SiemensS7Net Siemens { get; set; }

        private static PlcConfig currentConfig;



        // 初始化PLC连接
      

        public static void AutoConnectPLC()
        {
            try
            {
                currentConfig = PLCConfigProvider.GetConfig(); // <-- 关键赋值
                if (currentConfig == null) return;

                if (currentConfig.PlcType == "MelsecFxSerial")
                {
                    if (FxSerial == null) FxSerial = new MelsecFxSerial();
                    else if (FxSerial.IsOpen()) FxSerial.Close();

                    PLCConfigProvider.ConfigureFxSerial(FxSerial);
                    FxSerial.Open();
                }
                else if (currentConfig.PlcType == "SiemensS7Net")
                {
                    Siemens = PLCConfigProvider.ConfigureSiemensS7(currentConfig);
                    Siemens.ConnectTimeOut = 200;   // 连接超时 2 秒
                    Siemens.ReceiveTimeOut = 200;   // 通讯超时 2 秒
                    var connectResult = Siemens.ConnectServer();
                    if (!connectResult.IsSuccess)
                        throw new Exception("西门子 S7 连接失败: " + connectResult.Message);
                }
                else
                {
                    throw new Exception("未知PLC类型：" + currentConfig.PlcType);
                }
            }
            catch
            {
                // 异常忽略
            }
        }


        public static OperateResult<bool> ReadBool(string address)
        {
            var config = PLCConfigProvider.GetConfig();
            if (config.PlcType == "MelsecFxSerial") return FxSerial.ReadBool(address);
            else if (config.PlcType == "SiemensS7Net") return Siemens.ReadBool(address);
            else return new OperateResult<bool>("未知PLC类型");
        }

        public static OperateResult<short> ReadInt16(string address)
        {
            if (currentConfig?.PlcType == "MelsecFxSerial") return FxSerial.ReadInt16(address);
            else if (currentConfig?.PlcType == "SiemensS7Net") return Siemens.ReadInt16(address);
            else return new OperateResult<short>("PLC未连接或未知类型");
        }


        public static OperateResult Write(string address, bool value)
        {
            if (currentConfig?.PlcType == "MelsecFxSerial") return FxSerial.Write(address, value);
            else if (currentConfig?.PlcType == "SiemensS7Net") return Siemens.Write(address, value);
            else return new OperateResult("PLC未连接或未知类型");
        }

        public static OperateResult Write(string address, short value)
        {
            if (currentConfig?.PlcType == "MelsecFxSerial") return FxSerial.Write(address, value);
            else if (currentConfig?.PlcType == "SiemensS7Net") return Siemens.Write(address, value);
            else return new OperateResult("PLC未连接或未知类型");
        }

        public static OperateResult Write(string address, int value)
        {
            if (currentConfig?.PlcType == "MelsecFxSerial") return FxSerial.Write(address, value);
            else if (currentConfig?.PlcType == "SiemensS7Net") return Siemens.Write(address, value);
            else return new OperateResult("PLC未连接或未知类型");
        }

        public static OperateResult Write(string address, float value)
        {
            if (currentConfig?.PlcType == "MelsecFxSerial") return FxSerial.Write(address, value);
            else if (currentConfig?.PlcType == "SiemensS7Net") return Siemens.Write(address, value);
            else return new OperateResult("PLC未连接或未知类型");
        }





        // 配置页面逻辑
        public PLCConnect()
        {
            InitializeComponent();
            InitParam();
            UpdatePLCConnectStatusLabel();

        }

       

        private void InitParam()
        {
            // 1. 获取可用的串口号，并添加到 cmb_PortName 中（com口不从数据库获取）
            string[] portList = System.IO.Ports.SerialPort.GetPortNames();
            if (portList.Length > 0)
            {
                cmb_PortName.Items.AddRange(portList);
                cmb_PortName.SelectedIndex = 0;  // 默认选择第一个
            }

            // 2. 设置其它串口参数的可选项
            string[] baudRates = { "2400", "4800", "9600", "19200", "38400" };
            cmb_BaudRate.Items.AddRange(baudRates);

            string[] dataBits = { "7", "8" };
            cmb_DataBit.Items.AddRange(dataBits);

            // 使用枚举生成校验位和停止位选项
            cmb_Parity.DataSource = Enum.GetNames(typeof(System.IO.Ports.Parity));
            cmb_StopBit.DataSource = Enum.GetNames(typeof(System.IO.Ports.StopBits));

            // 3. 从数据库中读取波特率、数据位、校验位和停止位的保存值
            DataSet ds = SQLiteHelper.ExecuteQuery("SELECT com_port, baud_rate, data_bits, parity, stop_bits, ip_address FROM PLCConnection WHERE id = 1");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string savedComPort = row["com_port"].ToString();
                string savedBaudRate = row["baud_rate"].ToString();
                string savedDataBits = row["data_bits"].ToString();
                string savedParity = row["parity"].ToString();
                string savedStopBits = row["stop_bits"].ToString();
                string savedIpAddress = row["ip_address"].ToString() ;

                int comPortIndex = Array.IndexOf(portList, savedComPort);
                //cmb_PortName.SelectedIndex = (comPortIndex >=0 ? comPortIndex : 0);

                // 4. 设置波特率
                int baudIndex = Array.IndexOf(baudRates, savedBaudRate);
                cmb_BaudRate.SelectedIndex = (baudIndex >= 0 ? baudIndex : 2);  // 默认 9600

                // 5. 设置数据位
                int dataIndex = Array.IndexOf(dataBits, savedDataBits);
                cmb_DataBit.SelectedIndex = (dataIndex >= 0 ? dataIndex : 1);  // 默认 8

                // 6. 设置校验位
                int parityIndex = cmb_Parity.Items.IndexOf(savedParity);
                cmb_Parity.SelectedIndex = (parityIndex >= 0 ? parityIndex : 0);

                // 7. 设置停止位
                int stopIndex = cmb_StopBit.Items.IndexOf(savedStopBits);
                cmb_StopBit.SelectedIndex = (stopIndex >= 0 ? stopIndex : 1);

                // 8. 设置IP地址
                txt_IPAddress.Text = savedIpAddress;

                if (currentConfig?.PlcType == "MelsecFxSerial")
                {
                    label6.Visible = false;
                    txt_IPAddress.Visible = false;

                }
                else if (currentConfig?.PlcType == "SiemensS7Net")
                {
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    cmb_BaudRate.Visible = false;
                    cmb_Parity.Visible = false;
                    cmb_StopBit.Visible = false;
                    cmb_DataBit.Visible = false;
                    cmb_PortName.Visible = false;

                    label6.Top = 103;
                    txt_IPAddress.Top = 103;
                    btn_Connect.Left -= 140;

                }


            }


        }


        private void UpdatePLCConnectStatusLabel()
        {
            if (currentConfig?.PlcType == "MelsecFxSerial")
            {
                int stopBitsValue = (int)Enum.Parse(typeof(StopBits), this.cmb_StopBit.Text);
                DataSet ds = SQLiteHelper.ExecuteQuery("SELECT com_port, baud_rate, data_bits, parity, stop_bits FROM PLCConnection WHERE id = 1");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    string savedComPort = row["com_port"].ToString();
                    string savedBaudRate = row["baud_rate"].ToString();
                    string savedDataBits = row["data_bits"].ToString();
                    string savedParity = row["parity"].ToString();
                    string savedStopBits = row["stop_bits"].ToString();

                    label_PLCCurrentConnectConfig.Text = string.Format(
                    "Current: COM: {0}, Baud: {1}, Data Bits: {2}, Parity: {3}, Stop Bits: {4}",
                    savedComPort,
                    savedBaudRate,
                    savedDataBits,
                    savedParity,
                    savedStopBits);

                }
            }
            else if (currentConfig?.PlcType == "SiemensS7Net")
            {
                DataSet ds = SQLiteHelper.ExecuteQuery("SELECT ip_address FROM PLCConnection WHERE id = 1");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    string savedIpAddress = row["ip_address"].ToString();
                    label_PLCCurrentConnectConfig.Text = string.Format("Current: {0}", savedIpAddress);

                }


            }
        }



        private void btn_Save_Click(object sender, EventArgs e)
        {
            
            if (this.cmb_PortName.Text == "")
            {
                string updateSql = "UPDATE PLCConnection SET baud_rate = @baud_rate, data_bits = @data_bits, parity = @parity, stop_bits = @stop_bits WHERE id = 1";
                SQLiteParameter[] parameters = new SQLiteParameter[]
            {

                        //new SQLiteParameter("@com_port", this.cmb_PortName.Text),
                        new SQLiteParameter("@baud_rate", Convert.ToInt32(this.cmb_BaudRate.Text)),
                        new SQLiteParameter("@data_bits", Convert.ToInt32(this.cmb_DataBit.Text)),
                        new SQLiteParameter("@parity", this.cmb_Parity.Text),
                        // 假设数据库中存储的是整型的停止位，比如 1 或 2
                        new SQLiteParameter("@stop_bits", (int)Enum.Parse(typeof(StopBits), cmb_StopBit.Text))

            };
                SQLiteHelper.ExecuteNonQuery(updateSql, parameters);
                UpdatePLCConnectStatusLabel();
                Application.Restart();
                Environment.Exit(0);
            }
            else
            {
                string updateSql = "UPDATE PLCConnection SET com_port = @com_port, baud_rate = @baud_rate, data_bits = @data_bits, parity = @parity, stop_bits = @stop_bits WHERE id = 1";
                SQLiteParameter[] parameters = new SQLiteParameter[]
            {

                        new SQLiteParameter("@com_port", this.cmb_PortName.Text),
                        new SQLiteParameter("@baud_rate", Convert.ToInt32(this.cmb_BaudRate.Text)),
                        new SQLiteParameter("@data_bits", Convert.ToInt32(this.cmb_DataBit.Text)),
                        new SQLiteParameter("@parity", this.cmb_Parity.Text),
                        // 假设数据库中存储的是整型的停止位，比如 1 或 2
                        new SQLiteParameter("@stop_bits", (int)Enum.Parse(typeof(StopBits), cmb_StopBit.Text))

            };
                SQLiteHelper.ExecuteNonQuery(updateSql, parameters);
                UpdatePLCConnectStatusLabel();
                Application.Restart();
                Environment.Exit(0);
            }
            
        }








        // 页面UI移动逻辑

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
    }
}

