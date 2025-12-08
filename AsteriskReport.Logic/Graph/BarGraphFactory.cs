using AsteriskReport.Contracts.Config;
using AsteriskReport.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Logic.Graph
{
    public class BarGraphFactory : IBarGraphFactory
    {
        private readonly BarGraphConfig config;

        public BarGraphFactory(BarGraphConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public IBarGraph Create(IEnumerable<Bar> bars)
        {
            var barGraphWidth = bars.Count() * (config.BarWidth + config.HorizontalSpacing);
            var barGraphHeight = (int)bars.Max(bar => bar.Segments.Sum(segment => segment.Height));
            var bitmap = new Bitmap(barGraphWidth + config.GraphLeftOffset, barGraphHeight + config.GraphBottomOffset);
            var graphics = Graphics.FromImage(bitmap);

            return new BarGraph(bitmap, graphics, barGraphHeight, barGraphWidth, config);
        }
    }
}
