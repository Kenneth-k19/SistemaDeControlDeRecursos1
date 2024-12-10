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
    public partial class frmAjusteInventarioDetalle : Form
    {
        SqlDataAdapter adpAjuste,adpArticulo,adpTipoAjuste,adpAjusteDet;
        DataTable tabAjuste,tabArticulo,tabTipoAjuste,tabAjusteDet;
        SqlConnection con;
        int AjusteID;

        public frmAjusteInventarioDetalle(int ID, SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
            AjusteID = ID;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //validar que se haya seleccionado un articulo
            if (cmbArticulo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un artículo","Error, es necesario especificar un articulo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //validar que se haya seleccionado un tipo de ajuste
            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de ajuste","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //validar que se haya ingresado una cantidad y que sea mayor a 0
            if (txtCantidad.Text == "" || txtCantidad.Text == "0")
            {
                MessageBox.Show("Debe ingresar una cantidad y debe ser mayor a 0", "Error en la cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Agregar un nuevo detalle al DataTable
            DataRow newRow = tabAjusteDet.NewRow();
            newRow["ArticuloID"] = cmbArticulo.SelectedValue;
            newRow["Articulo"] = cmbArticulo.Text;
            newRow["Cantidad"] = txtCantidad.Text;
            newRow["TipoAjusteID"] = cmbTipo.SelectedValue;
            newRow["TipoAjuste"] = cmbTipo.Text;
            tabAjusteDet.Rows.Add(newRow);

            //limpiar esos 3 controles
            cmbArticulo.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            txtCantidad.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //tomar la fila seleccionada usando DefaultView
            int index = gridAjusteDet.CurrentRow.Index;

            //borrar esa fila
            tabAjusteDet.DefaultView.Table.Rows[index].Delete();
        }

        private void frmAjusteInventarioDetalle_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(145, 19, 66);
           
            // Cargar información del ajuste principal
            adpAjuste = new SqlDataAdapter("exec spAjusteSelect " + AjusteID, con);
            adpAjuste.SelectCommand.CommandType = CommandType.Text;
            tabAjuste = new DataTable();
            adpAjuste.Fill(tabAjuste);

            // Llenar el combo de artículos
            adpArticulo = new SqlDataAdapter("SELECT ArticuloID, Nombre FROM Articulo WHERE Tipo = 'C'", con);
            adpArticulo.SelectCommand.CommandType = CommandType.Text;
            tabArticulo = new DataTable();
            adpArticulo.Fill(tabArticulo);
            cmbArticulo.DataSource = tabArticulo;
            cmbArticulo.ValueMember = "ArticuloID";
            cmbArticulo.DisplayMember = "Nombre";

            // Llenar el combo de tipos de ajuste
            adpTipoAjuste = new SqlDataAdapter("SELECT TipoAjusteID, Nombre FROM TipoAjuste", con);
            adpTipoAjuste.SelectCommand.CommandType = CommandType.Text;
            tabTipoAjuste = new DataTable();
            adpTipoAjuste.Fill(tabTipoAjuste);
            cmbTipo.DataSource = tabTipoAjuste;
            cmbTipo.ValueMember = "TipoAjusteID";
            cmbTipo.DisplayMember = "Nombre";

            // Cargar el detalle del ajuste
            adpAjusteDet = new SqlDataAdapter("EXEC spAjusteDetSelect " + AjusteID, con);
            tabAjusteDet = new DataTable();
            adpAjusteDet.Fill(tabAjusteDet);

            if (AjusteID > 0)
            {
                // Modo edición: cargar información del ajuste en los controles
                txtCodigo.Text = tabAjuste.Rows[0]["Codigo Ajuste"].ToString();
                txtUsuario.Text = tabAjuste.Rows[0]["Usuario"].ToString();
                dtpFecha.Value = Convert.ToDateTime(tabAjuste.Rows[0]["Fecha"]);
                txtObservacion.Text = tabAjuste.Rows[0]["Observacion"].ToString();
            }
            else
            {
                // Modo inserción: nuevo ajuste
                txtCodigo.Text = "Nuevo";
                int userID = frmLogin.userID;
                SqlDataAdapter adpUsuario = new SqlDataAdapter("SELECT Nombre FROM Usuario WHERE UsuarioID = " + userID, con);
                DataTable tabUsuario = new DataTable();
                adpUsuario.Fill(tabUsuario);
                txtUsuario.Text = tabUsuario.Rows[0]["Nombre"].ToString();
            }

            // Configuración del DataGridView
            gridAjusteDet.DataSource = tabAjusteDet;
            gridAjusteDet.ReadOnly = false;
            gridAjusteDet.AllowUserToAddRows = false;
            gridAjusteDet.AllowUserToDeleteRows = true;
            gridAjusteDet.Columns["AjusteDetID"].Visible = false;
            gridAjusteDet.Columns["AjusteID"].Visible = false;
            gridAjusteDet.Columns["ArticuloID"].Visible = false;
            gridAjusteDet.Columns["Articulo"].Width = 200;
            gridAjusteDet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridAjusteDet.Columns["TipoAjuste"].Width = 150;

            // Permitir solo la edición de la columna Cantidad
            foreach (DataGridViewColumn column in gridAjusteDet.Columns)
            {
                if (column.Name != "Cantidad")
                    column.ReadOnly = true;
            }

            cmbArticulo.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!PeriodoAbierto(dtpFecha.Value))
            {
                MessageBox.Show("La fecha del ajuste no corresponde a un período abierto.", "Período Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //validar
            if (tabAjusteDet.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un artículo al ajuste", "Información Faltante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //preguntar si se quiere continuar sin ingresar observación
            if (txtObservacion.Text == "")
            {
                if (MessageBox.Show("¿Desea continuar sin registrar observación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    txtObservacion.Focus();
                    return;
                }
            }
            SqlCommandBuilder cbAjusteDet = new SqlCommandBuilder(adpAjusteDet);

            if (AjusteID == -1)
            {
                // Modo inserción: Insertar ajuste
                SqlCommand cmdInsert = new SqlCommand("EXEC spAjusteInsert @AjusteID OUTPUT, @Fecha, @PeriodoID OUTPUT, @UsuarioID, @Observacion, @Estado", con);
                cmdInsert.Parameters.AddWithValue("@Fecha", dtpFecha.Value);
                cmdInsert.Parameters.AddWithValue("@UsuarioID", frmLogin.userID);
                cmdInsert.Parameters.AddWithValue("@Observacion", txtObservacion.Text);
                cmdInsert.Parameters.AddWithValue("@Estado", "A");
                SqlParameter ajusteIDParam = new SqlParameter("@AjusteID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter periodoIDParam = new SqlParameter("@PeriodoID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmdInsert.Parameters.Add(ajusteIDParam);
                cmdInsert.Parameters.Add(periodoIDParam);

                con.Open();
                cmdInsert.ExecuteNonQuery();
                con.Close();

                AjusteID = (int)ajusteIDParam.Value;
            }
            else
            {
                // Modo edición: Actualizar ajuste
                SqlCommand cmdUpdate = new SqlCommand("EXEC spAjusteUpdate @AjusteID, @Fecha, @PeriodoID OUTPUT, @UsuarioID, @Observacion, @Estado", con);
                cmdUpdate.Parameters.AddWithValue("@AjusteID", AjusteID);
                cmdUpdate.Parameters.AddWithValue("@Fecha", dtpFecha.Value);
                cmdUpdate.Parameters.AddWithValue("@UsuarioID", frmLogin.userID);
                cmdUpdate.Parameters.AddWithValue("@Observacion", txtObservacion.Text);
                cmdUpdate.Parameters.AddWithValue("@Estado", "A");
                SqlParameter periodoIDParam = new SqlParameter("@PeriodoID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmdUpdate.Parameters.Add(periodoIDParam);

                con.Open();
                cmdUpdate.ExecuteNonQuery();
                con.Close();
            }

            // Guardar los detalles
            foreach (DataRow row in tabAjusteDet.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    SqlCommand cmdInsertDet = new SqlCommand("EXEC spAjusteDetInsert  NULL, @AjusteID, @ArticuloID, @Cantidad, @TipoAjusteID", con);
                    cmdInsertDet.Parameters.AddWithValue("@AjusteID", AjusteID);
                    cmdInsertDet.Parameters.AddWithValue("@ArticuloID", row["ArticuloID"]);
                    cmdInsertDet.Parameters.AddWithValue("@Cantidad", row["Cantidad"]);
                    cmdInsertDet.Parameters.AddWithValue("@TipoAjusteID", row["TipoAjusteID"]);

                    con.Open();
                    cmdInsertDet.ExecuteNonQuery();
                    con.Close();
                }
            }

            MessageBox.Show("¡Ajuste guardado exitosamente!","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }
        private bool PeriodoAbierto(DateTime fechaMovimiento)
        {
            try
            {
                // Consulta para verificar si la fecha pertenece a un período abierto
                string query = @"
                  SELECT COUNT(*)
                    FROM Periodo
                    WHERE @FechaMovimiento BETWEEN Inicio AND Final
                  AND Estado = 'A'";

                // Crear el comando con la conexión existente
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FechaMovimiento", fechaMovimiento);

                // Abrir la conexión si está cerrada
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Ejecutar la consulta y obtener el resultado
                int count = (int)cmd.ExecuteScalar();

                // Cerrar la conexión
                con.Close();

                // Si el resultado es mayor a 0, la fecha pertenece a un período abierto
                return count > 0;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al validar el período: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Cerrar la conexión en caso de error
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                return false; // En caso de error, devuelve false
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
