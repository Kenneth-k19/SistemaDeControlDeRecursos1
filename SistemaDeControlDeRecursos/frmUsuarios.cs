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
    public partial class frmUsuarios : Form
    {
        SqlConnection con2;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        public frmUsuarios(SqlConnection con)
        {
            InitializeComponent();

            con2 = con;
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            String nombreBoton = btnInsertar.Text;

            frmIngresarEditarUsuarios frm = new frmIngresarEditarUsuarios(nombreBoton,con2);
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            String nombreBoton = btnEditar.Text;

            frmIngresarEditarUsuarios frm = new frmIngresarEditarUsuarios(nombreBoton, con2);
            frm.ShowDialog();
        }
    }
}
