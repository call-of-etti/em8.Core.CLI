using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI
{
    public class CliArgsParamsParser
    {
        public CliParamCategorizedCollection Args
        {
            get;
        } = new CliParamCategorizedCollection();

        public CliArgsParamsParser()
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
                else if(a[0] == '-')
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
                        this.Args.SimpleValueArgs.Add(a);
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
            // is such an parameter expected?
            if (this.Args.KeyValuePairArgs.Contains(key))
            {
                this.Args.KeyValuePairArgs[key].Value = value;
            }
            else
            {
                // unexpected
                this.Args.GhostArgs.Register(new CliParam(key, value));
            }
        }
    }
}
