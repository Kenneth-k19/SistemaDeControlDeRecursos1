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
            frmConsumosDetalle frm = new frmConsumosDetalle(conn,-1);
            frm.ShowDialog();
            refrescarGrid();
        }

        private void frmConsumos_Load(object sender, EventArgs e)
        {
            dgvConsumo.ReadOnly = true;
            dgvConsumo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;            

            adpConsumo = new SqlDataAdapter("spConsumoSelect",conn);
            adpConsumo.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpConsumo.SelectCommand.Parameters.AddWithValue("@ConsumoID", 0);
            tabConsumo = new DataTable();
            adpConsumo.Fill(tabConsumo);
            dgvConsumo.DataSource = tabConsumo;


            dgvConsumo.Columns["ConsumoID"].Visible = false;
            dgvConsumo.Columns["ArticuloID"].Visible = false;
            dgvConsumo.Columns["Articulo"].Width = 200;
            dgvConsumo.Columns["Articulo"].HeaderText = "Plato";
            dgvConsumo.Columns["Observacion"].Width = 200;
            dgvConsumo.AllowUserToAddRows = false;
            dgvConsumo.AllowUserToDeleteRows = false;
            dgvConsumo.ReadOnly = true;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            //obtener el ajusteID de la filaSeleccionada
            int id = Convert.ToInt32(dgvConsumo.CurrentRow.Cells[0].Value.ToString());
            frmConsumosDetalle frm = new frmConsumosDetalle(conn, id);
            frm.ShowDialog();
            refrescarGrid();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text.Length == 0)
                {
                    //usar defaultView de dataTable para filtrar
                    tabConsumo.DefaultView.RowFilter = "";
                }
                else
                {
                    tabConsumo.DefaultView.RowFilter = "Observacion LIKE '%" + txtBuscar.Text + "%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void refrescarGrid()
        {
            adpConsumo = new SqlDataAdapter("spConsumoSelect", conn);
            adpConsumo.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpConsumo.SelectCommand.Parameters.AddWithValue("@ConsumoID", 0);
            tabConsumo = new DataTable();
            adpConsumo.Fill(tabConsumo);
            dgvConsumo.DataSource = tabConsumo;
        }
    }
}
