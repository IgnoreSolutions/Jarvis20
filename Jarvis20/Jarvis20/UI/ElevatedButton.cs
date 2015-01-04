using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jarvis20.UI
{
    /// <summary>
    /// Is a button with the UAC shield
    /// </summary>
    public partial class ElevatedButton : Button
    {
        /// <summary>
        /// The constructor to create the button with a UAC shield if necessary.
        /// </summary>
        public ElevatedButton()
        {
            FlatStyle = FlatStyle.System;
            if (!IsElevated()) ShowShield();
        }


        [DllImport("user32.dll")]
        private static extern IntPtr
            SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private uint BCM_SETSHIELD = 0x0000160C;

        private bool IsElevated()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }


        private void ShowShield()
        {
            IntPtr wParam = new IntPtr(0);
            IntPtr lParam = new IntPtr(1);
            SendMessage(new HandleRef(this, Handle), BCM_SETSHIELD, wParam, lParam);
        }
    }
}
