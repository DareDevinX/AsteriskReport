using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Contracts.DTOs
{
    public class BarSegment
    {
        public BarSegment(float y, float height, BarColor color = BarColor.Red)
        {
            this.Y = y;
            this.Height = height;
            this.Color = color;
        }
        public float Y { get; set; }
        public BarColor Color { get; set; }
        public float Height { get; set; }
    }
}
