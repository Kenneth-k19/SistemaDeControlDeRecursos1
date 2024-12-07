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

namespace SistemaDeControlDeRecursos
{
    public partial class frmAjusteInventarioDetalle : Form
    {
        SqlDataAdapter adpAjuste,adpArticulo,adpTipoAjuste,adpAjusteDet;
        DataTable tabAjuste,tabArticulo,tabTipoAjuste,tabAjusteDet;

        public frmAjusteInventarioDetalle(int AjusteID)
        {
            InitializeComponent();
        }

        

        private void frmAjusteInventarioDetalle_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(145, 19, 66);

            //lenar combos de articulo y tipoAjuste

            //gridView?

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
