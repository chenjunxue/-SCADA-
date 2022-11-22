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
    public partial class QX_qh : Form
    {
        public QX_qh()
        {
            InitializeComponent();
        }

        private void QX_qh_Load(object sender, EventArgs e)
        {
            if (Common.nole == "操作员")
            {
                lbl_qx.Text = Common.nole;
            }
            else if (Common.nole == "技术员")
            {
                lbl_qx.Text = Common.nole;
            }
            else if (Common.nole == "管理员")
            {
                lbl_qx.Text = Common.nole;
            }
        }

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

            if (txt_name.Text.Length > 0 && txt_pwd.Text.Length > 0)
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
                    MessageBox.Show("用户名或密码错误！", "权限切换提示");
                    this.txt_pwd.Focus();
                    return;

                }
                else
                {
                    Common.nole = objAdmin.nole;
                    this.Close();
                }
            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
