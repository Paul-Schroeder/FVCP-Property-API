using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Infrastructure.Core
{
    public static class Enums
    {
        public enum LogMessageType
        {
            Unknown = 100,
            Exception_Application = 101,
            Exception_Database = 102,
            Exception_General = 103,
            Exception_Unhandled = 104,
            Unauthorized = 400,
        }

    }
}
