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

        

        private void frmAjusteInventarioDetalle_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(145, 19, 66);

            adpAjuste = new SqlDataAdapter("spAjusteSelect " + AjusteID, con);
            adpAjuste.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabAjuste = new DataTable();
            adpAjuste.Fill(tabAjuste);

            adpArticulo = new SqlDataAdapter("Select ArticuloID, Nombre from Articulo where tipo = 'C'", con);
            adpArticulo.SelectCommand.CommandType = CommandType.Text;
            tabArticulo = new DataTable();
            adpArticulo.Fill(tabArticulo);
            cmbArticulo.DataSource = tabArticulo;
            cmbArticulo.ValueMember = "ArticuloID";
            cmbArticulo.DisplayMember = "Nombre";


            adpTipoAjuste = new SqlDataAdapter("Select TipoAjusteID, Nombre from TipoAjuste", con);
            adpTipoAjuste.SelectCommand.CommandType = CommandType.Text;
            tabTipoAjuste = new DataTable();
            adpTipoAjuste.Fill(tabTipoAjuste);
            cmbTipo.DataSource = tabTipoAjuste;
            cmbTipo.ValueMember = "TipoAjusteID";
            cmbTipo.DisplayMember = "Nombre";

            adpAjusteDet = new SqlDataAdapter("spAjusteDetSelect " + AjusteID, con);
            adpAjusteDet.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabAjusteDet = new DataTable();
            adpAjusteDet.Fill(tabAjusteDet);

            if(AjusteID > 0)
            {
                //cargar la información a modificar
                txtCodigo.Text = tabAjuste.Rows[0]["Codigo"].ToString();
                txtUsuario.Text = tabAjuste.Rows[0]["Usuario"].ToString();
                dtpFecha.Value = Convert.ToDateTime(tabAjuste.Rows[0]["Fecha"]);
                txtObservacion.Text = tabAjuste.Rows[0]["Observacion"].ToString();

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

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
