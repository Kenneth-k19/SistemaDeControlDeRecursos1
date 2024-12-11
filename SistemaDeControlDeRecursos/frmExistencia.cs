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
    public partial class frmExistencia : Form
    {
        SqlConnection con;
        DataTable dtExistencia;
        SqlDataAdapter adpExistencia;

        public frmExistencia()
        {
            InitializeComponent();
        }

        public frmExistencia(SqlConnection con)
        {
            this.con = con;



            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 142, 168);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            adpExistencia = new SqlDataAdapter("spExistenciaSelect", con);
            adpExistencia.SelectCommand.CommandType = CommandType.StoredProcedure;

        }

        private void frmExistencia_Load(object sender, EventArgs e)
        {
            try
            {
                dtExistencia = new DataTable();
                adpExistencia.Fill(dtExistencia);
                dataGridView1.DataSource = dtExistencia;

            }catch (Exception ex)
            {

                MessageBox.Show("Error al cargar la ventana de Existencias. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtBuscar.Text.Length == 0)
                {
                    dtExistencia.DefaultView.RowFilter = "";
                }
                else
                {
                dtExistencia.DefaultView.RowFilter = "Nombre LIKE '%" + txtBuscar.Text + "%'";    
                }
                dtExistencia.Clear();
                adpExistencia.Fill(dtExistencia);
                dataGridView1.DataSource = dtExistencia;
            }
            catch (Exception ex) {
                MessageBox.Show("Error al cargar la ventana de Existencias. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
