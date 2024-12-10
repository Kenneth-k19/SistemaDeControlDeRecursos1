namespace SistemaDeControlDeRecursos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button btnMaximizar;
            System.Windows.Forms.Button btnMinimize;
            System.Windows.Forms.Button btnMaximize;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnArticulos = new System.Windows.Forms.Button();
            this.pnlTopPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.flpLeftPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpInventario = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCierrePeriodo = new System.Windows.Forms.Button();
            this.btnAjusteInventario = new System.Windows.Forms.Button();
            this.btnMovimientos = new System.Windows.Forms.Button();
            this.btnFamilia = new System.Windows.Forms.Button();
            this.btnConsumos = new System.Windows.Forms.Button();
            this.btnReporte1 = new System.Windows.Forms.Button();
            this.btnReporteConsumo = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnFacturas = new System.Windows.Forms.Button();
            this.btnReporte5 = new System.Windows.Forms.Button();
            this.btnReporte6 = new System.Windows.Forms.Button();
            this.btnReporte7 = new System.Windows.Forms.Button();
            this.btnRpVentasAnual = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnComprasModulo = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnReporte8 = new System.Windows.Forms.Button();
            this.btnReporte9 = new System.Windows.Forms.Button();
            this.btnReporte10 = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAjustes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnReporte11 = new System.Windows.Forms.Button();
            this.btnMiPerfil = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.menuTransition = new System.Windows.Forms.Timer(this.components);
            this.sideBarTransition = new System.Windows.Forms.Timer(this.components);
            this.facturacionTransition = new System.Windows.Forms.Timer(this.components);
            this.comprasTransition = new System.Windows.Forms.Timer(this.components);
            this.ajustesTransition = new System.Windows.Forms.Timer(this.components);
            this.btnInventario = new System.Windows.Forms.Button();
            btnMaximizar = new System.Windows.Forms.Button();
            btnMinimize = new System.Windows.Forms.Button();
            btnMaximize = new System.Windows.Forms.Button();
            this.pnlTopPanel.SuspendLayout();
            this.flpLeftPanel.SuspendLayout();
            this.flpInventario.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMaximizar
            // 
            btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnMaximizar.BackgroundImage = global::SistemaDeControlDeRecursos.Properties.Resources.expandir_ventana;
            btnMaximizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMaximizar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnMaximizar.Location = new System.Drawing.Point(1172, 0);
            btnMaximizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new System.Drawing.Size(52, 48);
            btnMaximizar.TabIndex = 5;
            btnMaximizar.UseVisualStyleBackColor = true;
            btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnMinimize.BackgroundImage = global::SistemaDeControlDeRecursos.Properties.Resources.minimizar1;
            btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMinimize.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnMinimize.Location = new System.Drawing.Point(1121, 0);
            btnMinimize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new System.Drawing.Size(52, 48);
            btnMinimize.TabIndex = 4;
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnMaximize.BackgroundImage = global::SistemaDeControlDeRecursos.Properties.Resources.cerrar_ventana1;
            btnMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMaximize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            btnMaximize.Location = new System.Drawing.Point(1223, 0);
            btnMaximize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new System.Drawing.Size(52, 48);
            btnMaximize.TabIndex = 3;
            btnMaximize.UseVisualStyleBackColor = true;
            btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnArticulos
            // 
            this.btnArticulos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArticulos.FlatAppearance.BorderSize = 0;
            this.btnArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulos.ForeColor = System.Drawing.Color.White;
            this.btnArticulos.Location = new System.Drawing.Point(0, 74);
            this.btnArticulos.Margin = new System.Windows.Forms.Padding(0);
            this.btnArticulos.Name = "btnArticulos";
            this.btnArticulos.Size = new System.Drawing.Size(303, 74);
            this.btnArticulos.TabIndex = 4;
            this.btnArticulos.Text = "Artículos";
            this.btnArticulos.UseVisualStyleBackColor = true;
            this.btnArticulos.Visible = false;
            this.btnArticulos.Click += new System.EventHandler(this.button2_Click);
            // 
            // pnlTopPanel
            // 
            this.pnlTopPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlTopPanel.Controls.Add(this.label1);
            this.pnlTopPanel.Controls.Add(this.button4);
            this.pnlTopPanel.Controls.Add(btnMaximizar);
            this.pnlTopPanel.Controls.Add(btnMinimize);
            this.pnlTopPanel.Controls.Add(btnMaximize);
            this.pnlTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopPanel.Location = new System.Drawing.Point(0, 0);
            this.pnlTopPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTopPanel.Name = "pnlTopPanel";
            this.pnlTopPanel.Size = new System.Drawing.Size(1275, 62);
            this.pnlTopPanel.TabIndex = 1;
            this.pnlTopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTopPanel_Paint);
            this.pnlTopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopPanel_MouseDown);
            this.pnlTopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTopPanel_MouseMove);
            this.pnlTopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTopPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(536, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sistema de Control de Recursos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(-1, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 62);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // flpLeftPanel
            // 
            this.flpLeftPanel.AutoScroll = true;
            this.flpLeftPanel.AutoScrollMargin = new System.Drawing.Size(100, 0);
            this.flpLeftPanel.Controls.Add(this.panel1);
            this.flpLeftPanel.Controls.Add(this.flpInventario);
            this.flpLeftPanel.Controls.Add(this.flowLayoutPanel1);
            this.flpLeftPanel.Controls.Add(this.flowLayoutPanel2);
            this.flpLeftPanel.Controls.Add(this.flowLayoutPanel3);
            this.flpLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpLeftPanel.Location = new System.Drawing.Point(0, 62);
            this.flpLeftPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpLeftPanel.Name = "flpLeftPanel";
            this.flpLeftPanel.Size = new System.Drawing.Size(307, 573);
            this.flpLeftPanel.TabIndex = 8;
            this.flpLeftPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flpLeftPanel_Paint);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 190);
            this.panel1.TabIndex = 10;
            // 
            // flpInventario
            // 
            this.flpInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(19)))), ((int)(((byte)(66)))));
            this.flpInventario.Controls.Add(this.btnInventario);
            this.flpInventario.Controls.Add(this.btnArticulos);
            this.flpInventario.Controls.Add(this.btnCierrePeriodo);
            this.flpInventario.Controls.Add(this.btnAjusteInventario);
            this.flpInventario.Controls.Add(this.btnMovimientos);
            this.flpInventario.Controls.Add(this.btnFamilia);
            this.flpInventario.Controls.Add(this.btnConsumos);
            this.flpInventario.Controls.Add(this.btnReporte1);
            this.flpInventario.Controls.Add(this.btnReporteConsumo);
            this.flpInventario.Location = new System.Drawing.Point(0, 198);
            this.flpInventario.Margin = new System.Windows.Forms.Padding(0);
            this.flpInventario.Name = "flpInventario";
            this.flpInventario.Size = new System.Drawing.Size(303, 74);
            this.flpInventario.TabIndex = 9;
            this.flpInventario.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btnCierrePeriodo
            // 
            this.btnCierrePeriodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCierrePeriodo.FlatAppearance.BorderSize = 0;
            this.btnCierrePeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCierrePeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCierrePeriodo.ForeColor = System.Drawing.Color.White;
            this.btnCierrePeriodo.Location = new System.Drawing.Point(0, 148);
            this.btnCierrePeriodo.Margin = new System.Windows.Forms.Padding(0);
            this.btnCierrePeriodo.Name = "btnCierrePeriodo";
            this.btnCierrePeriodo.Size = new System.Drawing.Size(303, 74);
            this.btnCierrePeriodo.TabIndex = 5;
            this.btnCierrePeriodo.Text = "Cierre del Periodo";
            this.btnCierrePeriodo.UseVisualStyleBackColor = true;
            this.btnCierrePeriodo.Visible = false;
            this.btnCierrePeriodo.Click += new System.EventHandler(this.btnCierrePeriodo_Click);
            // 
            // btnAjusteInventario
            // 
            this.btnAjusteInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjusteInventario.FlatAppearance.BorderSize = 0;
            this.btnAjusteInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjusteInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjusteInventario.ForeColor = System.Drawing.Color.White;
            this.btnAjusteInventario.Location = new System.Drawing.Point(0, 222);
            this.btnAjusteInventario.Margin = new System.Windows.Forms.Padding(0);
            this.btnAjusteInventario.Name = "btnAjusteInventario";
            this.btnAjusteInventario.Size = new System.Drawing.Size(303, 74);
            this.btnAjusteInventario.TabIndex = 6;
            this.btnAjusteInventario.Text = "Ajuste de Inventario";
            this.btnAjusteInventario.UseVisualStyleBackColor = true;
            this.btnAjusteInventario.Visible = false;
            this.btnAjusteInventario.Click += new System.EventHandler(this.btnAjusteInventario_Click);
            // 
            // btnMovimientos
            // 
            this.btnMovimientos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMovimientos.FlatAppearance.BorderSize = 0;
            this.btnMovimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovimientos.ForeColor = System.Drawing.Color.White;
            this.btnMovimientos.Location = new System.Drawing.Point(0, 296);
            this.btnMovimientos.Margin = new System.Windows.Forms.Padding(0);
            this.btnMovimientos.Name = "btnMovimientos";
            this.btnMovimientos.Size = new System.Drawing.Size(303, 74);
            this.btnMovimientos.TabIndex = 7;
            this.btnMovimientos.Text = "Movimientos";
            this.btnMovimientos.UseVisualStyleBackColor = true;
            this.btnMovimientos.Visible = false;
            this.btnMovimientos.Click += new System.EventHandler(this.btnMovimientos_Click);
            // 
            // btnFamilia
            // 
            this.btnFamilia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFamilia.FlatAppearance.BorderSize = 0;
            this.btnFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFamilia.ForeColor = System.Drawing.Color.White;
            this.btnFamilia.Location = new System.Drawing.Point(0, 370);
            this.btnFamilia.Margin = new System.Windows.Forms.Padding(0);
            this.btnFamilia.Name = "btnFamilia";
            this.btnFamilia.Size = new System.Drawing.Size(303, 74);
            this.btnFamilia.TabIndex = 9;
            this.btnFamilia.Text = "Familia";
            this.btnFamilia.UseVisualStyleBackColor = true;
            this.btnFamilia.Visible = false;
            this.btnFamilia.Click += new System.EventHandler(this.btnFamilia_Click);
            // 
            // btnConsumos
            // 
            this.btnConsumos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsumos.FlatAppearance.BorderSize = 0;
            this.btnConsumos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumos.ForeColor = System.Drawing.Color.White;
            this.btnConsumos.Location = new System.Drawing.Point(0, 444);
            this.btnConsumos.Margin = new System.Windows.Forms.Padding(0);
            this.btnConsumos.Name = "btnConsumos";
            this.btnConsumos.Size = new System.Drawing.Size(303, 74);
            this.btnConsumos.TabIndex = 10;
            this.btnConsumos.Text = "Consumos por Platillo";
            this.btnConsumos.UseVisualStyleBackColor = true;
            this.btnConsumos.Visible = false;
            this.btnConsumos.Click += new System.EventHandler(this.btnConsumos_Click);
            // 
            // btnReporte1
            // 
            this.btnReporte1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte1.FlatAppearance.BorderSize = 0;
            this.btnReporte1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte1.ForeColor = System.Drawing.Color.White;
            this.btnReporte1.Location = new System.Drawing.Point(0, 518);
            this.btnReporte1.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporte1.Name = "btnReporte1";
            this.btnReporte1.Size = new System.Drawing.Size(303, 74);
            this.btnReporte1.TabIndex = 8;
            this.btnReporte1.Text = "[Reporte] Movimientos de inventario";
            this.btnReporte1.UseVisualStyleBackColor = true;
            this.btnReporte1.Visible = false;
            this.btnReporte1.Click += new System.EventHandler(this.btnReporte1_Click);
            // 
            // btnReporteConsumo
            // 
            this.btnReporteConsumo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteConsumo.FlatAppearance.BorderSize = 0;
            this.btnReporteConsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteConsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteConsumo.ForeColor = System.Drawing.Color.White;
            this.btnReporteConsumo.Location = new System.Drawing.Point(0, 592);
            this.btnReporteConsumo.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporteConsumo.Name = "btnReporteConsumo";
            this.btnReporteConsumo.Size = new System.Drawing.Size(303, 74);
            this.btnReporteConsumo.TabIndex = 11;
            this.btnReporteConsumo.Text = "[Reporte] Consumo inusual de articulo";
            this.btnReporteConsumo.UseVisualStyleBackColor = true;
            this.btnReporteConsumo.Visible = false;
            this.btnReporteConsumo.Click += new System.EventHandler(this.btnReporteConsumo_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(19)))), ((int)(((byte)(66)))));
            this.flowLayoutPanel1.Controls.Add(this.btnFacturacion);
            this.flowLayoutPanel1.Controls.Add(this.btnFacturas);
            this.flowLayoutPanel1.Controls.Add(this.btnReporte5);
            this.flowLayoutPanel1.Controls.Add(this.btnReporte6);
            this.flowLayoutPanel1.Controls.Add(this.btnReporte7);
            this.flowLayoutPanel1.Controls.Add(this.btnRpVentasAnual);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 272);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(303, 74);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacion.FlatAppearance.BorderSize = 0;
            this.btnFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturacion.ForeColor = System.Drawing.Color.White;
            this.btnFacturacion.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturacion.Image")));
            this.btnFacturacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturacion.Location = new System.Drawing.Point(0, 0);
            this.btnFacturacion.Margin = new System.Windows.Forms.Padding(0);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(303, 74);
            this.btnFacturacion.TabIndex = 3;
            this.btnFacturacion.Text = "       Facturacion";
            this.btnFacturacion.UseVisualStyleBackColor = true;
            this.btnFacturacion.Visible = false;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            // 
            // btnFacturas
            // 
            this.btnFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturas.FlatAppearance.BorderSize = 0;
            this.btnFacturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturas.ForeColor = System.Drawing.Color.White;
            this.btnFacturas.Location = new System.Drawing.Point(0, 74);
            this.btnFacturas.Margin = new System.Windows.Forms.Padding(0);
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(303, 74);
            this.btnFacturas.TabIndex = 11;
            this.btnFacturas.Text = "Facturas";
            this.btnFacturas.UseVisualStyleBackColor = true;
            this.btnFacturas.Visible = false;
            this.btnFacturas.Click += new System.EventHandler(this.btnFacturas_Click);
            // 
            // btnReporte5
            // 
            this.btnReporte5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte5.FlatAppearance.BorderSize = 0;
            this.btnReporte5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte5.ForeColor = System.Drawing.Color.White;
            this.btnReporte5.Location = new System.Drawing.Point(0, 148);
            this.btnReporte5.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporte5.Name = "btnReporte5";
            this.btnReporte5.Size = new System.Drawing.Size(303, 74);
            this.btnReporte5.TabIndex = 8;
            this.btnReporte5.Text = "[Reporte] Detalle de ventas diario";
            this.btnReporte5.UseVisualStyleBackColor = true;
            this.btnReporte5.Visible = false;
            this.btnReporte5.Click += new System.EventHandler(this.btnReporte5_Click);
            // 
            // btnReporte6
            // 
            this.btnReporte6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte6.FlatAppearance.BorderSize = 0;
            this.btnReporte6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte6.ForeColor = System.Drawing.Color.White;
            this.btnReporte6.Location = new System.Drawing.Point(0, 222);
            this.btnReporte6.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporte6.Name = "btnReporte6";
            this.btnReporte6.Size = new System.Drawing.Size(303, 74);
            this.btnReporte6.TabIndex = 12;
            this.btnReporte6.Text = "[Reporte] Comparativo de ventas por tipo";
            this.btnReporte6.UseVisualStyleBackColor = true;
            this.btnReporte6.Visible = false;
            this.btnReporte6.Click += new System.EventHandler(this.btnReporte6_Click);
            // 
            // btnReporte7
            // 
            this.btnReporte7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte7.FlatAppearance.BorderSize = 0;
            this.btnReporte7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte7.ForeColor = System.Drawing.Color.White;
            this.btnReporte7.Location = new System.Drawing.Point(0, 296);
            this.btnReporte7.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporte7.Name = "btnReporte7";
            this.btnReporte7.Size = new System.Drawing.Size(303, 74);
            this.btnReporte7.TabIndex = 13;
            this.btnReporte7.Text = "[Reporte] Pedidos a domicilio ";
            this.btnReporte7.UseVisualStyleBackColor = true;
            this.btnReporte7.Visible = false;
            this.btnReporte7.Click += new System.EventHandler(this.btnReporte7_Click);
            // 
            // btnRpVentasAnual
            // 
            this.btnRpVentasAnual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRpVentasAnual.FlatAppearance.BorderSize = 0;
            this.btnRpVentasAnual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRpVentasAnual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRpVentasAnual.ForeColor = System.Drawing.Color.White;
            this.btnRpVentasAnual.Location = new System.Drawing.Point(0, 370);
            this.btnRpVentasAnual.Margin = new System.Windows.Forms.Padding(0);
            this.btnRpVentasAnual.Name = "btnRpVentasAnual";
            this.btnRpVentasAnual.Size = new System.Drawing.Size(303, 74);
            this.btnRpVentasAnual.TabIndex = 13;
            this.btnRpVentasAnual.Text = "[Reporte] Resumen de ventas anual";
            this.btnRpVentasAnual.UseVisualStyleBackColor = true;
            this.btnRpVentasAnual.Visible = false;
            this.btnRpVentasAnual.Click += new System.EventHandler(this.btnRpVentasAnual_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(19)))), ((int)(((byte)(66)))));
            this.flowLayoutPanel2.Controls.Add(this.btnComprasModulo);
            this.flowLayoutPanel2.Controls.Add(this.btnProveedores);
            this.flowLayoutPanel2.Controls.Add(this.btnCompras);
            this.flowLayoutPanel2.Controls.Add(this.btnReporte8);
            this.flowLayoutPanel2.Controls.Add(this.btnReporte9);
            this.flowLayoutPanel2.Controls.Add(this.btnReporte10);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 346);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(303, 74);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // btnComprasModulo
            // 
            this.btnComprasModulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComprasModulo.FlatAppearance.BorderSize = 0;
            this.btnComprasModulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprasModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprasModulo.ForeColor = System.Drawing.Color.White;
            this.btnComprasModulo.Image = ((System.Drawing.Image)(resources.GetObject("btnComprasModulo.Image")));
            this.btnComprasModulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComprasModulo.Location = new System.Drawing.Point(0, 0);
            this.btnComprasModulo.Margin = new System.Windows.Forms.Padding(0);
            this.btnComprasModulo.Name = "btnComprasModulo";
            this.btnComprasModulo.Size = new System.Drawing.Size(303, 74);
            this.btnComprasModulo.TabIndex = 14;
            this.btnComprasModulo.Text = "        Compras";
            this.btnComprasModulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnComprasModulo.UseVisualStyleBackColor = true;
            this.btnComprasModulo.Visible = false;
            this.btnComprasModulo.Click += new System.EventHandler(this.btnComprasModulo_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.White;
            this.btnProveedores.Location = new System.Drawing.Point(0, 74);
            this.btnProveedores.Margin = new System.Windows.Forms.Padding(0);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(303, 74);
            this.btnProveedores.TabIndex = 10;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Visible = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompras.FlatAppearance.BorderSize = 0;
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.ForeColor = System.Drawing.Color.White;
            this.btnCompras.Location = new System.Drawing.Point(0, 148);
            this.btnCompras.Margin = new System.Windows.Forms.Padding(0);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(303, 74);
            this.btnCompras.TabIndex = 5;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = true;
            this.btnCompras.Visible = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnReporte8
            // 
            this.btnReporte8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte8.FlatAppearance.BorderSize = 0;
            this.btnReporte8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte8.ForeColor = System.Drawing.Color.White;
            this.btnReporte8.Location = new System.Drawing.Point(0, 222);
            this.btnReporte8.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporte8.Name = "btnReporte8";
            this.btnReporte8.Size = new System.Drawing.Size(303, 74);
            this.btnReporte8.TabIndex = 13;
            this.btnReporte8.Text = "[Reporte] Compras por periodo";
            this.btnReporte8.UseVisualStyleBackColor = true;
            this.btnReporte8.Visible = false;
            this.btnReporte8.Click += new System.EventHandler(this.btnReporte8_Click);
            // 
            // btnReporte9
            // 
            this.btnReporte9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte9.FlatAppearance.BorderSize = 0;
            this.btnReporte9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte9.ForeColor = System.Drawing.Color.White;
            this.btnReporte9.Location = new System.Drawing.Point(0, 296);
            this.btnReporte9.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporte9.Name = "btnReporte9";
            this.btnReporte9.Size = new System.Drawing.Size(303, 74);
            this.btnReporte9.TabIndex = 12;
            this.btnReporte9.Text = "(Boton disponible)";
            this.btnReporte9.UseVisualStyleBackColor = true;
            this.btnReporte9.Visible = false;
            this.btnReporte9.Click += new System.EventHandler(this.btnReporte9_Click);
            // 
            // btnReporte10
            // 
            this.btnReporte10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte10.FlatAppearance.BorderSize = 0;
            this.btnReporte10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte10.ForeColor = System.Drawing.Color.White;
            this.btnReporte10.Location = new System.Drawing.Point(0, 370);
            this.btnReporte10.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporte10.Name = "btnReporte10";
            this.btnReporte10.Size = new System.Drawing.Size(303, 74);
            this.btnReporte10.TabIndex = 8;
            this.btnReporte10.Text = "[Reporte] Diferencias de Consumo de Artículos";
            this.btnReporte10.UseVisualStyleBackColor = true;
            this.btnReporte10.Visible = false;
            this.btnReporte10.Click += new System.EventHandler(this.btnReporte10_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(19)))), ((int)(((byte)(66)))));
            this.flowLayoutPanel3.Controls.Add(this.btnAjustes);
            this.flowLayoutPanel3.Controls.Add(this.btnUsuarios);
            this.flowLayoutPanel3.Controls.Add(this.btnReporte11);
            this.flowLayoutPanel3.Controls.Add(this.btnMiPerfil);
            this.flowLayoutPanel3.Controls.Add(this.btnSalir);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 420);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(303, 74);
            this.flowLayoutPanel3.TabIndex = 15;
            // 
            // btnAjustes
            // 
            this.btnAjustes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjustes.FlatAppearance.BorderSize = 0;
            this.btnAjustes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjustes.ForeColor = System.Drawing.Color.White;
            this.btnAjustes.Image = ((System.Drawing.Image)(resources.GetObject("btnAjustes.Image")));
            this.btnAjustes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAjustes.Location = new System.Drawing.Point(0, 0);
            this.btnAjustes.Margin = new System.Windows.Forms.Padding(0);
            this.btnAjustes.Name = "btnAjustes";
            this.btnAjustes.Size = new System.Drawing.Size(303, 74);
            this.btnAjustes.TabIndex = 14;
            this.btnAjustes.Text = " Ajustes";
            this.btnAjustes.UseVisualStyleBackColor = true;
            this.btnAjustes.Click += new System.EventHandler(this.btnAjustes_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 74);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(0);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(303, 74);
            this.btnUsuarios.TabIndex = 10;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Visible = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnReporte11
            // 
            this.btnReporte11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte11.FlatAppearance.BorderSize = 0;
            this.btnReporte11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte11.ForeColor = System.Drawing.Color.White;
            this.btnReporte11.Location = new System.Drawing.Point(0, 148);
            this.btnReporte11.Margin = new System.Windows.Forms.Padding(0);
            this.btnReporte11.Name = "btnReporte11";
            this.btnReporte11.Size = new System.Drawing.Size(303, 74);
            this.btnReporte11.TabIndex = 16;
            this.btnReporte11.Text = "[Reporte] Actividad por usuario";
            this.btnReporte11.UseVisualStyleBackColor = true;
            this.btnReporte11.Visible = false;
            this.btnReporte11.Click += new System.EventHandler(this.btnReporte11_Click);
            // 
            // btnMiPerfil
            // 
            this.btnMiPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMiPerfil.FlatAppearance.BorderSize = 0;
            this.btnMiPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiPerfil.ForeColor = System.Drawing.Color.White;
            this.btnMiPerfil.Location = new System.Drawing.Point(0, 222);
            this.btnMiPerfil.Margin = new System.Windows.Forms.Padding(0);
            this.btnMiPerfil.Name = "btnMiPerfil";
            this.btnMiPerfil.Size = new System.Drawing.Size(303, 74);
            this.btnMiPerfil.TabIndex = 15;
            this.btnMiPerfil.Text = "Mi Perfil";
            this.btnMiPerfil.UseVisualStyleBackColor = true;
            this.btnMiPerfil.Visible = false;
            this.btnMiPerfil.Click += new System.EventHandler(this.btnMiPerfil_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(0, 296);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(303, 74);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // menuTransition
            // 
            this.menuTransition.Interval = 10;
            this.menuTransition.Tick += new System.EventHandler(this.menuTransition_Tick);
            // 
            // sideBarTransition
            // 
            this.sideBarTransition.Interval = 10;
            this.sideBarTransition.Tick += new System.EventHandler(this.sideBarTransition_Tick);
            // 
            // facturacionTransition
            // 
            this.facturacionTransition.Interval = 10;
            this.facturacionTransition.Tick += new System.EventHandler(this.facturacionTransition_Tick);
            // 
            // comprasTransition
            // 
            this.comprasTransition.Interval = 10;
            this.comprasTransition.Tick += new System.EventHandler(this.comprasTransition_Tick);
            // 
            // ajustesTransition
            // 
            this.ajustesTransition.Interval = 10;
            this.ajustesTransition.Tick += new System.EventHandler(this.ajustesTransition_Tick);
            // 
            // btnInventario
            // 
            this.btnInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnInventario.Image")));
            this.btnInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.Location = new System.Drawing.Point(0, 0);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(0);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(303, 74);
            this.btnInventario.TabIndex = 3;
            this.btnInventario.Text = "        Inventario";
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Visible = false;
            this.btnInventario.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1275, 635);
            this.Controls.Add(this.flpLeftPanel);
            this.Controls.Add(this.pnlTopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlTopPanel.ResumeLayout(false);
            this.pnlTopPanel.PerformLayout();
            this.flpLeftPanel.ResumeLayout(false);
            this.flpInventario.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTopPanel;
        private System.Windows.Forms.Button btnArticulos;
        private System.Windows.Forms.FlowLayoutPanel flpLeftPanel;
        private System.Windows.Forms.FlowLayoutPanel flpInventario;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnFacturas;
        private System.Windows.Forms.Timer menuTransition;
        private System.Windows.Forms.Timer sideBarTransition;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnCierrePeriodo;
        private System.Windows.Forms.Button btnAjusteInventario;
        private System.Windows.Forms.Button btnMovimientos;
        private System.Windows.Forms.Button btnReporte1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnReporte5;
        private System.Windows.Forms.Button btnReporte6;
        private System.Windows.Forms.Button btnReporte7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnReporte10;
        private System.Windows.Forms.Button btnReporte9;
        private System.Windows.Forms.Button btnReporte8;
        private System.Windows.Forms.Timer facturacionTransition;
        private System.Windows.Forms.Button btnComprasModulo;
        private System.Windows.Forms.Timer comprasTransition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnAjustes;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Timer ajustesTransition;
        private System.Windows.Forms.Button btnFamilia;
        private System.Windows.Forms.Button btnConsumos;
        private System.Windows.Forms.Button btnMiPerfil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReporte11;
        private System.Windows.Forms.Button btnReporteConsumo;
        private System.Windows.Forms.Button btnRpVentasAnual;
        private System.Windows.Forms.Button btnInventario;
    }
}

