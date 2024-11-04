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
    public partial class Form1 : Form
    {

        int m, mx, my; 

        frmInventario inventario;
        frmCompras compras;
        frmFactura factura;
        frmProveedores proveedores;
        frmAjusteInventario ajusteInventario;
        frmConsumos consumos;
        frmFamilia familia;
        frmMiPerfil miPerfil;
        frmMovimientos movimientos;
        frmUsuarios usuarios;
        frmCierrePeriodo cierrePeriodo;


        bool checker = true;


        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();

            //flpLeftPanel.BackColor = Color.FromArgb(23,24,29);
            flpLeftPanel.BackColor = Color.FromArgb(145, 19, 66);
            pnlTopPanel.BackColor = Color.FromArgb(145, 19, 66);
            //pnlTopRec.BackColor = Color.FromArgb(145, 19, 66);

            flpInventario.BackColor = Color.FromArgb(175, 50, 90);
            flowLayoutPanel1.BackColor = Color.FromArgb(175, 50, 90);
            flowLayoutPanel2.BackColor = Color.FromArgb(175, 50, 90);
            flowLayoutPanel3.BackColor = Color.FromArgb(175, 50, 90);

            btnInventario.BackColor = Color.FromArgb(145, 19, 66);
            btnFacturacion.BackColor = Color.FromArgb(145, 19, 66);
            btnComprasModulo.BackColor = Color.FromArgb(145, 19, 66);
            btnAjustes.BackColor = Color.FromArgb(145, 19, 66);
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            

            if(checker)
            {
                this.WindowState = FormWindowState.Maximized;
                checker = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                checker = true;
            }
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        private void flpLeftPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        bool menuExpand = false;

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if(menuExpand == false)
            {
                flpInventario.Height += 10;

                if(flpInventario.Height >= 501)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                flpInventario.Height -= 10;

                if(flpInventario.Height <= 60)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        bool sideBarExpand = true;

        private void sideBarTransition_Tick(object sender, EventArgs e)
        {
            if(sideBarExpand)
            {
                flpLeftPanel.Width -= 10;

                if(flpLeftPanel.Width <= 52)
                {
                    sideBarExpand = false;
                    sideBarTransition.Stop();
                    //btnInventario.Width = flpLeftPanel.Width;
                    //btnCompras.Width = flpLeftPanel.Width;
                    //btnFacturas.Width = flpLeftPanel.Width;
                    //btnProveedores.Width = flpLeftPanel.Width;
                }           }
            else
            {
                flpLeftPanel.Width += 10;

                if(flpLeftPanel.Width >= 230)
                {
                    sideBarExpand = true;
                    sideBarTransition.Stop();
                    btnInventario.Width = flpLeftPanel.Width;
                    btnCompras.Width = flpLeftPanel.Width;
                    btnFacturas.Width = flpLeftPanel.Width;
                    btnProveedores.Width = flpLeftPanel.Width;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sideBarTransition.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(inventario == null)
            {
                inventario = new frmInventario();
                inventario.FormClosed += Inventario_FormClosed;
                inventario.MdiParent = this;
                inventario.Dock = DockStyle.Fill;
                inventario.Show();
            }
            else
            {
                inventario.Activate();
            }
        }

        private void Inventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            inventario = null;
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (proveedores == null)
            {
                proveedores = new frmProveedores();
                proveedores.FormClosed += Proveedores_FormClosed;
                proveedores.MdiParent = this;
                proveedores.Dock = DockStyle.Fill;
                proveedores.Show();
            }
            else
            {
                proveedores.Activate();
            }
        }

        private void Proveedores_FormClosed(object sender, FormClosedEventArgs e)
        {
            proveedores = null;
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            if (factura == null)
            {
                factura = new frmFactura();
                factura.FormClosed += Factura_FormClosed;
                factura.MdiParent = this;
                factura.Dock = DockStyle.Fill;
                factura.Show();
            }
            else
            {
                factura.Activate();
            }
        }

        private void Factura_FormClosed(object sender, FormClosedEventArgs e)
        {
            factura = null;
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            if (compras == null)
            {
                compras = new frmCompras();
                compras.FormClosed += Compras_FormClosed;
                compras.MdiParent = this;
                compras.Dock = DockStyle.Fill;
                compras.Show();
            }
            else
            {
                compras.Activate();
            }
        }

        private void Compras_FormClosed(object sender, FormClosedEventArgs e)
        {
            compras = null;
        }

        bool facturacionExpand = false;

        private void facturacionTransition_Tick(object sender, EventArgs e)
        {
            if (facturacionExpand == false)
            {
                flowLayoutPanel1.Height += 10;

                if (flowLayoutPanel1.Height >= 309)
                {
                    facturacionTransition.Stop();
                    facturacionExpand = true;
                }
            }
            else
            {
                flowLayoutPanel1.Height -= 10;

                if (flowLayoutPanel1.Height <= 60)
                {
                    facturacionTransition.Stop();
                    facturacionExpand = false;
                }
            }
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            facturacionTransition.Start();
        }

        bool comprasExpand = false;
        private void comprasTransition_Tick(object sender, EventArgs e)
        {
            if (comprasExpand == false)
            {
                flowLayoutPanel2.Height += 10;

                if (flowLayoutPanel2.Height >= 381)
                {
                    comprasTransition.Stop();
                    comprasExpand = true;
                }
            }
            else
            {
                flowLayoutPanel2.Height -= 10;

                if (flowLayoutPanel2.Height <= 60)
                {
                    comprasTransition.Stop();
                    comprasExpand = false;
                }
            }
        }

        private void btnComprasModulo_Click(object sender, EventArgs e)
        {
            comprasTransition.Start();
        }

        bool ajustesExpand = false;
        private void ajustesTransition_Tick(object sender, EventArgs e)
        {
            if (ajustesExpand == false)
            {
                flowLayoutPanel3.Height += 10;

                if (flowLayoutPanel3.Height >= 256)
                {
                    ajustesTransition.Stop();
                    ajustesExpand = true;
                }
            }
            else
            {
                flowLayoutPanel3.Height -= 10;

                if (flowLayoutPanel3.Height <= 60)
                {
                    ajustesTransition.Stop();
                    ajustesExpand = false;
                }
            }
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            ajustesTransition.Start();
        }

        private void btnCierrePeriodo_Click(object sender, EventArgs e)
        {
            if (cierrePeriodo == null)
            {
                cierrePeriodo = new frmCierrePeriodo();
                cierrePeriodo.FormClosed += CierrePeriodo_FormClosed;
                cierrePeriodo.MdiParent = this;
                cierrePeriodo.Dock = DockStyle.Fill;
                cierrePeriodo.Show();
            }
            else
            {
                cierrePeriodo.Activate();
            }
        }

        private void CierrePeriodo_FormClosed(object sender, FormClosedEventArgs e)
        {
            cierrePeriodo = null;
        }

        private void btnAjusteInventario_Click(object sender, EventArgs e)
        {
            if (ajusteInventario == null)
            {
                ajusteInventario = new frmAjusteInventario();
                ajusteInventario.FormClosed += AjusteInventario_FormClosed;
                ajusteInventario.MdiParent = this;
                ajusteInventario.Dock = DockStyle.Fill;
                ajusteInventario.Show();
            }
            else
            {
                ajusteInventario.Activate();
            }
        }

        private void AjusteInventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            ajusteInventario = null;
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            if (movimientos == null)
            {
                movimientos = new frmMovimientos();
                movimientos.FormClosed += Movimientos_FormClosed;
                movimientos.MdiParent = this;
                movimientos.Dock = DockStyle.Fill;
                movimientos.Show();
            }
            else
            {
                movimientos.Activate();
            }
        }

        private void Movimientos_FormClosed(object sender, FormClosedEventArgs e)
        {
            movimientos = null;
        }

        private void btnFamilia_Click(object sender, EventArgs e)
        {
            if (familia == null)
            {
                familia = new frmFamilia();
                familia.FormClosed += Familia_FormClosed;
                familia.MdiParent = this;
                familia.Dock = DockStyle.Fill;
                familia.Show();
            }
            else
            {
                familia.Activate();
            }
        }

        private void Familia_FormClosed(object sender, FormClosedEventArgs e)
        {
            familia = null;
        }

        private void btnConsumos_Click(object sender, EventArgs e)
        {
            if (consumos == null)
            {
                consumos = new frmConsumos();
                consumos.FormClosed += Consumos_FormClosed;
                consumos.MdiParent = this;
                consumos.Dock = DockStyle.Fill;
                consumos.Show();
            }
            else
            {
                consumos.Activate();
            }
        }

        private void Consumos_FormClosed(object sender, FormClosedEventArgs e)
        {
            consumos = null;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (usuarios == null)
            {
                usuarios = new frmUsuarios();
                usuarios.FormClosed += Usuarios_FormClosed;
                usuarios.MdiParent = this;
                usuarios.Dock = DockStyle.Fill;
                usuarios.Show();
            }
            else
            {
                usuarios.Activate();
            }
        }

        private void Usuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            usuarios = null;
        }

        private void btnMiPerfil_Click(object sender, EventArgs e)
        {
            //if (miPerfil == null)
            //{
            //    miPerfil = new frmMiPerfil();
            //    miPerfil.FormClosed += MiPerfil_FormClosed;
            //    miPerfil.MdiParent = this;
            //    miPerfil.Dock = DockStyle.Fill;
            //    miPerfil.Show();
            //}
            //else
            //{
            //    miPerfil.Activate();
            //}

            frmMiPerfil frm = new frmMiPerfil();
            frm.ShowDialog();
        }

        private void pnlTopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void pnlTopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void pnlTopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MiPerfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            //miPerfil = null;
        }

        private void pnlTopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;

            this.WindowState = FormWindowState.Normal;
            checker = true;
        }

        //private void pnlTopPanel_MouseDown(object sender, MouseEventArgs e)
        //{

        //}
    }
}
