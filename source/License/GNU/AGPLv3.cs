using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.License.GNU
{
    public class AGPLv3 : GNULicenseInfo
    {
        const string LICENSE_NAME = "GNU Affero General Public License, Version 3";
        const string SHORT_LICENSE_NAME_WWW_GNU_ORG = "agpl-3.0";

        public AGPLv3(string appTitle, string appVersion, string copyright)
            : base(appTitle, appVersion, copyright, LICENSE_NAME, SHORT_LICENSE_NAME_WWW_GNU_ORG)
        {
        }
    }
}
