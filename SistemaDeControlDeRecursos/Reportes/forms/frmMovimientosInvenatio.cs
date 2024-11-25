using Microsoft.Reporting.WinForms;
using SistemaDeControlDeRecursos.Reportes.dataSets.dsResumenVentasAnualTableAdapters;
using SistemaDeControlDeRecursos.Reportes.dataSets.dsTotalVentasAnualTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SistemaDeControlDeRecursos.
namespace SistemaDeControlDeRecursos.Reportes.forms.rpDaniel
{
    public partial class frmMovimientosInvenatio : Form
    {
        public frmMovimientosInvenatio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            //reportViewerWnd1.LocalReport.DataSources.Clear();
            //reportViewerWnd1.LocalReport.DataSources.Add(rds);
            //reportViewerWnd1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", totalVentasTable));

            //reportViewerWnd1.RefreshReport();
        }

        private void frmMovimientosInvenatio_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmMovimientosInvenatio
            // 
            this.ClientSize = new System.Drawing.Size(669, 415);
            this.Name = "frmMovimientosInvenatio";
            this.ResumeLayout(false);

        }
    }
}
