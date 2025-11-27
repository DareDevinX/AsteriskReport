using AsteriskReport.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskReport.Contracts.Interfaces
{
    public interface ICallEventAnalyzer
    {
        Call[] Analyze(QueueEvent[] queueEvent);
    }
}
