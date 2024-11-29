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
    public partial class frmFactura : Form
    {
        string NombreBoton;

        SqlConnection con2;
        SqlDataAdapter adpFacturas;
        DataTable dtFacturas;

        public frmFactura()
        {
            InitializeComponent();
        }

        public frmFactura(SqlConnection con)
        {
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 142, 168);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            con2 = con;
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {

            try
            {
                adpFacturas = new SqlDataAdapter();
                dtFacturas = new DataTable();

                adpFacturas.SelectCommand = new SqlCommand("spSelectFactura", con2);
                adpFacturas.SelectCommand.CommandType = CommandType.StoredProcedure;
                adpFacturas.Fill(dtFacturas);
                dataGridView1.DataSource = dtFacturas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el grid: " + ex.Message);
            }
            
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
