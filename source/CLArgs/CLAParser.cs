using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.CLArgs
{
    /// <summary>
    /// Command-line args parser
    /// </summary>
    public class CLAParser
    {
        /// <summary>
        /// The matching storer gets called when an key-value pair arg is found
        /// </summary>
        public CLARegistry KeyValuePairArgStorers
        {
            get;
        } = new CLARegistry();

        /// <summary>
        /// Gets called for each arg that is a simple value
        /// </summary>
        public ValueStorer SimpleValueArgsStorer
        {
            get; set;
        }

        /// <summary>
        /// Gets called when there is no matching storer for a key-value pair arg found
        /// </summary>
        public KeyValuePairStorer LeftOverKeyValuePairArgsStorer
        {
            get; set;
        }


        /// <param name="simpleValueArgsStorer">Gets called for each arg that is a simple value</param>
        /// <param name="leftOverKeyValuePairArgsStorer">Gets called when there is no matching storer for a key-value pair arg found</param>
        /// <param name="keyValuePairArgStorers">The matching storer gets called when an key-value pair arg is found</param>
        public CLAParser(ValueStorer simpleValueArgsStorer, KeyValuePairStorer leftOverKeyValuePairArgsStorer, params CLArg[] keyValuePairArgStorers)
        {
            this.SimpleValueArgsStorer = simpleValueArgsStorer;
            this.LeftOverKeyValuePairArgsStorer = leftOverKeyValuePairArgsStorer;

            this.KeyValuePairArgStorers.RegisterRange(keyValuePairArgStorers);
        }

        /// <param name="keyValuePairArgStorers">The matching storer gets called when an key-value pair arg is found</param>
        public CLAParser(params CLArg[] keyValuePairArgStorers)
            : this(null, null, keyValuePairArgStorers)
        {
        }


        /// <summary>
        /// -  ... single-char key(s)
        ///         -x          => { x }
        ///         -abc        => { a, b, c }
        /// -- ... multi-char key
        ///         --abc       => { abc }
        ///         --xyz --qww => { xyz, qwe }
        /// /  ... multi-char key
        ///         /q          => { q }
        ///         /vb /nm     => { vb, nm }
        /// special cases:
        ///         //sdf       => { sdf }
        ///         ---ui --o-p => { ui, o-p }
        /// </summary>
        public void Parse(string[] args)
        {
            string key = null;

            foreach (string a in args)
            {
                if
                (
                    (a[0] == '/') ||
                    (
                        (a[0] == '-') &&
                        (a[1] == '-')
                    )
                )
                {
                    // multi-char key

                    if (key != null)
                    {
                        // the previous key has no specific value
                        this.StoreParam(key, true.ToString());
                    }

                    string a2 = a.TrimStart('/', '-');
                    key = a2;
                }
                else if (a[0] == '-')
                {
                    // single-char key(s)

                    if (key != null)
                    {
                        // the previous key has no specific value
                        this.StoreParam(key, true.ToString());
                    }

                    string a2 = a.Substring(1); // without identifier

                    if (a2.Length == 1)
                    {
                        // real key
                        key = a2;
                    }
                    else
                    {
                        // multiple single-char args
                        // (do not have values)

                        foreach (char c in a2)
                        {
                            if (c == '-')
                                continue;
                            this.StoreParam(c.ToString(), true.ToString());
                        }
                    }
                }
                else
                {
                    // value-of-key or simple-value

                    if (key == null)
                    {
                        // simple-value
                        this.SimpleValueArgsStorer?.Invoke(a);
                    }
                    else
                    {
                        // value-of-key

                        StoreParam(key, a);

                        key = null;
                    }
                }
            }

            if (key != null)
            {
                // the last key has no specific value
                this.StoreParam(key, true.ToString());
            }
        }

        protected void StoreParam(string key, string value)
        {
            // is such a parameter expected?
            if (this.KeyValuePairArgStorers.ContainsKey(key))
            {
                this.KeyValuePairArgStorers[key].storeValueHandler?.Invoke(value);
            }
            else
            {
                // unexpected
                this.LeftOverKeyValuePairArgsStorer?.Invoke(new KeyValuePair<string, string>(key, value));
            }
        }
    }
}
