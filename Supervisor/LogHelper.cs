using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor
{
    public static  class LogHelper
    {
        public static void WriteLog(string userName , string detail)
        {
            DateTime now = DateTime.Now;
            string sql = @"INSERT INTO Log(logTime, userName, detail)
                       VALUES(@logTime, @userName, @detail)";

            var parameters = new System.Data.SQLite.SQLiteParameter[]
            {
                new System.Data.SQLite.SQLiteParameter("@logTime", now.ToString("yyyy-MM-dd HH:mm:ss")),
                new System.Data.SQLite.SQLiteParameter("@userName", userName),
                new System.Data.SQLite.SQLiteParameter("@detail", detail)
            };

            if (GlobalUser.Permission == 0)
            {
                return;
            }

            try
            {
                SQLiteHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                
                //Console.WriteLine("写日志失败: " + ex.Message);
            }

        }
    }
}
