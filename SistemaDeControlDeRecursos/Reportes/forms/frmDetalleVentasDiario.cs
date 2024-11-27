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
            dateTimePicker1.Format = DateTimePickerFormat.Long;
            DateTime fechaActual = DateTime.Now;

            DateTime fechaMinima = new DateTime(fechaActual.Year - 2, 1, 1); //la fecha mínima sera dos años antes del año actual
            DateTime fechaMaxima = new DateTime(fechaActual.Year, 12, 31);

            dateTimePicker1.MinDate = fechaMinima;
            dateTimePicker1.MaxDate = fechaMaxima;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dateTimePicker1.Value.Date;

                var adapter = new spDetalleVentasDiarioTableAdapter();

                var adpTotalVentas = new spTotalVentasDiariasTableAdapter();
                var totalVentasDiarias = adpTotalVentas.GetData(fecha).FirstOrDefault()?.TotalVentasDiarias;

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
