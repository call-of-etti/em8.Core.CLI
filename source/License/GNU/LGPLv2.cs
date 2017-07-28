using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.License.GNU
{
    public class LGPLv2 : GNULicenseInfo
    {
        const string LICENSE_NAME = "GNU Library General Public License, Version 2";
        const string SHORT_LICENSE_NAME_WWW_GNU_ORG = "lgpl-2.0";

        public LGPLv2(string appTitle, string appVersion, string copyright)
            : base(appTitle, appVersion, copyright, LICENSE_NAME, SHORT_LICENSE_NAME_WWW_GNU_ORG)
        {
        }
    }
}
