using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.CLArgs
{
    /// <summary>
    /// Stores all passed values in the given collection
    /// </summary>
    public class CLACollectionStorer : CLArg
    {
        private ICollection<string> collection;

        public CLACollectionStorer(string argID, ICollection<string> collection, params string[] argAliases)
            : base(argID, null, argAliases)
        {
            this.collection = collection;
            this.storeValueHandler = this.Store;
        }

        private void Store(string valueToStore)
        {
            this.collection.Add(valueToStore);
        }
    }
}
