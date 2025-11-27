using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Contracts.DTOs
{
    public class Call
    {
        public DateTime StartTime { get; set; }
        public bool WasSuccessful { get; set; }
        public int WaitTimeSeconds { get; set; }
        public int CallTimeSeconds { get; set; }
    }
}
