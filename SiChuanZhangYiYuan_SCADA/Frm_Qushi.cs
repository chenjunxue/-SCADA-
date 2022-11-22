using SeeSharpTools.JY.GUI;
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
    public partial class Frm_Qushi : Form
    {
        public Frm_Qushi()
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

            //这里肯定时添加XY数据倒线条上
            List<double> ydata = new List<double>();
            if (Common.PLC_Connect)
            {
                ydata.Add(Convert.ToDouble(Common.VD0));
                ydata.Add(Convert.ToDouble(Common.VW10));
                ydata.Add(Convert.ToDouble(Common.VW20));
                ydata.Add(Convert.ToDouble(Common.VD50));
                ydata.Add(Convert.ToDouble(Common.VD60));
                ydata.Add(Convert.ToDouble(Common.VW70));
            }
            try
            {
                if (Common.PLC_Connect)
                {
                    chart_Trend.PlotSingle(ydata.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("实时数据显示错误,出错信息: " + ex, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Frm_Qushi_Load(object sender, EventArgs e)
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

            //设置Chart属性
            chart_Trend.XDataType = StripChartX.XAxisDataType.TimeStamp;
            chart_Trend.TimeStampFormat = "HH:mm:ss";
            chart_Trend.LegendVisible = true;
            chart_Trend.DisplayPoints = 60;
            chart_Trend.SeriesCount = 6;

            chart_Trend.Series[0].Name = "理瓶机-产速";
            chart_Trend.Series[1].Name = "数粒机1-产速";
            chart_Trend.Series[2].Name = "数粒机2-产速";
            chart_Trend.Series[3].Name = "旋盖机-产速";
            chart_Trend.Series[4].Name = "贴标机-产速";
            chart_Trend.Series[5].Name = "装盒机-产速";

            ckb_LP1_Speed.ForeColor = chart_Trend.Series[0].Color = Color.Red;
            ckb_SL1_Speed.ForeColor = chart_Trend.Series[1].Color = Color.Green;
            ckb_SL2_Speed.ForeColor = chart_Trend.Series[2].Color = Color.Blue;
            ckb_XG5_Speed.ForeColor = chart_Trend.Series[3].Color = Color.Yellow;
            ckb_TB6_Speed.ForeColor = chart_Trend.Series[4].Color = Color.DeepPink;
            ckb_ZH7_Speed.ForeColor = chart_Trend.Series[5].Color = Color.FromArgb(186,134,242);

            chart_Trend.Series[0].Width = StripChartXSeries.LineWidth.Middle;
            chart_Trend.Series[1].Width = StripChartXSeries.LineWidth.Middle;
            chart_Trend.Series[2].Width = StripChartXSeries.LineWidth.Middle;
            chart_Trend.Series[3].Width = StripChartXSeries.LineWidth.Middle;
            chart_Trend.Series[4].Width = StripChartXSeries.LineWidth.Middle;
            chart_Trend.Series[5].Width = StripChartXSeries.LineWidth.Middle;

            chart_Trend.Series[0].Marker = StripChartXSeries.MarkerType.Diamond;
            chart_Trend.Series[1].Marker = StripChartXSeries.MarkerType.Diamond;
            chart_Trend.Series[2].Marker = StripChartXSeries.MarkerType.Diamond;
            chart_Trend.Series[3].Marker = StripChartXSeries.MarkerType.Diamond;
            chart_Trend.Series[4].Marker = StripChartXSeries.MarkerType.Diamond;
            chart_Trend.Series[5].Marker = StripChartXSeries.MarkerType.Diamond;


        }

        private void Frm_Qushi_FormClosed(object sender, FormClosedEventArgs e)
        {
            mytime.Enabled = false;
        }

        //显示数据线路
        private void ckb_LP1_Speed_CheckedChanged(object sender, EventArgs e)
        {
            this.chart_Trend.Series[0].Visible = ckb_LP1_Speed.Checked;
        }

        private void ckb_SL1_Speed_CheckedChanged(object sender, EventArgs e)
        {
            this.chart_Trend.Series[1].Visible = ckb_SL1_Speed.Checked;
        }

        private void ckb_SL2_Speed_CheckedChanged(object sender, EventArgs e)
        {
            this.chart_Trend.Series[2].Visible = ckb_SL2_Speed.Checked;
        }

        private void ckb_XG5_Speed_CheckedChanged(object sender, EventArgs e)
        {
            this.chart_Trend.Series[3].Visible = ckb_XG5_Speed.Checked;

        }

        private void ckb_TB6_Speed_CheckedChanged(object sender, EventArgs e)
        {
            this.chart_Trend.Series[4].Visible = ckb_TB6_Speed.Checked;
        }

        private void ckb_ZH7_Speed_CheckedChanged(object sender, EventArgs e)
        {
            this.chart_Trend.Series[5].Visible = ckb_ZH7_Speed.Checked;
        }

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
