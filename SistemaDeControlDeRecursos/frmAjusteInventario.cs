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
    public partial class frmAjusteInventario : Form
    {
        SqlConnection conn;
        SqlDataAdapter adpAjuste;
        DataTable tabAjuste;
        public frmAjusteInventario( SqlConnection connect)
        {
            InitializeComponent();
            tabAjuste = new DataTable();
            conn = connect;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            frmAjusteInventarioDetalle frm = new frmAjusteInventarioDetalle(-1);
            frm.ShowDialog();
        }

        private void frmAjusteInventario_Load(object sender, EventArgs e)
        {
            adpAjuste = new SqlDataAdapter("spAjusteSelect",)
            dataGridView1.ReadOnly = true;
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tabAjuste.DefaultView.Table.Rows[dataGridView1.SelectedRows[0].Index]["AjusteID"].ToString());
            frmAjusteInventarioDetalle frm = new frmAjusteInventarioDetalle(id);
            frm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
