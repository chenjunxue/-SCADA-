
namespace SiChuanZhangYiYuan_SCADA
{
    partial class Frm_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_PLC_Connect = new System.Windows.Forms.Label();
            this.pcb_PLC_Connect = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_WX = new System.Windows.Forms.Label();
            this.lbl_week = new System.Windows.Forms.Label();
            this.lbl_QX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_timeweek = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.DateTimePicker();
            this.end = new System.Windows.Forms.DateTimePicker();
            this.btn_print = new System.Windows.Forms.Button();
            this.select = new System.Windows.Forms.Button();
            this.btn_expret = new System.Windows.Forms.Button();
            this.lbl_QX_qh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PLC_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(67)))), ((int)(((byte)(123)))));
            this.label3.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(766, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 35);
            this.label3.TabIndex = 9;
            this.label3.Text = "数据报表";
            // 
            // lbl_PLC_Connect
            // 
            this.lbl_PLC_Connect.AutoSize = true;
            this.lbl_PLC_Connect.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PLC_Connect.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_PLC_Connect.ForeColor = System.Drawing.Color.White;
            this.lbl_PLC_Connect.Location = new System.Drawing.Point(1553, 33);
            this.lbl_PLC_Connect.Name = "lbl_PLC_Connect";
            this.lbl_PLC_Connect.Size = new System.Drawing.Size(135, 24);
            this.lbl_PLC_Connect.TabIndex = 8;
            this.lbl_PLC_Connect.Text = "系统已连接";
            // 
            // pcb_PLC_Connect
            // 
            this.pcb_PLC_Connect.BackColor = System.Drawing.Color.Transparent;
            this.pcb_PLC_Connect.Image = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.system_status_06_1;
            this.pcb_PLC_Connect.Location = new System.Drawing.Point(1496, 22);
            this.pcb_PLC_Connect.Name = "pcb_PLC_Connect";
            this.pcb_PLC_Connect.Size = new System.Drawing.Size(51, 45);
            this.pcb_PLC_Connect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_PLC_Connect.TabIndex = 7;
            this.pcb_PLC_Connect.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.nav_03;
            this.pictureBox1.Location = new System.Drawing.Point(536, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(628, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_WX
            // 
            this.lbl_WX.AutoSize = true;
            this.lbl_WX.BackColor = System.Drawing.Color.Transparent;
            this.lbl_WX.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_WX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(2)))));
            this.lbl_WX.Location = new System.Drawing.Point(1181, 17);
            this.lbl_WX.Name = "lbl_WX";
            this.lbl_WX.Size = new System.Drawing.Size(309, 56);
            this.lbl_WX.TabIndex = 84;
            this.lbl_WX.Text = "网络有问题";
            this.lbl_WX.Visible = false;
            // 
            // lbl_week
            // 
            this.lbl_week.AutoSize = true;
            this.lbl_week.BackColor = System.Drawing.Color.Transparent;
            this.lbl_week.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_week.ForeColor = System.Drawing.Color.White;
            this.lbl_week.Location = new System.Drawing.Point(322, 13);
            this.lbl_week.Name = "lbl_week";
            this.lbl_week.Size = new System.Drawing.Size(103, 29);
            this.lbl_week.TabIndex = 89;
            this.lbl_week.Text = "星期一";
            // 
            // lbl_QX
            // 
            this.lbl_QX.AutoSize = true;
            this.lbl_QX.BackColor = System.Drawing.Color.Transparent;
            this.lbl_QX.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_QX.ForeColor = System.Drawing.Color.White;
            this.lbl_QX.Location = new System.Drawing.Point(114, 17);
            this.lbl_QX.Name = "lbl_QX";
            this.lbl_QX.Size = new System.Drawing.Size(103, 29);
            this.lbl_QX.TabIndex = 88;
            this.lbl_QX.Text = "操作员";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 35);
            this.label1.TabIndex = 87;
            this.label1.Text = "权限:";
            // 
            // lbl_timeweek
            // 
            this.lbl_timeweek.AutoSize = true;
            this.lbl_timeweek.BackColor = System.Drawing.Color.Transparent;
            this.lbl_timeweek.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_timeweek.ForeColor = System.Drawing.Color.White;
            this.lbl_timeweek.Location = new System.Drawing.Point(213, 58);
            this.lbl_timeweek.Name = "lbl_timeweek";
            this.lbl_timeweek.Size = new System.Drawing.Size(317, 29);
            this.lbl_timeweek.TabIndex = 86;
            this.lbl_timeweek.Text = "2022/11/16 12:12:12";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.main_bg_03;
            this.pictureBox2.Location = new System.Drawing.Point(12, 112);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1676, 684);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 90;
            this.pictureBox2.TabStop = false;
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.AllowUserToDeleteRows = false;
            this.dgv_data.AllowUserToResizeColumns = false;
            this.dgv_data.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(228)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SeaGreen;
            this.dgv_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_data.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(24)))), ((int)(((byte)(40)))));
            this.dgv_data.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_data.ColumnHeadersHeight = 40;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_data.EnableHeadersVisualStyles = false;
            this.dgv_data.GridColor = System.Drawing.Color.Silver;
            this.dgv_data.Location = new System.Drawing.Point(25, 218);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.ReadOnly = true;
            this.dgv_data.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SeaGreen;
            this.dgv_data.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_data.RowTemplate.Height = 35;
            this.dgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_data.Size = new System.Drawing.Size(1644, 552);
            this.dgv_data.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(175)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(557, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 29);
            this.label2.TabIndex = 95;
            this.label2.Text = "结束时间:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(175)))), ((int)(((byte)(250)))));
            this.label4.Location = new System.Drawing.Point(72, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 29);
            this.label4.TabIndex = 92;
            this.label4.Text = "开始时间:";
            // 
            // start
            // 
            this.start.CalendarFont = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.start.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.start.Location = new System.Drawing.Point(227, 156);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(244, 35);
            this.start.TabIndex = 94;
            // 
            // end
            // 
            this.end.CalendarFont = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.end.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.end.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.end.Location = new System.Drawing.Point(712, 156);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(244, 35);
            this.end.TabIndex = 93;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_print.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_print.Location = new System.Drawing.Point(1521, 148);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(148, 50);
            this.btn_print.TabIndex = 98;
            this.btn_print.Text = "PDF导出";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // select
            // 
            this.select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.select.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.select.Location = new System.Drawing.Point(1151, 148);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(148, 50);
            this.select.TabIndex = 96;
            this.select.Text = "查 询";
            this.select.UseVisualStyleBackColor = false;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // btn_expret
            // 
            this.btn_expret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btn_expret.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_expret.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_expret.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btn_expret.Location = new System.Drawing.Point(1336, 148);
            this.btn_expret.Name = "btn_expret";
            this.btn_expret.Size = new System.Drawing.Size(148, 50);
            this.btn_expret.TabIndex = 97;
            this.btn_expret.Text = "EXCEL导出";
            this.btn_expret.UseVisualStyleBackColor = false;
            this.btn_expret.Click += new System.EventHandler(this.btn_expret_Click);
            // 
            // lbl_QX_qh
            // 
            this.lbl_QX_qh.AutoSize = true;
            this.lbl_QX_qh.BackColor = System.Drawing.Color.Transparent;
            this.lbl_QX_qh.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_QX_qh.ForeColor = System.Drawing.Color.White;
            this.lbl_QX_qh.Location = new System.Drawing.Point(43, 58);
            this.lbl_QX_qh.Name = "lbl_QX_qh";
            this.lbl_QX_qh.Size = new System.Drawing.Size(133, 29);
            this.lbl_QX_qh.TabIndex = 107;
            this.lbl_QX_qh.Text = "切换权限";
            this.lbl_QX_qh.Click += new System.EventHandler(this.lbl_QX_qh_Click);
            // 
            // Frm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1700, 808);
            this.Controls.Add(this.lbl_QX_qh);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.select);
            this.Controls.Add(this.btn_expret);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.start);
            this.Controls.Add(this.end);
            this.Controls.Add(this.dgv_data);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbl_week);
            this.Controls.Add(this.lbl_QX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_timeweek);
            this.Controls.Add(this.lbl_WX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_PLC_Connect);
            this.Controls.Add(this.pcb_PLC_Connect);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Report";
            this.Text = "Frm_Report";
            this.Load += new System.EventHandler(this.Frm_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PLC_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_PLC_Connect;
        private System.Windows.Forms.PictureBox pcb_PLC_Connect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_WX;
        private System.Windows.Forms.Label lbl_week;
        private System.Windows.Forms.Label lbl_QX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_timeweek;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker start;
        private System.Windows.Forms.DateTimePicker end;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.Button btn_expret;
        private System.Windows.Forms.Label lbl_QX_qh;
    }
}