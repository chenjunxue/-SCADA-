using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiChuanZhangYiYuan_SCADA
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //如果应用程序已经启动，我们不希望他再次启动

            string processName = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcessesByName(processName).Length > 1)
            {
                MessageBox.Show("数据采集系统已经运行！", "系统运行", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            else
            {
                Frm_Log objLogin = new Frm_Log();
                objLogin.TopMost = true;
                DialogResult dr = objLogin.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    //登录成功，启动主窗体
                    Application.Run(new Frm_Main());
                }

            }
        }
    }
}
