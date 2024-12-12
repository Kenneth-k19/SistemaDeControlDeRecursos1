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
            this.rvCompras.RefreshReport();
        }
               
        private void generarReporte_Click(object sender, EventArgs e)
        {
            if (fechaFinPicker.Value.Date < fechaInicioPicker.Value.Date)
            {
                MessageBox.Show("La fecha de final NO DEBE SER MENOR que la fecha inicial." + MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    dtReporteCompras = DBAccess.getSelectCommandDT("spRpComprasPorPeriodo", new Dictionary<string, (object valor, ParameterDirection? direccion)> {
                    {"@fechaInicio", (fechaInicioPicker.Value.Date, null)},
                    {"@fechaFin", (fechaFinPicker.Value.Date, null)},
                    });

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
}
