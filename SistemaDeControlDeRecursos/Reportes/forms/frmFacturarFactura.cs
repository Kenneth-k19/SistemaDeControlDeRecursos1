using Microsoft.Reporting.WinForms;
using SistemaDeControlDeRecursos.Reportes.dataSets.dsFacturarFacturaTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeControlDeRecursos.Reportes.forms
{
    public partial class frmFacturarFactura : Form
    {
        int FACUTRAID;

        public frmFacturarFactura()
        {
            InitializeComponent();
        }

        public frmFacturarFactura(int facturaid)
        {
            InitializeComponent();

            FACUTRAID = facturaid;
        }

        private void frmFacturarFactura_Load(object sender, EventArgs e)
        {
            var adpfactura = new spSelectFacturarFacturaTableAdapter();
            var adpfacturadet = new spSelectFacturarFacturaDetTableAdapter();

            DataTable dtFactura = adpfactura.GetData(FACUTRAID);
            DataTable dtFacturaDet = adpfacturadet.GetData(FACUTRAID);

            var rds1 = new ReportDataSource("DataSet1",dtFactura);
            var rds2 = new ReportDataSource("DataSet2",dtFacturaDet);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds1);
            reportViewer1.LocalReport.DataSources.Add(rds2);

            this.reportViewer1.RefreshReport();
            
        }
    }
}
