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

    public partial class frmArticuloFactura : Form
    {
        int m, mx, my;


        public static int articuloid { get; set; }

        public static string nombreArticulo { get; set; }

        public static float precioArticulo { get; set; }

        public static int existencia { get; set; }

        public static string inventario { get; set; }


        SqlDataAdapter adpArticuloFac;
        DataTable dtArticuloFac;
        BindingSource bsArticuloFac;

        public frmArticuloFactura()
        {
            InitializeComponent();
        }

        public frmArticuloFactura(SqlConnection con)
        {
            InitializeComponent();

            adpArticuloFac = new SqlDataAdapter();
            dtArticuloFac = new DataTable();
            bsArticuloFac = new BindingSource();

            adpArticuloFac.SelectCommand = new SqlCommand("spArticuloFactura", con);
            adpArticuloFac.SelectCommand.CommandType = CommandType.StoredProcedure;

            adpArticuloFac.Fill(dtArticuloFac);
            bsArticuloFac.DataSource = dtArticuloFac;
            dataGridView1.DataSource = dtArticuloFac;

            articuloid = 0;
            nombreArticulo = "";
            precioArticulo = 0;
            existencia = 0;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                float precio = 0;
                int id = int.Parse(filaSeleccionada.Cells["ArticuloID"].Value.ToString());
                string nombre = filaSeleccionada.Cells["Nombre"].Value.ToString();

                if(!string.IsNullOrWhiteSpace(filaSeleccionada.Cells["Precio"].Value.ToString().Trim()))
                {
                    precio = float.Parse(filaSeleccionada.Cells["Precio"].Value.ToString());
                }

                int EXISTENCIA = int.Parse(filaSeleccionada.Cells["Existencia"].Value.ToString());
                string INVENTARIO = filaSeleccionada.Cells["Inventario"].Value.ToString();
                

                articuloid = id;
                nombreArticulo = nombre;
                precioArticulo = precio;
                existencia = EXISTENCIA;
                inventario = INVENTARIO;

                this.Dispose();
            }
            else
            {
                    MessageBox.Show("Seleccione solo una fila, por favor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.Trim();

            bsArticuloFac.Filter = $"Nombre like '%{filtro}%'";
        }

        private void frmArticuloFactura_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(145, 19, 66);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.Font = new Font("Poppins", 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
