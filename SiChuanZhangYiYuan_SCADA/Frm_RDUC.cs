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
    public partial class Frm_RDUC : Form
    {
        public Frm_RDUC()
        {
            InitializeComponent();
        }

        private void Frm_RDUC_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ReportDataSet", Common.list));

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }



    }
}
