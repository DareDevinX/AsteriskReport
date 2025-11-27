using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Contracts.DTOs
{
    public class BarSegment
    {
        public BarSegment(float y, float height)
        {
            this.Y = y;
            this.Height = height;
            this.Color = Color.Red;
        }
        public float Y { get; set; }
        public Color Color { get; set; }
        public float Height { get; set; }
    }
}
