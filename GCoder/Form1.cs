using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GCoder
{
    public partial class GCoder : Form
    {
        public GCoder()
        {
            InitializeComponent();
        }

        private void dgArchivos_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                var printData = GCodeParser.Parse(file);
                if (printData.Status == true)
                {
                    dgArchivos.Rows.Add(
                        printData.Thumbnail,
                        printData.FileName,
                        printData.PrintTime,
                        printData.Material,
                        printData.LineWeight,
                        printData.LineHeight,
                        printData.Infill,
                        Math.Round(printData.Cost, 2),
                        Math.Round(printData.Weight, 2),
                        Math.Round(printData.Amount, 2),
                        Math.Round(printData.Scale),
                        printData.SupportsEnabled.ToString(),
                        Math.Round(printData.ObjectWidth, 2),
                        Math.Round(printData.ObjectHeight, 2),
                        Math.Round(printData.ObjectBackground, 2),
                        (printData.Created_at.ToString() != "01/01/0001 12:00:00 a. m.") ? printData.Created_at?.ToString("dd/MM/yyyy") : null
                    ); ;
                }
            }
        }

        private void dgArchivos_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void btnClearDataset_Click(object sender, EventArgs e)
        {
            dgArchivos.Rows.Clear();
            MessageBox.Show("GCode files information has been removed", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            if(dgArchivos.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                Clipboard.SetDataObject(dgArchivos.GetClipboardContent());
            } else
            {
                MessageBox.Show("No cell or row selected to copy", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgArchivos_DoubleClick(object sender, EventArgs e)
        {
            if (dgArchivos.CurrentCell.ColumnIndex.Equals(0) && dgArchivos.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                Image selectedThumbnail = (Image)dgArchivos.CurrentCell.Value;
                Clipboard.SetImage(selectedThumbnail);
                MessageBox.Show("Image copied to clipboard", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            if (dgArchivos.GetCellCount(DataGridViewElementStates.Visible) > 0)
            {
                string timestamp = DateTime.Now.ToString("yyMMddHHmmss");
                string filename = "GCODE_data_" + timestamp + ".csv";
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
                SaveFileDialog1.DefaultExt = "csv";
                saveFileDialog1.Title = "Save CSV file";
                saveFileDialog1.InitialDirectory = path;
                saveFileDialog1.FileName = filename;
                saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    List<string> lines = new List<string>();
                    DataGridViewColumnCollection column = dgArchivos.Columns;
                    StringBuilder columnLine = new StringBuilder();
                    List<string> headers = new List<string>();
                    foreach (DataGridViewColumn col in column)
                        headers.Add(col.Name.ToString());
                    lines.Add(String.Join(",", headers).ToString());

                    foreach (DataGridViewRow row in dgArchivos.Rows)
                    {
                        List<string> dataLine = new List<string>();
                        for (var i = 0; i < dgArchivos.Columns.Count; i++)
                            dataLine.Add(row.Cells[i].Value.ToString());
                        lines.Add(String.Join(",", dataLine).ToString());
                    }

                    string file = Path.Combine(Application.StartupPath, saveFileDialog1.FileName.Replace(@"\", @"\\"));
                    File.WriteAllLines(file, lines);
                    System.Diagnostics.Process.Start(file);
                }
            }
            else
            {
                MessageBox.Show("The information to export has not been loaded", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            openFileDialog1.DefaultExt = "gcode";
            openFileDialog1.Title = "Open GCode File";
            openFileDialog1.Filter = "GCode Files (*.gcode)|*.gcode|All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = true;
            openFileDialog1.FileName = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    var printData = GCodeParser.Parse(file.Replace(@"\", @"\\"));
                    if (printData.Status == true)
                    {
                        dgArchivos.Rows.Add(
                            printData.Thumbnail,
                            printData.FileName,
                            printData.PrintTime,
                            printData.Material,
                            printData.LineWeight,
                            printData.LineHeight,
                            printData.Infill,
                            Math.Round(printData.Cost, 2),
                            Math.Round(printData.Weight, 2),
                            Math.Round(printData.Amount, 2),
                            Math.Round(printData.Scale),
                            printData.SupportsEnabled.ToString(),
                            Math.Round(printData.ObjectWidth, 2),
                            Math.Round(printData.ObjectHeight, 2),
                            Math.Round(printData.ObjectBackground, 2),
                            (printData.Created_at != null) ? printData.Created_at?.ToString("dd/MM/yyyy") : null
                        );
                    }
                }
            }
        }
    }
}
