using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.CLArgs
{
    public delegate void ValueStorer(string valueToStore);
    public delegate void KeyValuePairStorer(KeyValuePair<string, string> kvpToStore);
}
