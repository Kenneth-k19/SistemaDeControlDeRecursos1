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
    public partial class frmConsumosDetalle : Form
    {
        SqlConnection connection;
        int ConsumoID;
        SqlDataAdapter adpConsumo, adpConsumoDet;
        DataTable tabConsumo, tabConsumoDet;

        public frmConsumosDetalle(SqlConnection conn, int id)
        {
            InitializeComponent();
            connection = conn;
            ConsumoID = id;
        }

        private void frmConsumosDetalle_Load(object sender, EventArgs e)
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
    }
}
