using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Contracts.Interfaces
{
    public interface ITimestampConverter
    {
        public DateTime FromUnix(string unixTimestamp);
    }
}
