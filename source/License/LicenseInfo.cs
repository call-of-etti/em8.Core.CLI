using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.License
{
    public class LicenseInfo : ILicenseInfo
    {
        public string AppTitle { get; }
        public string AppVersion { get; }
        public string Copyright { get; }
        public string LicenseName { get; }

        public LicenseInfo(string appTitle, string appVersion, string copyright, string licenseName)
        {
            this.AppTitle = appTitle;
            this.AppVersion = appVersion;
            this.Copyright = copyright;
            this.LicenseName = licenseName;
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]\n{2}\nLicense: {3}\n", this.AppTitle, this.AppVersion, this.Copyright, this.LicenseName);
        }
    }
}
