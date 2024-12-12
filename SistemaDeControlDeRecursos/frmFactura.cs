using SistemaDeControlDeRecursos.Reportes.forms;
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
        string validarFacIDEnMod;


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
        }

        public void habilitarCamposFactura()
        {
            cmbTipo.Enabled = true;
            cmbConsumo.Enabled = true;
            cmbEstado.Enabled = true;  
        }

        public void llenarGrid()
        {
            //adpFacturas.SelectCommand = new SqlCommand("spSelectFactura", con2);
            //adpFacturas.SelectCommand.CommandType = CommandType.StoredProcedure;
            //adpFacturas.Fill(dtFacturas);
            //bsFacturas.DataSource = dtFacturas;
            //dataGridView1.DataSource = dtFacturas;

            try
            {
                dtFacturas.Clear();
                adpFacturas.Fill(dtFacturas);
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar los datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void calcularDescuento()
        {
            
                //para que se calcule el cambio lo pongo aqui y en el textchanged de textbox1
                float dsubtotal = string.IsNullOrWhiteSpace(txtsubtotal.Text) ? 0 : float.Parse(txtsubtotal.Text);
                float ddescuento = string.IsNullOrWhiteSpace(textBox1.Text) ? 0 : float.Parse(textBox1.Text);

                float totalSegunDescuento = (float)Math.Round(dsubtotal - (dsubtotal * (ddescuento / 100)), 2);

                if (totalSegunDescuento < 0)
                {
                    MessageBox.Show("El total no puede ser negativo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtTotal.Text = totalSegunDescuento.ToString();
                }
            
        }

        public static int Facturaid { get; set; }

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
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.MultiSelect = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.Font = new Font("Poppins", 10);

            textBox2.Enabled = false;

            adpFacturas = new SqlDataAdapter();
            dtFacturas = new DataTable();
            bsFacturas = new BindingSource();

            adpFacturas.InsertCommand = new SqlCommand("spInsertarFactura", con);
            adpFacturas.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpFacturas.InsertCommand.Parameters.Add("@codigo", SqlDbType.VarChar,20,"Codigo");
            adpFacturas.InsertCommand.Parameters["@codigo"].Direction = ParameterDirection.Output;
            adpFacturas.InsertCommand.Parameters.Add("@fecha", SqlDbType.DateTime,8,"Fecha");
            adpFacturas.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar,1,"TipoID");
            adpFacturas.InsertCommand.Parameters.Add("@consumo", SqlDbType.VarChar, 1, "ConsumoID");
            adpFacturas.InsertCommand.Parameters.Add("@usuarioid", SqlDbType.Int, 4, "UsuarioID");
            adpFacturas.InsertCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpFacturas.InsertCommand.Parameters.Add("@descuento", SqlDbType.Float, 4, "Descuento");

            adpFacturas.UpdateCommand = new SqlCommand("spModificarFactura", con);
            adpFacturas.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpFacturas.UpdateCommand.Parameters.Add("@codigo",SqlDbType.VarChar,20,"Codigo");
            adpFacturas.UpdateCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 8, "Fecha");
            adpFacturas.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 1, "TipoID");
            adpFacturas.UpdateCommand.Parameters.Add("@consumo", SqlDbType.VarChar, 1, "ConsumoID");
            adpFacturas.UpdateCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpFacturas.UpdateCommand.Parameters.Add("@descuento", SqlDbType.Float, 4, "Descuento");






            cmbConsumo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;

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
                dataGridView1.Columns["TipoID"].Visible = false;
                dataGridView1.Columns["ConsumoID"].Visible = false;
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
            if (dataGridView1.SelectedRows.Count == 1)
            {

            }
            else
            {
                MessageBox.Show("Seleccione solo una fila, por favor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /* obtenemos los valores necesarios para enviar al constructor del form e instanciamos y llamamos al form */
            string codigo="";
            int id=0;
            string estado = "";

            var a = dataGridView1.CurrentRow.Cells["FacturaID"].Value;
            estado = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();

            if (estado == "F")
            {
                MessageBox.Show("La factura ya ha sido facturada, ya no puede editarla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView1.CurrentRow != null)
            {
                codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                id = (int) dataGridView1.CurrentRow.Cells["FacturaID"].Value;
            }

            frmFacturaDetalle frm = new frmFacturaDetalle(codigo,id,con2);

            //frm.FormClosed += (s, args) =>
            //{
            //    llenarGrid();
            //};
            frm.Owner = this;
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
                btnNuevo.Text = "Agregar";

                habilitarCamposFactura();
                btnEditar.Enabled = false; //este es el boton de agregar detalle
                btnModificar.Enabled = false; //este el boton para modificar en el form actual
                btnFacturar.Enabled = false;
            }
            else if(btnNuevo.Text == "Agregar")
            {
                DataRow nuevaFila = dtFacturas.NewRow();

                float descuento = float.Parse(textBox1.Text);

                nuevaFila["Codigo"] = 0;
                nuevaFila["Fecha"] = dateTimePicker1.Value;
                nuevaFila["TipoID"] = cmbTipo.SelectedValue;
                nuevaFila["ConsumoID"] = cmbConsumo.SelectedValue;
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
                    btnFacturar.Enabled = true;

                    MessageBox.Show("Los datos se agregaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if(dataGridView1.SelectedRows.Count == 1)
                {




                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                    string codigo = filaSeleccionada.Cells["Codigo"].Value.ToString();
                    validarFacIDEnMod = codigo;
                    DateTime fecha = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value.ToString());
                    string tipo = filaSeleccionada.Cells["TipoID"].Value.ToString();
                    string consumo = filaSeleccionada.Cells["ConsumoID"].Value.ToString();
                    string estado = filaSeleccionada.Cells["Estado"].Value.ToString();
                    string descuento = filaSeleccionada.Cells["Descuento"].Value.ToString();
                    string subtotal = filaSeleccionada.Cells["Subtotal"].Value.ToString();

                    if (estado == "F")
                    {
                        MessageBox.Show("La factura ya ha sido facturada, ya no puede editarla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    habilitarCamposFactura();
                    textBox1.Enabled = true;

                    btnModificar.Text = "Guardar";

                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnFacturar.Enabled = false;

                    textBox2.Text = codigo;
                    dateTimePicker1.Value = fecha;
                    cmbTipo.SelectedValue = tipo;
                    cmbConsumo.SelectedValue = consumo;
                    cmbEstado.SelectedValue = estado;
                    textBox1.Text = descuento;
                    txtsubtotal.Text = subtotal;

                    
                }
                else
                {
                    MessageBox.Show("Seleccione solo una fila, por favor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if(btnModificar.Text == "Guardar")
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    if(textBox1.Text == "")
                    {
                        MessageBox.Show("Debe ingresar un valor en el descuento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Convert.ToInt32(textBox1.Text) < 0 || Convert.ToInt32(textBox1.Text) > 100)
                    {
                        MessageBox.Show("El porcentaje de descuento no debe ser mayor a 100.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dtFacturas.PrimaryKey = new DataColumn[] { dtFacturas.Columns["Codigo"] };

                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                    if(filaSeleccionada.Cells["Codigo"].Value.ToString() != validarFacIDEnMod)
                    {
                        MessageBox.Show("La fila seleccionada al principio ha cambiado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataRow filaDatos = dtFacturas.Rows.Find(filaSeleccionada.Cells["Codigo"].Value);

                    if(filaDatos != null)
                    {
                        //filaDatos["Codigo"] = txtCodigo.Text;
                        filaDatos["Fecha"] = dateTimePicker1.Value;
                        filaDatos["TipoID"] = cmbTipo.SelectedValue;
                        filaDatos["ConsumoID"] = cmbConsumo.SelectedValue;
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
                            btnFacturar.Enabled = true;
                            textBox2.Clear();
                            textBox1.Text = "0";
                            txtsubtotal.Text = "0.00";
                            txtTotal.Text = "0.00";
                            txtCambio.Text = "0.00";
                            inhabilitarCamposFactura();
                            textBox1.Enabled = false;
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else 
                {
                    MessageBox.Show("Seleccione solo una fila, por favor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            float subtotal = string.IsNullOrWhiteSpace(txtsubtotal.Text) ? 0 : float.Parse(txtsubtotal.Text);
            float descuento = string.IsNullOrWhiteSpace(textBox1.Text) ? 0 : float.Parse(textBox1.Text);

            float total = (float) Math.Round(subtotal - (subtotal * (descuento / 100)),2);

            if (total < 0)
            {
                MessageBox.Show("El porcentaje de descuento no debe ser mayor a 100.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtTotal.Text = total.ToString();
            }
        }

        private void txtMontoPagado_TextChanged(object sender, EventArgs e)
        {
            
            if(txtMontoPagado.Text == "." && txtMontoPagado.Text.Length <= 1)
            {
                MessageBox.Show("Formato numerico incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float total = string.IsNullOrWhiteSpace(txtTotal.Text) ? 0 : float.Parse(txtTotal.Text);
            float montoPagado = string.IsNullOrWhiteSpace(txtMontoPagado.Text) ? 0 : float.Parse(txtMontoPagado.Text);

            float cambio = (float) Math.Round((montoPagado - total),2);

            txtCambio.Text = cambio.ToString();

            if (cambio < 0)
            {
                cambio = 0;
            }

            

        }

        private void txtFacturar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

            }
            else
            {
                MessageBox.Show("Seleccione solo una fila, por favor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                if (btnFacturar.Text == "Facturar")
            {
                

                btnFacturar.Text = "Imprimir";
                
                txtMontoPagado.Enabled = true;
                btnEditar.Enabled = false;
                btnNuevo.Enabled = false;
                btnModificar.Enabled = false;

                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                    Facturaid = Convert.ToInt32(filaSeleccionada.Cells["FacturaID"].Value.ToString());

                    string codigo = filaSeleccionada.Cells["Codigo"].Value.ToString();
                    DateTime fecha = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value.ToString());
                    string tipo = filaSeleccionada.Cells["TipoID"].Value.ToString();
                    string consumo = filaSeleccionada.Cells["ConsumoID"].Value.ToString();
                    string estado = filaSeleccionada.Cells["Estado"].Value.ToString();
                    string descuento = filaSeleccionada.Cells["Descuento"].Value.ToString();
                    string subtotal = filaSeleccionada.Cells["Subtotal"].Value.ToString();

                    if(float.Parse(subtotal) == 0)
                    {
                        MessageBox.Show("La factura no tiene detalle.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    textBox2.Text = codigo;
                    dateTimePicker1.Value = fecha;
                    cmbTipo.SelectedValue = tipo;
                    cmbConsumo.SelectedValue = consumo;
                    cmbEstado.SelectedValue = estado;
                    textBox1.Text = descuento;
                    txtsubtotal.Text = subtotal;




                    calcularDescuento();
                }
            }
            else if(btnFacturar.Text == "Imprimir")
            {

                if(textBox1.Text == "")
                {
                    MessageBox.Show("Debe ingresar un valor en Descuento, ya sea cero o mayor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (txtMontoPagado.Text == "")
                {
                    MessageBox.Show("Debe ingresar un valor en el Monto Pagado, mayor o igual al Total a pagar.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if(float.Parse(txtCambio.Text) < 0)
                {
                    MessageBox.Show("El cambio es negativo, el monto ingresado debe ser mayor o igual que el total a pagar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(float.Parse(txtMontoPagado.Text) < float.Parse(txtTotal.Text))
                {
                    MessageBox.Show("El monto pagado debe ser mayor o igual al Total a pagar.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                txtMontoPagado.Enabled = false;
                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
                btnModificar.Enabled = true;

                float subtotal = float.Parse(txtsubtotal.Text);
                float descuento = float.Parse(textBox1.Text);
                float total = float.Parse(txtTotal.Text);
                float montopagado = float.Parse(txtMontoPagado.Text);
                float cambio = float.Parse(txtCambio.Text);

                frmFacturarFactura frm = new frmFacturarFactura(Facturaid,subtotal,descuento,total,montopagado,cambio);
                frm.ShowDialog();

                if(btnFacturar.Text == "Imprimir")
                {
                    btnFacturar.Text = "Facturar";

                    textBox2.Clear();
                    txtsubtotal.Text = "0.00";
                    textBox1.Text = "0";
                    txtTotal.Text = "0.00";
                    txtMontoPagado.Text = "0.00";
                    txtCambio.Text = "0.00";
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            inhabilitarCamposFactura();
            if(btnNuevo.Text == "Insertar")
            {
                btnNuevo.Text = "Nuevo";
                inhabilitarCamposFactura();
                btnModificar.Enabled= true;
                btnEditar.Enabled= true;
                btnFacturar.Enabled= true;
            }
            else if(btnModificar.Text =="Guardar")
            {
                btnModificar.Text = "Editar";
                inhabilitarCamposFactura();
                btnEditar.Enabled = true;
                btnFacturar.Enabled = true;
                btnNuevo.Enabled= true;
                textBox2.Clear();
                txtsubtotal.Text = "0.00";
                cmbConsumo.SelectedIndex = 0;
                cmbEstado.SelectedIndex = 0;
                cmbTipo.SelectedIndex = 0;
                textBox1.Enabled = false;
                textBox1.Text = "0";
            }
            else if(btnFacturar.Text == "Imprimir")
            {
                btnFacturar.Text = "Facturar";
                inhabilitarCamposFactura();
                textBox1.Enabled = false;
                txtMontoPagado.Enabled = false;
                btnEditar.Enabled = true;
                btnModificar.Enabled = true;
                btnNuevo.Enabled= true;
                textBox2.Clear();
                txtsubtotal.Text = "0.00";
                cmbConsumo.SelectedIndex = 0;
                cmbEstado.SelectedIndex = 0;
                cmbTipo.SelectedIndex = 0;
                txtMontoPagado.Text = "0.00";
                txtCambio.Text = "0.00";
                textBox1.Text = "0";
                txtTotal.Text = "0.00";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear la entrada
            }

            
        }

        private void txtMontoPagado_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, el punto, y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear la entrada
            }

            // Permitir solo un punto (.)
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Bloquear si ya hay un punto
            }
        }






        //DateTime fechaSeleccionada;

        //bsFacturas.Filter = $"Fecha = #{fechaSeleccionada:dd/MM/yyyy}#";

    }
}
