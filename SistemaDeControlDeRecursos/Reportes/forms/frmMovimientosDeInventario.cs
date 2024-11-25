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
   
    public partial class frmMovimientosDeInventario : Form
    {
        DataTable dtReporte;
        public frmMovimientosDeInventario()
        {
            InitializeComponent();
            dtReporte = new DataTable();
        }

        private void frmMovimientosDeInventario_Load(object sender, EventArgs e)
        {
            fechaInicioPicker.Format = DateTimePickerFormat.Short;
            fechaInicioPicker.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            fechaInicioPicker.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            fechaInicioPicker.Value = fechaInicioPicker.MinDate;

            fechaFinPicker.Format = DateTimePickerFormat.Short;
            fechaFinPicker.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            fechaFinPicker.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            fechaFinPicker.Value = fechaFinPicker.MaxDate;
            this.reportViewerWnd1.RefreshReport();
        }

        private void generarReporte_Click(object sender, EventArgs e)
        {
            dtReporte = DBAccess.getSelectCommandDT("rpMovimientosInventario", new Dictionary<string, (object valor, ParameterDirection? direccion)> {
                { "@Des", (fechaInicioPicker.Value.Date, null)},
                {"@has", (fechaFinPicker.Value.Date, null)},
                }
            );

            ReportDataSource rds = new ReportDataSource("dsMovimientosInventario", dtReporte);




            reportViewerWnd1.LocalReport.DataSources.Clear();

            ReportParameter[] param = { new ReportParameter("fechaInicio", fechaInicioPicker.Value.Date.ToString()),
                                        new ReportParameter("fechaFinal", fechaFinPicker.Value.Date.ToString())
                                                                                                                };
            reportViewerWnd1.LocalReport.SetParameters(param);


            reportViewerWnd1.LocalReport.DataSources.Add(rds);
            reportViewerWnd1.LocalReport.Refresh();
            reportViewerWnd1.RefreshReport();

            reportViewerWnd1.Visible = true;
        }
    }
}
