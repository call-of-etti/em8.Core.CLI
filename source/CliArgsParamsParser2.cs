using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI
{
    [Obsolete("Use CoE.em8.Core.CLI.CLArgs.Parser instead.")]
    public class CliArgsParamsParser2 : CliArgsParamsParser
    {
        public List<string> SimpleValueArgs => base.Args.SimpleValueArgs;

        public CliArgsRegistry KeyValuePairArgs => base.Args.KeyValuePairArgs;

        public CliArgsRegistry GhostArgs => base.Args.GhostArgs;


        public CliArgsParamsParser2()
            : base()
        {
        }
    }
}
