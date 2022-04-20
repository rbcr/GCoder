namespace GCoder
{
    partial class GCoder
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbSeleccionarArchivo = new System.Windows.Forms.GroupBox();
            this.dgArchivos = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Infill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSeleccionarArchivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArchivos)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gbSeleccionarArchivo
            // 
            this.gbSeleccionarArchivo.Controls.Add(this.dgArchivos);
            this.gbSeleccionarArchivo.Location = new System.Drawing.Point(12, 12);
            this.gbSeleccionarArchivo.Name = "gbSeleccionarArchivo";
            this.gbSeleccionarArchivo.Size = new System.Drawing.Size(719, 421);
            this.gbSeleccionarArchivo.TabIndex = 0;
            this.gbSeleccionarArchivo.TabStop = false;
            this.gbSeleccionarArchivo.Text = "Select File(s)";
            // 
            // dgArchivos
            // 
            this.dgArchivos.AllowDrop = true;
            this.dgArchivos.AllowUserToAddRows = false;
            this.dgArchivos.AllowUserToOrderColumns = true;
            this.dgArchivos.AllowUserToResizeColumns = false;
            this.dgArchivos.AllowUserToResizeRows = false;
            this.dgArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.PrintTime,
            this.Material,
            this.LineWeight,
            this.LineHeight,
            this.Infill,
            this.Cost,
            this.Weight,
            this.Amount});
            this.dgArchivos.Location = new System.Drawing.Point(6, 19);
            this.dgArchivos.Name = "dgArchivos";
            this.dgArchivos.Size = new System.Drawing.Size(707, 379);
            this.dgArchivos.TabIndex = 1;
            this.dgArchivos.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgArchivos_DragDrop);
            this.dgArchivos.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgArchivos_DragEnter);
            // 
            // FileName
            // 
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PrintTime
            // 
            this.PrintTime.HeaderText = "Print Time";
            this.PrintTime.Name = "PrintTime";
            this.PrintTime.ReadOnly = true;
            this.PrintTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Material
            // 
            this.Material.HeaderText = "Material";
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            this.Material.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // LineWeight
            // 
            this.LineWeight.HeaderText = "Line Weight";
            this.LineWeight.Name = "LineWeight";
            this.LineWeight.ReadOnly = true;
            this.LineWeight.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // LineHeight
            // 
            this.LineHeight.HeaderText = "Line Height";
            this.LineHeight.Name = "LineHeight";
            this.LineHeight.ReadOnly = true;
            this.LineHeight.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Infill
            // 
            this.Infill.HeaderText = "Infill";
            this.Infill.Name = "Infill";
            this.Infill.ReadOnly = true;
            this.Infill.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // GCoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 445);
            this.Controls.Add(this.gbSeleccionarArchivo);
            this.Name = "GCoder";
            this.Text = "GCoder";
            this.gbSeleccionarArchivo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgArchivos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox gbSeleccionarArchivo;
        private System.Windows.Forms.DataGridView dgArchivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Infill;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}

