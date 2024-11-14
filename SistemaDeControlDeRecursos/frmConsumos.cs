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
    public partial class frmConsumos : Form
    {
        public frmConsumos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmConsumosDetalle frm = new frmConsumosDetalle();
            frm.ShowDialog();
        }

        private void frmConsumos_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmConsumosDetalle frm = new frmConsumosDetalle();
            frm.ShowDialog();
        }
    }
}
