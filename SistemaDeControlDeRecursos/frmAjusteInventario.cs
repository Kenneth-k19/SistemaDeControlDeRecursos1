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
            frmAjusteInventarioDetalle frm = new frmAjusteInventarioDetalle(-1,conn);
            frm.ShowDialog();
            tabAjuste.Clear();

            adpAjuste.Fill(tabAjuste);
        }

        private void frmAjusteInventario_Load(object sender, EventArgs e)
        {
            adpAjuste = new SqlDataAdapter("spAjusteSelect", conn);
            adpAjuste.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpAjuste.SelectCommand.Parameters.AddWithValue("@AjusteID", 0);
            adpAjuste.Fill(tabAjuste);
            dataGridView1.ReadOnly = true; dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = tabAjuste;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmAjusteInventarioDetalle frm = new frmAjusteInventarioDetalle(id,conn);
            frm.ShowDialog();

            tabAjuste.Clear();
            
            adpAjuste.Fill(tabAjuste);
            dataGridView1.DataSource = tabAjuste;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 0)
                {
                    //usar defaultView de dataTable para filtrar
                    tabAjuste.DefaultView.RowFilter = "";
                }
                else
                {
                    tabAjuste.DefaultView.RowFilter = "Usuario LIKE '%" + textBox1.Text + "%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
