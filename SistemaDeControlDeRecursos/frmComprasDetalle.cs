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
    public partial class frmComprasDetalle : Form
    {
        SqlConnection con;
        SqlDataAdapter adpCompraDetalle;
        DataTable dtCompraDetalle;
        string codigo;


        public frmComprasDetalle()
        {
            InitializeComponent();
        }

        public frmComprasDetalle(string codigo, SqlConnection con)
        {
            this.con = con;
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 142, 168);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            adpCompraDetalle = new SqlDataAdapter("spCompraDetalleSelect", con);
            adpCompraDetalle.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpCompraDetalle.SelectCommand.Parameters.AddWithValue("@codigoCompra", codigo);


            //@codigo varchar(20), @articuloID int, @cantidad int, @precio float, @descuento float, @impuesto float
            adpCompraDetalle.InsertCommand = new SqlCommand("spCompraDetalleInsert", con);
            adpCompraDetalle.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpCompraDetalle.InsertCommand.Parameters.AddWithValue("@codigo", codigo);
            adpCompraDetalle.InsertCommand.Parameters.Add("@articuloID", SqlDbType.Int, 4, "ArticuloID");
            adpCompraDetalle.InsertCommand.Parameters.Add("@cantidad", SqlDbType.Int, 4, "Cantidad");
            adpCompraDetalle.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 4, "Precio");
            adpCompraDetalle.InsertCommand.Parameters.Add("@descuento", SqlDbType.Float, 4, "Descuento");
            adpCompraDetalle.InsertCommand.Parameters.Add("@impuesto", SqlDbType.Float, 4, "Impuesto");


            adpCompraDetalle.InsertCommand = new SqlCommand("spCompraDetalleUpdate", con);
            adpCompraDetalle.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpCompraDetalle.InsertCommand.Parameters.AddWithValue("@codigo", codigo);
            adpCompraDetalle.InsertCommand.Parameters.Add("@articuloID", SqlDbType.Int, 4, "ArticuloID");
            adpCompraDetalle.InsertCommand.Parameters.Add("@cantidad", SqlDbType.Int, 4, "Cantidad");
            adpCompraDetalle.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 4, "Precio");
            adpCompraDetalle.InsertCommand.Parameters.Add("@descuento", SqlDbType.Float, 4, "Descuento");
            adpCompraDetalle.InsertCommand.Parameters.Add("@impuesto", SqlDbType.Float, 4, "Impuesto");


            this.codigo = codigo;
        }

        private void habilitarCampos()
        {
            txtCantidad.Enabled = true;
            txtPrecio.Enabled = true;
            txtDescuento.Enabled = true;
            txtImpuesto.Enabled = true;
        }

        private void deshabilitarCampos()
        {
            txtCantidad.Enabled = false;
            txtPrecio.Enabled = false;
            txtDescuento.Enabled = false;
            txtImpuesto.Enabled = false;
        }

        private void frmComprasDetalle_Load(object sender, EventArgs e)
        {
            
            panel1.BackColor = Color.FromArgb(145, 19, 66);
            try
            {
                txtCodigo.Text = codigo;
                dtCompraDetalle = new DataTable();
                adpCompraDetalle.Fill(dtCompraDetalle);
                dataGridView1.DataSource = dtCompraDetalle;
            }catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la ventana de Detalles. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionarArticulo_Click(object sender, EventArgs e)
        {
            frmArticuloFactura frm = new frmArticuloFactura(con);
            frm.ShowDialog();

            if(!string.IsNullOrWhiteSpace(frmArticuloFactura.nombreArticulo))
            {
                txtArticuloId.Text = frmArticuloFactura.articuloid.ToString();
                txtArticuloNombre.Text = frmArticuloFactura.nombreArticulo.ToString();
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if(btnNuevo.Text == "Nuevo")
                {
                    habilitarCampos();
                    btnNuevo.Text = "Guardar";

                    btnEliminar.Enabled = false;
                    btnSeleccionarArticulo.Enabled = true;
                }
                else
                {

                    adpCompraDetalle.InsertCommand.Parameters["@articuloID"].Value = txtArticuloId.Text;
                    adpCompraDetalle.InsertCommand.Parameters["@cantidad"].Value = txtCantidad.Text;
                    adpCompraDetalle.InsertCommand.Parameters["@precio"].Value = txtPrecio.Text;
                    adpCompraDetalle.InsertCommand.Parameters["@descuento"].Value = txtDescuento.Text;
                    adpCompraDetalle.InsertCommand.Parameters["@impuesto"].Value = txtImpuesto.Text;

                    this.con.Open();
                    adpCompraDetalle.InsertCommand.ExecuteNonQuery();
                    this.con.Close();


                    dtCompraDetalle.Clear();
                    adpCompraDetalle.Fill(dtCompraDetalle);
                    dataGridView1.Refresh();

                    deshabilitarCampos();

                    btnNuevo.Text = "Nuevo";

                    btnEliminar.Enabled = true;
                    btnSeleccionarArticulo.Enabled = false;

                    MessageBox.Show("Los datos se insertaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la ventana de Detalles. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
