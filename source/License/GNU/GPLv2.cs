using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.License.GNU
{
    public class GPLv2 : GNULicenseInfo
    {
        const string LICENSE_NAME = "GNU General Public License, Version 2";
        const string SHORT_LICENSE_NAME_WWW_GNU_ORG = "gpl-2.0";

        public GPLv2(string appTitle, string appVersion, string copyright)
            : base(appTitle, appVersion, copyright, LICENSE_NAME, SHORT_LICENSE_NAME_WWW_GNU_ORG)
        {
        }
    }
}
