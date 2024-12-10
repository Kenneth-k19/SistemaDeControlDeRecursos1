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
    public partial class frmConsumos : Form
    {
        SqlDataAdapter adpConsumo;
        DataTable tabConsumo;
        SqlConnection conn;

        public frmConsumos(SqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmConsumosDetalle frm = new frmConsumosDetalle();
            frm.ShowDialog();
        }

        private void frmConsumos_Load(object sender, EventArgs e)
        {
            dgvConsumo.ReadOnly = true;
            dgvConsumo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            adpConsumo = new SqlDataAdapter("spConsumoSelect",conn);
            adpConsumo.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabConsumo = new DataTable();
            adpConsumo.Fill(tabConsumo);
            dgvConsumo.DataSource = tabConsumo;


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmConsumosDetalle frm = new frmConsumosDetalle();
            frm.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
