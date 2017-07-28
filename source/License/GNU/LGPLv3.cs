using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.License.GNU
{
    public class LGPLv3 : GNULicenseInfo
    {
        const string LICENSE_NAME = "GNU Lesser General Public License, Version 3";
        const string SHORT_LICENSE_NAME_WWW_GNU_ORG = "lgpl-3.0";

        public LGPLv3(string appTitle, string appVersion, string copyright)
            : base(appTitle, appVersion, copyright, LICENSE_NAME, SHORT_LICENSE_NAME_WWW_GNU_ORG)
        {
        }
    }
}
