using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace WindowBorderColor
{
    public class WindowBorderColor
    {
        /// <summary>
        /// Retrieves the aero border color on Windows 8/Windows 8.1
        /// </summary>
        /// <returns>System.Drawing.Color drawingColor: the actual color</returns>
        public static System.Drawing.Color BorderColor()
        {
            System.Windows.Media.Color mediaColor;
            mediaColor = SystemParameters.WindowGlassColor;
            System.Drawing.Color drawingColor = System.Drawing.Color.FromArgb(160, mediaColor.R, mediaColor.G, mediaColor.B);
            return drawingColor;
        }

        static void SystemParameters_StaticPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "WindowGlassColor")
            {
                BorderColor();
            }
        }
        /// <summary>
        /// Gets the right ContrastColor (aka set your font color to whatever this spits out)
        /// </summary>
        /// <param name="color">Put in the value you retrieved for BorderColor</param>
        /// <returns>White or black, depending. It outputs a System.Drawing.Color</returns>
        public static System.Drawing.Color ConstrastColor(System.Drawing.Color color)
        {
            int d = 0;

            // Counting the perceptive luminance - human eye favors green color... 
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (a < 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return System.Drawing.Color.FromArgb(d, d, d);
        }
        //
        public static void InitializeWindows8Theme(System.Windows.Forms.Form frm)
        {
            Console.WriteLine("Initializing theme");
            System.Drawing.Color windowBorderColor = BorderColor();
            System.Drawing.Color fontcolor = ConstrastColor(windowBorderColor);

            foreach (Control c in frm.Controls)
            {
                if (c is Button)
                {
                    Button b = (Button)c;
                    b.FlatStyle = FlatStyle.Flat;
                    b.BackColor = windowBorderColor;
                    b.ForeColor = fontcolor;
                    b.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                }
            }
        }
        //
    }
}
