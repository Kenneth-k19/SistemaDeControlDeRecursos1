using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.CodeDom;

namespace SistemaDeControlDeRecursos
{
    public partial class frmInventario : Form
    {
        SqlConnection connection;
        SqlDataAdapter adpArticulo,adpFamilia,adpUnidad,adpTipo;
        DataTable tabArticulo, tabFamilia, tabUnidad,tabTipo;
        bool modoEdicion = false;
        int articuloID = 0;

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //que solo cuando se escoga tipo "venta" se habilite unidad
            if(cmbTipo.Text == "Consumo")
            {
                cmbUnidad.Enabled = true;
            }
            else
            {
                cmbUnidad.Enabled = false;
                cmbUnidad.SelectedIndex = 0;

            }
        }
        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtObservacion.Clear();
            chkbInventario.Checked = false;
            cmbFamilia.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            cmbUnidad.SelectedIndex = -1;
            articuloID = 0;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que solo se acepten numeros y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten numeros y el punto decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }

            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            btnEditar.Visible = false;
            modoEdicion = true;
            btnInsertar.Text = "Salvar";

            //validar que haya una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String Nombre = tabArticulo.DefaultView.Table.Rows[dataGridView1.SelectedRows[0].Index]["nomArticulo"].ToString();
                DataRow fila = tabArticulo.DefaultView.Table.Rows[dataGridView1.SelectedRows[0].Index];

                txtCodigo.Text = fila["Codigo"].ToString();
                txtNombre.Text = fila["nomArticulo"].ToString();
                txtPrecio.Text = fila["Precio"].ToString();
                txtObservacion.Text = fila["Observacion"].ToString();
                chkbInventario.Checked = Convert.ToBoolean(fila["Inventario"]);
                articuloID = int.Parse(fila["ArticuloID"].ToString());
                cmbFamilia.SelectedValue = fila["codFamilia"];
                cmbTipo.SelectedValue = fila["codTipo"];
                cmbUnidad.SelectedValue = fila["codUnidad"];
                txtNombre.Focus();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text.Length == 0)
                {
                    //usar defaultView de dataTable para filtrar
                    tabArticulo.DefaultView.RowFilter = "";
                }
                else
                {
                    tabArticulo.DefaultView.RowFilter = "Articulo LIKE '%" + txtBuscar.Text + "%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //validaciones
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Debe indicar el Codigo del Articulo","El código de artículo es necesario",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtCodigo.Focus();
                return;
            }
            //verificar que no sea demasiado largo
            if(txtCodigo.Text.Length >= 10)
            {
                MessageBox.Show("El Codigo de Articulo no puede ser demasiado extenso","El Codigo es demasiado extenso",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtCodigo.Focus();
                return;
            }
            //verificar que no exista un articulo con el código ingresado
            DataTable tabTemporal = new DataTable();
            tabTemporal = DBAccess.getDataTable("spArticuloSelect", new Dictionary<string, object>() {
                {"articuloID",0},{"cod",txtCodigo.Text} 
            });

            if (tabTemporal.Rows.Count > 0 && modoEdicion == false)
            {
                MessageBox.Show("El Codigo de Articulo ya existe","El Codigo ya existe",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtCodigo.Focus();
                return;
            }

            //verificar que el nombre no sea vacio
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe indicar el Nombre del Articulo", "El Nombre de Articulo es necesario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

            //verificar que el nombre no sea demasiado largo
            if (txtNombre.Text.Length >= 50)
            {
                MessageBox.Show("El Nombre del Articulo no puede ser demasiado extenso", "El Nombre es demasiado extenso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }
            if (txtPrecio.Text == "" && cmbTipo.Text =="Venta")
            {
                MessageBox.Show("Debe indicar el Precio del Articulo", "El Precio de Articulo es necesario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }

            if(txtPrecio.Text == "")
                    txtPrecio.Text =0.ToString();
            //que el precio no sea demasiado alto
            if (Convert.ToDecimal(txtPrecio.Text) > 1000000)
            {
                MessageBox.Show("El Precio del Articulo no puede ser demasiado alto", "El Precio es demasiado alto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }

            //que observación no sea demasiado extensa >60
            if(txtObservacion.Text.Length >= 60)
            {
                MessageBox.Show("La Observación del Articulo no puede ser demasiado extensa","La Observación es demasiado extensa",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtObservacion.Focus();
                return;
            }
            //que haya una familia seleccionada
            if(cmbFamilia.SelectedIndex == -1)
            {
                MessageBox.Show("Debe indicar la Familia del Articulo", "La Familia de Articulo es necesario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFamilia.Focus();
                return;
            }
            //que haya un tipo seleccionado
            if(cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe indicar el Tipo del Articulo", "El Tipo de Articulo es necesario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTipo.Focus();
                return;
            }


           
            try
            {

                if (modoEdicion)
                {
                    // Modo de Edición: Actualizar el registro existente
                    DataRow fila = tabArticulo.Select($"ArticuloID = {articuloID}").FirstOrDefault();
                    if (fila != null)
                    {

                        fila["Codigo"] = txtCodigo.Text;
                        fila["nomArticulo"] = txtNombre.Text;
                        fila["Precio"] = Convert.ToDecimal(txtPrecio.Text);
                        fila["Observacion"] = txtObservacion.Text;
                        fila["Inventario"] = chkbInventario.Checked;
                        fila["codFamilia"] = cmbFamilia.SelectedValue;
                        fila["codTipo"] = cmbTipo.SelectedValue;
                        fila["codUnidad"] = cmbUnidad.SelectedValue;

                        // Guardar cambios en la base de datos
                        adpArticulo.Update(tabArticulo);

                        MessageBox.Show("Artículo actualizado correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarControles();
                        // Reiniciar el modo de edición
                        modoEdicion = false;
                        btnInsertar.Text = "Insertar";
                        btnEditar.Enabled = true;
                        btnEditar.Visible = true;
                        dataGridView1.Enabled = true;
                        refrescarGrid();
                    }
                }
                else
                {
                    // Configurar parámetros del InsertCommand con los valores de los controles
                    adpArticulo.InsertCommand.Parameters["@Codigo"].Value = txtCodigo.Text;
                    adpArticulo.InsertCommand.Parameters["@Nombre"].Value = txtNombre.Text;
                    adpArticulo.InsertCommand.Parameters["@Tipo"].Value = cmbTipo.SelectedValue;
                    adpArticulo.InsertCommand.Parameters["@FamiliaID"].Value = cmbFamilia.SelectedValue;
                    adpArticulo.InsertCommand.Parameters["@precio"].Value = Convert.ToDouble(txtPrecio.Text);
                    adpArticulo.InsertCommand.Parameters["@unidadID"].Value = cmbUnidad.SelectedValue;
                    adpArticulo.InsertCommand.Parameters["@Inventario"].Value = chkbInventario.Checked;
                    adpArticulo.InsertCommand.Parameters["@observacion"].Value = txtObservacion.Text;
                    adpArticulo.InsertCommand.Parameters["@minimo"].Value = 0; // Puedes permitir que el usuario lo defina

                    // Ejecutar la inserción
                    DataRow newRow = tabArticulo.NewRow();
                    tabArticulo.Rows.Add(newRow);
                    adpArticulo.Update(tabArticulo);

                    // Obtener el ID del artículo insertado
                    int articuloID = Convert.ToInt32(adpArticulo.InsertCommand.Parameters["@ArticuloID"].Value);

                    MessageBox.Show("Artículo insertado correctamente con ID: " + articuloID, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    refrescarGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void refrescarGrid()
        {
            try
            {
                tabArticulo.Clear();
                adpArticulo.Fill(tabArticulo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public frmInventario(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
            adpArticulo = new SqlDataAdapter("spArticuloSelect",connection);
            adpArticulo.SelectCommand.CommandType = CommandType.StoredProcedure;

            tabArticulo = new DataTable();
            adpArticulo.Fill(tabArticulo);
           
            adpFamilia = new SqlDataAdapter("spFamiliaSelect", connection);
            adpFamilia.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabFamilia = new DataTable();
            adpFamilia.Fill(tabFamilia);

            adpUnidad = new SqlDataAdapter("select *from Unidad", connection);  
            adpUnidad.SelectCommand.CommandType = CommandType.Text;
            tabUnidad = new DataTable();
            adpUnidad.Fill(tabUnidad);

            adpTipo = new SqlDataAdapter("select Distinct Tipo\r\n,case Tipo when 'C' then 'Consumo' when 'V' then 'Venta' end as nomTipo\r\nfrom Articulo", connection);
            adpTipo.SelectCommand.CommandType = CommandType.Text;
            tabTipo = new DataTable();
            adpTipo.Fill(tabTipo);
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.DataSource = tabArticulo;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Código"; dataGridView1.Columns[1].Width =60;
            dataGridView1.Columns["codTipo"].Visible = false; dataGridView1.Columns["codFamilia"].Visible = false;
            dataGridView1.Columns["codUnidad"].Visible = false;
            dataGridView1.Columns["nomArticulo"].Width = 200;
            dataGridView1.Columns["nomTipo"].HeaderText = "Tipo"; dataGridView1.Columns["nomArticulo"].HeaderText = "Articulo";
            dataGridView1.Columns["nomFamilia"].HeaderText = "Familia"; dataGridView1.Columns["nomUnidad"].HeaderText = "Unidad";


            cmbFamilia.DataSource = tabFamilia;
            cmbFamilia.DisplayMember = "Nombre";
            cmbFamilia.ValueMember = "FamiliaID";
            cmbFamilia.SelectedItem = null;

            cmbUnidad.DataSource = tabUnidad;
            cmbUnidad.DisplayMember = "Nombre";
            cmbUnidad.ValueMember = "UnidadID";
            cmbUnidad.SelectedItem = null;

            cmbTipo.DataSource = tabTipo;
            cmbTipo.DisplayMember = "nomTipo";
            cmbTipo.ValueMember = "Tipo";
            cmbTipo.SelectedItem = null;


            adpArticulo.InsertCommand = new SqlCommand("spArticuloInsert", connection);
            adpArticulo.InsertCommand.CommandType = CommandType.StoredProcedure;

            // Configurar parámetros
            adpArticulo.InsertCommand.Parameters.Add(new SqlParameter("@ArticuloID", SqlDbType.Int));
            adpArticulo.InsertCommand.Parameters["@ArticuloID"].Direction = ParameterDirection.Output;

            adpArticulo.InsertCommand.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.VarChar, 5));
            adpArticulo.InsertCommand.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100));
            adpArticulo.InsertCommand.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 1));
            adpArticulo.InsertCommand.Parameters.Add(new SqlParameter("@FamiliaID", SqlDbType.Int));
            adpArticulo.InsertCommand.Parameters.Add(new SqlParameter("@precio", SqlDbType.Float));
            adpArticulo.InsertCommand.Parameters.Add(new SqlParameter("@unidadID", SqlDbType.Int));
            adpArticulo.InsertCommand.Parameters.Add(new SqlParameter("@Inventario", SqlDbType.Bit));
            adpArticulo.InsertCommand.Parameters.Add(new SqlParameter("@observacion", SqlDbType.VarChar, 200));
            adpArticulo.InsertCommand.Parameters.Add(new SqlParameter("@minimo", SqlDbType.Int));



            // Configuración del UpdateCommand
            adpArticulo.UpdateCommand = new SqlCommand("spArticuloUpdate", connection);
            adpArticulo.UpdateCommand.CommandType = CommandType.StoredProcedure;

            // Configuración de los parámetros
            adpArticulo.UpdateCommand.Parameters.Add("@ArticuloID", SqlDbType.Int).SourceColumn = "ArticuloID";
            adpArticulo.UpdateCommand.Parameters.Add("@Codigo", SqlDbType.VarChar, 5).SourceColumn = "Codigo";
            adpArticulo.UpdateCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).SourceColumn = "nomArticulo";
            adpArticulo.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).SourceColumn = "codTipo";
            adpArticulo.UpdateCommand.Parameters.Add("@FamiliaID", SqlDbType.Int).SourceColumn = "codFamilia";
            adpArticulo.UpdateCommand.Parameters.Add("@Precio", SqlDbType.Float).SourceColumn = "Precio";
            adpArticulo.UpdateCommand.Parameters.Add("@UnidadID", SqlDbType.Int).SourceColumn = "codUnidad";
            adpArticulo.UpdateCommand.Parameters.Add("@Inventario", SqlDbType.Bit).SourceColumn = "Inventario";
            adpArticulo.UpdateCommand.Parameters.Add("@Observacion", SqlDbType.VarChar, 200).SourceColumn = "Observacion";
            adpArticulo.UpdateCommand.Parameters.Add("@Minimo", SqlDbType.Int).SourceColumn = "minimo";

            // Opcional: Asegúrate de que el parámetro ArticuloID se envíe como el valor original.
            adpArticulo.UpdateCommand.Parameters["@ArticuloID"].SourceVersion = DataRowVersion.Original;


        }
    }
}
