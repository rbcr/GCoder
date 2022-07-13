using System;
using System.Collections.Generic;
using System.Drawing;
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
        public double Scale { get; set; }
        public bool SupportsEnabled { get; set; } = false;
        public double ObjectWidth { get; set; } = 0;
        public double ObjectHeight { get; set; } = 0;
        public double ObjectBackground { get; set; } = 0;
        public DateTime? Created_at { get; set; } = null;
        public Image Thumbnail { get; set; }
        public bool Status { get; set; } = false;
    }
}
