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
    public partial class frmActividadPorUsuario : Form
    {
        DataTable dtUsuarios;
        DataTable dtReporte;
        public frmActividadPorUsuario()
        {
            InitializeComponent();
            dtUsuarios = new DataTable();


        }

        private void frmActividadPorUsuario_Load(object sender, EventArgs e)
        {
            dtUsuarios = DBAccess.getSelectCommandDT("spTodosUsuariosSelect", null);

            fechaInicioPicker.Format = DateTimePickerFormat.Short;
            fechaInicioPicker.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            fechaInicioPicker.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            fechaInicioPicker.Value = fechaInicioPicker.MinDate;

            fechaFinPicker.Format = DateTimePickerFormat.Short;
            fechaFinPicker.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            fechaFinPicker.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            fechaFinPicker.Value = fechaFinPicker.MaxDate;
            this.reportViewerWnd1.RefreshReport();

            comboUsuario.DataSource = dtUsuarios;
            comboUsuario.DisplayMember = "Nombre";
            comboUsuario.ValueMember = "UsuarioID";
        }

        private void generarReporte_Click(object sender, EventArgs e)
        {
            dtReporte = DBAccess.getSelectCommandDT("spRpActividadPorUsuario", new Dictionary<string, (object valor, ParameterDirection? direccion)> {
                { "@fechaInicial", (fechaInicioPicker.Value.Date, null)},
                {"@fechaFinal", (fechaFinPicker.Value.Date, null)},
                {"@usuarioid", (comboUsuario.SelectedValue, null) }
                }
           );
            ReportDataSource rds = new ReportDataSource("dsActividadUsuarioRDLC", dtReporte);




            reportViewerWnd1.LocalReport.DataSources.Clear();

            ReportParameter[] param = { new ReportParameter("fechaInicial", fechaInicioPicker.Value.Date.ToString()),
                                        new ReportParameter("fechaFinal", fechaFinPicker.Value.Date.ToString()),
                                        new ReportParameter("usuario", comboUsuario.Text)
                                                                                                                };
            reportViewerWnd1.LocalReport.SetParameters(param);


            reportViewerWnd1.LocalReport.DataSources.Add(rds);
            reportViewerWnd1.LocalReport.Refresh();
            reportViewerWnd1.RefreshReport();

            reportViewerWnd1.Visible = true;
        }
    }
}
