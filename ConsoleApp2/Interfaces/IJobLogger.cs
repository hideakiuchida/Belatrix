using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Interfaces
{
    public interface IJobLogger
    {
        bool Error(string message);
        bool Message(string message);
        bool Warning(string message);
    }
}
