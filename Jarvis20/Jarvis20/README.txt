---What is Jarvis?---

Jarvis is a simplistic resource monitor written in C# using Visual Studio and the .NET framework. He will monitor your CPU load and available RAM and warn you when things start to get a little hectic, by speaking to you! Jarvis stores these in a log which can be written to the disk later.

---Does Jarvis spy on me?---

No! Jarvis collects anonymous data only, Jarvis does not collect in depth stats on processes; only your CPU load and memory (and if you use the system specs tool, these are not sent back to a server).

---Why does my antivirus report Jarvis20.exe as a virus?---

Jarvis monitors the system through Performance Counters, these are built into the system and programs that utilize them can sometimes be marked as malicious. In addition, Jarvis uses the WMI interface to collect system information.

---I found a bug!---

Please, report any and all bugs to our GitHub page at
http://github.com/MikeSantiagoInc/Jarvis20/issues

You will require and account to report bugs but this way, we can track bug fixes and better reference them between my partner and I.