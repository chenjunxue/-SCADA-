using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiChuanZhangYiYuan_SCADA
{
    public partial class Frm_Admins : Form
    {
        public Frm_Admins()
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
        private bool select_OK;

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

        }

        private void Frm_Admins_Load(object sender, EventArgs e)
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

            //读取App配置文件
            this.txt_Err_path.Text = ConfigurationManager.AppSettings["Err_log_path"];
            this.txt_PLC_read.Text = ConfigurationManager.AppSettings["PLC_read"];
            this.txt_Date_SC.Text = ConfigurationManager.AppSettings["Date_SC"];

        }


        //增
        private void btn_ADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_name.Text != null && txt_pwd.Text != null && txt_nole.Text != null)
                {
                    string sql = $"insert into Admins (name ,pwd,nole) values ('{txt_name.Text.Trim()}','{txt_pwd.Text.Trim()}','{txt_nole.Text.Trim()}')";
                    int i = SQLiteHelper.Update(sql);
                    if (i == 1)
                    {
                        MessageBox.Show("添加用户成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_Select_Click(null, null);
                        txt_name.Text = "";
                        txt_pwd.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("添加用户失败", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("请输入账号密码", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误消息："+ex.Message, "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
        //查
        private void btn_Select_Click(object sender, EventArgs e)
        {
            string sql = "select * from Admins";

            //查询
            DataTable dt = SQLiteHelper.GetDataSet(sql).Tables[0];


            this.dgv_use.DataSource = dt;

            this.dgv_use.Columns[0].HeaderText = "序号";
            this.dgv_use.Columns[0].Width = 80;

            this.dgv_use.Columns[1].HeaderText = "登录名";
            this.dgv_use.Columns[1].Width = 250;


            this.dgv_use.Columns[2].HeaderText = "密码";
            this.dgv_use.Columns[2].Width = 250;

            this.dgv_use.Columns[3].HeaderText = "权限";
            this.dgv_use.Columns[3].Width = 100;

            select_OK = true;
        }
        //改
        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                int id_index = 0;
                if (!select_OK)
                {
                    MessageBox.Show("未打开用户信息表不能进行删除的数据记录操作", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    id_index = Convert.ToInt16(dgv_use.CurrentRow.Cells["ID"].Value);
                }
                if (txt_name.Text == null || txt_pwd.Text == null || txt_nole.Text == null)
                {
                    MessageBox.Show("账号，密码，权限不能为空必须输入正确的字符", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sql = $"update Admins SET name='{txt_name.Text}',pwd='{txt_pwd.Text}',nole='{txt_nole.Text}'  where id = {id_index}";
                int i = SQLiteHelper.Update(sql);
                if (i == 1)
                {
                    MessageBox.Show("修改用户成功", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Select_Click(null, null);
                    txt_name.Text = "";
                    txt_pwd.Text = "";
                }
                else
                {
                    MessageBox.Show("修改用户失败", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误消息：" + ex.Message, "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //删
        private void btn_Del_Click(object sender, EventArgs e)
        {
            int id_index = 0;
            try
            {
                if (!select_OK)
                {
                    MessageBox.Show("未打开用户信息表不能进行删除的数据记录操作", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                     id_index = Convert.ToInt16(dgv_use.CurrentRow.Cells["id"].Value);
                }

                string sql = $"delete from Admins where ID = {id_index}";
                int i = SQLiteHelper.Update(sql);
                if (i == 1)
                {
                    MessageBox.Show("删除用户成功", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Select_Click(null, null);
                    txt_name.Text = "";
                    txt_pwd.Text = "";
                }
                else
                {
                    MessageBox.Show("删除用户失败", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误消息：" + ex.Message, "错误消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        //修改配置参数
        private void btn_write_App_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(this.txt_PLC_read.Text.Trim(), out int i))
                {
                    MessageBox.Show("输入的值必须为整数", "配置写入提示");
                    return;
                }
                if (!int.TryParse(this.txt_Date_SC.Text.Trim(), out int iii))
                {
                    MessageBox.Show("输入的值必须为整数", "配置写入提示");
                    return;
                }

                System.Configuration.Configuration cafa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //写入配置
                cafa.AppSettings.Settings["Date_SC"].Value = this.txt_Date_SC.Text.Trim();
                cafa.AppSettings.Settings["PLC_read"].Value = this.txt_PLC_read.Text.Trim();
                cafa.AppSettings.Settings["Err_log_path"].Value = this.txt_Err_path.Text.Trim();

                cafa.Save();
                ConfigurationManager.RefreshSection("appSettings");
                MessageBox.Show("配置文件修改成功,请重启软件后生效", "修改成功后提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("配置文件修改失败", "失败提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
