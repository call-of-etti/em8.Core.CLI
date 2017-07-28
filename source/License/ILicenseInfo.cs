using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoE.em8.Core.CLI.License
{
    public interface ILicenseInfo
    {
        string AppTitle { get; }
        string AppVersion { get; }
        string Copyright { get; }
        string LicenseName { get; }

        string ToString();
    }
}
