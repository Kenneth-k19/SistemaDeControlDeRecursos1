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

namespace SistemaDeControlDeRecursos.Reportes.forms
{
    public partial class frmResumenVentasAnual : Form
    {
        public frmResumenVentasAnual()
        {
            InitializeComponent();
        }

        private void frmResumenVentasAnual_Load(object sender, EventArgs e)
        {
            anioPicker.Format = DateTimePickerFormat.Custom;
            anioPicker.CustomFormat = "yyyy";

            int anioActual = DateTime.Now.Year;
            anioPicker.MinDate = new DateTime(anioActual - 2, 1, 1);
            anioPicker.MaxDate = new DateTime(anioActual, 12, 31);

            anioPicker.Value = DateTime.Now;
            anioPicker.ShowUpDown = true;

        }

        private void generarReporte_Click(object sender, EventArgs e)
        {
            var adapter = new spReporteResumenDeVentasAnualTableAdapter();
            var adpTotales = new spTotalVentasAnualTableAdapter();
            DateTime anio = anioPicker.Value;

            DataTable dataTable = adapter.GetData(anio);
            var totalVentasAnual = adpTotales.GetData(anio).FirstOrDefault()?.TotalVentasAnual;

            DataTable totalVentasTable = new DataTable();
            totalVentasTable.Columns.Add("TotalVentasAnual", typeof(float));
            totalVentasTable.Rows.Add(totalVentasAnual);


            var rds = new ReportDataSource("DataSet1", dataTable);



            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", totalVentasTable));

            reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
    }
}
