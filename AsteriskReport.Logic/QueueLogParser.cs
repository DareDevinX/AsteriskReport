using AsteriskReport.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Logic
{
    public class QueueLogParser : IQueueLogParser
    {
        public QueueLog Parse(string queueLogEntry)
        {
            var logEntryElements = queueLogEntry.Split('|');
        }
    }
}
