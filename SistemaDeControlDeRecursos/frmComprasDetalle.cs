﻿using System;
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
    public partial class frmComprasDetalle : Form
    {
        public frmComprasDetalle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmComprasDetalle_Load(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.FromArgb(145, 19, 66);

            panel1.BackColor = Color.FromArgb(145, 19, 66);
        }
    }
}
