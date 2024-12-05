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

namespace SistemaDeControlDeRecursos
{
    public partial class frmInventario : Form
    {
        SqlConnection connection;
        SqlDataAdapter adpArticulo,adpFamilia,adpUnidad,adpTipo;
        DataTable tabArticulo, tabFamilia, tabUnidad,tabTipo;
        bool modoEdicion = false;
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

            //
            /*
             * editar
             * insertar
             * TODO: ocultar columnas cod 
                renombrar clumnas nom 
                revisar ancho de columnas
                agregar combo para filtar por familia
                filtrado común
            *
             * 
             */
        }
    }
}
