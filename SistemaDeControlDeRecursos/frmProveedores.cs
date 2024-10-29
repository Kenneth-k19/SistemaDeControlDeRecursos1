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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            btnEditar.BackColor = Color.FromArgb(145, 19, 66);
            btnInsertar.BackColor = Color.FromArgb(145, 19, 66);
            btnEliminar.BackColor = Color.FromArgb(145, 19, 66);
        }
    }
}
