using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCoder.Model
{
    public  class PrintData
    {
        public string FileName { get; set; }
        public string PrintTime { get; set; }
        public string Material { get; set; }
        public double LineWeight { get; set; }
        public double LineHeight { get; set; }
        public double Infill { get; set; }
        public double Cost { get; set; }
        public double Weight { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; } = false;
    }
}
