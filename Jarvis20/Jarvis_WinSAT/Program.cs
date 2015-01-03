using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis_WinSAT
{
    class Program
    {
        const int ERROR_CANCELLED = 1223;

        public static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                if (args[0] == "-help")
                {
                    Console.WriteLine("Available Command Line Arguments");
                    Console.WriteLine("Please, only use one of these at a time!");
                    Console.WriteLine("-help: displays this help dialog");
                    Console.WriteLine("-prepop: runs the winsat prepop tool and outputs it to a file (output.sat)");
                    Console.WriteLine("-formal: runs the winsat formal tool and outputs it to a file (output.sat)");
                    Console.WriteLine("-prepop_formal: runs the winsat prepop tool, then winsat formal and outputs it to a file (output.sat)");
                }
                else if (args[0] == "-prepop")
                {

                    /*System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C winsat prepop > output.txt";
                    process.StartInfo = startInfo;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.Verb = "runas";*/

                    try
                    {
                        ///TODO: wait for process to exit
                        if(File.Exists(Environment.SystemDirectory + @"\WinSAT.exe"))
                            Process.Start(Environment.SystemDirectory + "\\WinSAT.exe", "prepop")
                    }
                    catch(Win32Exception ex)
                    {
                        if (ex.HResult == ERROR_CANCELLED)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; 
                            Console.WriteLine("ERROR: User denied UAC Access"); 
                            Console.ForegroundColor = ConsoleColor.White; 
                            Environment.Exit(-1); 
                        }
                        else
                            throw;
                    }
                    Console.WriteLine("Press enter to exit..");
                    Console.ReadLine();
                }
                else if (args[0] == "-formal")
                {
                    try
                    {
                        if (File.Exists(Environment.SystemDirectory + @"\WinSAT.exe"))
                            Process.Start(Environment.SystemDirectory + "\\WinSAT.exe", "formal");
                    }
                    catch (Win32Exception ex)
                    {
                        if (ex.HResult == ERROR_CANCELLED)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: User denied UAC Access");
                            Console.ForegroundColor = ConsoleColor.White;
                            Environment.Exit(-1);
                        }
                        else
                            throw;
                    }
                    Console.WriteLine("Press enter to exit..");
                    Console.ReadLine();
                }
                else if (args[0] == "-prepop_formal")
                { 
                    const int ERROR_CANCELLED = 1223;

                    try
                    {
                        if (File.Exists(Environment.SystemDirectory + @"\WinSAT.exe"))
                            Process.Start(Environment.SystemDirectory + "\\WinSAT.exe", "prepop");
                    }
                    catch (Win32Exception ex)
                    {
                        if (ex.HResult == ERROR_CANCELLED)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: User denied UAC Access");
                            Console.ForegroundColor = ConsoleColor.White;
                            Environment.Exit(-1);
                        }
                        else
                            throw;
                    }
                    try
                    {
                        if (File.Exists(Environment.SystemDirectory + @"\WinSAT.exe"))
                            Process.Start(Environment.SystemDirectory + "\\WinSAT.exe", "formal");
                    }
                    catch (Win32Exception ex)
                    {
                        if (ex.HResult == ERROR_CANCELLED)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: User denied UAC Access");
                            Console.ForegroundColor = ConsoleColor.White;
                            Environment.Exit(-1);
                        }
                        else
                            throw;
                    }
                    Console.WriteLine("Press enter to exit..");
                    Console.ReadLine();

                }
            }
            else
            {
                Console.WriteLine("No argument provided, exiting");
            }
        }
    }
}
