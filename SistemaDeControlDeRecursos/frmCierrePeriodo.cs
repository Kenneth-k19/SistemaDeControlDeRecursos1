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
    public partial class frmCierrePeriodo : Form
    {
        SqlConnection connection;
        SqlDataAdapter adpPeriodo;
        DataTable tabPeriodo;

        public frmCierrePeriodo(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Llama al procedimiento almacenado para insertar un nuevo periodo
                SqlCommand cmd = new SqlCommand("spPeriodoInsert", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Nuevo periodo agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar los periodos en el DataGridView
                CargarPeriodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el nuevo periodo: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un periodo para cerrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener el ID y estado del periodo seleccionado
                int periodoID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["CodigoPeriodo"].Value);
                string estado = dataGridView1.SelectedRows[0].Cells["Estado"].Value.ToString();

                // Validar si el periodo ya está cerrado
                if (estado == "Cerrado")
                {
                    MessageBox.Show("El periodo seleccionado ya está cerrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Validar si el periodo anterior sigue abierto
                DataRow[] rows = tabPeriodo.Select($"CodigoPeriodo < {periodoID} AND Estado = 'Abierto'");
                if (rows.Length > 0)
                {
                    MessageBox.Show("No se puede cerrar este periodo porque el periodo anterior está abierto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llama al procedimiento almacenado para cerrar el periodo
                SqlCommand cmd = new SqlCommand("spPeriodoCierre", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PeriodoID", periodoID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Periodo cerrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar los periodos en el DataGridView
                CargarPeriodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar el periodo: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        private void frmCierrePeriodo_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Deshabilitar la reorganización de columnas
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // Cargar los periodos en el DataGridView al cargar el formulario
            CargarPeriodos();

        }
        private void CargarPeriodos()
        {
            try
            {
                adpPeriodo = new SqlDataAdapter("EXEC spPeriodoSelect", connection);
                tabPeriodo = new DataTable();
                adpPeriodo.Fill(tabPeriodo);

                dataGridView1.DataSource = tabPeriodo;

                // Configurar encabezados y deshabilitar ordenamiento
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dataGridView1.Columns["CodigoPeriodo"].HeaderText = "Código";
                dataGridView1.Columns["Inicio"].HeaderText = "Fecha Inicio";
                dataGridView1.Columns["Final"].HeaderText = "Fecha Final";
                dataGridView1.Columns["Tipo"].HeaderText = "Tipo";
                dataGridView1.Columns["Estado"].HeaderText = "Estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los periodos: " + ex.Message);
            }
        }
    }
}
