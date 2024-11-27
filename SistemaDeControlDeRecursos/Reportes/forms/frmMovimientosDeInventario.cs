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
            //Control de fechas para datetimepicker para seleccion de fecha inicial
            fechaInicioPicker.Format = DateTimePickerFormat.Short;
            DateTime fechaActualPicker1 = DateTime.Now;

            DateTime fechaMinimaPicker1 = new DateTime(fechaActualPicker1.Year - 2, 1, 1); //la fecha mínima sera dos años antes del año actual
            DateTime fechaMaximaPicker1 = new DateTime(fechaActualPicker1.Year, 12, 31);

            fechaInicioPicker.MinDate = fechaMinimaPicker1;
            fechaInicioPicker.MaxDate = fechaMaximaPicker1;
            fechaInicioPicker.Value = fechaInicioPicker.MinDate;

            //Control de fechas para datetimepicker para seleccion de fecha final
            fechaFinPicker.Format = DateTimePickerFormat.Short;
            DateTime fechaActualPicker2 = DateTime.Now;

            DateTime fechaMinimaPicker2 = new DateTime(fechaActualPicker2.Year - 2, 1, 1);
            DateTime fechaMaximaPicker2 = new DateTime(fechaActualPicker2.Year, 12, 31);

            fechaFinPicker.MinDate = fechaMinimaPicker2;
            fechaFinPicker.MaxDate = fechaMaximaPicker2;
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
