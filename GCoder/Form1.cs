using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCoder
{
    public partial class GCoder : Form
    {
        public GCoder()
        {
            InitializeComponent();
        }

        private void lbListadoArchivo_DragEnter(object sender, DragEventArgs e)
        {
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
                        printData.FileName, 
                        printData.PrintTime, 
                        printData.Material, 
                        printData.LineWeight, 
                        printData.LineHeight,
                        printData.Infill,
                        Math.Round(printData.Cost, 2),
                        Math.Round(printData.Weight, 2),
                        Math.Round(printData.Amount, 2)
                    );
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
    }
}
