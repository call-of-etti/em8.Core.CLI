using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI
{
    /// <summary>
    /// Recommendation: All aliases in lower-case
    /// </summary>
    public class CliParam : IAlias<string>, IResetable
    {
        public string Id => this.Aliases.First();

        public List<string> Aliases
        {
            get;
        } = new List<string>();

        public string DefaultValue
        {
            get;
        }

        public string Value
        {
            get; internal set;
        }

        public bool IsSingleChar
        {
            get { return (this.Id.Length == 1); }
        }


        public CliParam(string id, string defaultValue, params string[] aliases)
        {
            this.Aliases.Add(id);
            this.DefaultValue = defaultValue;
            this.Value = defaultValue;

            this.Aliases.AddRange(aliases);
        }


        public void Reset()
        {
            this.Value = this.DefaultValue;
        }

        public override string ToString()
        {
            return this.Aliases.First();
        }
    }
}
