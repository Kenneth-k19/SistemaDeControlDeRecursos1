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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaDeControlDeRecursos
{
    public partial class frmCompras : Form
    {
        private SqlConnection con;
        private SqlDataAdapter adpCompras;
        private DataTable dtCompras;
        private SqlDataAdapter adpCodigo;
        private SqlDataAdapter adpCombos;
        private SqlDataAdapter adpInsert;
        private DataTable dtInsert;
        private DataSet dsCombos;
        private BindingSource bsCompras;


        int usuarioID;

       

        public frmCompras()
        {
            InitializeComponent();
        }

        public frmCompras(SqlConnection con)
        {

            usuarioID = frmLogin.userID;
            this.con = con;

            string sentenciaDS = "select * from Proveedor; " +
                                 "select * from vValores where Tabla = 'Compra' and Columna = 'Tipo'; " +
                                 "select * from vValores where Tabla = 'Compra' and Columna = 'Estado'; ";
            InitializeComponent();

            usuarioID = frmLogin.userID;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 142, 168);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            adpCompras = new SqlDataAdapter("spCompraTotaleSelect", this.con);
            adpCompras.SelectCommand.CommandType = CommandType.StoredProcedure;

            adpCodigo = new SqlDataAdapter("select dbo.fCalcularCodigoCompra()", this.con);


            //@compraid int output, @codigo varchar(20) output, @proveedorID int,
            //@fecha datetime, @tipo varchar(1),
            //@documento varchar(20), @estado int, @usuarioID int
            adpCompras.InsertCommand = new SqlCommand("spCompraInsert", this.con);
            adpCompras.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpCompras.InsertCommand.Parameters.Add("@proveedorID", SqlDbType.Int, 4, "ProveedorID");
            adpCompras.InsertCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 8, "Fecha");
            adpCompras.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 1, "Tipo");
            adpCompras.InsertCommand.Parameters.Add("@documento", SqlDbType.VarChar, 20, "Documento");
            adpCompras.InsertCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpCompras.InsertCommand.Parameters.Add("@usuarioID", SqlDbType.Int, 4, "UsuarioID");

            //@codigo varchar(20), @proveedorID int, @tipo varchar(1),
            //@documento varchar(1), @estado int, @usuarioID int
            adpCompras.UpdateCommand = new SqlCommand("spCompraUpdate", this.con);
            adpCompras.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpCompras.UpdateCommand.Parameters.Add("@codigo", SqlDbType.VarChar, 20, "Codigo");
            adpCompras.UpdateCommand.Parameters.Add("@proveedorID", SqlDbType.Int, 4, "ProveedorID");
            adpCompras.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 1, "Tipo");
            adpCompras.UpdateCommand.Parameters.Add("@documento", SqlDbType.VarChar, 20, "Documento");
            adpCompras.UpdateCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpCompras.UpdateCommand.Parameters.Add("@usuarioID", SqlDbType.Int, 4, "UsuarioID");

            adpCombos = new SqlDataAdapter(sentenciaDS, this.con);

            if (adpCombos == null)
            {
                throw new InvalidOperationException("El adaptador de datos 'adpCombos' no se inicializó correctamente.");
            }
        }

        private void inhabilitarCamposCompras()
        {
            txtCodigo.Enabled = false;
            dtpFecha.Enabled = false;
            cmbProveedor.Enabled = false;
            txtDocumento.Enabled = false;
            cmbEstado.Enabled = false;
            cmbTipo.Enabled = false;
        }

        private void habilitarCamposCompras()
        {
            //dtpFecha.Enabled = true;
            cmbProveedor.Enabled = true;
            txtDocumento.Enabled = true;
            cmbEstado.Enabled = true;
            cmbTipo.Enabled = true;
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            try
            {

                dtCompras = new DataTable();
                bsCompras = new BindingSource();
                dsCombos = new DataSet();
                adpCombos.Fill(dsCombos);

                cmbProveedor.ValueMember = "ProveedorID";
                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.DataSource = dsCombos.Tables[0];

                cmbTipo.ValueMember = "Codigo";
                cmbTipo.DisplayMember = "Valor";
                cmbTipo.DataSource = dsCombos.Tables[1];

                cmbTipoFiltro.ValueMember = "Codigo";
                cmbTipoFiltro.DisplayMember = "Valor";
                cmbTipoFiltro.DataSource = dsCombos.Tables[1];

                cmbEstado.ValueMember = "Codigo";
                cmbEstado.DisplayMember = "Valor";
                cmbEstado.DataSource = dsCombos.Tables[2];

                adpCompras.Fill(dtCompras);
                dataGridView1.DataSource = dtCompras;
                bsCompras.DataSource = dtCompras;

                dtpFecha.Value = DateTime.Now.Date;
            }catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la ventana de Compras. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnNuevo.Text == "Nuevo")
                {
                    btnNuevo.Text = "Insertar";

                    dtInsert    = new DataTable();
                    adpInsert = new SqlDataAdapter("select * from Compra", this.con);
                    adpInsert.Fill(dtInsert);

                    this.con.Open();
                    object codigo = adpCodigo.SelectCommand.ExecuteScalar();
                    this.con.Close();
                    txtCodigo.Text = codigo.ToString();

                    habilitarCamposCompras();
                    btnAgregarDetalle.Enabled = false;
                    btnModificar.Enabled = false;

                    btnVolver.Visible = true;
                }
                else if (btnNuevo.Text == "Insertar")
                {

                    DataRow nuevaFila = dtInsert.NewRow();

                    nuevaFila["ProveedorID"] = cmbProveedor.SelectedValue;
                    nuevaFila["Tipo"] = cmbTipo.SelectedValue;
                    nuevaFila["Documento"] = txtDocumento.Text;
                    nuevaFila["Estado"] = cmbEstado.SelectedValue;
                    nuevaFila["UsuarioID"] = frmLogin.userID;

                    dtInsert.Rows.Add(nuevaFila);


                    adpCompras.Update(dtInsert);
                    dtCompras.Clear();
                    adpCompras.Fill(dtCompras);
                    dataGridView1.Refresh();

                    inhabilitarCamposCompras();
                    btnNuevo.Text = "Nuevo";
                    btnAgregarDetalle.Enabled = true;
                    btnModificar.Enabled = true;

                    MessageBox.Show("Los datos se insertaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }catch (Exception ex){
                MessageBox.Show("Error al insertar los datos. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnModificar.Text == "Editar")
            {

                dtInsert = new DataTable();
                adpInsert = new SqlDataAdapter("select * from Compra where Codigo = '" + txtCodigo.Text + "'", this.con);
                adpInsert.Fill(dtInsert);

                habilitarCamposCompras();
                dtpFecha.Enabled = true;
                btnModificar.Text = "Guardar";

                btnNuevo.Enabled = false;
                btnAgregarDetalle.Enabled = false;
                btnVolver.Visible = true;

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int indice = dataGridView1.SelectedRows[0].Index;

                    txtCodigo.Text = dtCompras.DefaultView[indice]["Codigo"].ToString();
                    dtpFecha.Value = Convert.ToDateTime(dtCompras.DefaultView[indice]["Fecha"]);
                    cmbProveedor.DisplayMember = dtCompras.DefaultView[indice]["Proveedor"].ToString();
                    txtDocumento.Text = dtCompras.DefaultView[indice]["Documento"].ToString();
                    cmbEstado.DisplayMember = dtCompras.DefaultView[indice]["Estado"].ToString();
                    cmbTipo.DisplayMember = dtCompras.DefaultView[indice]["Tipo de Compra"].ToString();

                    dtInsert = new DataTable();
                    adpInsert = new SqlDataAdapter("select * from Compra where Codigo = '" + txtCodigo.Text + "'", this.con);
                    adpInsert.Fill(dtInsert);
                }
            }
            else if (btnModificar.Text == "Guardar")
            {
                DataRow filaModificada = dtInsert.Rows[0];

                filaModificada["Codigo"] = txtCodigo.Text;
                filaModificada["ProveedorID"] = cmbProveedor.SelectedValue;
                filaModificada["Tipo"] = cmbTipo.SelectedValue;
                filaModificada["Documento"] = txtDocumento.Text;
                filaModificada["Estado"] = cmbEstado.SelectedValue;
                filaModificada["UsuarioID"] = frmLogin.userID;

                adpCompras.Update(dtInsert);
                dtCompras.Clear();
                adpCompras.Fill(dtCompras);
                dataGridView1.Refresh();

                inhabilitarCamposCompras();
                btnModificar.Text = "Editar";
                btnAgregarDetalle.Enabled = true;
                btnNuevo.Enabled = true;

                MessageBox.Show("Los datos se modificaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            string codigo;

            if (dataGridView1.SelectedRows.Count > 0)
            { 
                int indice = dataGridView1.SelectedRows[0].Index;

                codigo = dtCompras.DefaultView[indice]["Codigo"].ToString();

                frmComprasDetalle frm = new frmComprasDetalle(codigo, this.con);
                frm.Owner = this;
                frm.ShowDialog();

                dtCompras.Clear();
                adpCompras.Fill(dtCompras);
                dataGridView1.Refresh();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if(btnNuevo.Text == "Insertar")
            {
                inhabilitarCamposCompras();
                btnNuevo.Text = "Nuevo";
                btnAgregarDetalle.Enabled = true;
                btnModificar.Enabled = true;

                txtCodigo.Text = "";
                dtpFecha.Value = DateTime.Now;
                cmbProveedor.SelectedIndex = -1;
                txtDocumento.Text = "";
                cmbEstado.SelectedIndex = -1;
                cmbTipo.SelectedIndex = -1;
            }

            if (btnModificar.Text == "Guardar")
            {
                inhabilitarCamposCompras();
                btnModificar.Text = "Editar";
                btnAgregarDetalle.Enabled = true;
                btnNuevo.Enabled = true;

                txtCodigo.Text = "";
                dtpFecha.Value = DateTime.Now;
                cmbProveedor.SelectedIndex = -1;
                txtDocumento.Text = "";
                cmbEstado.SelectedIndex = -1;
                cmbTipo.SelectedIndex = -1;
            }
        }
    }
}
