using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SistemaDeControlDeRecursos.Reportes.forms
{
    public partial class frmRpComprasPorPeriodo : Form
    {
        DataTable dtReporteCompras;
        public frmRpComprasPorPeriodo()
        {
            InitializeComponent();
            dtReporteCompras = new DataTable();
        }

        private void frmRpComprasPorPeriodo_Load(object sender, EventArgs e)
        {
            fechaInicioPicker.Format = DateTimePickerFormat.Short;
            fechaInicioPicker.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            fechaInicioPicker.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);

            fechaFinPicker.Format = DateTimePickerFormat.Short;
            fechaFinPicker.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            fechaFinPicker.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            this.rvCompras.RefreshReport();
        }
               
        private void generarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                dtReporteCompras = DBAccess.getSelectCommandDT("spRpComprasPorPeriodo", new Dictionary<string, (object valor, ParameterDirection? direccion)> {
                {"@fechaInicio", (fechaInicioPicker.Value.Date, null)},
                {"@fechaFin", (fechaFinPicker.Value.Date, null)},
                }
            );
                ReportDataSource rds = new ReportDataSource("rdlcDataSetCompras", dtReporteCompras);
                rvCompras.LocalReport.DataSources.Clear();
                ReportParameter[] param = { new ReportParameter("desde", fechaInicioPicker.Value.Date.ToShortDateString()),
                                        new ReportParameter("hasta", fechaFinPicker.Value.Date.ToShortDateString())
                                          };
                rvCompras.LocalReport.SetParameters(param);
                rvCompras.LocalReport.DataSources.Add(rds);
                rvCompras.LocalReport.Refresh();
                rvCompras.RefreshReport();
                rvCompras.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
