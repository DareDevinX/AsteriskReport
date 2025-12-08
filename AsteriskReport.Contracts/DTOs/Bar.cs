using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Contracts.DTOs
{
    public class Bar
    {
        public float X { get; set; }
        public IEnumerable<BarSegment> Segments { get; set; }
        public float Width { get; set; }

        public Bar(IEnumerable<BarSegment> segments, float x, float width)
        {
            this.Segments = segments;
            this.X = x;
            this.Width = width;
        }
    }
}
