using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jarvis20
{
    public class DetectOperatingSystem
    {
        public enum OSFriendly { Windows95, Windows98, WindowsME, Windows2000, WindowsXP, WindowsVista, Windows7, Windows8, Windows81, Windows10, Linux, Unknown }
        
        public static OSFriendly OSName()
        {
            double osVersion = double.Parse(Environment.OSVersion.Version.Major.ToString() + "." + Environment.OSVersion.Version.Minor.ToString());
            int p = (int)Environment.OSVersion.Platform;

            if (osVersion == 5.0)
                return OSFriendly.Windows2000;
            else if (osVersion == 5.1)
                return OSFriendly.WindowsXP;
            else if (osVersion == 6.0)
                return OSFriendly.WindowsVista;
            else if (osVersion == 6.1)
                return OSFriendly.Windows7;
            else if (osVersion == 6.2)
            {
                string osName = new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName;
                if (osName.IndexOf("8.1", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    return OSFriendly.Windows81;
                else if (osName.IndexOf("technical preview", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    return OSFriendly.Windows10;
                else
                    return OSFriendly.Windows8;
            }
            else if (osVersion == 6.3)
                return OSFriendly.Windows81;
            else if (osVersion == 6.4)
                return OSFriendly.Windows10;
            else if (Environment.OSVersion.VersionString.IndexOf("technical preview", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                return OSFriendly.Windows10;
            else if (osVersion == 10.0)
                return OSFriendly.Windows10;
            else if (p == 4 || p == 6 || p == 128)
                return OSFriendly.Linux;
            else
                return OSFriendly.Unknown;
            
        }
    }
}
