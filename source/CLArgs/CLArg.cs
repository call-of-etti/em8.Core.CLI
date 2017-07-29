using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.CLArgs
{
    public class CLArg : IAlias<string>
    {
        internal ValueStorer storeValueHandler;

        public List<string> Aliases
        {
            get;
        } = new List<string>();

        public CLArg(string id, ValueStorer storeValueHandler, params string[] aliases)
        {
            this.Aliases.Add(id);

            this.storeValueHandler = storeValueHandler;

            this.Aliases.AddRange(aliases);
        }
    }
}
