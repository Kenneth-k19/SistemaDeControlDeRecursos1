﻿namespace SistemaDeControlDeRecursos.Reportes.forms
{
    partial class frmRpConsumoAnormalArticulos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewerWnd1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.generarReporte = new System.Windows.Forms.Button();
            this.fechaFinPicker = new System.Windows.Forms.DateTimePicker();
            this.fechaInicioPicker = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewerWnd1
            // 
            this.reportViewerWnd1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = null;
            this.reportViewerWnd1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewerWnd1.LocalReport.ReportEmbeddedResource = "SistemaDeControlDeRecursos.Reportes.rdlc.rpConsumoAnormalArticulos.rdlc";
            this.reportViewerWnd1.Location = new System.Drawing.Point(214, 0);
            this.reportViewerWnd1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewerWnd1.Name = "reportViewerWnd1";
            this.reportViewerWnd1.ServerReport.BearerToken = null;
            this.reportViewerWnd1.Size = new System.Drawing.Size(586, 515);
            this.reportViewerWnd1.TabIndex = 4;
            this.reportViewerWnd1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(140)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.generarReporte);
            this.panel1.Controls.Add(this.fechaFinPicker);
            this.panel1.Controls.Add(this.fechaInicioPicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 515);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.label2.Location = new System.Drawing.Point(24, 245);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fin de Periodo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.label1.Location = new System.Drawing.Point(24, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inicio de Periodo";
            // 
            // generarReporte
            // 
            this.generarReporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.generarReporte.FlatAppearance.BorderSize = 2;
            this.generarReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(108)))), ((int)(((byte)(127)))));
            this.generarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generarReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.generarReporte.Location = new System.Drawing.Point(34, 451);
            this.generarReporte.Margin = new System.Windows.Forms.Padding(2);
            this.generarReporte.Name = "generarReporte";
            this.generarReporte.Size = new System.Drawing.Size(146, 35);
            this.generarReporte.TabIndex = 2;
            this.generarReporte.Text = "Generar Reporte";
            this.generarReporte.UseVisualStyleBackColor = true;
            this.generarReporte.Click += new System.EventHandler(this.generarReporte_Click_1);
            // 
            // fechaFinPicker
            // 
            this.fechaFinPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaFinPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaFinPicker.Location = new System.Drawing.Point(24, 271);
            this.fechaFinPicker.Margin = new System.Windows.Forms.Padding(2);
            this.fechaFinPicker.Name = "fechaFinPicker";
            this.fechaFinPicker.Size = new System.Drawing.Size(108, 24);
            this.fechaFinPicker.TabIndex = 1;
            // 
            // fechaInicioPicker
            // 
            this.fechaInicioPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaInicioPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaInicioPicker.Location = new System.Drawing.Point(24, 193);
            this.fechaInicioPicker.Margin = new System.Windows.Forms.Padding(2);
            this.fechaInicioPicker.Name = "fechaInicioPicker";
            this.fechaInicioPicker.Size = new System.Drawing.Size(108, 24);
            this.fechaInicioPicker.TabIndex = 0;
            // 
            // frmRpConsumoAnormalArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.reportViewerWnd1);
            this.Controls.Add(this.panel1);
            this.Name = "frmRpConsumoAnormalArticulos";
            this.Text = "Reporte de Diferencia de Consumo de artículos";
            this.Load += new System.EventHandler(this.frmRpConsumoAnormalArticulos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerWnd1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button generarReporte;
        private System.Windows.Forms.DateTimePicker fechaFinPicker;
        private System.Windows.Forms.DateTimePicker fechaInicioPicker;
    }
}