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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var printData = GCodeParser.Parse(@"C:\\Users\\Roberto\\Desktop\\Arm First v2-[T011707][LW0.8mm][LH0.32mm][IF20.0].gcode");
            Console.WriteLine("PRINT_DATA: " + printData.Status);
        }
    }
}
