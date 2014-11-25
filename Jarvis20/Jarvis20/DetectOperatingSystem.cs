using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jarvis20
{
    public class DetectOperatingSystem
    {
        public enum OSFriendly { Windows95, Windows98, WindowsME, WindowsXP, WindowsVista, Windows7, Windows8, Windows81, Windows10 }
        
        public OSFriendly OSName()
        {
            float osVersion = float.Parse(Environment.OSVersion.Version.Major.ToString() + "." + Environment.OSVersion.Version.Minor.ToString());
            switch(osVersion)
            {
                case(4.0f):
                    break;
                case(4.03f):
                    break;
                case(4.10f):
                    break;
                case(4.90):
                    break;
                case(5.00):
                    break;
                case(5.1):
                    break;
                case(6.0):
                    break;
            }
            return null;
        }
    }
}
