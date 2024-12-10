using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaDeControlDeRecursos
{
    public partial class frmProveedoresInsertarModificar : Form
    {
        string conOriginal, nomOriginal, rtnOriginal, dirOriginal, desOriginal, telOriginal, tipoOriginal;
        public frmProveedoresInsertarModificar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
                if(nomOriginal == "")
                {
                    this.Dispose();
                }
                else
                {
                    txtCon.Text = conOriginal;
                    txtDes.Text = desOriginal;
                    txtDir.Text = dirOriginal;
                    txtNombre.Text = nomOriginal;
                    txtRtn.Text = rtnOriginal;
                    txtTelf.Text = telOriginal;
                    comboBoxTipo.SelectedItem = tipoOriginal;

                    this.Close();
                }   
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe registrar el nombre del proveedor.");
                txtNombre.Focus();
                return;
            }

            if (txtNombre.Text.Trim().Length > 50)
            {
                MessageBox.Show("El nombre del proveedor está muy extenso!");
                txtNombre.Focus();
                return;
            }

            if (txtTelf.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe registrar el número de teléfono del contacto.");
                txtTelf.Focus();
                return;
            }

            if (txtCon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe registrar el nombre de su contacto.");
                txtCon.Focus();
                return;
            }

            if (txtCon.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre del contacto debe tener más de tres letras.");
                txtCon.Focus();
                return;
            }

            if (txtCon.Text.Trim().Length > 35)
            {
                MessageBox.Show("Nombre del contacto demasiado extenso!");
                txtCon.Focus();
                return;
            }

            if (txtDes.Text.Trim().Length == 0)
            {
                MessageBox.Show("Es obligatorio que registre la descripción de los productos.");
                txtDes.Focus();
                return;
            }

            if (txtDes.Text.Trim().Length < 3)
            {
                MessageBox.Show("La descripción no puede tener menos de tres letras.");
                txtDes.Focus();
                return;
            }

            if (txtDes.Text.Trim().Length > 150)
            {
                MessageBox.Show("Descripción demasiado extensa!");
                txtDes.Focus();
                return;
            }

            if (txtDir.Text.Trim().Length > 150)
            {
                MessageBox.Show("Dirección demasiado extensa!");
                txtDir.Focus();
                return;
            }

            if (comboBoxTipo.SelectedIndex == -1) { 
                MessageBox.Show("Por favor, seleccione el Tipo de proveedor.");
                comboBoxTipo.Focus();
                return;
            }

            if (comboBoxCatProd.Enabled == true && comboBoxCatProd.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado la Categoría del producto.");
                comboBoxCatProd.Focus();
                return;
            }

            try
            {
                if (txtRtn.Text.Trim().Length != 0 ) { 
                    if (Double.Parse(txtRtn.Text) < 0)
                    {
                        MessageBox.Show("RTN no válido.");
                        txtRtn.Focus();
                        return;
                    }
                    else if (txtRtn.Text.Trim().Length != 14)
                    {
                        MessageBox.Show("El RTN debe tener 14 dígitos sin guiones.");
                        txtRtn.Focus();
                        return;
                    }
                }

                if (txtTelf.Text.Trim().Length == 0 || Double.Parse(txtTelf.Text) < 0 
                    || txtTelf.Text.Trim().Length < 8 || txtTelf.Text.Trim().Length > 13)
                {
                        MessageBox.Show("Teléfono no valido.");
                        txtTelf.Focus();
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Teléfono y RTN deben contener sólo números.");
                return;
            }
            this.Close();
        }

        private void frmProveedoresInsertarModificar_Load(object sender, EventArgs e)
        {
            conOriginal = txtCon.Text;
            nomOriginal = txtNombre.Text;
            rtnOriginal = txtRtn.Text;
            desOriginal = txtDes.Text;
            telOriginal = txtTelf.Text;
            dirOriginal = txtDir.Text;
            tipoOriginal = comboBoxTipo.Text;
        }

        private void txtDes_Enter(object sender, EventArgs e)
        {
        }

        private void txtDes_Leave(object sender, EventArgs e)
        {
        }
    }
}
