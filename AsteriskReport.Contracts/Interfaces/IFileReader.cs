using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Contracts.Interfaces
{
    public interface IFileReader
    {
        string[] ReadLines(string filePath);
    }
}
