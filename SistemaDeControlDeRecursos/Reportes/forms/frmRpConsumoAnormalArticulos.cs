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
    public partial class frmRpConsumoAnormalArticulos : Form
    {
        DataTable dtReporte;
        public frmRpConsumoAnormalArticulos()
        {
            InitializeComponent();
            dtReporte = new DataTable();
        }

        private void frmRpConsumoAnormalArticulos_Load(object sender, EventArgs e)
        {
            //Control de fechas para datetimepicker para seleccion de fecha inicial            
            fechaInicioPicker.Format = DateTimePickerFormat.Short;

            //fechaInicioPicker.Value = fechaInicioPicker.MinDate.AddMonths(-6);

            //Control de fechas para datetimepicker para seleccion de fecha final
            fechaFinPicker.Format = DateTimePickerFormat.Short;
            DateTime fechaActualPicker2 = DateTime.Now;
            //fechaFinPicker.Value = fechaFinPicker.MaxDate;
            reportViewerWnd1.RefreshReport();
        }

        private void generarReporte_Click(object sender, EventArgs e)
        {

            try
            {
                dtReporte = DBAccess.getSelectCommandDT("rpConsumoAnormalArticulo", new Dictionary<string, (object valor, ParameterDirection? direccion)> {
                {"@des", (fechaInicioPicker.Value.Date, null)},
                {"@has", (fechaFinPicker.Value.Date, null)},
                }
            );
                ReportDataSource rds = new ReportDataSource("DataSet1", dtReporte);
                reportViewerWnd1.LocalReport.DataSources.Clear();
                //ReportParameter[] param = { new ReportParameter("des", fechaInicioPicker.Value.Date.ToShortDateString()),
                //                        new ReportParameter("has", fechaFinPicker.Value.Date.ToShortDateString())
                //                          };

                //reportViewerWnd1.LocalReport.SetParameters(param);
                reportViewerWnd1.LocalReport.DataSources.Add(rds);
                reportViewerWnd1.LocalReport.Refresh();
                reportViewerWnd1.RefreshReport();
                reportViewerWnd1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generarReporte_Click_1(object sender, EventArgs e)
        {
            try
            {
                dtReporte = DBAccess.getSelectCommandDT("rpConsumoAnormalArticulo", new Dictionary<string, (object valor, ParameterDirection? direccion)> {
                {"@des", (fechaInicioPicker.Value.Date, null)},
                {"@has", (fechaFinPicker.Value.Date, null)},
                }
            );
                ReportDataSource rds = new ReportDataSource("DataSet1", dtReporte);
                reportViewerWnd1.LocalReport.DataSources.Clear();
                //ReportParameter[] param = { new ReportParameter("des", fechaInicioPicker.Value.Date.ToShortDateString()),
                //                        new ReportParameter("has", fechaFinPicker.Value.Date.ToShortDateString())
                //                          };

                //reportViewerWnd1.LocalReport.SetParameters(param);
                reportViewerWnd1.LocalReport.DataSources.Add(rds);
                reportViewerWnd1.LocalReport.Refresh();
                reportViewerWnd1.RefreshReport();
                reportViewerWnd1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
