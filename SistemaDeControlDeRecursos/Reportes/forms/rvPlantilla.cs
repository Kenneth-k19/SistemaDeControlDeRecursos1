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
    public partial class frmMovimientosInventario : Form
    {
        public frmMovimientosInventario()
        {
            InitializeComponent();
            this.Load += Plantilla_Load;
        }

        private void Plantilla_Load(object sender, EventArgs e)
        {
            fechaInicioPicker.Format = DateTimePickerFormat.Short;
            fechaInicioPicker.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            fechaInicioPicker.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);

            fechaFinPicker.Format = DateTimePickerFormat.Short;
            fechaFinPicker.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            fechaFinPicker.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            this.reportViewerWnd1.RefreshReport();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
