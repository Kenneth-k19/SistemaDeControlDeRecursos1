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
    public partial class frmCierrePeriodo : Form
    {
        SqlConnection connection;
        public frmCierrePeriodo(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void frmCierrePeriodo_Load(object sender, EventArgs e)
        {

        }
    }
}
