using SistemaDeControlDeRecursos.Reportes.dataSets.dsDetalleVentasDiarioTableAdapters;
using SistemaDeControlDeRecursos.Reportes.dataSets.dsTotalVentasDiariasTableAdapters;
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
    public partial class frmDetalleVentasDiario : Form
    {
        public frmDetalleVentasDiario()
        {
            InitializeComponent();
        }

        private void frmDetalleVentasDiario_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dateTimePicker1.Value.Date;

                var adapter = new spDetalleVentasDiarioTableAdapter();

                var adpTotalVentas = new spTotalVentasDiariasTableAdapter();
                var totalVentasDiarias = adpTotalVentas.GetData().FirstOrDefault()?.TotalVentasDiarias;

                DataTable dtTotalVentas = new DataTable();
                dtTotalVentas.Columns.Add("TotalVentasDiarias",typeof(float));
                dtTotalVentas.Rows.Add(totalVentasDiarias);


                DataTable datatable = adapter.GetData(fecha);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetDVD", datatable));

                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dtTotalVentas));

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
