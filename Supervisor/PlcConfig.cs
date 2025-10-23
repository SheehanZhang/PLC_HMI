using System;
using System.Data;
using System.Data.SQLite;
using System.IO.Ports;
using System.Net;
using HslCommunication.Profinet.Melsec;
using HslCommunication.Profinet.Siemens;

namespace Supervisor
{
    /// <summary>
    /// 用于存储 PLC 配置数据的类，格式符合 FxSerial 的要求
    /// </summary>
    public class PlcConfig
    {
        public string PlcType { get; set; }

        // 三菱FX系列串口
        public string ComPort { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public Parity ParityValue { get; set; }
        public StopBits StopBits { get; set; }

        // 西门子S7系列以太网
        public string IpAddress { get; set; }
    }

    /// <summary>
    /// 静态类，用于从数据库中读取 PLC 连接配置，并转换为 FxSerial 所需的格式
    /// </summary>
    public static class PLCConfigProvider
    {
        /// <summary>
        /// 从数据库中读取 PLC 配置，要求数据库表 PLCConnection 中存在一条 id = 1 的记录，
        /// 字段：com_port (TEXT), baud_rate (INTEGER), data_bits (INTEGER), parity (TEXT), stop_bits (INTEGER)
        /// </summary>
        /// <returns>返回一个 PlcConfig 对象，如果读取失败则返回 null</returns>
        public static PlcConfig GetConfig()
        {
            string sql = "SELECT * FROM PLCConnection WHERE id = 1";
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return null;

            DataRow row = ds.Tables[0].Rows[0];
            var config = new PlcConfig
            {
                PlcType = row["plc_type"].ToString(),
                ComPort = row["com_port"]?.ToString(),
                BaudRate = row["baud_rate"] != DBNull.Value ? Convert.ToInt32(row["baud_rate"]) : 9600,
                DataBits = row["data_bits"] != DBNull.Value ? Convert.ToInt32(row["data_bits"]) : 8,
                ParityValue = Enum.TryParse(row["parity"]?.ToString(), out Parity parity) ? parity : Parity.None,
                StopBits = row["stop_bits"] != DBNull.Value ? (StopBits)Convert.ToInt32(row["stop_bits"]) : StopBits.One,
                IpAddress = row["ip_address"]?.ToString(),
                
            };

            return config;
        }


        /// <summary>
        /// 将读取到的 PLC 配置应用到传入的 MelsecFxSerial 实例中
        /// </summary>
        /// <param name="fxSerial">MelsecFxSerial 实例</param>
        public static void ConfigureFxSerial(MelsecFxSerial fxSerial)
        {
            PlcConfig config = GetConfig();
            if (config != null)
            {
                fxSerial.SerialPortInni(sp =>
                {
                    sp.PortName = config.ComPort;
                    sp.BaudRate = config.BaudRate;
                    sp.DataBits = config.DataBits;
                    sp.Parity = config.ParityValue;
                    sp.StopBits = config.StopBits;
                });
            }
            else
            {
                throw new Exception("未能从数据库中读取到有效的 PLC 配置。");
            }
        }

        public static SiemensS7Net ConfigureSiemensS7(PlcConfig config)
        {
            if (string.IsNullOrEmpty(config.IpAddress))
                throw new Exception("西门子PLC IP地址不能为空");

            SiemensS7Net siemens = new SiemensS7Net(SiemensPLCS.S200Smart, config.IpAddress);
            
            return siemens;
        }
    }
}
