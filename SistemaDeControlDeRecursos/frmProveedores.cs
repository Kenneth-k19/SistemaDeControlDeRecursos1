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
    public partial class frmProveedores : Form
    {
        DataTable dt;
        public frmProveedores()
        {
            InitializeComponent();
            dt = new DataTable();
        }

        public void cargarDatos()
        {
            try
            {
                dt = DBAccess.getSelectCommandDT("spProveedorSelect", new Dictionary<string, (object valor, ParameterDirection? direccion)> 
                {
                    {"@provId", (0, null)}
                });
                grid1.DataSource = this.dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmProveedores_Load(object sender, EventArgs e)
        {
            cargarDatos();

            grid1.RowHeadersVisible = false;
            grid1.ReadOnly = true;
            grid1.AllowUserToAddRows = false;
            grid1.AllowUserToDeleteRows = false;
            grid1.AllowUserToResizeRows = false;
            grid1.MultiSelect = false;

            this.grid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grid1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grid1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grid1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grid1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grid1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.grid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.grid1.DefaultCellStyle.Font = new Font("Poppins", 10);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmProveedoresInsertarModificar provForm = new frmProveedoresInsertarModificar();
            provForm.ShowDialog();

            if (provForm.IsDisposed == false)
            {
                try
                {
                    dt = DBAccess.getSelectCommandDT("spProveedorInsert", new Dictionary<string, (object valor, ParameterDirection? direccion)> 
                    {
                        {"@nombre", (provForm.txtNombre.Text, null)},
                        {"@tipoCompleto", (provForm.comboBoxTipo.Text, null)},
                        {"@rtn", (provForm.txtRtn.Text, null)},
                        {"@dir", (provForm.txtDir.Text, null)},
                        {"@telf", (provForm.txtTelf.Text, null)},
                        {"@contacto", (provForm.txtCon.Text, null)},
                        {"@descr", (provForm.txtDes.Text, null)},
                        {"@catgProd", (provForm.comboBoxCatProd.Text, null)}
                    });
                
                    this.dt.Clear();
                    this.cargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar agregar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dt.Rows.Count == 0)
                return;

            frmProveedoresInsertarModificar provForm = new frmProveedoresInsertarModificar();
            
            provForm.comboBoxCatProd.Enabled = false;
            provForm.txtNombre.Text = grid1.CurrentRow.Cells["Nombre"].Value.ToString();
            string tipoBD = grid1.CurrentRow.Cells["Tipo"].Value.ToString();
            if (tipoBD == "E")
                tipoBD = "Empresa";
            if (tipoBD == "I")
                tipoBD = "Individuo";

            provForm.comboBoxTipo.SelectedItem = tipoBD;
            provForm.txtRtn.Text = grid1.CurrentRow.Cells["RTN"].Value.ToString();
            provForm.txtDir.Text = grid1.CurrentRow.Cells["Direccion"].Value.ToString();
            provForm.txtTelf.Text = grid1.CurrentRow.Cells["Telefono"].Value.ToString();
            provForm.txtCon.Text = grid1.CurrentRow.Cells["Contacto"].Value.ToString();
            provForm.txtDes.Text = grid1.CurrentRow.Cells["Descripcion"].Value.ToString();

            provForm.ShowDialog();

                try
                {
                    dt = DBAccess.getSelectCommandDT("spProveedorUpdate", new Dictionary<string, (object valor, ParameterDirection? direccion)>
                    {
                        {"@cod", (grid1.CurrentRow.Cells["Codigo"].Value.ToString(), null)},
                        {"@nombre", (provForm.txtNombre.Text, null)},
                        {"@tipoCompleto", (provForm.comboBoxTipo.Text, null)},
                        {"@rtn", (provForm.txtRtn.Text, null)},
                        {"@dir", (provForm.txtDir.Text, null)},
                        {"@telf", (provForm.txtTelf.Text, null)},
                        {"@contacto", (provForm.txtCon.Text, null)},
                        {"@descr", (provForm.txtDes.Text, null)}
                    });

                    this.dt.Clear();
                    this.cargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar actualizar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtBusqueda.Text == "")
                MessageBox.Show("No ha escrito ningún nombre para hacer la busqueda");

            try
            {
                dt = DBAccess.getSelectCommandDT("spProveedorSelectBusqueda", new Dictionary<string, (object valor, ParameterDirection? direccion)>
                    {
                        {"@busqueda", (txtBusqueda.Text, null)}
                    });

                grid1.DataSource = this.dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBusqueda.Text != "")
                {
                    dt = DBAccess.getSelectCommandDT("spProveedorSelectBusqueda", new Dictionary<string, (object valor, ParameterDirection? direccion)>
                    {
                        {"@busqueda", (txtBusqueda.Text, null)}
                    });

                    grid1.DataSource = this.dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los datos. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

