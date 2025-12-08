namespace AsteriskReport.Contracts.Interfaces
{
    public interface IFileReader
    {
        string[] ReadLines(string filePath);
    }
}
