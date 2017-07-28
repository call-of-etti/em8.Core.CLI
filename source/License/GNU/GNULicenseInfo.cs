using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.License.GNU
{
    public abstract class GNULicenseInfo : LicenseInfo
    {
        public string ShortLicenseNameWwwGNUorg { get; }

        public GNULicenseInfo(string appTitle, string appVersion, string copyright, string licenseName, string shortLicenseNameWwwGNUorg)
            : base(appTitle, appVersion, copyright, licenseName)
        {
            this.ShortLicenseNameWwwGNUorg = shortLicenseNameWwwGNUorg;
        }

        public override string ToString()
        {
            return string.Format
(@"{0} [{1}]
{2}

This program comes with ABSOLUTELY NO WARRANTY.
This is free software, and you are welcome to redistribute it under certain conditions.
For more information, please refer to <https://www.gnu.org/licenses/{3}.html>
", this.AppTitle, this.AppVersion, this.Copyright, this.ShortLicenseNameWwwGNUorg);
        }
    }
}
