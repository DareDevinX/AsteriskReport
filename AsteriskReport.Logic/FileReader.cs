using AsteriskReport.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
