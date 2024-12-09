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
        int m, mx, my;

        int FACUTRAID;
        float SUBTOTAL;
        float DESCUENTO;
        float TOTAL;
        float MONTOPAGADO;
        float CAMBIO;

        public frmFacturarFactura()
        {
            InitializeComponent();
        }

        public frmFacturarFactura(int facturaid, float subtotal, float descuento,float total, float montopagado, float cambio)
        {
            InitializeComponent();

            FACUTRAID = facturaid;
            SUBTOTAL = subtotal;
            DESCUENTO = descuento;
            TOTAL = total;
            MONTOPAGADO = montopagado;
            CAMBIO = cambio;

            panel1.BackColor = Color.FromArgb(145, 19, 66);
        }

        private void frmFacturarFactura_Load(object sender, EventArgs e)
        {
            ReportParameter[] parametros = new ReportParameter[]
            {
                new ReportParameter("subtotal",SUBTOTAL.ToString("C2")),
                new ReportParameter("descuento", (DESCUENTO/100).ToString("P0")),
                new ReportParameter("total", TOTAL.ToString("C2")),
                new ReportParameter("montoPagado", MONTOPAGADO.ToString("C2")),
                new ReportParameter("cambio", CAMBIO.ToString("C2"))
            };

            var adpfactura = new spSelectFacturarFacturaTableAdapter();
            var adpfacturadet = new spSelectFacturarFacturaDetTableAdapter();

            DataTable dtFactura = adpfactura.GetData(FACUTRAID);
            DataTable dtFacturaDet = adpfacturadet.GetData(FACUTRAID);

            var rds1 = new ReportDataSource("DataSet1",dtFactura);
            var rds2 = new ReportDataSource("DataSet2",dtFacturaDet);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds1);
            reportViewer1.LocalReport.DataSources.Add(rds2);
            reportViewer1.LocalReport.SetParameters(parametros);

            this.reportViewer1.RefreshReport();
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
