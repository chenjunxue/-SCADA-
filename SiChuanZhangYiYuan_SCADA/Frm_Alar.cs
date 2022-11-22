using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiChuanZhangYiYuan_SCADA
{
    public partial class Frm_Alar : Form
    {
        public Frm_Alar()
        {
            InitializeComponent();
            mytime = new Timer();
            mytime.Interval = 1000;
            mytime.Tick += Mytime_Tick;
            mytime.Enabled = true;
        }

        private Timer mytime;
        string weekstr = "";
        bool M3 = false;

        private void Frm_Alar_Load(object sender, EventArgs e)
        {
            if (Common.nole == "操作员")
            {
                lbl_QX.Text = Common.nole;
            }
            else if (Common.nole == "技术员")
            {
                lbl_QX.Text = Common.nole;
            }
            else if (Common.nole == "管理员")
            {
                lbl_QX.Text = Common.nole;
            }
        }

        private void Frm_Alar_FormClosed(object sender, FormClosedEventArgs e)
        {
            mytime.Enabled = false;
            Common.List_Count = 0;

        }

        private void Mytime_Tick(object sender, EventArgs e)
        {
            //把得到的星期转换成中文
            switch (DateTime.Now.DayOfWeek.ToString())
            {
                case "Monday": weekstr = "星期一"; break;
                case "Tuesday": weekstr = "星期二"; break;
                case "Wednesday": weekstr = "星期三"; break;
                case "Thursday": weekstr = "星期四"; break;
                case "Friday": weekstr = "星期五"; break;
                case "Saturday": weekstr = "星期六"; break;
                case "Sunday": weekstr = "星期日"; break;
            }
            lbl_timeweek.Text = DateTime.Now.ToString();
            lbl_week.Text = weekstr;

            //更新PLC连接状态
            pcb_PLC_Connect.BackColor = Common.PLC_Connect ? Color.Transparent : Color.Red;
            lbl_PLC_Connect.Text = Common.PLC_Connect ? "系统已连接" : "系统未连接";
            lbl_PLC_Connect.ForeColor = Common.PLC_Connect ? Color.Lime : Color.Red;

            //检测连接的设备有没有全部连接网线
            if (Common.PLC_Connect)
            {
                if (Common.Err_WX)
                {
                    if (!M3)
                    {
                        lbl_WX.Visible = true;
                        M3 = true;
                    }
                    else
                    {
                        lbl_WX.Visible = false;
                        M3 = false;
                    }
                }
                else
                {
                    lbl_WX.Visible = false;
                    M3 = false;
                }
            }

            //刷新实时报警数据
            if(Common.List_Count!= Common.V_Err_List.Items.Count)
            {
                try
                {
                    //更新报警日志
                    lstInfo.Items.Clear();
                    //把listview数据给中间件
                    for (int i = 0; i < Common.V_Err_List.Items.Count; i++)
                    {
                        lstInfo.Items.Add(Common.V_Err_List.Items[i].Text, Common.V_Err_List.Items[i].ImageIndex);
                    }
                    Common.List_Count = Common.V_Err_List.Items.Count;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
        }

        //清除报警记录
        private void lbl_clear_baojing_Click(object sender, EventArgs e)
        {
            try
            {
                if ( Common.nole == "技术员" || Common.nole == "管理员")
                {
                    lstInfo.Items.Clear();
                    Common.V_Err_List.Items.Clear();
                    Common.List_Count = 0;
                    MessageBox.Show("把实时报警记录成功清除", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("用户权限不够不能操作控制", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("清空报警记录时出错,错误信息: " + ex, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbl_save_err_log_Click(object sender, EventArgs e)
        {
            if (Common.nole == "技术员" || Common.nole == "管理员")
            {
                try
                {
                    //带写数据导出
                    for (int i = 0; i < Common.V_Err_List.Items.Count; i++)
                    {
                        Common.WriteLog(Common.V_Err_List.Items[i].Text.ToString());
                    }
                    MessageBox.Show("把数据记录成功导出", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("导出报警记录时出错,错误信息: " + ex, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("用户权限不够不能操作控制", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               
        }


        //查询数据显示到数据表
        private void btn_Select_ErrDate_Click(object sender, EventArgs e)
        {
            if (Common.nole == "技术员" || Common.nole == "管理员")
            {
                try
                {

                    string sql = "Select * from AlarmDate where time between {0} and {1} order by time DESC";

                    sql = string.Format(sql, '"' + this.dpt_Start.Text + '"', '"' + this.dpt_End.Text + '"');

                    this.dgv_Log.DataSource = null;

                    this.dgv_Log.DataSource = SQLiteHelper.GetDataSet(sql).Tables[0];

                    this.dgv_Log.Columns[0].Width = 270;
                    this.dgv_Log.Columns[1].Width = 500;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("现在的权限不支持该操作,请联系管理员或者技术员 ", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            
        }

        //导出报表
        private void lbl_write_LogDate_Click(object sender, EventArgs e)
        {
            if (Common.nole == "技术员" || Common.nole == "管理员")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XLS文件(*.xls)|*.xls|所有文件|*.*";//设置保存文件的类型
                sfd.FileName = "历史日志导出Excel";
                sfd.DefaultExt = "xls";
                sfd.AddExtension = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (NiceExcelSaveAndRead.SaveToExcelNew(sfd.FileName, this.dgv_Log))
                    {
                        MessageBox.Show("历史日志导出成功！", "日志导出");
                    }

                    else
                    {
                        MessageBox.Show("历史日志导出失败！", "日志导出");
                    }

                }
            }
            else
            {
                MessageBox.Show("现在的权限不支持该操作,请联系管理员或者技术员 ", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        //切换权限
        private void lbl_QX_qh_Click(object sender, EventArgs e)
        {
            QX_qh objFrm = new QX_qh();
            objFrm.ShowDialog();
            if (Common.nole == "操作员")
            {
                lbl_QX.Text = Common.nole;
            }
            else if (Common.nole == "技术员")
            {
                lbl_QX.Text = Common.nole;
            }
            else if (Common.nole == "管理员")
            {
                lbl_QX.Text = Common.nole;
            }
        }
    }
}
