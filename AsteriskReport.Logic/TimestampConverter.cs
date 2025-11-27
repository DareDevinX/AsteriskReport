using AsteriskReport.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Logic
{
    public class TimestampConverter : ITimestampConverter
    {
        public DateTime FromUnix(string unixTimestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(unixTimestamp)).DateTime;
        }
    }
}
