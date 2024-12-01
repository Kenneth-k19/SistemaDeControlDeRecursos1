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
    public partial class frmFacturaDetalle : Form
    {
        SqlConnection Con;
        SqlDataAdapter adpFacturaDet;
        DataTable dtFacturaDet;

        int ID;

        public frmFacturaDetalle()
        {
            InitializeComponent();
        }

        public frmFacturaDetalle(SqlConnection con)
        {
            InitializeComponent();

            txtFacturaID.Enabled = false;
            txtArticuloId.Enabled = false;
            txtArtiNombre.Enabled = false;
            txtCantidad.Enabled = false;
            txtPrecio.Enabled = false;
            txtDescuento.Enabled = false;
            txtReferencia.Enabled = false;
            txtObservacion.Enabled = false;
            btnSeleccionarArticulo.Enabled = false;

            Con = con;
        }

        public frmFacturaDetalle(int id, SqlConnection con)
        {
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 142, 168);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtCodigo.Enabled = false;
            txtFacturaID.Enabled=false;

            try
            {
                adpFacturaDet = new SqlDataAdapter();
                dtFacturaDet = new DataTable();

                adpFacturaDet.SelectCommand = new SqlCommand("spSelectFacturaDet", con);
                adpFacturaDet.SelectCommand.CommandType = CommandType.StoredProcedure;
                adpFacturaDet.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)
                {
                    Value = id
                });

                adpFacturaDet.Fill(dtFacturaDet);
                dataGridView1.DataSource = dtFacturaDet;




                ID = id;
                Con = con;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmFacturaDetalle_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(145, 19, 66);

            txtFacturaID.Text = ID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
