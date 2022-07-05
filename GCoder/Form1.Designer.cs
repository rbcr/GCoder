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
            this.btnClearDataset = new System.Windows.Forms.Button();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.btnExportToCSV = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Infill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupportsEnabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectBackground = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.gbSeleccionarArchivo.Location = new System.Drawing.Point(12, 53);
            this.gbSeleccionarArchivo.Name = "gbSeleccionarArchivo";
            this.gbSeleccionarArchivo.Size = new System.Drawing.Size(719, 409);
            this.gbSeleccionarArchivo.TabIndex = 0;
            this.gbSeleccionarArchivo.TabStop = false;
            this.gbSeleccionarArchivo.Text = "Drag & drop GCode files";
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
            this.Amount,
            this.Scale,
            this.SupportsEnabled,
            this.ObjectWidth,
            this.ObjectHeight,
            this.ObjectBackground,
            this.Created_at});
            this.dgArchivos.Location = new System.Drawing.Point(12, 19);
            this.dgArchivos.Name = "dgArchivos";
            this.dgArchivos.Size = new System.Drawing.Size(707, 379);
            this.dgArchivos.TabIndex = 1;
            this.dgArchivos.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgArchivos_DragDrop);
            this.dgArchivos.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgArchivos_DragEnter);
            // 
            // btnClearDataset
            // 
            this.btnClearDataset.Location = new System.Drawing.Point(623, 12);
            this.btnClearDataset.Name = "btnClearDataset";
            this.btnClearDataset.Size = new System.Drawing.Size(108, 23);
            this.btnClearDataset.TabIndex = 2;
            this.btnClearDataset.Text = "Drop GCode data";
            this.btnClearDataset.UseVisualStyleBackColor = true;
            this.btnClearDataset.Click += new System.EventHandler(this.btnClearDataset_Click);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(508, 12);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(109, 23);
            this.btnCopyToClipboard.TabIndex = 3;
            this.btnCopyToClipboard.Text = "Copy to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnExportToCSV
            // 
            this.btnExportToCSV.Location = new System.Drawing.Point(406, 12);
            this.btnExportToCSV.Name = "btnExportToCSV";
            this.btnExportToCSV.Size = new System.Drawing.Size(96, 23);
            this.btnExportToCSV.TabIndex = 4;
            this.btnExportToCSV.Text = "Export to CSV";
            this.btnExportToCSV.UseVisualStyleBackColor = true;
            this.btnExportToCSV.Click += new System.EventHandler(this.btnExportToCSV_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(120, 23);
            this.btnOpenFile.TabIndex = 5;
            this.btnOpenFile.Text = "Open GCode File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
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
            // Scale
            // 
            this.Scale.HeaderText = "Scale";
            this.Scale.Name = "Scale";
            // 
            // SupportsEnabled
            // 
            this.SupportsEnabled.HeaderText = "Supports Enabled";
            this.SupportsEnabled.Name = "SupportsEnabled";
            // 
            // ObjectWidth
            // 
            this.ObjectWidth.HeaderText = "Object Width";
            this.ObjectWidth.Name = "ObjectWidth";
            // 
            // ObjectHeight
            // 
            this.ObjectHeight.HeaderText = "Object Height";
            this.ObjectHeight.Name = "ObjectHeight";
            // 
            // ObjectBackground
            // 
            this.ObjectBackground.HeaderText = "Object Background";
            this.ObjectBackground.Name = "ObjectBackground";
            // 
            // Created_at
            // 
            this.Created_at.HeaderText = "Created at";
            this.Created_at.Name = "Created_at";
            // 
            // GCoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 473);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnExportToCSV);
            this.Controls.Add(this.btnClearDataset);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.gbSeleccionarArchivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GCoder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GCoder";
            this.gbSeleccionarArchivo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgArchivos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox gbSeleccionarArchivo;
        private System.Windows.Forms.DataGridView dgArchivos;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button btnClearDataset;
        private System.Windows.Forms.Button btnExportToCSV;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Infill;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupportsEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectBackground;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created_at;
    }
}

