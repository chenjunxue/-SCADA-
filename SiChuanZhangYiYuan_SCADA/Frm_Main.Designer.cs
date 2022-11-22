
namespace SiChuanZhangYiYuan_SCADA
{
    partial class Frm_Main
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Peizhi = new System.Windows.Forms.Button();
            this.btn_report = new System.Windows.Forms.Button();
            this.btn_qushi = new System.Windows.Forms.Button();
            this.btn_View = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Error = new System.Windows.Forms.Button();
            this.main_panal = new System.Windows.Forms.Panel();
            this.lbl_Write_SQLDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.top_bg_01;
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Write_SQLDate);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Peizhi);
            this.splitContainer1.Panel1.Controls.Add(this.btn_report);
            this.splitContainer1.Panel1.Controls.Add(this.btn_qushi);
            this.splitContainer1.Panel1.Controls.Add(this.btn_View);
            this.splitContainer1.Panel1.Controls.Add(this.btn_exit);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Error);
            this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel1_MouseDown);
            this.splitContainer1.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel1_MouseMove);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.main_panal);
            this.splitContainer1.Size = new System.Drawing.Size(1700, 900);
            this.splitContainer1.SplitterDistance = 91;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_Peizhi
            // 
            this.btn_Peizhi.BackgroundImage = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.top_07;
            this.btn_Peizhi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Peizhi.FlatAppearance.BorderSize = 0;
            this.btn_Peizhi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Peizhi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Peizhi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Peizhi.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Peizhi.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Peizhi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Peizhi.Location = new System.Drawing.Point(1449, 34);
            this.btn_Peizhi.Name = "btn_Peizhi";
            this.btn_Peizhi.Size = new System.Drawing.Size(128, 43);
            this.btn_Peizhi.TabIndex = 6;
            this.btn_Peizhi.Text = "配置";
            this.btn_Peizhi.UseVisualStyleBackColor = true;
            this.btn_Peizhi.Click += new System.EventHandler(this.btn_Peizhi_Click);
            // 
            // btn_report
            // 
            this.btn_report.BackgroundImage = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.top_07;
            this.btn_report.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_report.FlatAppearance.BorderSize = 0;
            this.btn_report.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_report.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_report.ForeColor = System.Drawing.Color.Transparent;
            this.btn_report.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_report.Location = new System.Drawing.Point(1315, 34);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(128, 43);
            this.btn_report.TabIndex = 5;
            this.btn_report.Text = "报表";
            this.btn_report.UseVisualStyleBackColor = true;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // btn_qushi
            // 
            this.btn_qushi.BackgroundImage = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.top_08;
            this.btn_qushi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_qushi.FlatAppearance.BorderSize = 0;
            this.btn_qushi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_qushi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_qushi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_qushi.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_qushi.ForeColor = System.Drawing.Color.Transparent;
            this.btn_qushi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_qushi.Location = new System.Drawing.Point(259, 34);
            this.btn_qushi.Name = "btn_qushi";
            this.btn_qushi.Size = new System.Drawing.Size(128, 43);
            this.btn_qushi.TabIndex = 4;
            this.btn_qushi.Text = "趋势";
            this.btn_qushi.UseVisualStyleBackColor = true;
            this.btn_qushi.Click += new System.EventHandler(this.btn_qushi_Click);
            // 
            // btn_View
            // 
            this.btn_View.FlatAppearance.BorderSize = 0;
            this.btn_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_View.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_View.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_View.ForeColor = System.Drawing.Color.Transparent;
            this.btn_View.Image = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.top_03;
            this.btn_View.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View.Location = new System.Drawing.Point(3, 30);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(108, 51);
            this.btn_View.TabIndex = 2;
            this.btn_View.Text = "首页";
            this.btn_View.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_exit.ForeColor = System.Drawing.Color.Transparent;
            this.btn_exit.Image = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.top_10;
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.Location = new System.Drawing.Point(1578, 30);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(120, 51);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "关闭";
            this.btn_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            this.btn_exit.MouseEnter += new System.EventHandler(this.btn_exit_MouseEnter);
            this.btn_exit.MouseLeave += new System.EventHandler(this.btn_exit_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(572, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(542, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "浙江龙源双龙Scada数据采集系统";
            // 
            // btn_Error
            // 
            this.btn_Error.BackgroundImage = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.top_08;
            this.btn_Error.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Error.FlatAppearance.BorderSize = 0;
            this.btn_Error.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Error.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Error.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Error.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Error.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Error.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Error.Location = new System.Drawing.Point(125, 34);
            this.btn_Error.Name = "btn_Error";
            this.btn_Error.Size = new System.Drawing.Size(128, 43);
            this.btn_Error.TabIndex = 3;
            this.btn_Error.Text = "报警";
            this.btn_Error.UseVisualStyleBackColor = true;
            this.btn_Error.Click += new System.EventHandler(this.btn_Error_Click);
            // 
            // main_panal
            // 
            this.main_panal.BackColor = System.Drawing.Color.Transparent;
            this.main_panal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panal.Location = new System.Drawing.Point(0, 0);
            this.main_panal.Name = "main_panal";
            this.main_panal.Size = new System.Drawing.Size(1700, 808);
            this.main_panal.TabIndex = 0;
            // 
            // lbl_Write_SQLDate
            // 
            this.lbl_Write_SQLDate.AutoSize = true;
            this.lbl_Write_SQLDate.ForeColor = System.Drawing.Color.White;
            this.lbl_Write_SQLDate.Location = new System.Drawing.Point(0, 0);
            this.lbl_Write_SQLDate.Name = "lbl_Write_SQLDate";
            this.lbl_Write_SQLDate.Size = new System.Drawing.Size(11, 12);
            this.lbl_Write_SQLDate.TabIndex = 7;
            this.lbl_Write_SQLDate.Text = "0";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SiChuanZhangYiYuan_SCADA.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(1700, 900);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主页面";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.Button btn_Error;
        private System.Windows.Forms.Button btn_Peizhi;
        private System.Windows.Forms.Button btn_report;
        private System.Windows.Forms.Button btn_qushi;
        private System.Windows.Forms.Panel main_panal;
        private System.Windows.Forms.Label lbl_Write_SQLDate;
    }
}