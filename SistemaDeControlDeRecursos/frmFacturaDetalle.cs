using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeControlDeRecursos
{
    public partial class frmFacturaDetalle : Form
    {
        SqlConnection Con;
        SqlDataAdapter adpFacturaDet;
        DataTable dtFacturaDet;

        int ID;
        string CODIGO;
        int articuloID;
        string articuloNombre;
        float precioArticulo;

        public frmFacturaDetalle()
        {
            InitializeComponent();
        }

        public frmFacturaDetalle(SqlConnection con)
        {
            InitializeComponent();

            Con = con;
        }

        public frmFacturaDetalle(string codigo, int id, SqlConnection con)
        {
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 142, 168);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
            txtFacturaID.Enabled=false;

            try
            {
                adpFacturaDet = new SqlDataAdapter();
                dtFacturaDet = new DataTable();

                adpFacturaDet.SelectCommand = new SqlCommand("spSelectFacturaDet", con);
                adpFacturaDet.SelectCommand.CommandType = CommandType.StoredProcedure;
                adpFacturaDet.SelectCommand.Parameters.Add(new SqlParameter("@id",SqlDbType.Int)
                {
                    Value = id
                });
                adpFacturaDet.SelectCommand.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar,20)
                {
                    Value = codigo
                });

                adpFacturaDet.Fill(dtFacturaDet);
                dataGridView1.DataSource = dtFacturaDet;




                adpFacturaDet.InsertCommand = new SqlCommand("spInsertFacturaDet", con);
                adpFacturaDet.InsertCommand.CommandType = CommandType.StoredProcedure;
                adpFacturaDet.InsertCommand.Parameters.Add("@facturaid", SqlDbType.Int, 4, "FacturaID");
                adpFacturaDet.InsertCommand.Parameters.Add("@articuloid", SqlDbType.Int, 4, "ArticuloID");
                adpFacturaDet.InsertCommand.Parameters.Add("@cantidad", SqlDbType.Int, 4, "Cantidad");
                adpFacturaDet.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 4, "Precio");
                adpFacturaDet.InsertCommand.Parameters.Add("@observacion", SqlDbType.VarChar, 75, "Observacion");
                adpFacturaDet.InsertCommand.Parameters.Add("@descuento", SqlDbType.Float, 4, "Descuento");


                adpFacturaDet.DeleteCommand = new SqlCommand("spEliminarFacturaDet", con);
                adpFacturaDet.DeleteCommand.CommandType = CommandType.StoredProcedure;
                adpFacturaDet.DeleteCommand.Parameters.Add("@facturadetid",SqlDbType.Int,4,"FacturaDetID");


                dataGridView1.Columns["FacturaID"].Visible = false;
                dataGridView1.Columns["ArticuloID"].Visible = false;
                dataGridView1.Columns["FacturaDetID"].Visible = false;

                ID = id;
                CODIGO = codigo;
                Con = con;
                articuloID = 0;
                articuloNombre = "";
                precioArticulo = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmFacturaDetalle_Load(object sender, EventArgs e)
        {
           

            panel1.BackColor = Color.FromArgb(145, 19, 66);

            txtFacturaID.Text = CODIGO;

            txtFacturaID.Enabled = false;
            txtArticuloId.Enabled = false;
            txtArtiNombre.Enabled = false;
            txtCantidad.Enabled = false;
            txtPrecio.Enabled = false;
            txtDescuento.Enabled = false;
            txtReferencia.Enabled = false;
            txtObservacion.Enabled = false;
            btnSeleccionarArticulo.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSeleccionarArticulo_Click(object sender, EventArgs e)
        {
            frmArticuloFactura frm = new frmArticuloFactura(Con);
            frm.ShowDialog();

            txtArticuloId.Text = frmArticuloFactura.articuloid.ToString();
            txtArtiNombre.Text = frmArticuloFactura.nombreArticulo;
            txtPrecio.Text = frmArticuloFactura.precioArticulo.ToString();

            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if(btnNuevo.Text == "Nuevo")
            {
                txtCantidad.Enabled = true;
                txtDescuento.Enabled = true;
                txtObservacion.Enabled = true;
                btnSeleccionarArticulo.Enabled = true;

                btnNuevo.Text = "Insertar";
            }
            else if(btnNuevo.Text == "Insertar")
            {
                DataRow nuevafila = dtFacturaDet.NewRow();

                float descuento = float.Parse(txtDescuento.Text);

                nuevafila["FacturaID"] = ID;
                nuevafila["ArticuloID"] = int.Parse(txtArticuloId.Text);
                nuevafila["Cantidad"] = int.Parse(txtCantidad.Text);
                nuevafila["Precio"] = float.Parse( txtPrecio.Text);
                nuevafila["Observacion"] = txtObservacion.Text;
                nuevafila["Descuento"] = Math.Round( float.Parse(txtDescuento.Text),2);

                dtFacturaDet.Rows.Add(nuevafila);

                try
                {
                    adpFacturaDet.Update(dtFacturaDet);
                    dtFacturaDet.Clear();
                    adpFacturaDet.Fill(dtFacturaDet);
                    dataGridView1.Refresh();

                    txtCantidad.Enabled = false;
                    txtDescuento.Enabled = false;
                    txtObservacion.Enabled = false;
                    btnNuevo.Text = "Nuevo";
                    btnSeleccionarArticulo.Enabled = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["FacturaDetID"].Value);

                    DataRow[] fila = dtFacturaDet.Select("FacturaDetID = " + id);

                    if(fila.Length == 1)
                    {
                        fila[0].Delete();
                    }

                    adpFacturaDet.Update(dtFacturaDet);
                    dtFacturaDet.Clear();
                    adpFacturaDet.Fill(dtFacturaDet);
                    dataGridView1.Refresh();
                    MessageBox.Show("El registro se eliminó correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Por favor, selecciona una fila para eliminar.");
                }
                
                
            }
        }
    }
}
