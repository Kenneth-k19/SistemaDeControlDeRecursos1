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
    public partial class frmLogin : Form
    {
       // private SqlConnection conexion;
        private bool conectado;
        private SqlDataAdapter adpAutenticacion;
        private DataTable dtAutenticacion;
        private DataTable dtAccesos;
        private int usuarioID;


        int m, mx, my;

       /* public SqlConnection getConexion
        {
            get { return this.conexion; }
        }*/

        public bool getConectado
        {
            get { return this.conectado; }
        }

        public int getUsuarioID
        {
            get { return usuarioID; }
        }

        public DataTable getAccesos
        {
            get { return dtAccesos; }
        }

        public frmLogin()
        {
            InitializeComponent();
       //     conexion = new SqlConnection();
            dtAutenticacion = new DataTable();
            dtAccesos = new DataTable();
        }

        private bool validarBlancos()
        {
            errorProvider1.Clear();
            bool hayError = false;

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text == "Ingrese su usuario")
            {
                hayError = true;
                errorProvider1.SetError(txtUsuario, "No pueden haber valores en blanco");
                return hayError;
            }
            if (string.IsNullOrWhiteSpace(txtContrasena.Text) || txtContrasena.Text == "Ingrese su contraseña")
            {
                hayError = true;
                errorProvider1.SetError(txtContrasena, "No pueden haber valores en blanco");
                return hayError;
            }


            return hayError;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            

            this.BackColor = Color.FromArgb(242, 124, 36);
            txtUsuario.BackColor = Color.FromArgb(255, 200, 112);
            txtUsuario.Text = "Ingrese su usuario";
            txtUsuario.ForeColor = Color.FromArgb(165, 109, 77);

            btnIngresar.BackColor = Color.FromArgb(191, 73, 0);
            btnIngresar.ForeColor = Color.FromArgb(107, 44, 0);

            txtContrasena.Text = "Ingrese su contraseña";
            txtContrasena.BackColor = Color.FromArgb(255, 200, 112);
            txtContrasena.ForeColor = Color.FromArgb(165, 109, 77);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Ingrese su usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "Ingrese su usuario";
                txtUsuario.ForeColor = Color.FromArgb(165, 109, 77);
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "Ingrese su contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.Black;
                txtContrasena.PasswordChar = '*';
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                txtContrasena.Text = "Ingrese su contraseña";
                txtContrasena.ForeColor = Color.FromArgb(165, 109, 77);
                txtContrasena.PasswordChar = '\0';
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try 
            {
                label2.Text = "";
                if (this.validarBlancos())
                {
                    return;
                }

                DBAccess NewConnection = new DBAccess();
                NewConnection.getDBConnection();

                /*String url = "Server=" + "3.128.144.165" + "; Database=" + "DB20172001423"
                             + "; UID=" + "brandon.portan" + "; PWD=" + "BP20172001423" + ";";

                conexion.ConnectionString = url;*/

                adpAutenticacion = new SqlDataAdapter("spAutenticarUsuario", DBAccess.conn);
                adpAutenticacion.SelectCommand.CommandType = CommandType.StoredProcedure;
                adpAutenticacion.SelectCommand.Parameters.AddWithValue("@codigo", txtUsuario.Text);
                adpAutenticacion.SelectCommand.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

                adpAutenticacion.Fill(dtAutenticacion);

                if (dtAutenticacion.Rows.Count > 0)
                {
                    conectado = true;
                    this.usuarioID = (int)dtAutenticacion.Rows[0][0];

                    adpAutenticacion = new SqlDataAdapter("spObtenerAcceso", DBAccess.conn);
                    adpAutenticacion.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adpAutenticacion.SelectCommand.Parameters.AddWithValue("@usuarioid", this.usuarioID);

                    adpAutenticacion.Fill(dtAccesos);
                }
                else
                {
                    label2.Text = "Usuario o contraseña incorrecta";
                    return;
                }

                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;

        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }
    }
}
