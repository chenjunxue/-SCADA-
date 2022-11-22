using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Document = iTextSharp.text.Document;
using Font = iTextSharp.text.Font;

namespace SiChuanZhangYiYuan_SCADA
{
    public partial class Frm_Report : Form
    {
        public Frm_Report()
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

        }

        private void Frm_Report_Load(object sender, EventArgs e)
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

        //查询
        private void select_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Select * from ReportDate where time between {0} and {1} order by time DESC";

                sql = string.Format(sql, '"' + this.start.Text + '"', '"' + this.end.Text + '"');


                //查询
                DataTable dt = SQLiteHelper.GetDataSet(sql).Tables[0];

                ////数据展示到打印表中
                ////List < Date_Report > list= new List<Date_Report>();

                //foreach (DataRow row in dt.Rows)
                //{
                //    Common.list.Add(new Date_Report()
                //    {
                //        time = row["time"].ToString(),
                //        LP1_WorkNuber = row["LP1_WorkNuber"].ToString(),
                //        LP1_WorkSpeed = row["LP1_WorkSpeed"].ToString(),

                //        SJ16D_1_WorkNuber = row["SJ16D_1_WorkNuber"].ToString(),
                //        SJ16D_1_WorkSpeed = row["SJ16D_1_WorkSpeed"].ToString(),

                //        SJ16D_2_WorkNuber = row["SJ16D_2_WorkNuber"].ToString(),
                //        SJ16D_2_WorkSpeed = row["SJ16D_2_WorkSpeed"].ToString(),

                //        XG5_WorkNuber = row["XG5_WorkNuber"].ToString(),
                //        XG5_WorkSpeed = row["XG5_WorkSpeed"].ToString(),

                //        TB6_WorkNuber = row["TB6_WorkNuber"].ToString(),
                //        TB6_WorkSpeed = row["TB6_WorkSpeed"].ToString(),

                //        ZH7_WorkNuber = row["ZH7_WorkNuber"].ToString(),
                //        ZH7_WorkSpeed = row["ZH7_WorkSpeed"].ToString()
                //    });
                //}




                if (dt.Rows.Count > 0)
                {
                    this.dgv_data.DataSource = dt;
                    this.dgv_data.Columns[0].HeaderText = "写入时间";
                    this.dgv_data.Columns[0].Width = 200;

                    this.dgv_data.Columns[1].HeaderText = "理瓶机-产量";
                    this.dgv_data.Columns[1].Width = 110;

                    this.dgv_data.Columns[2].HeaderText = "理瓶机-产速";
                    this.dgv_data.Columns[2].Width = 110;

                    this.dgv_data.Columns[3].HeaderText = "数粒机1-产量";
                    this.dgv_data.Columns[3].Width = 110;

                    this.dgv_data.Columns[4].HeaderText = "数粒机1-产速";
                    this.dgv_data.Columns[4].Width = 110;

                    this.dgv_data.Columns[5].HeaderText = "数粒机2-产量";
                    this.dgv_data.Columns[5].Width = 110;

                    this.dgv_data.Columns[6].HeaderText = "数粒机2-产速";
                    this.dgv_data.Columns[6].Width = 110;

                    this.dgv_data.Columns[7].HeaderText = "旋盖机-产量";
                    this.dgv_data.Columns[7].Width = 110;

                    this.dgv_data.Columns[8].HeaderText = "旋盖机-产速";
                    this.dgv_data.Columns[8].Width = 110;

                    this.dgv_data.Columns[9].HeaderText = "贴标机-产量";
                    this.dgv_data.Columns[9].Width = 110;

                    this.dgv_data.Columns[10].HeaderText = "贴标机-产速";
                    this.dgv_data.Columns[10].Width = 110;

                    this.dgv_data.Columns[11].HeaderText = "装盒机-产量";
                    this.dgv_data.Columns[11].Width = 110;

                    this.dgv_data.Columns[12].HeaderText = "装盒机-产速";
                    this.dgv_data.Columns[12].Width = 110;
                }
                else
                {
                    MessageBox.Show("未查到对应的数据请检查查询数据的时间是否正确！", "查询提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误,报错信息："+ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        //导出excel
        private void btn_expret_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XLS文件(*.xls)|*.xls|所有文件|*.*";//设置保存文件的类型

            string filename = string.Empty;
            filename = this.start.Value.ToString("yyyyMMdd") + "数据报表";

            sfd.FileName = filename;
            sfd.DefaultExt = "xls";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.dgv_data.Columns[0].HeaderText = "写入时间";
                this.dgv_data.Columns[0].Width = 200;

                this.dgv_data.Columns[1].HeaderText = "理瓶机-产量";
                this.dgv_data.Columns[1].Width = 110;

                this.dgv_data.Columns[2].HeaderText = "理瓶机-产速";
                this.dgv_data.Columns[2].Width = 110;

                this.dgv_data.Columns[3].HeaderText = "数粒机1-产量";
                this.dgv_data.Columns[3].Width = 110;

                this.dgv_data.Columns[4].HeaderText = "数粒机1-产速";
                this.dgv_data.Columns[4].Width = 110;

                this.dgv_data.Columns[5].HeaderText = "数粒机2-产量";
                this.dgv_data.Columns[5].Width = 110;

                this.dgv_data.Columns[6].HeaderText = "数粒机2-产速";
                this.dgv_data.Columns[6].Width = 110;

                this.dgv_data.Columns[7].HeaderText = "旋盖机-产量";
                this.dgv_data.Columns[7].Width = 110;

                this.dgv_data.Columns[8].HeaderText = "旋盖机-产速";
                this.dgv_data.Columns[8].Width = 110;

                this.dgv_data.Columns[9].HeaderText = "贴标机-产量";
                this.dgv_data.Columns[9].Width = 110;

                this.dgv_data.Columns[10].HeaderText = "贴标机-产速";
                this.dgv_data.Columns[10].Width = 110;

                this.dgv_data.Columns[11].HeaderText = "装盒机-产量";
                this.dgv_data.Columns[11].Width = 110;

                this.dgv_data.Columns[12].HeaderText = "装盒机-产速";
                this.dgv_data.Columns[12].Width = 110;
                if (NiceExcelSaveAndRead.SaveToExcelNew(sfd.FileName, this.dgv_data))
                {
                    MessageBox.Show("报表导出成功！", "报表导出");
                }

                else
                {
                    MessageBox.Show("报表导出失败！", "报表导出");
                }

            }
        }

        //导出PDF
        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                ExportTOPdf(this.dgv_data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出PDF错误,报错信息：" + ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //导出PDF
        private void ExportTOPdf(DataGridView datagridview)
        {

            ///设置导出字体
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            string FontPath = path + "\\simsun.ttc";
            int FontSize = 10;
            if (File.Exists(FontPath))
            {
                FontPath += ",1";
            }
            else
            {
                MessageBox.Show("无法导出，因为无法取得中文宋体字型。");
                return;
            }


            Boolean cc = false;
            string strFileName;
            SaveFileDialog savFile = new SaveFileDialog();
            savFile.Filter = "PDF文件|.pdf";
            savFile.ShowDialog();
            if (savFile.FileName != "")
            {
                strFileName = savFile.FileName;
            }
            else
            {
                //MessageBox.Show("终止导出", "终止导出", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //初始化一个目标文档类       
            //Document document = new Document();
            //竖排模式,大小为A4，四周边距均为25
            //Document document = new Document(PageSize.A4, 1, 1, 1, 1);
            //横排模式,大小为A4，四周边距均为25
            Document document = new Document(PageSize.A4.Rotate(), 5, 5, 5, 5);

            //调用PDF的写入方法流
            //注意FileMode-Create表示如果目标文件不存在，则创建，如果已存在，则覆盖。
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));

            //创建PDF文档中的字体
            BaseFont baseFont = BaseFont.CreateFont(
                FontPath,
                BaseFont.IDENTITY_H,
                BaseFont.NOT_EMBEDDED);

            //根据字体路径和字体大小属性创建字体
            Font font = new Font(baseFont, FontSize);

            // 添加页脚
            // HeaderFooter footer = new HeaderFooter(new Phrase("-- ", font), new Phrase(" --", font));
            //footer.Border = Rectangle.NO_BORDER;        // 不显示两条横线
            //footer.Alignment = Rectangle.UNDEFINED;  // 让页码居中
            //document.Footer = footer;

            //打开目标文档对象
            document.Open();

            int ColCount = 0;

            //根据数据表内容创建一个PDF格式的表
            for (int j = 0; j < datagridview.Columns.Count; j++)
            {
                if (datagridview.Columns[j].Visible == true)
                {
                    ColCount++;
                }
            }
            PdfPTable table = new PdfPTable(ColCount);

            // GridView的所有数据全输出
            //datagridview.AllowPaging = false;

            // ---------------------------------------------------------------------------
            // 添加表头
            // ---------------------------------------------------------------------------
            // 设置表头背景色
            //table.DefaultCell.BackgroundColor = Color.GRAY;  // OK
            //table.DefaultCell.BackgroundColor = (iTextSharp.text.Color)System.Drawing.Color.FromName("#3399FF"); // NG
            //table.DefaultCell.BackgroundColor = iTextSharp.text.Color;

            table.DefaultCell.BackgroundColor = BaseColor.BLUE;
            // 添加表头，每一页都有表头
            for (int j = 0; j < datagridview.Columns.Count; j++)
            {
                if (datagridview.Columns[j].Visible == true)
                {
                    table.AddCell(new Phrase(datagridview.Columns[j].HeaderText, font));
                }
            }

            // 告诉程序这行是表头，这样页数大于1时程序会自动为你加上表头。
            table.HeaderRows = 1;
            //
            // ---------------------------------------------------------------------------
            // 添加数据
            // ---------------------------------------------------------------------------
            // 设置表体背景色
            table.DefaultCell.BackgroundColor = BaseColor.WHITE;
            //遍历原gridview的数据行
            //写内容  
            for (int j = 0; j < datagridview.Rows.Count; j++)
            {

                for (int k = 0; k < datagridview.Columns.Count; k++)
                {
                    if (datagridview.Rows[j].Cells[k].Visible == true)
                    {
                        try
                        {
                            string value = "";
                            if (datagridview.Rows[j].Cells[k].Value != null)
                            {
                                value = datagridview.Rows[j].Cells[k].Value.ToString();

                            }
                            table.AddCell(new Phrase(value, font));
                        }
                        catch (Exception)
                        {

                            //MessageBox.Show(e.Message);
                            cc = true;
                        }

                    }
                }

            }


            //在目标文档中添加转化后的表数据
            document.Add(table);

            //关闭目标文件
            document.Close();

            //关闭写入流
            writer.Close();

            // Dialog
            if (!cc)
            {
                MessageBox.Show("已生成PDF文件。", "生成成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //private void btn_RDLC_Click(object sender, EventArgs e)
        //{
        //    Frm_RDUC obj = new Frm_RDUC();
        //    obj.ShowDialog();


        //}
    }








}

