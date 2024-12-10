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
    public partial class frmConsumosDetalle : Form
    {
        SqlConnection connection;
        int ConsumoID;
        SqlDataAdapter adpConsumo, adpConsumoDet,adpArticuloVenta,adpArticuloConsumo;
        DataTable tabConsumo, tabConsumoDet,tabArticuloVenta,tabArticuloConsumo;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //debe haber un platillo seleccionado
            if (cmbPlatillo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un platillo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //preguntar si se quiere continuar si la observación está vacía
            if (txtObservacion.Text == "")
            {
                if (MessageBox.Show("¿Desea continuar sin observación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    txtObservacion.Focus();
                    return;
                }
            }

            //debe haber al menos un ingrediente en el detalle
            if (tabConsumoDet.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un ingrediente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Abrir la conexión si no está abierta
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Guardar en la tabla Consumo
                SqlCommand cmdConsumo;
                if (ConsumoID == -1)
                {
                    cmdConsumo = new SqlCommand("spConsumoInsert", connection);
                    cmdConsumo.Parameters.AddWithValue("@ConsumoID", 0);
                    cmdConsumo.Parameters[0].Direction = ParameterDirection.Output;
                }
                else
                {
                    cmdConsumo = new SqlCommand("spConsumoUpdate", connection);
                    cmdConsumo.Parameters.AddWithValue("@ConsumoID", ConsumoID);
                }
                cmdConsumo.CommandType = CommandType.StoredProcedure;
                cmdConsumo.Parameters.AddWithValue("@ArticuloID", cmbPlatillo.SelectedValue);
                cmdConsumo.Parameters.AddWithValue("@Observacion", txtObservacion.Text);

                // Ejecutar el comando para guardar en Consumo
                cmdConsumo.ExecuteNonQuery();

                ConsumoID = (int)cmdConsumo.Parameters[0].Value;

                // **Manejo de filas eliminadas**: 
                foreach (DataRow row in tabConsumoDet.Rows)
                {
                    // Verifica si la fila está marcada como eliminada
                    if (row.RowState == DataRowState.Deleted)
                    {
                        // Obtener el ConsumoDetID de la fila eliminada
                        int consumoDetID = (int)row["ConsumoDetID", DataRowVersion.Original];

                        // Ejecutar el procedimiento almacenado o consulta para eliminar
                        SqlCommand cmdDelete = new SqlCommand("spConsumoDetDelete", connection);
                        cmdDelete.CommandType = CommandType.StoredProcedure;
                        cmdDelete.Parameters.AddWithValue("@ConsumoDetID", consumoDetID);
                        cmdDelete.ExecuteNonQuery();
                    }
                }

                // Guardar los detalles del consumo en la tabla ConsumoDet
                foreach (DataRow row in tabConsumoDet.Rows)
                {
                    // Ignorar filas eliminadas y filas sin cambios
                    if (row.RowState == DataRowState.Deleted || row.RowState == DataRowState.Unchanged)
                    {
                        continue;
                    }

                    SqlCommand cmdConsumoDet = new SqlCommand("spConsumoDetInsert", connection);
                    cmdConsumoDet.CommandType = CommandType.StoredProcedure;
                    cmdConsumoDet.Parameters.AddWithValue("@ConsumoDetID", 0);
                    cmdConsumoDet.Parameters.AddWithValue("@ConsumoID", ConsumoID);
                    cmdConsumoDet.Parameters.AddWithValue("@ArticuloID", row["ArticuloID"]);
                    cmdConsumoDet.Parameters.AddWithValue("@Cantidad", row["Cantidad"]);
                    cmdConsumoDet.ExecuteNonQuery();
                }

                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Asegurarse de cerrar la conexión al finalizar
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvConsumoDet.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvConsumoDet.SelectedRows)
                {
                    dgvConsumoDet.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
           
        }

        public frmConsumosDetalle(SqlConnection conn, int id)
        {
            InitializeComponent();
            connection = conn;
            ConsumoID = id;
        }

        private void frmConsumosDetalle_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(145, 19, 66);
            tabConsumo = new DataTable();
            adpConsumo = new SqlDataAdapter("spConsumoSelect", connection);
            adpConsumo.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpConsumo.SelectCommand.Parameters.AddWithValue("@ConsumoID", ConsumoID);
            adpConsumo.Fill(tabConsumo);
                      

            tabConsumoDet = new DataTable();
            adpConsumoDet = new SqlDataAdapter("spConsumoDetSelect", connection);
            adpConsumoDet.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpConsumoDet.SelectCommand.Parameters.AddWithValue("@ConsumoID", ConsumoID);
            adpConsumoDet.Fill(tabConsumoDet);            
            dgvConsumoDet.DataSource = tabConsumoDet;


            dgvConsumoDet.AllowUserToAddRows = false;
            dgvConsumoDet.ReadOnly = true;
            
            dgvConsumoDet.SelectionMode =DataGridViewSelectionMode.FullRowSelect;
            dgvConsumoDet.ReadOnly = true;
            dgvConsumoDet.Columns[0].Visible = false;
            dgvConsumoDet.Columns[1].Visible = false;
            dgvConsumoDet.Columns[2].Visible = false;
            dgvConsumoDet.Columns["Articulo"].Width = 200;

            adpArticuloConsumo = new SqlDataAdapter("select a.ArticuloID,a.Codigo,a.Nombre Articulo,f.Nombre Familia from (select *from Articulo where Tipo = 'C') a inner join Familia f on f.FamiliaID = a.FamiliaID ", connection);
            adpArticuloConsumo.SelectCommand.CommandType = CommandType.Text;
            tabArticuloConsumo = new DataTable();
            adpArticuloConsumo.Fill(tabArticuloConsumo);

            string sql = "Select *from Articulo where Tipo = 'V' ";
            if (ConsumoID ==-1)
                sql += "and ArticuloID not in (select articuloID from Consumo);";
            adpArticuloVenta = new SqlDataAdapter(sql, connection);
            adpArticuloVenta.SelectCommand.CommandType = CommandType.Text;
            tabArticuloVenta = new DataTable();
            adpArticuloVenta.Fill(tabArticuloVenta);

            cmbPlatillo.DataSource = tabArticuloVenta;
            cmbIngrediente.DataSource = tabArticuloConsumo;
            cmbPlatillo.ValueMember = "ArticuloID"; cmbPlatillo.DisplayMember = "Nombre";
            cmbIngrediente.ValueMember = "ArticuloID"; cmbIngrediente.DisplayMember = "Articulo";

            // Si es un nuevo registro
            if (ConsumoID == -1)
            {
                txtCodigo.Text = string.Empty;
                txtObservacion.Text = string.Empty;
                cmbPlatillo.SelectedIndex = -1;
                cmbIngrediente.SelectedIndex = -1;
            }
            else
            {
                // Cargar los datos del consumo
                if (tabConsumo.Rows.Count > 0)
                {
                    txtCodigo.Text = tabConsumo.Rows[0]["Codigo"].ToString();
                    txtObservacion.Text = tabConsumo.Rows[0]["Observacion"].ToString();
                    cmbPlatillo.SelectedValue = tabConsumo.Rows[0]["ArticuloID"];
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica que se haya seleccionado un ingrediente y que exista una cantidad válida
                if (cmbIngrediente.SelectedValue == null || string.IsNullOrEmpty(txtCantidad.Text.Trim()))
                {
                    MessageBox.Show("Debe seleccionar un ingrediente y especificar una cantidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Valida que la cantidad sea un número positivo
                if (!decimal.TryParse(txtCantidad.Text.Trim(), out decimal cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtén el ArtículoID seleccionado del combo
                int articuloID = (int)cmbIngrediente.SelectedValue;

                // Busca la fila correspondiente en la tabla tabArticuloConsumo para obtener información adicional
                DataRow[] articuloInfo = tabArticuloConsumo.Select($"ArticuloID = {articuloID}");
                if (articuloInfo.Length == 0)
                {
                    MessageBox.Show("No se encontró información del artículo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Extrae la información del artículo
                string cod = articuloInfo[0]["Codigo"].ToString();
                string nombre = articuloInfo[0]["Articulo"].ToString();
                string familia = articuloInfo[0]["Familia"].ToString();

                // Crea una nueva fila en tabConsumoDet y rellénala
                DataRow newRow = tabConsumoDet.NewRow();
                newRow["ArticuloID"] = articuloID; // Código del artículo
                newRow["Articulo"] = nombre;        // Nombre del artículo
                newRow["Familia"] = familia;      // Familia del artículo
                newRow["Cantidad"] = cantidad;    // Cantidad especificada por el usuario
                newRow["Codigo"] = cod;          // Código del ingrediente
                // Agrega la nueva fila al DataTable
                tabConsumoDet.Rows.Add(newRow);

                // Limpia los controles después de agregar
                txtCantidad.Clear();
                cmbIngrediente.SelectedIndex = -1;

                MessageBox.Show("Artículo agregado al detalle correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al agregar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
