using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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


            adpCompraDetalle.UpdateCommand = new SqlCommand("spCompraDetalleUpdate", con);
            adpCompraDetalle.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpCompraDetalle.UpdateCommand.Parameters.AddWithValue("@codigo", codigo);
            adpCompraDetalle.UpdateCommand.Parameters.Add("@articuloID", SqlDbType.Int, 4, "ArticuloID");
            adpCompraDetalle.UpdateCommand.Parameters.Add("@cantidad", SqlDbType.Int, 4, "Cantidad");
            adpCompraDetalle.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 4, "Precio");
            adpCompraDetalle.UpdateCommand.Parameters.Add("@descuento", SqlDbType.Float, 4, "Descuento");
            adpCompraDetalle.UpdateCommand.Parameters.Add("@impuesto", SqlDbType.Float, 4, "Impuesto");

            adpCompraDetalle.DeleteCommand = new SqlCommand("spCompraDetalleDelete", con);
            adpCompraDetalle.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adpCompraDetalle.DeleteCommand.Parameters.Add("@compradetalleid", SqlDbType.Int, 4, "CompraDetalleID");



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

        private bool validarBLancos()
        {
            if(txtArticuloId.Text.Trim() == "")
            {
                MessageBox.Show("El campo Articulo es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(txtCantidad.Text.Trim() == "")
            {
                MessageBox.Show("El campo Cantidad es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(txtPrecio.Text.Trim() == "")
            {
                MessageBox.Show("El campo Precio es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(txtDescuento.Text.Trim() == "")
            {
                MessageBox.Show("El campo Descuento es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(txtImpuesto.Text.Trim() == "")
            {
                MessageBox.Show("El campo Impuesto es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool validarNumeros()
        {

            /*
             * using System;

public class Program
{
    public static void Main()
    {
        string input = "123.45";  // Ejemplo de cadena que contiene un número flotante
        float result;

        bool isValid = float.TryParse(input, out result);

        if (isValid)
        {
            Console.WriteLine($"El valor '{input}' es un número flotante válido: {result}");
        }
        else
        {
            Console.WriteLine($"El valor '{input}' no es un número flotante válido.");
        }
    }
}

             * */
            if(!float.TryParse(txtPrecio.Text, out float result))
            {
                MessageBox.Show("El campo Precio debe ser un número decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                float valor = float.Parse(txtPrecio.Text);

                if(valor <= 0)
                {
                    MessageBox.Show("El campo Precio debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }
            }

            if(!float.TryParse(txtDescuento.Text, out float result2))
            {
                MessageBox.Show("El campo Descuento debe ser un número decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                float valor = float.Parse(txtDescuento.Text);

                if (valor < 0)
                {
                    MessageBox.Show("El campo Descuento debe ser mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if(!float.TryParse(txtImpuesto.Text, out float result3))
            {
                MessageBox.Show("El campo Impuesto debe ser un número decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                float valor = float.Parse(txtImpuesto.Text);

                if (valor < 0)
                {
                    MessageBox.Show("El campo Impuesto debe ser mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            

            if(!int.TryParse(txtCantidad.Text, out int result4))
            {
                MessageBox.Show("El campo Cantidad debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                int valor = int.Parse(txtCantidad.Text);

                if (valor <= 0)
                {
                    MessageBox.Show("El campo Cantidad debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
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

                dataGridView1.Columns[0].Visible = false;
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
                    btnVolver.Visible = true;
                }
                else
                {
                    if(!validarBLancos())
                    {
                        return;
                    }

                    if(!validarNumeros())
                    {
                        return;
                    }

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
                    btnVolver.Visible = false;

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                string nombreArticulo = dtCompraDetalle.DefaultView[indice]["Articulo"].ToString();

                if (MessageBox.Show("¿Desea eliminar los datos para el articulo " + nombreArticulo + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    adpCompraDetalle.DeleteCommand.Parameters["@compradetalleid"].Value = dtCompraDetalle.DefaultView[indice]["CompraDetID"].ToString();

                    this.con.Open();
                    adpCompraDetalle.DeleteCommand.ExecuteNonQuery();
                    this.con.Close();

                    dtCompraDetalle.Clear();
                    adpCompraDetalle.Fill(dtCompraDetalle);
                    dataGridView1.Refresh();

                    MessageBox.Show("Los datos se eliminaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {


            if(btnNuevo.Text == "Guardar")
            {
                deshabilitarCampos();
                btnNuevo.Text = "Nuevo";
                btnEliminar.Enabled = true;
                btnSeleccionarArticulo.Enabled = false;

                txtArticuloId.Text = "";
                txtArticuloNombre.Text = "";
                txtCantidad.Text = "0";
                txtPrecio.Text = "0.00";
                txtDescuento.Text = "0.00";
                txtImpuesto.Text = "0.00";
            }
        }

        //private void btnEditar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (btnEliminar.Text == "Editar")
        //        {
        //            habilitarCampos();
        //            btnEliminar.Text = "Actualizar";

        //            btnNuevo.Enabled = false;
        //            btnSeleccionarArticulo.Enabled = true;

        //            if(dataGridView1.SelectedRows.Count > 0)
        //            {
        //                int indice = dataGridView1.SelectedRows[0].Index;

        //                txtArticuloNombre.Text = dtCompraDetalle.DefaultView[indice]["Articulo"].ToString();

        //                DataTable dtArticulo = new DataTable();
        //                SqlDataAdapter adpArticulo = new SqlDataAdapter("select ArticuloID from Articulo where Nombre = '" + txtArticuloNombre.Text + "'", con);
        //                adpArticulo.Fill(dtArticulo);
        //                txtArticuloId.Text = dtArticulo.Rows[0][0].ToString();


        //                int cdID = dtCompraDetalle.DefaultView[indice]["CompraDetID"].ToString() == "" ? 0 : Convert.ToInt32(dtCompraDetalle.DefaultView[indice]["CompraDetID"].ToString());
        //                DataTable dtCD = new DataTable();
        //                SqlDataAdapter adpCD = new SqlDataAdapter("select Cantidad, Precio, Descuento, Impuesto from CompraDet where CompraID = " + codigo + " and ArticuloID = " + txtArticuloId.Text, con);
        //                adpCD.Fill(dtCD);

        //                if (dtCD.Rows.Count > 0)
        //                {
        //                    txtCantidad.Text = dtCD.Rows[0][0].ToString();
        //                    txtPrecio.Text = dtCD.Rows[0][1].ToString();
        //                    txtDescuento.Text = dtCD.Rows[0][2].ToString();
        //                    txtImpuesto.Text = dtCD.Rows[0][3].ToString();
        //                }

        //                //DataTable dt = new DataTable();

        //                //txtArticuloNombre.Text = dtCompraDetalle.DefaultView[indice]["Articulo"].ToString();
        //                //txtCantidad.Text = dtCompraDetalle.DefaultView[indice]["Cantidad"].ToString();
        //                //txtPrecio.Text = dtCompraDetalle.DefaultView[indice]["Precio"].ToString();
        //                //txtDescuento.Text = dtCompraDetalle.DefaultView[indice]["Descuento"].ToString();
        //                //txtImpuesto.Text = dtCompraDetalle.DefaultView[indice]["Impuesto"].ToString();

        //                //SqlDataAdapter adapter = new SqlDataAdapter("select ArticuloID from Articulo where Nombre = '" + txtArticuloNombre.Text + "'", con);

        //                //adapter.Fill(dt);
        //                //txtArticuloId.Text = dt.Rows[0][0].ToString();
        //            }
        //        }
        //        else
        //        {

        //            adpCompraDetalle.UpdateCommand.Parameters["@articuloID"].Value = txtArticuloId.Text;
        //            adpCompraDetalle.UpdateCommand.Parameters["@cantidad"].Value = txtCantidad.Text;
        //            adpCompraDetalle.UpdateCommand.Parameters["@precio"].Value = txtPrecio.Text;
        //            adpCompraDetalle.UpdateCommand.Parameters["@descuento"].Value = txtDescuento.Text;
        //            adpCompraDetalle.UpdateCommand.Parameters["@impuesto"].Value = txtImpuesto.Text;

        //            this.con.Open();
        //            adpCompraDetalle.UpdateCommand.ExecuteNonQuery();
        //            this.con.Close();


        //            dtCompraDetalle.Clear();
        //            adpCompraDetalle.Fill(dtCompraDetalle);
        //            dataGridView1.Refresh();

        //            deshabilitarCampos();

        //            btnEliminar.Text = "Editar";

        //            btnNuevo.Enabled = true;
        //            btnSeleccionarArticulo.Enabled = false;

        //            MessageBox.Show("Los datos se actualizaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }catch(Exception ex) {
        //        MessageBox.Show("Error al cargar la ventana de Detalles. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

    }
}
