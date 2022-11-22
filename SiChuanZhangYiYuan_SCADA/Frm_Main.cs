using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xktComm;
using xktComm.Common;

namespace SiChuanZhangYiYuan_SCADA
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private Point mPoint;
        private xktComm.SiemensS7 Scada_10 = new SiemensS7();
        private bool LP1_Err0 = false, LP1_Err1 = false, LP1_Err2 = false, LP1_Err3 = false, LP1_Err4 = false, LP1_Err5 = false;
        private bool SL1_Err0 = false, SL1_Err1 = false, SL1_Err2 = false, SL1_Err3 = false, SL1_Err4 = false, SL1_Err5 = false, SL1_Err6 = false, SL1_Err7 = false;
        private bool SL2_Err0 = false, SL2_Err1 = false, SL2_Err2 = false, SL2_Err3 = false, SL2_Err4 = false, SL2_Err5 = false, SL2_Err6 = false, SL2_Err7 = false;
        private bool XG5_Err0 = false, XG5_Err1 = false, XG5_Err2 = false, XG5_Err3 = false, XG5_Err4 = false, XG5_Err5 = false, XG5_Err6 = false;



        private bool TB6_Err0 = false, TB6_Err1 = false, TB6_Err2 = false, TB6_Err3 = false, TB6_Err4 = false, TB6_Err5 = false;
        private bool ZH7_Err0 = false, ZH7_Err1 = false, ZH7_Err2 = false, ZH7_Err3 = false, ZH7_Err4 = false, ZH7_Err5 = false, ZH7_Err6 = false;
        private bool ZH7_Err7 = false, ZH7_Err8 = false, ZH7_Err9 = false, ZH7_Err10 = false, ZH7_Err11 = false, ZH7_Err12 = false, ZH7_Err13 = false;

        private bool Datewrite = false;


        private void Frm_Main_Load(object sender, EventArgs e)
        {
            btn_View_Click(null, null);

            Datewrite = true;

            Task tskPLC = Task.Run(() =>
            {
                Get_PLC_Statue();
            });

            Task Write_Date = Task.Run(() =>
            {
                WriteDate();
            });

        }

        #region 读取PLC变量
        private void Get_PLC_Statue()
        {
            //初始化连接
            Common.PLC_Connect= Scada_10.Connect("192.168.0.10", CPU_Type.S7200SMART, 0, 0);

            while (Datewrite)
            {
                object V0_0 = Scada_10.Read("DB1.DBX0.0", VarType.Bit);
                if (Common.PLC_Connect)
                {
                    if(V0_0==null)
                    {
                        Common.PLC_Connect = false;
                    }
                    else
                    {
                        //如果true就是有一处或者多出网线断开
                        object Err_WX = Scada_10.Read("M0.1", VarType.Bit);
                        Common.Err_WX = Convert.ToBoolean(Err_WX);

                        //读取数据
                        #region 理瓶数据
                        object VD0 = Scada_10.Read("DB1.DBD0", VarType.Real);
                        Common.VD0 = Convert.ToInt32(VD0).ToString();

                        object VD4 = Scada_10.Read("DB1.DBD4", VarType.DWord);
                        Common.VD4 = Convert.ToUInt32(VD4).ToString();

                        object Run_V8_0 = Scada_10.Read("DB1.DBX8.0", VarType.Bit);
                        Common.Run_V8_0 = Convert.ToBoolean(Run_V8_0);

                        object Err_V9_0 = Scada_10.Read("DB1.DBX9.0", VarType.Bit);
                        Common.Err_V9_0 = Convert.ToBoolean(Err_V9_0);
                        object Err_V9_1 = Scada_10.Read("DB1.DBX9.1", VarType.Bit);
                        Common.Err_V9_1 = Convert.ToBoolean(Err_V9_1);

                        object Err_V9_2 = Scada_10.Read("DB1.DBX9.2", VarType.Bit);
                        Common.Err_V9_2 = Convert.ToBoolean(Err_V9_2);

                        object Err_V9_3 = Scada_10.Read("DB1.DBX9.3", VarType.Bit);
                        Common.Err_V9_3 = Convert.ToBoolean(Err_V9_3);

                        object Err_V9_4 = Scada_10.Read("DB1.DBX9.4", VarType.Bit);
                        Common.Err_V9_4 = Convert.ToBoolean(Err_V9_4);

                        object Err_V9_5 = Scada_10.Read("DB1.DBX9.5", VarType.Bit);
                        Common.Err_V9_5 = Convert.ToBoolean(Err_V9_5);

                        //报警1
                        if (Common.Err_V9_0 && !LP1_Err0)
                        {
                            Common.AddLog_Err(2, "理瓶机-急停按下");
                            LP1_Err0 = true;
                        }
                        else if (LP1_Err0 && !Common.Err_V9_0)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-急停恢复");
                            LP1_Err0 = false;
                        }

                        //报警2
                        if (Common.Err_V9_1&&!LP1_Err1)
                        {
                            Common.AddLog_Err(1, "理瓶机-堵瓶报警");
                            LP1_Err1 = true;
                        }
                        else if(LP1_Err1 && !Common.Err_V9_1)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-堵瓶畅通");
                            LP1_Err1 = false;
                        }

                        //报警3
                        if (Common.Err_V9_2 && !LP1_Err2)
                        {
                            Common.AddLog_Err(1, "理瓶机-满瓶报警");
                            LP1_Err2 = true;
                        }
                        else if (LP1_Err2 && !Common.Err_V9_2)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-满瓶消除正常运行");
                            LP1_Err2 = false;
                        }

                        //报警4
                        if (Common.Err_V9_3 && !LP1_Err3)
                        {
                            Common.AddLog_Err(2, "理瓶机-理瓶电机故障");
                            LP1_Err3 = true;
                        }
                        else if (LP1_Err3 && !Common.Err_V9_3)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-理瓶电机恢复");
                            LP1_Err3 = false;
                        }

                        //报警5
                        if (Common.Err_V9_4 && !LP1_Err4)
                        {
                            Common.AddLog_Err(2, "理瓶机-送瓶电机故障");
                            LP1_Err4 = true;
                        }
                        else if (LP1_Err4 && !Common.Err_V9_4)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-送瓶电机恢复");
                            LP1_Err4 = false;
                        }

                        //报警6
                        if (Common.Err_V9_5 && !LP1_Err5)
                        {
                            Common.AddLog_Err(2, "理瓶机-料仓缺瓶报警");
                            LP1_Err5 = true;
                        }
                        else if (LP1_Err5 && !Common.Err_V9_5)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-料仓有瓶");
                            LP1_Err5 = false;
                        }

                        #endregion

                        #region 数粒1数据
                        object VW10 = Scada_10.Read("DB1.DBW10", VarType.Word);
                        Common.VW10 = Convert.ToInt16(VW10).ToString();

                        object VW12 = Scada_10.Read("DB1.DBW12", VarType.Word);
                        Common.VW12 = Convert.ToInt16(VW12).ToString();

                        object Run_V14_0 = Scada_10.Read("DB1.DBX14.0", VarType.Bit);
                        Common.Run_V14_0 = Convert.ToBoolean(Run_V14_0);

                        object Err_V15_0 = Scada_10.Read("DB1.DBX15.0", VarType.Bit);
                        Common.Err_V15_0 = Convert.ToBoolean(Err_V15_0);

                        object Err_V15_1 = Scada_10.Read("DB1.DBX15.1", VarType.Bit);
                        Common.Err_V15_1 = Convert.ToBoolean(Err_V15_1);

                        object Err_V15_2 = Scada_10.Read("DB1.DBX15.2", VarType.Bit);
                        Common.Err_V15_2 = Convert.ToBoolean(Err_V15_2);

                        object Err_V15_3 = Scada_10.Read("DB1.DBX15.3", VarType.Bit);
                        Common.Err_V15_3 = Convert.ToBoolean(Err_V15_3);

                        object Err_V15_4 = Scada_10.Read("DB1.DBX15.4", VarType.Bit);
                        Common.Err_V15_4 = Convert.ToBoolean(Err_V15_4);

                        object Err_V15_5 = Scada_10.Read("DB1.DBX15.5", VarType.Bit);
                        Common.Err_V15_5 = Convert.ToBoolean(Err_V15_5);

                        object Err_V15_6 = Scada_10.Read("DB1.DBX15.6", VarType.Bit);
                        Common.Err_V15_6 = Convert.ToBoolean(Err_V15_6);

                        object Err_V15_7 = Scada_10.Read("DB1.DBX15.7", VarType.Bit);
                        Common.Err_V15_7 = Convert.ToBoolean(Err_V15_7);

                        //报警1
                        if (Common.Err_V15_0 && !SL1_Err0)
                        {
                            Common.AddLog_Err(2, "数粒机1-急停按下");
                            SL1_Err0 = true;
                        }
                        else if (SL1_Err0 && !Common.Err_V15_0)
                        {
                            Common.AddLog_Err(0, "数粒机1-报警消除-急停恢复");
                            SL1_Err0 = false;
                        }

                        //报警2
                        if (Common.Err_V15_1 && !SL1_Err1)
                        {
                            Common.AddLog_Err(2, "数粒机1-气压不足");
                            SL1_Err1 = true;
                        }
                        else if (SL1_Err1 && !Common.Err_V15_1)
                        {
                            Common.AddLog_Err(0, "数粒机1-报警消除-气压恢复");
                            SL1_Err1 = false;
                        }

                        //报警3
                        if (Common.Err_V15_2 && !SL1_Err2)
                        {
                            Common.AddLog_Err(1, "数粒机1-堵瓶报警");
                            SL1_Err2 = true;
                        }
                        else if (SL1_Err2 && !Common.Err_V15_2)
                        {
                            Common.AddLog_Err(0, "数粒机1-报警消除-堵瓶恢复");
                            SL1_Err2 = false;
                        }

                        //报警4
                        if (Common.Err_V15_3 && !SL1_Err3)
                        {
                            Common.AddLog_Err(1, "数粒机1-暂停按下");
                            SL1_Err3 = true;
                        }
                        else if (SL1_Err3 && !Common.Err_V15_3)
                        {
                            Common.AddLog_Err(0, "数粒机1-报警消除-暂停恢复");
                            SL1_Err3 = false;
                        }

                        //报警5
                        if (Common.Err_V15_4 && !SL1_Err4)
                        {
                            Common.AddLog_Err(1, "数粒机1-左输送带缺瓶");
                            SL1_Err4 = true;
                        }
                        else if (SL1_Err4 && !Common.Err_V15_4)
                        {
                            Common.AddLog_Err(0, "数粒机1-报警消除-左输送带有瓶");
                            SL1_Err4 = false;
                        }

                        //报警6
                        if (Common.Err_V15_5 && !SL1_Err5)
                        {
                            Common.AddLog_Err(1, "数粒机1-左输送带缺瓶");
                            SL1_Err5 = true;
                        }
                        else if (SL1_Err5 && !Common.Err_V15_5)
                        {
                            Common.AddLog_Err(0, "数粒机1-报警消除-右输送带有瓶");
                            SL1_Err5 = false;
                        }

                        //报警7
                        if (Common.Err_V15_6 && !SL1_Err6)
                        {
                            Common.AddLog_Err(2, "数粒机1-机架到上限位");
                            SL1_Err6 = true;
                        }
                        else if (SL1_Err6 && !Common.Err_V15_6)
                        {
                            Common.AddLog_Err(0, "数粒机1-报警消除-离开上限位");
                            SL1_Err6 = false;
                        }

                        //报警8
                        if (Common.Err_V15_7 && !SL1_Err7)
                        {
                            Common.AddLog_Err(2, "数粒机1-机架到下限位");
                            SL1_Err7 = true;
                        }
                        else if (SL1_Err7 && !Common.Err_V15_7)
                        {
                            Common.AddLog_Err(0, "数粒机1-报警消除-离开下限位");
                            SL1_Err7 = false;
                        }

                        
                        #endregion

                        #region 数粒2数据
                        object VW20 = Scada_10.Read("DB1.DBW20", VarType.Word);
                        Common.VW20 = Convert.ToInt16(VW20).ToString();

                        object VW22 = Scada_10.Read("DB1.DBW22", VarType.Word);
                        Common.VW22 = Convert.ToInt16(VW22).ToString();

                        object Run_V24_0 = Scada_10.Read("DB1.DBX24.0", VarType.Bit);
                        Common.Run_V24_0 = Convert.ToBoolean(Run_V24_0);

                        object Err_V25_0 = Scada_10.Read("DB1.DBX25.0", VarType.Bit);
                        Common.Err_V25_0 = Convert.ToBoolean(Err_V25_0);

                        object Err_V25_1 = Scada_10.Read("DB1.DBX25.1", VarType.Bit);
                        Common.Err_V25_1 = Convert.ToBoolean(Err_V25_1);

                        object Err_V25_2 = Scada_10.Read("DB1.DBX25.2", VarType.Bit);
                        Common.Err_V25_2 = Convert.ToBoolean(Err_V25_2);

                        object Err_V25_3 = Scada_10.Read("DB1.DBX25.3", VarType.Bit);
                        Common.Err_V25_3 = Convert.ToBoolean(Err_V25_3);

                        object Err_V25_4 = Scada_10.Read("DB1.DBX25.4", VarType.Bit);
                        Common.Err_V25_4 = Convert.ToBoolean(Err_V25_4);

                        object Err_V25_5 = Scada_10.Read("DB1.DBX25.5", VarType.Bit);
                        Common.Err_V25_5 = Convert.ToBoolean(Err_V25_5);

                        object Err_V25_6 = Scada_10.Read("DB1.DBX25.6", VarType.Bit);
                        Common.Err_V25_6 = Convert.ToBoolean(Err_V25_6);

                        object Err_V25_7 = Scada_10.Read("DB1.DBX25.7", VarType.Bit);
                        Common.Err_V25_7 = Convert.ToBoolean(Err_V25_7);

                        //报警1
                        if (Common.Err_V25_0 && !SL2_Err0)
                        {
                            Common.AddLog_Err(2, "数粒机2-急停按下");
                            SL2_Err0 = true;
                        }
                        else if (SL2_Err0 && !Common.Err_V25_0)
                        {
                            Common.AddLog_Err(0, "数粒机2-报警消除-急停恢复");
                            SL2_Err0 = false;
                        }

                        //报警2
                        if (Common.Err_V25_1 && !SL2_Err1)
                        {
                            Common.AddLog_Err(2, "数粒机2-气压不足");
                            SL1_Err2 = true;
                        }
                        else if (SL2_Err1 && !Common.Err_V25_1)
                        {
                            Common.AddLog_Err(0, "数粒机2-报警消除-气压恢复");
                            SL2_Err1 = false;
                        }

                        //报警3
                        if (Common.Err_V25_2 && !SL2_Err2)
                        {
                            Common.AddLog_Err(1, "数粒机2-堵瓶报警");
                            SL2_Err2 = true;
                        }
                        else if (SL2_Err2 && !Common.Err_V25_2)
                        {
                            Common.AddLog_Err(0, "数粒机2-报警消除-堵瓶恢复");
                            SL2_Err2 = false;
                        }

                        //报警4
                        if (Common.Err_V25_3 && !SL2_Err3)
                        {
                            Common.AddLog_Err(1, "数粒机2-暂停按下");
                            SL2_Err3 = true;
                        }
                        else if (SL2_Err3 && !Common.Err_V25_3)
                        {
                            Common.AddLog_Err(0, "数粒机2-报警消除-暂停恢复");
                            SL2_Err3 = false;
                        }

                        //报警5
                        if (Common.Err_V25_4 && !SL2_Err4)
                        {
                            Common.AddLog_Err(1, "数粒机2-左输送带缺瓶");
                            SL2_Err4 = true;
                        }
                        else if (SL2_Err4 && !Common.Err_V25_4)
                        {
                            Common.AddLog_Err(0, "数粒机2-报警消除-左输送带有瓶");
                            SL2_Err4 = false;
                        }

                        //报警6
                        if (Common.Err_V25_5 && !SL2_Err5)
                        {
                            Common.AddLog_Err(1, "数粒机2-左输送带缺瓶");
                            SL2_Err5 = true;
                        }
                        else if (SL2_Err5 && !Common.Err_V25_5)
                        {
                            Common.AddLog_Err(0, "数粒机2-报警消除-右输送带有瓶");
                            SL2_Err5 = false;
                        }

                        //报警7
                        if (Common.Err_V25_6 && !SL2_Err6)
                        {
                            Common.AddLog_Err(2, "数粒机2-机架到上限位");
                            SL2_Err6 = true;
                        }
                        else if (SL2_Err6 && !Common.Err_V25_6)
                        {
                            Common.AddLog_Err(0, "数粒机2-报警消除-离开上限位");
                            SL2_Err6 = false;
                        }

                        //报警8
                        if (Common.Err_V25_7 && !SL2_Err7)
                        {
                            Common.AddLog_Err(2, "数粒机2-机架到下限位");
                            SL2_Err7 = true;
                        }
                        else if (SL2_Err7 && !Common.Err_V25_7)
                        {
                            Common.AddLog_Err(0, "数粒机2-报警消除-离开下限位");
                            SL2_Err7 = false;
                        }

                       
                        #endregion

                        #region 旋盖数据
                        object VD50 = Scada_10.Read("DB1.DBD50", VarType.Real);
                        Common.VD50 = Convert.ToInt32(VD50).ToString();

                        object VD54 = Scada_10.Read("DB1.DBD54", VarType.DWord);
                        Common.VD54 = Convert.ToUInt32(VD54).ToString();

                        object Run_V58_0 = Scada_10.Read("DB1.DBX58.0", VarType.Bit);
                        Common.Run_V58_0 = Convert.ToBoolean(Run_V58_0);

                        object Err_V59_0 = Scada_10.Read("DB1.DBX59.0", VarType.Bit);
                        Common.Err_V59_0 = Convert.ToBoolean(Err_V59_0);

                        object Err_V59_1 = Scada_10.Read("DB1.DBX59.1", VarType.Bit);
                        Common.Err_V59_1 = Convert.ToBoolean(Err_V59_1);

                        object Err_V59_2 = Scada_10.Read("DB1.DBX59.2", VarType.Bit);
                        Common.Err_V59_2 = Convert.ToBoolean(Err_V59_2);

                        object Err_V59_3 = Scada_10.Read("DB1.DBX59.3", VarType.Bit);
                        Common.Err_V59_3 = Convert.ToBoolean(Err_V59_3);

                        object Err_V59_4 = Scada_10.Read("DB1.DBX59.4", VarType.Bit);
                        Common.Err_V59_4 = Convert.ToBoolean(Err_V59_4);

                        object Err_V59_5 = Scada_10.Read("DB1.DBX59.5", VarType.Bit);
                        Common.Err_V59_5 = Convert.ToBoolean(Err_V59_5);

                        object Err_V59_6 = Scada_10.Read("DB1.DBX59.6", VarType.Bit);
                        Common.Err_V59_6 = Convert.ToBoolean(Err_V59_6);

                        //报警1
                        if (Common.Err_V59_0 && !XG5_Err0)
                        {
                            Common.AddLog_Err(2, "旋盖机-急停按下");
                            XG5_Err0 = true;
                        }
                        else if (XG5_Err0 && !Common.Err_V59_0)
                        {
                            Common.AddLog_Err(0, "旋盖机-报警消除-急停恢复");
                            XG5_Err0 = false;
                        }

                        //报警2
                        if (Common.Err_V59_1 && !XG5_Err1)
                        {
                            Common.AddLog_Err(1, "旋盖机-缺盖报警");
                            XG5_Err1 = true;
                        }
                        else if (XG5_Err1 && !Common.Err_V59_1)
                        {
                            Common.AddLog_Err(0, "旋盖机-报警消除-缺盖恢复");
                            XG5_Err1 = false;
                        }

                        //报警3
                        if (Common.Err_V59_2 && !XG5_Err2)
                        {
                            Common.AddLog_Err(1, "旋盖机-堵盖报警");
                            XG5_Err2 = true;
                        }
                        else if (XG5_Err2 && !Common.Err_V59_2)
                        {
                            Common.AddLog_Err(0, "旋盖机-报警消除-堵盖恢复");
                            XG5_Err2 = false;
                        }

                        //报警4
                        if (Common.Err_V59_3 && !XG5_Err3)
                        {
                            Common.AddLog_Err(2, "旋盖机-旋盖电机故障");
                            XG5_Err3 = true;
                        }
                        else if (XG5_Err3 && !Common.Err_V59_3)
                        {
                            Common.AddLog_Err(0, "旋盖机-报警消除-旋盖电机恢复");
                            XG5_Err3 = false;
                        }

                        //报警5
                        if (Common.Err_V59_4 && !XG5_Err4)
                        {
                            Common.AddLog_Err(2, "旋盖机-夹瓶电机故障");
                            XG5_Err4 = true;
                        }
                        else if (XG5_Err4 && !Common.Err_V59_4)
                        {
                            Common.AddLog_Err(0, "旋盖机-报警消除-夹瓶电机恢复");
                            XG5_Err4 = false;
                        }

                        //报警6
                        if (Common.Err_V59_5 && !XG5_Err5)
                        {
                            Common.AddLog_Err(2, "旋盖机-理盖电机故障");
                            XG5_Err5 = true;
                        }
                        else if (XG5_Err5 && !Common.Err_V59_5)
                        {
                            Common.AddLog_Err(0, "旋盖机-报警消除-理盖电机恢复");
                            XG5_Err5 = false;
                        }

                        //报警7
                        if (Common.Err_V59_6 && !XG5_Err6)
                        {
                            Common.AddLog_Err(3, "旋盖机-输送电机故障");
                            XG5_Err6 = true;
                        }
                        else if (XG5_Err6 && !Common.Err_V59_6)
                        {
                            Common.AddLog_Err(0, "旋盖机-报警消除-输送电机恢复");
                            XG5_Err6 = false;
                        }


                       

                        #endregion

                        #region 贴标数据
                        object VD60 = Scada_10.Read("DB1.DBD60", VarType.Real);
                        Common.VD60 = Convert.ToInt32(VD60).ToString();

                        object VD64 = Scada_10.Read("DB1.DBD64", VarType.DWord);
                        Common.VD64 = Convert.ToUInt32(VD64).ToString();

                        object Run_V68_0 = Scada_10.Read("DB1.DBX68.0", VarType.Bit);
                        Common.Run_V68_0 = Convert.ToBoolean(Run_V68_0);

                        object Err_V69_0 = Scada_10.Read("DB1.DBX69.0", VarType.Bit);
                        Common.Err_V69_0 = Convert.ToBoolean(Err_V69_0);

                        object Err_V69_1 = Scada_10.Read("DB1.DBX69.1", VarType.Bit);
                        Common.Err_V69_1 = Convert.ToBoolean(Err_V69_1);

                        object Err_V69_2 = Scada_10.Read("DB1.DBX69.2", VarType.Bit);
                        Common.Err_V69_2 = Convert.ToBoolean(Err_V69_2);

                        object Err_V69_3 = Scada_10.Read("DB1.DBX69.3", VarType.Bit);
                        Common.Err_V69_3 = Convert.ToBoolean(Err_V69_3);

                        object Err_V69_4 = Scada_10.Read("DB1.DBX69.4", VarType.Bit);
                        Common.Err_V69_4 = Convert.ToBoolean(Err_V69_4);

                        object Err_V69_5 = Scada_10.Read("DB1.DBX69.5", VarType.Bit);
                        Common.Err_V69_5 = Convert.ToBoolean(Err_V69_5);

                        //报警1
                        if (Common.Err_V69_0 && !TB6_Err0)
                        {
                            Common.AddLog_Err(2, "贴标机-急停按下");
                            TB6_Err0 = true;
                        }
                        else if (TB6_Err0 && !Common.Err_V69_0)
                        {
                            Common.AddLog_Err(0, "贴标机-报警消除-急停恢复");
                            TB6_Err0 = false;
                        }

                        //报警2
                        if (Common.Err_V69_1 && !TB6_Err1)
                        {
                            Common.AddLog_Err(2, "贴标机-色带不足报警");
                            TB6_Err1 = true;
                        }
                        else if (TB6_Err1 && !Common.Err_V69_1)
                        {
                            Common.AddLog_Err(0, "贴标机-报警消除-色带满足恢复");
                            TB6_Err1 = false;
                        }

                        //报警3
                        if (Common.Err_V69_2 && !TB6_Err2)
                        {
                            Common.AddLog_Err(2, "贴标机-伺服报警");
                            TB6_Err2 = true;
                        }
                        else if (TB6_Err2 && !Common.Err_V69_2)
                        {
                            Common.AddLog_Err(0, "贴标机-报警消除-伺服恢复");
                            TB6_Err2 = false;
                        }

                        //报警4
                        if (Common.Err_V69_3 && !TB6_Err3)
                        {
                            Common.AddLog_Err(2, "贴标机-滚标电机故障");
                            TB6_Err3 = true;
                        }
                        else if (TB6_Err3 && !Common.Err_V69_3)
                        {
                            Common.AddLog_Err(0, "贴标机-报警消除-滚标电机恢复");
                            TB6_Err3 = false;
                        }

                        //报警5
                        if (Common.Err_V69_4 && !TB6_Err4)
                        {
                            Common.AddLog_Err(2, "贴标机-输送电机故障");
                            TB6_Err4 = true;
                        }
                        else if (TB6_Err4 && !Common.Err_V69_4)
                        {
                            Common.AddLog_Err(0, "贴标机-报警消除-输送电机恢复");
                            TB6_Err4 = false;
                        }

                        //报警6
                        if (Common.Err_V69_5 && !TB6_Err5)
                        {
                            Common.AddLog_Err(2, "贴标机-标签不足报警");
                            TB6_Err5 = true;
                        }
                        else if (TB6_Err5 && !Common.Err_V69_5)
                        {
                            Common.AddLog_Err(0, "贴标机-报警消除-预存标签恢复");
                            TB6_Err5 = false;
                        }

                        

                        #endregion

                        #region 装盒数据
                        object VW70 = Scada_10.Read("DB1.DBW70", VarType.Word);
                        Common.VW70 = Convert.ToUInt16(VW70).ToString();

                        object VD74 = Scada_10.Read("DB1.DBD74", VarType.DWord);
                        Common.VD74 = Convert.ToUInt32(VD74).ToString();

                        object Run_V78_7 = Scada_10.Read("DB1.DBX78.7", VarType.Bit);
                        Common.Run_V78_7 = Convert.ToBoolean(Run_V78_7);


                        object Err_V79_1 = Scada_10.Read("DB1.DBX79.1", VarType.Bit);
                        Common.Err_V79_1 = Convert.ToBoolean(Err_V79_1);

                        object Err_V79_2 = Scada_10.Read("DB1.DBX79.2", VarType.Bit);
                        Common.Err_V79_2 = Convert.ToBoolean(Err_V79_2);

                        object Err_V79_3 = Scada_10.Read("DB1.DBX79.3", VarType.Bit);
                        Common.Err_V79_3 = Convert.ToBoolean(Err_V79_3);

                        object Err_V79_4 = Scada_10.Read("DB1.DBX79.4", VarType.Bit);
                        Common.Err_V79_4 = Convert.ToBoolean(Err_V79_4);

                        object Err_V79_5 = Scada_10.Read("DB1.DBX79.5", VarType.Bit);
                        Common.Err_V79_5 = Convert.ToBoolean(Err_V79_5);

                        object Err_V80_0 = Scada_10.Read("DB1.DBX80.0", VarType.Bit);
                        Common.Err_V80_0 = Convert.ToBoolean(Err_V80_0);

                        object Err_V80_1 = Scada_10.Read("DB1.DBX80.1", VarType.Bit);
                        Common.Err_V80_1 = Convert.ToBoolean(Err_V80_1);

                        object Err_V80_2 = Scada_10.Read("DB1.DBX80.2", VarType.Bit);
                        Common.Err_V80_2 = Convert.ToBoolean(Err_V80_2);

                        object Err_V80_3 = Scada_10.Read("DB1.DBX80.3", VarType.Bit);
                        Common.Err_V80_3 = Convert.ToBoolean(Err_V80_3);

                        object Err_V80_4 = Scada_10.Read("DB1.DBX80.4", VarType.Bit);
                        Common.Err_V80_4 = Convert.ToBoolean(Err_V80_4);

                        object Err_V80_6 = Scada_10.Read("DB1.DBX80.6", VarType.Bit);
                        Common.Err_V80_6 = Convert.ToBoolean(Err_V80_6);

                        object Err_V80_7 = Scada_10.Read("DB1.DBX80.7", VarType.Bit);
                        Common.Err_V80_7 = Convert.ToBoolean(Err_V80_7);

                        object Err_V81_0 = Scada_10.Read("DB1.DBX81.0", VarType.Bit);
                        Common.Err_V81_0 = Convert.ToBoolean(Err_V81_0);

                        object Err_V81_1 = Scada_10.Read("DB1.DBX81.1", VarType.Bit);
                        Common.Err_V81_1 = Convert.ToBoolean(Err_V81_1);

                        //报警1
                        if (Common.Err_V79_1 && !ZH7_Err0)
                        {
                            Common.AddLog_Err(2, "装盒机-无料吸盒保护");
                            ZH7_Err0 = true;
                        }
                        else if (ZH7_Err0 && !Common.Err_V79_1)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-有料吸盒恢复");
                            ZH7_Err0 = false;
                        }

                        //报警2
                        if (Common.Err_V79_2 && !ZH7_Err1)
                        {
                            Common.AddLog_Err(1, "装盒机-踢废异常");
                            ZH7_Err1 = true;
                        }
                        else if (ZH7_Err1 && !Common.Err_V79_2)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-踢废异常恢复");
                            ZH7_Err1 = false;
                        }

                        //报警3
                        if (Common.Err_V79_3 && !ZH7_Err2)
                        {
                            Common.AddLog_Err(2, "装盒机-门保护报警");
                            ZH7_Err2 = true;
                        }
                        else if (ZH7_Err2 && !Common.Err_V79_3)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-门保护恢复");
                            ZH7_Err2 = false;
                        }

                        //报警4
                        if (Common.Err_V79_4 && !ZH7_Err3)
                        {
                            Common.AddLog_Err(1, "装盒机-输送带缺料");
                            ZH7_Err3 = true;
                        }
                        else if (ZH7_Err3 && !Common.Err_V79_4)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-输送带缺料恢复");
                            ZH7_Err3 = false;
                        }

                        //报警5
                        if (Common.Err_V79_5 && !ZH7_Err4)
                        {
                            Common.AddLog_Err(2, "装盒机-输送带堵料报警");
                            ZH7_Err4 = true;
                        }
                        else if (ZH7_Err4 && !Common.Err_V79_5)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-输送带堵料恢复");
                            ZH7_Err4 = false;
                        }

                        //报警6
                        if (Common.Err_V80_0 && !ZH7_Err5)
                        {
                            Common.AddLog_Err(2, "装盒机-变频器报警");
                            ZH7_Err5 = true;
                        }
                        else if (ZH7_Err5 && !Common.Err_V80_0)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-变频器恢复");
                            ZH7_Err5 = false;
                        }

                        //报警7
                        if (Common.Err_V80_1 && !ZH7_Err6)
                        {
                            Common.AddLog_Err(2, "装盒机-缺说明书");
                            ZH7_Err6 = true;
                        }
                        else if (ZH7_Err6 && !Common.Err_V80_1)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-说明书足够恢复");
                            ZH7_Err6 = false;
                        }

                        //报警8
                        if (Common.Err_V80_2 && !ZH7_Err7)
                        {
                            Common.AddLog_Err(2, "装盒机-纸盒未到位报警");
                            ZH7_Err7 = true;
                        }
                        else if (ZH7_Err7 && !Common.Err_V80_2)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-纸盒到位恢复");
                            ZH7_Err7 = false;
                        }

                        //报警9
                        if (Common.Err_V80_3 && !ZH7_Err8)
                        {
                            Common.AddLog_Err(2, "装盒机-入盒退料保护报警");
                            ZH7_Err8 = true;
                        }
                        else if (ZH7_Err8 && !Common.Err_V80_3)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-入盒退料恢复");
                            ZH7_Err8 = false;
                        }

                        //报警10
                        if (Common.Err_V80_4 && !ZH7_Err9)
                        {
                            Common.AddLog_Err(2, "装盒机-推瓶子过载报警");
                            ZH7_Err9 = true;
                        }
                        else if (ZH7_Err9 && !Common.Err_V80_4)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-推瓶子过载恢复");
                            ZH7_Err9 = false;
                        }

                        //报警11
                        if (Common.Err_V80_6 && !ZH7_Err10)
                        {
                            Common.AddLog_Err(2, "装盒机-急停报警");
                            ZH7_Err10 = true;
                        }
                        else if (ZH7_Err10 && !Common.Err_V80_6)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-急停恢复");
                            ZH7_Err10 = false;
                        }

                        //报警12
                        if (Common.Err_V80_7 && !ZH7_Err11)
                        {
                            Common.AddLog_Err(2, "装盒机-气压报警");
                            ZH7_Err11 = true;
                        }
                        else if (ZH7_Err11 && !Common.Err_V80_7)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-气压报警恢复");
                            ZH7_Err11 = false;
                        }

                        //报警13
                        if (Common.Err_V81_0 && !ZH7_Err12)
                        {
                            Common.AddLog_Err(2, "装盒机-说明书下限报警");
                            ZH7_Err12 = true;
                        }
                        else if (ZH7_Err12 && !Common.Err_V81_0)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-说明书下限恢复");
                            ZH7_Err12 = false;
                        }

                        //报警14
                        if (Common.Err_V80_1 && !ZH7_Err13)
                        {
                            Common.AddLog_Err(2, "装盒机-纸盒下限报警");
                            ZH7_Err13 = true;
                        }
                        else if (ZH7_Err13 && !Common.Err_V80_1)
                        {
                            Common.AddLog_Err(0, "理瓶机-报警消除-纸盒下限恢复");
                            ZH7_Err13 = false;
                        }

                        
                        #endregion
                    }
                }
                else
                {
                    //理瓶机断线重连
                    if (Scada_10.Connect("192.168.0.10", CPU_Type.S7200SMART, 0, 0))
                    {
                        Common.PLC_Connect = true;
                    }
                }

                //线程停止时间-数据刷新时间
                Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["PLC_read"]));
            }

        }
        #endregion

        #region 写入数据线程
        private void WriteDate()
        {
            int nuber = 0;
            bool LP1Runfirst = false, SL1Runfirst = false, SL2Runfirst = false, XG5Runfirst = false, TB6Runfirst = false, ZH7_Runfirst = false;
            while (Datewrite)
            {
                if(!LP1Runfirst && Common.Run_V8_0)
                {
                    LP1Runfirst = true;
                }
                if (!SL1Runfirst && Common.Run_V14_0)
                {
                    LP1Runfirst = true;
                }
                if (!SL2Runfirst && Common.Run_V24_0)
                {
                    LP1Runfirst = true;
                }
                if (!XG5Runfirst && Common.Run_V58_0)
                {
                    LP1Runfirst = true;
                }
                if (!TB6Runfirst && Common.Run_V68_0)
                {
                    LP1Runfirst = true;
                }
                if (!ZH7_Runfirst && Common.Run_V78_7)
                {
                    LP1Runfirst = true;
                }
                //全部没运行停止数据写入
                if(!Common.Run_V8_0&& !Common.Run_V14_0 && !Common.Run_V24_0 && !Common.Run_V58_0 && !Common.Run_V68_0 && !Common.Run_V78_7)
                {
                    LP1Runfirst = false;
                    SL1Runfirst = false;
                    SL2Runfirst = false;
                    XG5Runfirst = false;
                    TB6Runfirst = false;
                    ZH7_Runfirst = false;
                }

                //制药有一台运行就数据写入
                if(LP1Runfirst|| SL1Runfirst || SL2Runfirst || XG5Runfirst || TB6Runfirst || ZH7_Runfirst)
                {
                    string sql = "insert into ReportDate (time,LP1_WorkNuber,LP1_WorkSpeed,SJ16D_1_WorkNuber,SJ16D_1_WorkSpeed,SJ16D_2_WorkNuber,SJ16D_2_WorkSpeed,XG5_WorkNuber,XG5_WorkSpeed,TB6_WorkNuber,TB6_WorkSpeed,ZH7_WorkNuber,ZH7_WorkSpeed) " +
               $"values ('{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}','{Common.VD4}','{Common.VD0}','{Common.VW12}','{Common.VW10}','{Common.VW22}','{Common.VW20}','{Common.VD54}','{Common.VD50}','{Common.VD64}','{Common.VD60}','{Common.VD74}','{Common.VW70}')";

                    try
                    {
                        nuber = SQLiteHelper.Update(sql);
                        if(nuber == 1)
                        {
                            Common.writeSQL_Date = Common.writeSQL_Date + 1;
                            lbl_Write_SQLDate.Text = Common.writeSQL_Date.ToString();
                            nuber = 0;
                        }
                        
                    }
                    catch (Exception)
                    {
                        nuber = 0;
                        throw;
                    }
                }


                //线程停止时间-数据写入时间
                Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["Date_SC"]));
            }
        }
        #endregion

        #region 一些帮助方法
        //移动窗体
        private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }
        private void splitContainer1_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        //关闭窗体
        private bool CloseWindow(Form Frm)
        {
            bool Res = false;
            foreach (Control ct in this.main_panal.Controls)
            {
                if (ct is Form frm)
                {
                    if (frm.Name == Frm.Name)
                    {
                        Res = true;
                        break;
                    }
                    else
                    {
                        frm.Close();
                    }
                }
            }
            return Res;
        }
        //打开窗体
        private void OpenWindow(Form Frm)
        {
            Frm.TopLevel = false;
            Frm.FormBorderStyle = FormBorderStyle.None;
            Frm.Dock = DockStyle.Fill;
            Frm.Parent = this.main_panal;
            //实现标题栏同步切换
            //this.lbl_Title.Text = Frm.Text;
            //实现导航栏按钮同步切换
            //BackColorSet(Frm.Text);
            Frm.Show();
        }


        #endregion

        #region 按钮事件
        //退出按钮
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Datewrite = false;
            Application.Exit();
        }
        private void btn_exit_MouseEnter(object sender, EventArgs e)
        {
            this.btn_exit.Image = Properties.Resources.top_11;
            this.btn_exit.ForeColor = Color.FromArgb(255, 234, 162);
        }
        private void btn_exit_MouseLeave(object sender, EventArgs e)
        {
            this.btn_exit.Image = Properties.Resources.top_10;
            this.btn_exit.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //首页按钮
        private void btn_View_Click(object sender, EventArgs e)
        {
            Frm_View objFrm = new Frm_View();
            if (!CloseWindow(objFrm))
            {
                OpenWindow(objFrm);
                this.btn_View.Image = Properties.Resources.top_03_1;
                this.btn_View.ForeColor = Color.FromArgb(255, 234, 162);

                this.btn_Error.BackgroundImage = Properties.Resources.top_08;
                this.btn_Error.ForeColor = Color.FromArgb(255, 255, 255);
                this.btn_qushi.BackgroundImage = Properties.Resources.top_08;
                this.btn_qushi.ForeColor = Color.FromArgb(255, 255, 255);
                this.btn_report.BackgroundImage = Properties.Resources.top_07;
                this.btn_report.ForeColor = Color.FromArgb(255, 255, 255);
                this.btn_Peizhi.BackgroundImage = Properties.Resources.top_07;
                this.btn_Peizhi.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }
        //报警
        private void btn_Error_Click(object sender, EventArgs e)
        {
            Frm_Alar objFrm = new Frm_Alar();
            if (!CloseWindow(objFrm))
            {
                OpenWindow(objFrm);
                this.btn_Error.BackgroundImage = Properties.Resources.top_09;
                this.btn_Error.ForeColor = Color.FromArgb(255, 234, 162);

                this.btn_View.Image = Properties.Resources.top_03;
                this.btn_View.ForeColor = Color.FromArgb(255, 255, 255);
                this.btn_qushi.BackgroundImage = Properties.Resources.top_08;
                this.btn_qushi.ForeColor = Color.FromArgb(255, 255, 255);
                this.btn_report.BackgroundImage = Properties.Resources.top_07;
                this.btn_report.ForeColor = Color.FromArgb(255, 255, 255);
                this.btn_Peizhi.BackgroundImage = Properties.Resources.top_07;
                this.btn_Peizhi.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }
        //趋势
        private void btn_qushi_Click(object sender, EventArgs e)
        {

                Frm_Qushi objFrm = new Frm_Qushi();
                if (!CloseWindow(objFrm))
                {
                    OpenWindow(objFrm);
                    this.btn_qushi.BackgroundImage = Properties.Resources.top_09;
                    this.btn_qushi.ForeColor = Color.FromArgb(255, 234, 162);

                    this.btn_View.Image = Properties.Resources.top_03;
                    this.btn_View.ForeColor = Color.FromArgb(255, 255, 255);
                    this.btn_Error.BackgroundImage = Properties.Resources.top_08;
                    this.btn_Error.ForeColor = Color.FromArgb(255, 255, 255);
                    this.btn_report.BackgroundImage = Properties.Resources.top_07;
                    this.btn_report.ForeColor = Color.FromArgb(255, 255, 255);
                    this.btn_Peizhi.BackgroundImage = Properties.Resources.top_07;
                    this.btn_Peizhi.ForeColor = Color.FromArgb(255, 255, 255);
                }

            
        }
        //报表
        private void btn_report_Click(object sender, EventArgs e)
        {
            if (true)
            {
                Frm_Report objFrm = new Frm_Report();
                if (!CloseWindow(objFrm))
                {
                    OpenWindow(objFrm);
                    this.btn_report.BackgroundImage = Properties.Resources.top_06;
                    this.btn_report.ForeColor = Color.FromArgb(255, 234, 162);

                    this.btn_Peizhi.BackgroundImage = Properties.Resources.top_07;
                    this.btn_Peizhi.ForeColor = Color.FromArgb(255, 255, 255);
                    this.btn_qushi.BackgroundImage = Properties.Resources.top_08;
                    this.btn_qushi.ForeColor = Color.FromArgb(255, 255, 255);
                    this.btn_Error.BackgroundImage = Properties.Resources.top_08;
                    this.btn_Error.ForeColor = Color.FromArgb(255, 255, 255);
                    this.btn_View.Image = Properties.Resources.top_03;
                    this.btn_View.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }
            else
            {
                MessageBox.Show("用户权限不够不能进行操作控制", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        //配置
        private void btn_Peizhi_Click(object sender, EventArgs e)
        {
            if (Common.nole == "管理员")
            {
                Frm_Admins objFrm = new Frm_Admins();
                if (!CloseWindow(objFrm))
                {
                    OpenWindow(objFrm);

                    this.btn_Peizhi.BackgroundImage = Properties.Resources.top_06;
                    this.btn_Peizhi.ForeColor = Color.FromArgb(255, 234, 162);

                    this.btn_report.BackgroundImage = Properties.Resources.top_07;
                    this.btn_report.ForeColor = Color.FromArgb(255, 255, 255);
                    this.btn_qushi.BackgroundImage = Properties.Resources.top_08;
                    this.btn_qushi.ForeColor = Color.FromArgb(255, 255, 255);
                    this.btn_Error.BackgroundImage = Properties.Resources.top_08;
                    this.btn_Error.ForeColor = Color.FromArgb(255, 255, 255);
                    this.btn_View.Image = Properties.Resources.top_03;
                    this.btn_View.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }
            else
            {
                MessageBox.Show("用户权限不够不能进行操作控制需要-管理员权限", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        #endregion


    }
}
