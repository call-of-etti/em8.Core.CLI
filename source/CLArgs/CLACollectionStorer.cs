using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.CLArgs
{
    public class CLACollectionStorer
    {
        private ICollection<string> collection;

        public CLACollectionStorer(ICollection<string> collection, CLAParser parser, string argID, params string[] argAliases)
        {
            this.collection = collection;
            parser.KeyValuePairArgStorers.Register(new CLArg(argID, this.Store, argAliases));
        }

        private void Store(string valueToStore)
        {
            this.collection.Add(valueToStore);
        }
    }
}
