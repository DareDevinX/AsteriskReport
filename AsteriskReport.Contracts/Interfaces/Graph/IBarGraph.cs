using AsteriskReport.Contracts.DTOs;

namespace AsteriskReport.Contracts.Interfaces.Graph
{
    public interface IBarGraph
    {
        void DrawAxis();
        void DrawBackground();
        void DrawBarLabel(DateTime timestamp, float x);
        void DrawBarSegment(BarSegment segment, float x);
        void SaveBitmap();
    }
}