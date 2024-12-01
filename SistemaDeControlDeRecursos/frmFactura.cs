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

        private SqlConnection con2;
        private SqlDataAdapter adpFacturas;
        private DataTable dtFacturas;
        private BindingSource bsFacturas;

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
                bsFacturas = new BindingSource();

                adpFacturas.SelectCommand = new SqlCommand("spSelectFactura", con2);
                adpFacturas.SelectCommand.CommandType = CommandType.StoredProcedure;
                adpFacturas.Fill(dtFacturas);
                bsFacturas.DataSource = dtFacturas;
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
            /* pasamos los valores necesarios al constructor del form e instanciamos y llamamos al form */
            frmFacturaDetalle frm = new frmFacturaDetalle(con2);
            frm.ShowDialog();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            /* obtenemos los valores necesarios para enviar al constructor del form e instanciamos y llamamos al form */
            int id=0;
            var a = dataGridView1.CurrentRow.Cells["FacturaID"].Value;
            if(dataGridView1.CurrentRow != null)
            {
                id = (int) (dataGridView1.CurrentRow.Cells["FacturaID"].Value);
            }

            frmFacturaDetalle frm = new frmFacturaDetalle(id,con2);
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtCodigo.Text.Trim();

            bsFacturas.Filter = $"Codigo like '%{filtro}%'";
        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtTipo.Text.Trim();

            bsFacturas.Filter = $"Tipo like '%{filtro}%'";
        }

        private void txtFecha1_TextChanged(object sender, EventArgs e)
        {

            // Verifica que el texto no esté vacío
            if (string.IsNullOrEmpty(txtFecha1.Text.Trim()))
            {
                bsFacturas.Filter = string.Empty;  // Si no hay texto, no filtra
            }
            else
            {
                // Convertir la columna Fecha a una cadena en formato 'yyyy-MM-dd' y luego aplicar LIKE
                bsFacturas.Filter = $"CONVERT(Fecha, 'System.String') LIKE '%{txtFecha1.Text.Trim()}%'";
            }
        }

        private void txtFecha1_Leave(object sender, EventArgs e)
        {
            
        }

        




        //DateTime fechaSeleccionada;

        //bsFacturas.Filter = $"Fecha = #{fechaSeleccionada:dd/MM/yyyy}#";

    }
}
