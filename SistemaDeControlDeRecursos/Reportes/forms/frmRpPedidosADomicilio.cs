using Microsoft.Reporting.WinForms;
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
    public partial class frmRpPedidosADomicilio : Form
    {
        DataTable dtReportePedidos;
        public frmRpPedidosADomicilio()
        {
            InitializeComponent();
            dtReportePedidos = new DataTable();
        }

        private void frmRpPedidosADomicilio_Load(object sender, EventArgs e)
        {
            fechaInicioPicker.Format = DateTimePickerFormat.Short;
            fechaInicioPicker.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            fechaInicioPicker.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);

            fechaFinPicker.Format = DateTimePickerFormat.Short;
            fechaFinPicker.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            fechaFinPicker.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            this.rvPedidosDom.RefreshReport();
        }

        private void generarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                dtReportePedidos = DBAccess.getSelectCommandDT("spRpPedidosADomicilio", new Dictionary<string, (object valor, ParameterDirection? direccion)> {
                {"@fechaInicio", (fechaInicioPicker.Value.Date, null)},
                {"@fechaFin", (fechaFinPicker.Value.Date, null)},
                }
            );
                ReportDataSource rds = new ReportDataSource("rdlcDataSetPedidosDom", dtReportePedidos);
                rvPedidosDom.LocalReport.DataSources.Clear();
                ReportParameter[] param = { new ReportParameter("desde", fechaInicioPicker.Value.Date.ToShortDateString()),
                                        new ReportParameter("hasta", fechaFinPicker.Value.Date.ToShortDateString())
                                          };
                rvPedidosDom.LocalReport.SetParameters(param);
                rvPedidosDom.LocalReport.DataSources.Add(rds);
                rvPedidosDom.LocalReport.Refresh();
                rvPedidosDom.RefreshReport();
                rvPedidosDom.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
