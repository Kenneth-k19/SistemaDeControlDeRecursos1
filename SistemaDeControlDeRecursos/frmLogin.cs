using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeControlDeRecursos
{
    public partial class frmLogin : Form
    {

        int m, mx, my;

        public frmLogin()
        {
            InitializeComponent();
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
