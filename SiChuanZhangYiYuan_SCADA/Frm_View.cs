using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiChuanZhangYiYuan_SCADA
{
    public partial class Frm_View : Form
    {
        public Frm_View()
        {
            InitializeComponent();
            mytime = new Timer();
            mytime.Interval = 1000;
            mytime.Tick += Mytime_Tick;
            mytime.Enabled = true;
        }
        private Timer mytime;
        string weekstr = "";
        bool M1 = false, M2 = false;
        bool M3 = false;
        bool M_LP1 = false, M_SL1 = false, M_SL2 = false, M_XG5 = false, M_TB6 = false, M_ZH7 = false;

        

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

            //指示灯控制点位
            if (!M1)
            {               
                pcb_statue_LP1_Run.Image = Properties.Resources.右箭头红;
                pcb_statue_SL1_Run.Image = Properties.Resources.右箭头红;
                pcb_statue_SL2_Run.Image = Properties.Resources.右箭头红;
                pcb_statue_XG5_Run.Image = Properties.Resources.右箭头红;
                pcb_statue_TB6_Run.Image = Properties.Resources.右箭头红;
                pcb_statue_ZH7_Run.Image = Properties.Resources.右箭头红;
                M1 = true;
            }
            else
            {
                if (!M2)
                {
                    if (M_LP1)
                    {
                        pcb_statue_LP1_Run.Image = Properties.Resources.右箭头黄;
                    }
                    if (M_SL1)
                    {
                        pcb_statue_SL1_Run.Image = Properties.Resources.右箭头黄;
                    }
                    if (M_SL2)
                    {
                        pcb_statue_SL2_Run.Image = Properties.Resources.右箭头黄;
                    }
                    if (M_XG5)
                    {
                        pcb_statue_XG5_Run.Image = Properties.Resources.右箭头黄;
                    }
                    if (M_TB6)
                    {
                        pcb_statue_TB6_Run.Image = Properties.Resources.右箭头黄;
                    }
                    if (M_ZH7)
                    {
                        pcb_statue_ZH7_Run.Image = Properties.Resources.右箭头黄;
                    }
                    M2 = true;
                }
                else if (M2)
                {
                    if (M_LP1)
                    {
                        pcb_statue_LP1_Run.Image = Properties.Resources.右箭头绿;
                    }
                    if (M_SL1)
                    {
                        pcb_statue_SL1_Run.Image = Properties.Resources.右箭头绿;
                    }
                    if (M_SL2)
                    {
                        pcb_statue_SL2_Run.Image = Properties.Resources.右箭头绿;
                    }
                    if (M_XG5)
                    {
                        pcb_statue_XG5_Run.Image = Properties.Resources.右箭头绿;
                    }
                    if (M_TB6)
                    {
                        pcb_statue_TB6_Run.Image = Properties.Resources.右箭头绿;
                    }
                    if (M_ZH7)
                    {
                        pcb_statue_ZH7_Run.Image = Properties.Resources.右箭头绿;
                    }
                    
                    M2 = false;
                }
            }

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

            # region 理瓶机指示及图片切换
            //理瓶机指示及图片切换
            if (Common.Run_V8_0 && !Common.Err_V9_0 && !Common.Err_V9_1 && !Common.Err_V9_3 && !Common.Err_V9_4)
            {
                if (lbl_LP1_Statue.Text == "运行")
                {
                    return;
                }
                lbl_LP1_Statue.Text = "运行";
                lbl_LP1_Statue.BackColor = Color.Lime;
                pcb_bg_LP1.Image = Properties.Resources.PumpStateBg_1;
                pcb_statue_LP1.Image = Properties.Resources.PumpState_1;
                M_LP1 = true;
            }
            else if (Common.Err_V9_0 || Common.Err_V9_1 || Common.Err_V9_3 || Common.Err_V9_4)
            {
                lbl_LP1_Statue.Text = "报警";
                lbl_LP1_Statue.BackColor = Color.Yellow;
                pcb_bg_LP1.Image = Properties.Resources.PumpStateBg_2;
                pcb_statue_LP1.Image = Properties.Resources.PumpState_2;
                M_LP1 = false;
                pcb_statue_LP1_Run.Image = Properties.Resources.右箭头红;
            }
            else
            {
                lbl_LP1_Statue.Text = "停止";
                lbl_LP1_Statue.BackColor = Color.Red;
                pcb_bg_LP1.Image = Properties.Resources.PumpStateBg_0;
                pcb_statue_LP1.Image = Properties.Resources.PumpState_0;
                M_LP1 = false;
                pcb_statue_LP1_Run.Image = Properties.Resources.右箭头红;
            }
            //参数赋值
            btn_LP1_Speed.Text = "产速" + "\n\t" + "\n\t" + Common.VD0 + "瓶/分";
            btn_LP1_Nuber.Text = "产量" + "\n\t" + "\n\t" + Common.VD4 + "瓶";
            #endregion

            # region 数粒机1指示及图片切换
            //数粒机1指示及图片切换
            if (Common.Run_V14_0 && !Common.Err_V15_0 && !Common.Err_V15_1 && !Common.Err_V15_2 && !Common.Err_V15_3 && !(Common.Err_V15_4 && Common.Err_V15_5))
            {
                if (lbl_SL1_Statue.Text == "运行")
                {
                    return;
                }
                lbl_SL1_Statue.Text = "运行";
                lbl_SL1_Statue.BackColor = Color.Lime;
                pcb_bg_SL1.Image = Properties.Resources.PumpStateBg_1;
                pcb_statue_SL1.Image = Properties.Resources.PumpState_1;
                M_SL1 = true;
            }
            else if (Common.Err_V15_0 || Common.Err_V15_1 || Common.Err_V15_2 || Common.Err_V15_3 || (Common.Err_V15_4 && Common.Err_V15_5))
            {
                lbl_SL1_Statue.Text = "报警";
                lbl_SL1_Statue.BackColor = Color.Yellow;
                pcb_bg_SL1.Image = Properties.Resources.PumpStateBg_2;
                pcb_statue_SL1.Image = Properties.Resources.PumpState_2;
                M_SL1 = false;
                pcb_statue_SL1_Run.Image = Properties.Resources.右箭头红;
            }
            else
            {
                lbl_SL1_Statue.Text = "停止";
                lbl_SL1_Statue.BackColor = Color.Red;
                pcb_bg_SL1.Image = Properties.Resources.PumpStateBg_0;
                pcb_statue_SL1.Image = Properties.Resources.PumpState_0;
                M_SL1 = false;
                pcb_statue_SL1_Run.Image = Properties.Resources.右箭头红;
            }
            //参数赋值
            btn_SL1_Speed.Text = "产速" + "\n\t" + "\n\t" + Common.VW10 + "瓶/分";
            btn_SL1_Nuber.Text = "产量" + "\n\t" + "\n\t" + Common.VW12 + "瓶";
            #endregion

            # region 数粒机2指示及图片切换
            //数粒机2指示及图片切换
            if (Common.Run_V24_0 && !Common.Err_V25_0 && !Common.Err_V25_1 && !Common.Err_V25_2 && !Common.Err_V25_3 && !(Common.Err_V25_4 && Common.Err_V25_5))
            {
                if (lbl_SL2_Statue.Text == "运行")
                {
                    return;
                }
                lbl_SL2_Statue.Text = "运行";
                lbl_SL2_Statue.BackColor = Color.Lime;
                pcb_bg_SL2.Image = Properties.Resources.PumpStateBg_1;
                pcb_statue_SL2.Image = Properties.Resources.PumpState_1;
                M_SL2 = true;
            }
            else if (Common.Err_V25_0 || Common.Err_V25_1 || Common.Err_V25_2 || Common.Err_V25_3 || (Common.Err_V25_4 && Common.Err_V25_5))
            {
                lbl_SL2_Statue.Text = "报警";
                lbl_SL2_Statue.BackColor = Color.Yellow;
                pcb_bg_SL2.Image = Properties.Resources.PumpStateBg_2;
                pcb_statue_SL2.Image = Properties.Resources.PumpState_2;
                M_SL2 = false;
                pcb_statue_SL2_Run.Image = Properties.Resources.右箭头红;
            }
            else
            {
                lbl_SL2_Statue.Text = "停止";
                lbl_SL2_Statue.BackColor = Color.Red;
                pcb_bg_SL2.Image = Properties.Resources.PumpStateBg_0;
                pcb_statue_SL2.Image = Properties.Resources.PumpState_0;
                M_SL2 = false;
                pcb_statue_SL2_Run.Image = Properties.Resources.右箭头红;
            }
            //参数赋值
            btn_SL2_Speed.Text = "产速" + "\n\t" + "\n\t" + Common.VW20 + "瓶/分";
            btn_SL2_Nuber.Text = "产量" + "\n\t" + "\n\t" + Common.VW22 + "瓶";
            #endregion

            #region 旋盖机机指示及图片切换
            //旋盖机指示及图片切换
            if (Common.Run_V58_0 && !Common.Err_V59_0 && !Common.Err_V59_1 && !Common.Err_V59_3 && !Common.Err_V59_4 && !Common.Err_V59_5 && !Common.Err_V59_6)
            {
                if(lbl_XG5_Statue.Text== "运行")
                {
                    return;
                }
                lbl_XG5_Statue.Text = "运行";
                lbl_XG5_Statue.BackColor = Color.Lime;
                pcb_bg_XG5.Image = Properties.Resources.PumpStateBg_1;
                pcb_statue_XG5.Image = Properties.Resources.PumpState_1;
                M_XG5 = true;
            }
            else if (Common.Err_V59_0 || Common.Err_V59_1 || Common.Err_V59_3 || Common.Err_V59_4 || Common.Err_V59_5 || Common.Err_V59_6)
            {
                lbl_XG5_Statue.Text = "报警";
                lbl_XG5_Statue.BackColor = Color.Yellow;
                pcb_bg_XG5.Image = Properties.Resources.PumpStateBg_2;
                pcb_statue_XG5.Image = Properties.Resources.PumpState_2;
                M_XG5 = false;
                pcb_statue_XG5_Run.Image = Properties.Resources.右箭头红;
            }
            else
            {
                lbl_XG5_Statue.Text = "停止";
                lbl_XG5_Statue.BackColor = Color.Red;
                pcb_bg_XG5.Image = Properties.Resources.PumpStateBg_0;
                pcb_statue_XG5.Image = Properties.Resources.PumpState_0;
                M_XG5 = false;
                pcb_statue_XG5_Run.Image = Properties.Resources.右箭头红;
            }
            //参数赋值
            btn_XG5_Speed.Text = "产速" + "\n\t" + "\n\t" + Common.VD50 + "瓶/分";
            btn_XG5_Nuber.Text = "产量" + "\n\t" + "\n\t" + Common.VD54 + "瓶";
            #endregion

            # region 贴标机指示及图片切换
            //贴标机指示及图片切换
            if (Common.Run_V68_0 && !Common.Err_V69_0 && !Common.Err_V69_1 && !Common.Err_V69_2 && !Common.Err_V69_3 && !Common.Err_V69_4 && !Common.Err_V69_5)
            {
                if (lbl_TB6_Statue.Text == "运行")
                {
                    return;
                }
                lbl_TB6_Statue.Text = "运行";
                lbl_TB6_Statue.BackColor = Color.Lime;
                pcb_bg_TB6.Image = Properties.Resources.PumpStateBg_1;
                pcb_statue_TB6.Image = Properties.Resources.PumpState_1;
                M_TB6 = true;
            }
            else if (Common.Err_V69_0 || Common.Err_V69_1 || Common.Err_V69_2 || Common.Err_V69_3 || Common.Err_V9_4 || Common.Err_V9_5)
            {
                lbl_TB6_Statue.Text = "报警";
                lbl_TB6_Statue.BackColor = Color.Yellow;
                pcb_bg_TB6.Image = Properties.Resources.PumpStateBg_2;
                pcb_statue_TB6.Image = Properties.Resources.PumpState_2;
                M_TB6 = false;
                pcb_statue_TB6_Run.Image = Properties.Resources.右箭头红;
            }
            else
            {
                lbl_TB6_Statue.Text = "停止";
                lbl_TB6_Statue.BackColor = Color.Red;
                pcb_bg_TB6.Image = Properties.Resources.PumpStateBg_0;
                pcb_statue_TB6.Image = Properties.Resources.PumpState_0;
                M_TB6 = false;
                pcb_statue_TB6_Run.Image = Properties.Resources.右箭头红;
            }
            //参数赋值
            btn_TB6_Speed.Text = "产速" + "\n\t" + "\n\t" + Common.VD60 + "瓶/分";
            btn_TB6_Nuber.Text = "产量" + "\n\t" + "\n\t" + Common.VD64 + "瓶";
            #endregion

            # region 装盒机指示及图片切换
            //装盒机指示及图片切换
            if (Common.Run_V78_7 && !Common.Err_V79_1 && !Common.Err_V79_2 && !Common.Err_V79_3 && !Common.Err_V79_4 && !Common.Err_V79_5 && !Common.Err_V80_0 && !Common.Err_V80_1
                 && !Common.Err_V80_2 && !Common.Err_V80_3 && !Common.Err_V80_4 && !Common.Err_V80_6 && !Common.Err_V80_7 && !Common.Err_V81_0 && !Common.Err_V81_1)
            {
                if (lbl_ZH7_Statue.Text == "运行")
                {
                    return;
                }
                lbl_ZH7_Statue.Text = "运行";
                lbl_ZH7_Statue.BackColor = Color.Lime;
                pcb_bg_ZH7.Image = Properties.Resources.PumpStateBg_1;
                pcb_statue_ZH7.Image = Properties.Resources.PumpState_1;
                M_ZH7 = true;
            }
            else if (Common.Err_V79_1 || Common.Err_V79_2 || Common.Err_V79_3 || Common.Err_V79_4 || Common.Err_V79_5 || Common.Err_V80_0 || Common.Err_V80_1
                 || Common.Err_V80_2 || Common.Err_V80_3 || Common.Err_V80_4 || Common.Err_V80_6 || Common.Err_V80_7 || Common.Err_V81_0 || Common.Err_V81_1)
            {
                lbl_ZH7_Statue.Text = "报警";
                lbl_ZH7_Statue.BackColor = Color.Yellow;
                pcb_bg_ZH7.Image = Properties.Resources.PumpStateBg_2;
                pcb_statue_ZH7.Image = Properties.Resources.PumpState_2;
                M_ZH7 = false;
                pcb_statue_ZH7_Run.Image = Properties.Resources.右箭头红;
            }
            else
            {
                lbl_ZH7_Statue.Text = "停止";
                lbl_ZH7_Statue.BackColor = Color.Red;
                pcb_bg_ZH7.Image = Properties.Resources.PumpStateBg_0;
                pcb_statue_ZH7.Image = Properties.Resources.PumpState_0;
                M_ZH7 = false;
                pcb_statue_ZH7_Run.Image = Properties.Resources.右箭头红;
            }
            //参数赋值
            btn_ZH7_Speed.Text = "产速" + "\n\t" + "\n\t" + Common.VW70 + "瓶/分";
            btn_ZH7_Nuber.Text = "产量" + "\n\t" + "\n\t" + Common.VD74 + "瓶";
            #endregion
        }

        private void Frm_View_Load(object sender, EventArgs e)
        {
            if (Common.nole == "操作员")
            {
                lbl_QX.Text = Common.nole;
            }
            else if(Common.nole == "技术员")
            {
                lbl_QX.Text = Common.nole;
            }
            else if (Common.nole == "管理员")
            {
                lbl_QX.Text = Common.nole;
            }
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
