using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI
{
    [Serializable]
    public class CliArgException : Exception
    {
        public CliArgException()
            : base()
        {
        }

        public CliArgException(string message)
            : base(message)
        {
        }

        public CliArgException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
