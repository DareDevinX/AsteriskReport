using AsteriskReport.Contracts.Interfaces;

namespace AsteriskReport.Logic
{
    public class FileReader : IFileReader
    {
        public string[] ReadLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
