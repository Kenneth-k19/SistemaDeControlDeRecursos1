using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeControlDeRecursos
{
    public partial class frmFactura : Form
    {
        public frmFactura()
        {
            InitializeComponent();
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            //this.ControlBox = false;   

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            frmFacturaDetalle frm = new frmFacturaDetalle();
            frm.ShowDialog();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            frmFacturaDetalle frm = new frmFacturaDetalle();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
