using CoE.em8.Core.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI
{
    [Obsolete]
    public class CliArgsRegistry
    {
        Dictionary<string, CliParam> registry = new Dictionary<string, CliParam>();

        public void Register(CliParam option)
        {
            foreach (string alias in option.Aliases)
                registry.Add(alias, option);
        }

        public CliParam this[string alias] => this.Get(alias);
        public CliParam Get(string alias) => registry[alias];


        public bool Contains(string id)
        {
            return this.registry.ContainsKey(id);
        }
    }
}
