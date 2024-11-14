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
    public partial class frmFacturaDetalle : Form
    {
        public frmFacturaDetalle()
        {
            InitializeComponent();
        }

        private void frmFacturaDetalle_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(145, 19, 66);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
