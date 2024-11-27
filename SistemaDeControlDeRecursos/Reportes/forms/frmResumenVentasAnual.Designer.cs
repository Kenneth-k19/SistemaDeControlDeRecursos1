namespace SistemaDeControlDeRecursos.Reportes.forms
{
    partial class frmResumenVentasAnual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.generarReporte = new System.Windows.Forms.Button();
            this.anioPicker = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(140)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.generarReporte);
            this.panel1.Controls.Add(this.anioPicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 709);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Noto Sans ExtraBold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.label1.Location = new System.Drawing.Point(32, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione el año";
            // 
            // generarReporte
            // 
            this.generarReporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.generarReporte.FlatAppearance.BorderSize = 2;
            this.generarReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(108)))), ((int)(((byte)(127)))));
            this.generarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generarReporte.Font = new System.Drawing.Font("Noto Sans SemiBold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generarReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.generarReporte.Location = new System.Drawing.Point(32, 654);
            this.generarReporte.Name = "generarReporte";
            this.generarReporte.Size = new System.Drawing.Size(216, 43);
            this.generarReporte.TabIndex = 2;
            this.generarReporte.Text = "Generar Reporte";
            this.generarReporte.UseVisualStyleBackColor = true;
            // 
            // anioPicker
            // 
            this.anioPicker.Font = new System.Drawing.Font("Source Sans 3 Medium", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anioPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.anioPicker.Location = new System.Drawing.Point(32, 251);
            this.anioPicker.Name = "anioPicker";
            this.anioPicker.Size = new System.Drawing.Size(143, 38);
            this.anioPicker.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaDeControlDeRecursos.Reportes.rdlc.rptResumenVentasAnual.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(285, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(782, 709);
            this.reportViewer1.TabIndex = 5;
            // 
            // frmResumenVentasAnual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 709);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmResumenVentasAnual";
            this.Text = "frmResumenVentasAnual";
            this.Load += new System.EventHandler(this.frmResumenVentasAnual_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button generarReporte;
        private System.Windows.Forms.DateTimePicker anioPicker;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}