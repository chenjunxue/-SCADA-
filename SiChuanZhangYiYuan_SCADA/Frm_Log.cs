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
    public partial class Frm_Log : Form
    {
        public Frm_Log()
        {
            InitializeComponent();
            SQLiteHelper.ConStr = "Data Source=" + Application.StartupPath + "\\datebase\\SiChuanZhangYiYuan_Scada;Pooling=true;FailIfMissing=false";
        }
        private Point mPoint;
        //登录
        private void btn_log_Click(object sender, EventArgs e)
        {
            //执行查询
            //判断用户ID和用户密码的正确性
            if (this.txt_name.Text.Trim().Length == 0)
            {
                MessageBox.Show("请填写账号", "登录提示");
                this.txt_name.Focus();
                return;
            }

            if (this.txt_pwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请填写登录密码", "登录提示");
                this.txt_pwd.Focus();
                return;
            }

            if (txt_name.Text.Length>0 && txt_pwd.Text.Length>0)
            {
                //封装对象
                Admins objAdmin = new Admins()
                {
                    name = this.txt_name.Text.Trim(),
                    pwd = this.txt_pwd.Text.Trim()
                };

                //查询数据库
                objAdmin = AdminLogin(objAdmin);

                if (objAdmin == null)
                {
                    MessageBox.Show("用户名或密码错误！", "登录提示");
                    this.txt_pwd.Focus();
                    return;

                }
                else
                {
                    Common.nole = objAdmin.nole;
                    this.DialogResult = DialogResult.OK;
                }
            }


        }

        //查询数据库账号密码
        private Admins AdminLogin(Admins objAdmin)
        {
            string sql = "Select nole from Admins where name='{0}' and pwd='{1}'";

            sql = string.Format(sql, objAdmin.name, objAdmin.pwd);

            DataSet ds = SQLiteHelper.GetDataSet(sql);

            if (ds != null && ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 1)
            {
                objAdmin.nole = ds.Tables[0].Rows[0]["nole"].ToString();
                return objAdmin;
            }
            else
            {
                return null;
            }
        }

        //退出
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //移动窗口
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
    }
}
