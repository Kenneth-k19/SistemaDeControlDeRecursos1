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

            adpFacturas.UpdateCommand = new SqlCommand("spModificarFactura", con);
            adpFacturas.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpFacturas.UpdateCommand.Parameters.Add("@codigo",SqlDbType.VarChar,20,"Codigo");
            adpFacturas.UpdateCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 8, "Fecha");
            adpFacturas.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 1, "Tipo");
            adpFacturas.UpdateCommand.Parameters.Add("@consumo", SqlDbType.VarChar, 1, "Consumo");
            adpFacturas.UpdateCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpFacturas.UpdateCommand.Parameters.Add("@descuento", SqlDbType.Float, 4, "Descuento");






            
            
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

                dataGridView1.Columns["FacturaID"].Visible = false;
                dataGridView1.Columns["UsuarioID"].Visible = false;
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
            string codigo="";
            int id=0;

            var a = dataGridView1.CurrentRow.Cells["FacturaID"].Value;
            if(dataGridView1.CurrentRow != null)
            {
                codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                id = (int) dataGridView1.CurrentRow.Cells["FacturaID"].Value;
            }

            frmFacturaDetalle frm = new frmFacturaDetalle(codigo,id,con2);
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
                btnEditar.Enabled = false; //este es el boton de agregar detalle
                btnModificar.Enabled = false; //este el boton para modificar en el form actual
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
                    btnEditar.Enabled = true; //este es el boton de agregar detalle
                    btnModificar.Enabled = true; //este el boton para modificar en el form actual

                    MessageBox.Show("Los datos se insertaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(btnModificar.Text == "Editar")
            {
                habilitarCamposFactura();
                btnModificar.Text = "Guardar";

                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;

                if(dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                    string codigo = filaSeleccionada.Cells["Codigo"].Value.ToString();
                    DateTime fecha = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value.ToString());
                    string tipo = filaSeleccionada.Cells["Tipo"].Value.ToString();
                    string consumo = filaSeleccionada.Cells["Consumo"].Value.ToString();
                    string estado = filaSeleccionada.Cells["Estado"].Value.ToString();
                    string descuento = filaSeleccionada.Cells["Descuento"].Value.ToString();

                    textBox2.Text = codigo;
                    dateTimePicker1.Value = fecha;
                    cmbTipo.SelectedValue = tipo;
                    cmbConsumo.SelectedValue = consumo;
                    cmbEstado.SelectedValue = estado;
                    textBox1.Text = descuento;
                }
            }
            else if(btnModificar.Text == "Guardar")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    dtFacturas.PrimaryKey = new DataColumn[] { dtFacturas.Columns["Codigo"] };

                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                    DataRow filaDatos = dtFacturas.Rows.Find(filaSeleccionada.Cells["Codigo"].Value);

                    if(filaDatos != null)
                    {
                        //filaDatos["Codigo"] = txtCodigo.Text;
                        filaDatos["Fecha"] = dateTimePicker1.Value;
                        filaDatos["Tipo"] = cmbTipo.SelectedValue;
                        filaDatos["Consumo"] = cmbConsumo.SelectedValue;
                        filaDatos["Estado"] = cmbEstado.SelectedValue;
                        filaDatos["Descuento"] = textBox1.Text;

                        try
                        {
                            adpFacturas.Update(dtFacturas);
                            dtFacturas.Clear();
                            adpFacturas.Fill(dtFacturas);
                            dataGridView1.Refresh();
                            MessageBox.Show("Los datos se actualizaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnModificar.Text = "Editar";
                            btnNuevo.Enabled = true;
                            btnEditar.Enabled = true;
                            textBox2.Clear();
                            textBox1.Text = "0.00";
                            inhabilitarCamposFactura();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else 
                { 
                }
            }
        }






        //DateTime fechaSeleccionada;

        //bsFacturas.Filter = $"Fecha = #{fechaSeleccionada:dd/MM/yyyy}#";

    }
}
