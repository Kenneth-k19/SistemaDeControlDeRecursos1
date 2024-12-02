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
        int usuarioID;

        private SqlConnection con2;
        private SqlDataAdapter adpFacturas;
        private DataTable dtFacturas;
        private BindingSource bsFacturas;

        private SqlDataAdapter adpFacturaTipo;
        private DataTable dtFacturaTipo;

        private SqlDataAdapter adpFacturaConsumo;
        private DataTable dtFacturaConsumo;

        private SqlDataAdapter adpFacturaEstado;
        private DataTable dtFacturaEstado;

        public void inhabilitarCamposFactura()
        {
            textBox2.Enabled = false;
            cmbConsumo.Enabled = false;
            cmbEstado.Enabled = false;
            cmbTipo.Enabled = false;
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
        }

        public void habilitarCamposFactura()
        {
            cmbTipo.Enabled = true;
            cmbConsumo.Enabled = true;
            cmbEstado.Enabled = true;
            textBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        public frmFactura()
        {
            InitializeComponent();
        }

        public frmFactura(SqlConnection con)
        {
            InitializeComponent();

            usuarioID = frmLogin.userID;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 142, 168);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            textBox2.Enabled = false;

            adpFacturas = new SqlDataAdapter();
            dtFacturas = new DataTable();
            bsFacturas = new BindingSource();

            adpFacturas.InsertCommand = new SqlCommand("spInsertarFactura", con);
            adpFacturas.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpFacturas.InsertCommand.Parameters.Add("@codigo", SqlDbType.VarChar,20,"Codigo");
            adpFacturas.InsertCommand.Parameters["@codigo"].Direction = ParameterDirection.Output;
            adpFacturas.InsertCommand.Parameters.Add("@fecha", SqlDbType.DateTime,8,"Fecha");
            adpFacturas.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar,1,"Tipo");
            adpFacturas.InsertCommand.Parameters.Add("@consumo", SqlDbType.VarChar, 1, "Consumo");
            adpFacturas.InsertCommand.Parameters.Add("@usuarioid", SqlDbType.Int, 4, "UsuarioID");
            adpFacturas.InsertCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpFacturas.InsertCommand.Parameters.Add("@descuento", SqlDbType.Float, 4, "Descuento");


            con2 = con;
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {



            try
            {


                adpFacturas.SelectCommand = new SqlCommand("spSelectFactura", con2);
                adpFacturas.SelectCommand.CommandType = CommandType.StoredProcedure;
                adpFacturas.Fill(dtFacturas);
                bsFacturas.DataSource = dtFacturas;
                dataGridView1.DataSource = dtFacturas;

                adpFacturaTipo = new SqlDataAdapter();
                dtFacturaTipo = new DataTable();

                adpFacturaTipo.SelectCommand = new SqlCommand("spFacturaTipoPago", con2);
                adpFacturaTipo.SelectCommand.CommandType = CommandType.StoredProcedure;

                adpFacturaTipo.Fill(dtFacturaTipo);
                cmbTipo.DataSource = dtFacturaTipo;
                cmbTipo.DisplayMember = "Valor";
                cmbTipo.ValueMember = "Codigo";

                adpFacturaConsumo = new SqlDataAdapter();
                dtFacturaConsumo = new DataTable();

                adpFacturaConsumo.SelectCommand = new SqlCommand("spFacturaConsumo", con2);
                adpFacturaConsumo.SelectCommand.CommandType = CommandType.StoredProcedure;

                adpFacturaConsumo.Fill(dtFacturaConsumo);
                cmbConsumo.DataSource = dtFacturaConsumo;
                cmbConsumo.DisplayMember = "Valor";
                cmbConsumo.ValueMember = "Codigo";

                adpFacturaEstado = new SqlDataAdapter();
                dtFacturaEstado = new DataTable();

                adpFacturaEstado.SelectCommand = new SqlCommand("spFacturaEstado", con2);
                adpFacturaEstado.SelectCommand.CommandType = CommandType.StoredProcedure;

                adpFacturaEstado.Fill(dtFacturaEstado);
                cmbEstado.DataSource = dtFacturaEstado;
                cmbEstado.DisplayMember = "Valor";
                cmbEstado.ValueMember = "Codigo";
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if(btnNuevo.Text == "Nuevo")
            {
                btnNuevo.Text = "Insertar";

                habilitarCamposFactura();
            }
            else if(btnNuevo.Text == "Insertar")
            {
                DataRow nuevaFila = dtFacturas.NewRow();

                float descuento = float.Parse(textBox1.Text);

                nuevaFila["Codigo"] = 0;
                nuevaFila["Fecha"] = dateTimePicker1.Value;
                nuevaFila["Tipo"] = cmbTipo.SelectedValue;
                nuevaFila["Consumo"] = cmbConsumo.SelectedValue;
                nuevaFila["UsuarioID"] = usuarioID;
                nuevaFila["Estado"] = cmbEstado.SelectedValue;
                nuevaFila["Descuento"] = Math.Round(descuento,2);

                dtFacturas.Rows.Add(nuevaFila);

                try
                {
                    adpFacturas.Update(dtFacturas);
                    dtFacturas.Clear();
                    adpFacturas.Fill(dtFacturas);
                    dataGridView1.Refresh();

                    inhabilitarCamposFactura();
                    btnNuevo.Text = "Nuevo";

                    MessageBox.Show("Los datos se insertaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }






        //DateTime fechaSeleccionada;

        //bsFacturas.Filter = $"Fecha = #{fechaSeleccionada:dd/MM/yyyy}#";

    }
}
