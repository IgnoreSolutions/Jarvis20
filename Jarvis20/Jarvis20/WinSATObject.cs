using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis_WinSAT
{
    public class WinSATObject
    {
        public decimal CPUScore { get; set; }
        public decimal D3DScore { get; set; }
        public decimal DiskScore { get; set; }
        public decimal GraphicsScore { get; set; } //desktop
        public decimal MemoryScore { get; set; }
        public decimal WinSPRLevel { get; set; } //lowest score

        public WinSATObject()
        {
            CPUScore = decimal.Parse(GetComponent("Win32_WinSAT", "CPUScore"));
            D3DScore = decimal.Parse(GetComponent("Win32_WinSAT", "D3DScore"));
            DiskScore = decimal.Parse(GetComponent("Win32_WinSAT", "DiskScore"));
            GraphicsScore = decimal.Parse(GetComponent("Win32_WinSAT", "GraphicsScore"));
            MemoryScore = decimal.Parse(GetComponent("Win32_WinSAT", "GraphicsScore"));
            WinSPRLevel = decimal.Parse(GetComponent("Win32_WinSAT", "WinSPRLevel"));
        }

        public void WriteToFile(string dest)
        {
            StreamWriter sw = new StreamWriter(dest);
            sw.WriteLine("CPUScore={0}", CPUScore);
            sw.WriteLine("D3DScore={0}", D3DScore);
            sw.WriteLine("DiskScore={0}", DiskScore);
            sw.WriteLine("GraphicsScore={0}", GraphicsScore);
            sw.WriteLine("MemoryScore={0}", MemoryScore);
            sw.WriteLine("WinSPRLevel={0}", WinSPRLevel);
            sw.Flush();
            sw.Close();
        }

        public void ReadFromFile(string input)
        {
            var file = File.ReadAllLines(input);
            var config = (from line in file
                          let s = line.Split('=')
                          select new { Key = s[0], Value = s[1] }).ToDictionary(x => x.Key, x => x.Value);
            for(int index = 0; index < config.Count; index++)
            {
                var item = config.ElementAt(index);
                switch(item.Key)
                {
                    case("CPUScore"):
                        CPUScore = decimal.Parse(item.Value);
                        break;
                    case("D3DScore"):
                        D3DScore = decimal.Parse(item.Value);
                        break;
                    case("DiskScore"):
                        DiskScore = decimal.Parse(item.Value);
                        break;
                    case("GraphicsScore"):
                        GraphicsScore = decimal.Parse(item.Value);
                        break;
                    case("MemoryScore"):
                        MemoryScore = decimal.Parse(item.Value);
                        break;
                    case("WinSPRLevel"):
                        WinSPRLevel = decimal.Parse(item.Value);
                        break;
                }
            }
        }

        /// <summary>
        /// Returns a component's information from WMI
        /// </summary>
        /// <param name="hwclass">The hardware to return a certain value for</param>
        /// <param name="syntax">The value to be returned of the hardware</param>
        /// <returns></returns>
        private static string GetComponent(string hwclass, string syntax)
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
                foreach (ManagementObject mj in mos.Get())
                {
                    return mj[syntax].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Error while trying to retrieve {0} for {1}\n\tException: {2}", syntax, hwclass, ex.Message);
            }
            return "NULL";
        }
    }
}
