using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.License.GNU
{
    public class LGPLv21 : GNULicenseInfo
    {
        const string LICENSE_NAME = "GNU Lesser General Public License, Version 2.1";
        const string SHORT_LICENSE_NAME_WWW_GNU_ORG = "lgpl-2.1";

        public LGPLv21(string appTitle, string appVersion, string copyright)
            : base(appTitle, appVersion, copyright, LICENSE_NAME, SHORT_LICENSE_NAME_WWW_GNU_ORG)
        {
        }
    }
}
