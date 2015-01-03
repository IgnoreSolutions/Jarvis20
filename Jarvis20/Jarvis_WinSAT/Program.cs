using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
            if (Environment.Is64BitProcess)
            { 
                Console.WriteLine("x64 Build\n"); 
            }
            else
            {
                if(Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess)
                {
                    Console.WriteLine("ERROR: User is running x86 build on x64 operating system.\nPlease use the x64 Build");
                    Environment.Exit(-2);
                }
                else
                    Console.WriteLine("x86 Build\n"); 
            }

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
                    Console.WriteLine("\nPress enter to exit..");
                    Console.ReadLine();
                }
                else if (args[0] == "-prepop")
                {
                    try
                    {
                        ///TODO: wait for process to exit
                        Process p = new Process();
                        p.StartInfo.FileName = Environment.SystemDirectory + "\\WinSAT.exe";
                        p.StartInfo.Arguments = "prepop";
                        p.StartInfo.UseShellExecute = true;
                        p.StartInfo.Verb = "runas";
                        if (File.Exists(Environment.SystemDirectory + "\\WinSAT.exe"))
                        {
                            Console.WriteLine("Running WinSAT prepop..");
                            p.Start();
                            p.WaitForExit();
                        }
                        else
                        {
                            Console.WriteLine("ERROR: WinSAT.exe not found in " + Environment.SystemDirectory);
                        }
                        WinSATObject w = new WinSATObject();
                        w.WriteToFile(Environment.CurrentDirectory + "\\output.sat");   
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
                        ///TODO: wait for process to exit
                        Process p = new Process();
                        p.StartInfo.FileName = Environment.SystemDirectory + "\\WinSAT.exe";
                        p.StartInfo.Arguments = "formal";
                        p.StartInfo.UseShellExecute = true;
                        p.StartInfo.Verb = "runas";
                        if (File.Exists(Environment.SystemDirectory + "\\WinSAT.exe"))
                        {
                            Console.WriteLine("Running WinSAT prepop..");
                            p.Start();
                            p.WaitForExit();
                        }
                        else
                        {
                            Console.WriteLine("ERROR: WinSAT.exe not found in " + Environment.SystemDirectory);
                        }
                        WinSATObject w = new WinSATObject();
                        w.WriteToFile(Environment.CurrentDirectory + "\\output.sat");
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
                        Process p = new Process();
                        p.StartInfo.FileName = Environment.SystemDirectory + "\\WinSAT.exe";
                        p.StartInfo.Arguments = "prepop";
                        p.StartInfo.UseShellExecute = true;
                        p.StartInfo.Verb = "runas";
                        if (File.Exists(Environment.SystemDirectory + "\\WinSAT.exe"))
                        {
                            Console.WriteLine("Running WinSAT prepop..");
                            p.Start();
                            p.WaitForExit();
                            Console.WriteLine("Running WinSAT formal..");
                            p.StartInfo.Arguments = "formal";
                            p.Start();
                            p.WaitForExit();
                        }
                        else
                        {
                            Console.WriteLine("ERROR: WinSAT.exe not found in " + Environment.SystemDirectory);
                        }
                        WinSATObject w = new WinSATObject();
                        w.WriteToFile(Environment.CurrentDirectory + "\\output.sat");
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
                Console.WriteLine("No argument provided, use -help to list commands");
            }

        }
    }
}
