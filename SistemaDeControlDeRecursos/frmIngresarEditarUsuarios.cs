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
    public partial class frmIngresarEditarUsuarios : Form
    {
        int m, mx, my;
        string NombreBoton;

        SqlConnection Con;
        SqlDataAdapter adapterUsuario;
        DataTable dtUsuario;

        public frmIngresarEditarUsuarios()
        {
            InitializeComponent();
        }

        public frmIngresarEditarUsuarios(string nombreBoton, SqlConnection con)
        {
            InitializeComponent();

            NombreBoton = nombreBoton;

            adapterUsuario = new SqlDataAdapter();
            dtUsuario = new DataTable();

            adapterUsuario.SelectCommand = new SqlCommand("spSelectUsuario", con);
            adapterUsuario.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapterUsuario.Fill(dtUsuario);
            

            adapterUsuario.InsertCommand = new SqlCommand("spInsertarUsuario", con);
            adapterUsuario.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapterUsuario.InsertCommand.Parameters.Add("@codigo",SqlDbType.VarChar, 15,"Codigo");
            adapterUsuario.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "Nombre");
            adapterUsuario.InsertCommand.Parameters.Add("@identidad", SqlDbType.VarChar, 15, "Identidad");
            adapterUsuario.InsertCommand.Parameters.Add("@areaid", SqlDbType.Int, 4, "AreaID");
            adapterUsuario.InsertCommand.Parameters.Add("@contrasena", SqlDbType.VarChar, 20, "Contrasena");



            Con = con;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmIngresarEditarUsuarios_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(145, 19, 66);


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(NombreBoton == "Insertar")
            {
                DataRow nuevaFila = dtUsuario.NewRow();

                nuevaFila["Codigo"] = txtCodigo.Text;
                nuevaFila["Nombre"] = txtNombre.Text;
                nuevaFila["Identidad"] = txtIdentidad.Text;
                nuevaFila["AreaID"] = txtArea.Text;
                nuevaFila["Contrasena"] = txtContra.Text;

                dtUsuario.Rows.Add(nuevaFila);

                try
                {
                    adapterUsuario.Update(dtUsuario);
                    dtUsuario.Clear();
                    adapterUsuario.Fill(dtUsuario);
                    MessageBox.Show("Los datos se insertaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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
    }
}
