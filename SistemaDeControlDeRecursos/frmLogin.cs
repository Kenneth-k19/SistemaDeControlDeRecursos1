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

        //variables usadas para la funcionalidad de mover la ventana
        int m, mx, my;

       /* public SqlConnection getConexion
        {
            get { return this.conexion; }
        }*/

        public bool getConectado
        {
            get { return this.conectado; }
        }

        public static int userID { get; set; }

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

        //Funcion para validar que ambos textboxes en el login estén llenos para proceder a verificar los accesos
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
            
            //Se establecen los colores de los elementos en el login
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
            //cerramos la ventana de login en caso de que el usuario haga clic en la X
            this.Dispose();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            /* Si el usuario se posiciona en el txt de usuario quitamos el placeholder */
            if(txtUsuario.Text == "Ingrese su usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.FromArgb(107, 44, 0);
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            /* Si el usuario se quita del txt usuario y no ha escrito nada volvemos a poner el placeholder */
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "Ingrese su usuario";
                txtUsuario.ForeColor = Color.FromArgb(165, 109, 77);
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            /* Si el usuario se posiciona en el txt de contraseña quitamos el placeholder */
            if (txtContrasena.Text == "Ingrese su contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.FromArgb(107, 44, 0);
                txtContrasena.PasswordChar = '*';
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            /* Si el usuario se quita del txt contraseña y no ha escrito nada volvemos a poner el
             * placeholder y el passwordChar deja de ser asterisco*/
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
                /* al dar clic en ingresar se verifica que no haya txt en blanco para hacer
                 * autenticacion de las credenciales del usuario */
                label2.Text = "";
                if (this.validarBlancos())
                {
                    return;
                }



                /*String url = "Server=" + "3.128.144.165" + "; Database=" + "DB20172001423"
                             + "; UID=" + "brandon.portan" + "; PWD=" + "BP20172001423" + ";";

                conexion.ConnectionString = url;*/

                /* se verifica en la bd que las credenciales sean las correctas */
                dtAutenticacion = DBAccess.getSelectCommandDT("spAutenticarUsuario",new Dictionary<string, (object valor, ParameterDirection? direccion)>
                {
                    {"@codigo", (txtUsuario.Text, null) },
                    {"@contrasena", (txtContrasena.Text, null) }
                } );
                //adpAutenticacion = new SqlDataAdapter("spAutenticarUsuario", DBAccess.getDBConnection);
                //adpAutenticacion.SelectCommand.CommandType = CommandType.StoredProcedure;
                //adpAutenticacion.SelectCommand.Parameters.AddWithValue("@codigo", txtUsuario.Text);
                //adpAutenticacion.SelectCommand.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

                //adpAutenticacion.Fill(dtAutenticacion);X

                /* Si las credenciales son correctas se recibira una fila */
                if (dtAutenticacion.Rows.Count > 0)
                {
                    conectado = true;
                    this.usuarioID = (int)dtAutenticacion.Rows[0][0];
                    frmLogin.userID = this.usuarioID;

                    /* se obtienen los accesos con los que cuenta el usuario que se esta conectando. */

                    dtAccesos = DBAccess.getSelectCommandDT("spObtenerAcceso", new Dictionary<string, (object valor, ParameterDirection? direccion)>
                    {
                        {"@usuarioid", (this.usuarioID, null) }
                    });

                    
                    
                    //adpAutenticacion = new SqlDataAdapter("spObtenerAcceso", DBAccess.getDBConnection);
                    //adpAutenticacion.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //adpAutenticacion.SelectCommand.Parameters.AddWithValue("@usuarioid", this.usuarioID);

                    //adpAutenticacion.Fill(dtAccesos);
                }
                else
                {
                    /* si no recibimos fila las credenciales fueron incorrectas y se lo decimos al usuario */
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
            /* obteniendo los parametros de posicion cuando el mouse esta siendo arrastrado a traves de
             * la pantalla */
            m = 1;
            mx = e.X;
            my = e.Y;

        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            /* cuando el moues es soltado establecemos m=0 para dejar de enviar parametros de posicion */
            m = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            /* mientras m=1 vamos a estar recibiendo parametros de poscision ya que el mouse estará
             * siendo arrastrado */
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }
    }
}
