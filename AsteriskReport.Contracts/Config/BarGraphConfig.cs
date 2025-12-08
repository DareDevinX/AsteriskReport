using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Contracts.Config
{
    public class BarGraphConfig
    {
        public int MaxBarSegmentLength { get; set; }
        public int BarWidth { get; set; }
        public int HorizontalSpacing { get; set; }
        public int MinBarSegmentLength { get; set; }
    }
}
