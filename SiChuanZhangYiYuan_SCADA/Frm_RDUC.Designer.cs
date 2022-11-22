
namespace SiChuanZhangYiYuan_SCADA
{
    partial class Frm_RDUC
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Date_ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Date_ReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Date_ReportBindingSource
            // 
            this.Date_ReportBindingSource.DataSource = typeof(SiChuanZhangYiYuan_SCADA.Date_Report);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "ReportDataSet";
            reportDataSource1.Value = this.Date_ReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SiChuanZhangYiYuan_SCADA.DateReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 68);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1217, 679);
            this.reportViewer1.TabIndex = 0;
            // 
            // Frm_RDUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 759);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_RDUC";
            this.Text = "报表打印";
            this.Load += new System.EventHandler(this.Frm_RDUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Date_ReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource Date_ReportBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}