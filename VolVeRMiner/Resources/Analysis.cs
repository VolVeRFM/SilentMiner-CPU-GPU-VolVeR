using System.Management;
using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace MinerAns
{
   


    public class Analysis
    {

        public static bool DetectVirtualMachine()
        {
       
                using (var searcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
                {
                    using (var items = searcher.Get())
                    {
                        foreach (var item in items)
                        {
                            string manufacturer = item["Manufacturer"].ToString().ToLower();
                            if ((manufacturer == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL"))
                                || manufacturer.Contains("vmware")
                                || item["Model"].ToString() == "VirtualBox")
                            {
                                return true;
                            }
                        }
                    }
                }
            return false;
        }

        public static bool DetectSandboxie()
        {
            try
            {
                if (Analysis.GetModuleHandle("SbieDll.dll").ToInt32() != 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CheckRemoteDebuggerPresent(
          IntPtr hProcess,
          ref bool isDebuggerPresent);
    }
}

 
