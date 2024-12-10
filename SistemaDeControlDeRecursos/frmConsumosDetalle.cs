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
            

            dgvConsumoDet.ReadOnly = true;
            dgvConsumoDet.Columns[0].Visible = false;
            dgvConsumoDet.Columns[1].Visible = false;


            adpArticuloConsumo = new SqlDataAdapter("Select *from Articulo where Tipo = 'C' ", connection);
            adpArticuloConsumo.SelectCommand.CommandType = CommandType.Text;
            tabArticuloConsumo = new DataTable();
            adpArticuloConsumo.Fill(tabArticuloConsumo);

            adpArticuloVenta = new SqlDataAdapter("Select *from Articulo where Tipo = 'V' and ArticuloID not in (select articuloID from Consumo)", connection);
            adpArticuloVenta.SelectCommand.CommandType = CommandType.Text;
            tabArticuloVenta = new DataTable();
            adpArticuloVenta.Fill(tabArticuloVenta);

            cmbPlatillo.DataSource = tabArticuloVenta;
            cmbIngrediente.DataSource = tabArticuloConsumo;
            cmbPlatillo.ValueMember = "ArticuloID"; cmbPlatillo.DisplayMember = "Nombre";
            cmbIngrediente.ValueMember = "ArticuloID"; cmbIngrediente.DisplayMember = "Nombre";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

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
