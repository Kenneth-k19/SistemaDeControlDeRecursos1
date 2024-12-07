using System;
using System.CodeDom;
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
    public partial class frmFamilia : Form
    {
        SqlConnection connection;
        SqlDataAdapter adpFamilia;
        DataTable dtFamilia;
        bool modoEdicion = false;

        public frmFamilia(SqlConnection con)
        {
            InitializeComponent();
            connection = con;
        }

        private void frmFamilia_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            

            adpFamilia = new SqlDataAdapter("exec spFamiliaSelect", connection);                      
            dtFamilia = new DataTable();
            adpFamilia.Fill(dtFamilia);
            dataGridView1.DataSource = dtFamilia;

            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[0].HeaderText = "Código";
            dataGridView1.Columns[1].Width = dataGridView1.Width -70;            
            dataGridView1.Font = new Font("Segoe UI", 12);
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //validar que txtnombre no esté vacío
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Por favor, ingrese el nombre de la familia","Datos necesarios");
                txtNombre.Focus();
            }

            //hacer el insert en la db usando spFamiliaInsert
            else
            {
                try
                {
                    if (modoEdicion)
                    {
                        //hacer el update y refrescar el datagridView
                        connection.Open();
                        SqlCommand cmdUpdate = new SqlCommand("spFamiliaUpdate", connection);
                        cmdUpdate.CommandType = CommandType.StoredProcedure;
                        cmdUpdate.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmdUpdate.Parameters.AddWithValue("@FamiliaID", dtFamilia.DefaultView.Table.Rows[dataGridView1.SelectedRows[0].Index]["FamiliaID"].ToString());
                        cmdUpdate.ExecuteNonQuery();
                        adpFamilia = new SqlDataAdapter("exec spFamiliaSelect", connection);
                        dtFamilia = new DataTable();
                        adpFamilia.Fill(dtFamilia);
                        dataGridView1.DataSource = dtFamilia;
                        connection.Close();

                        //edición terminada
                        txtNombre.Text = "";
                        btnEditar.Visible = true;
                        modoEdicion = false;
                        btnInsertar.Text = "Insertar";
                        dataGridView1.Enabled = true;
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand cmdInsert = new SqlCommand("spFamiliaInsert", connection);
                        cmdInsert.CommandType = CommandType.StoredProcedure;
                        cmdInsert.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmdInsert.Parameters.AddWithValue("@FamiliaID", 0 /* valor por defecto */);
                        cmdInsert.ExecuteNonQuery();
                        adpFamilia = new SqlDataAdapter("exec spFamiliaSelect", connection);
                        dtFamilia = new DataTable();
                        adpFamilia.Fill(dtFamilia);
                        dataGridView1.DataSource = dtFamilia;
                        connection.Close();

                        txtNombre.Text = "";
                        txtBuscar.Focus();

                        MessageBox.Show("Familia creada correctamente", "Familia creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {                
                if (txtBuscar.Text.Length == 0)
                {
                    //usar defaultView de dataTable para filtrar
                    dtFamilia.DefaultView.RowFilter = "";
                }
                else
                {
                    dtFamilia.DefaultView.RowFilter = "Nombre LIKE '%" + txtBuscar.Text + "%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                String Nombre = dtFamilia.DefaultView.Table.Rows[dataGridView1.SelectedRows[0].Index]["Nombre"].ToString();
                txtNombre.Text = Nombre;

                txtNombre.Focus();
            }
        }
    }
}
