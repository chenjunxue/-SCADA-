using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiChuanZhangYiYuan_SCADA
{
    public static class Common
    {
        public static string nole = "";
        public static int writeSQL_Date = 0;
        public static bool PLC_Connect = false;

        public static bool LP1 = false;
        public static bool SL1 = false;
        public static bool SL2 = false;
        public static bool XG5 = false;
        public static bool TB6 = false;
        public static bool ZH7 = false;

        public static bool Err_WX = false;

        //理瓶数据采集点位
        public static string VD0 = "0";
        public static string VD4 = "0";
        public static bool Run_V8_0 = false;
        public static bool Err_V9_0 = false;
        public static bool Err_V9_1 = false;
        public static bool Err_V9_2 = false;
        public static bool Err_V9_3 = false;
        public static bool Err_V9_4 = false;
        public static bool Err_V9_5 = false;

        //数粒1采集点位
        public static string VW10 = "0";
        public static string VW12 = "0";
        public static bool Run_V14_0 = false;
        public static bool Err_V15_0 = false;
        public static bool Err_V15_1 = false;
        public static bool Err_V15_2 = false;
        public static bool Err_V15_3 = false;
        public static bool Err_V15_4 = false;
        public static bool Err_V15_5 = false;
        public static bool Err_V15_6 = false;
        public static bool Err_V15_7 = false;

        //数粒2采集点位
        public static string VW20 = "0";
        public static string VW22 = "0";
        public static bool Run_V24_0 = false;
        public static bool Err_V25_0 = false;
        public static bool Err_V25_1 = false;
        public static bool Err_V25_2 = false;
        public static bool Err_V25_3 = false;
        public static bool Err_V25_4 = false;
        public static bool Err_V25_5 = false;
        public static bool Err_V25_6 = false;
        public static bool Err_V25_7 = false;

        //旋盖5采集点位
        public static string VD50 = "0";
        public static string VD54 = "0";
        public static bool Run_V58_0 = false;
        public static bool Err_V59_0 = false;
        public static bool Err_V59_1 = false;
        public static bool Err_V59_2 = false;
        public static bool Err_V59_3 = false;
        public static bool Err_V59_4 = false;
        public static bool Err_V59_5 = false;
        public static bool Err_V59_6 = false;

        //贴标6采集点位
        public static string VD60 = "0";
        public static string VD64 = "0";
        public static bool Run_V68_0 = false;
        public static bool Err_V69_0 = false;
        public static bool Err_V69_1 = false;
        public static bool Err_V69_2 = false;
        public static bool Err_V69_3 = false;
        public static bool Err_V69_4 = false;
        public static bool Err_V69_5 = false;

        //装盒7采集点位
        public static string VW70 = "0";
        public static string VD74 = "0";
        public static bool Run_V78_7 = false;
        public static bool Err_V79_1 = false;
        public static bool Err_V79_2 = false;
        public static bool Err_V79_3 = false;
        public static bool Err_V79_4 = false;
        public static bool Err_V79_5 = false;
        public static bool Err_V80_0 = false;
        public static bool Err_V80_1 = false;
        public static bool Err_V80_2 = false;
        public static bool Err_V80_3 = false;
        public static bool Err_V80_4 = false;
        public static bool Err_V80_6 = false;
        public static bool Err_V80_7 = false;
        public static bool Err_V81_0 = false;
        public static bool Err_V81_1 = false;


        //中间listviw数据控件
        public static ListView copylst = new ListView();
        public static ListView GC_copylst = new ListView();

        public static ListViewItem Err_List;
        public static ListView V_Err_List = new ListView();

        public static int List_Count = 0;

        //写入报警记录
        public static void AddLog_Err(int info, string Log)
        {
            Err_List = new ListViewItem(" " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + Log, info);
            V_Err_List.Items.Insert(0, Err_List);

            LogSQLite(Log);
        }


        // 将报警信息写入日志文件
        public static void WriteLog(string msg)
        {
            string date = DateTime.Now.ToString();
            string numberString = System.Text.RegularExpressions.Regex.Replace(date, @"[^0-9]+", "");

            FileStream fs = new FileStream(@ConfigurationManager.AppSettings["Err_log_path"]+ numberString+ "_LogErr.text", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("[{0}]  报警信息：{1}", DateTime.Now.ToString(), msg);
            sw.Close();
            fs.Close();
        }


        public static void LogSQLite(string Errmsg)
        {
            string sql = "Insert into AlarmDate(time,alarm_name) values('{0}','{1}')";

            sql = string.Format(sql, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),Errmsg);

            SQLiteHelper.Update(sql);
        }


        //数据展示到打印表中
        public static List<Date_Report> list = new List<Date_Report>();
    }
}
