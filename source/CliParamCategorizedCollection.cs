using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI
{
    public class CliParamCategorizedCollection
    {
        public List<string> SimpleValueArgs
        {
            get;
        } = new List<string>();

        public CliArgsRegistry KeyValuePairArgs
        {
            get;
        } = new CliArgsRegistry();

        public CliArgsRegistry GhostArgs
        {
            get;
        } = new CliArgsRegistry();
    }
}
