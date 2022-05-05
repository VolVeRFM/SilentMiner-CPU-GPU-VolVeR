

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace Miner
{
    public static class RAM
    {
        public static int GetVRAM()
        {
            List<int> source = new List<int>();
            int num = 0;
            foreach (string str in RAM.GetName())
            {
                if (str.Contains("radeon") && str.Contains("rx"))
                {
                    if (str.Contains("560") && str.Contains("xt"))
                        num = 4096;
                    if (str.Contains("590"))
                        num = 8192;
                    if (str.Contains("580") && str.Contains("g"))
                        num = 8192;
                    if (str.Contains("550") && str.Contains("x"))
                        num = 4096;
                    if (str.Contains("580") && str.Contains("x"))
                        num = 8192;
                    if (str.Contains("570") && str.Contains("x"))
                        num = 8192;
                    if (str.Contains("560") && str.Contains("x"))
                        num = 4096;
                    if (str.Contains("560") && str.Contains("d"))
                        num = 4096;
                    if (str.Contains("580"))
                        num = 8192;
                    if (str.Contains("570"))
                        num = 4096;
                    if (str.Contains("560"))
                        num = 4096;
                    if (str.Contains("550"))
                        num = 2048;
                    if (str.Contains("470"))
                        num = 4096;
                    if (str.Contains("460"))
                        num = 2048;
                    if (str.Contains("580") && str.Contains("oem"))
                        num = 8192;
                    if (str.Contains("480"))
                        num = 8192;
                    if (str.Contains("6800m"))
                        num = 12288;
                    if (str.Contains("6700m"))
                        num = 12288;
                    if (str.Contains("6600"))
                        num = 8192;
                    if (str.Contains("6500"))
                        num = 8192;
                    if (str.Contains("6300"))
                        num = 4096;
                    if (str.Contains("6700") || str.Contains("6700 xt"))
                        num = 12288;
                    if (str.Contains("6900") || str.Contains("6900 xt"))
                        num = 16384;
                    if (str.Contains("6800") || str.Contains("6800 xt"))
                        num = 16384;
                    if (str.Contains("5700m"))
                        num = 8192;
                    if (str.Contains("5600m"))
                        num = 6144;
                    if (str.Contains("5600m") && str.Contains("pro"))
                        num = 8192;
                    if (str.Contains("590") && str.Contains("gme"))
                        num = 8192;
                    if (str.Contains("5600") && str.Contains("xt"))
                        num = 6144;
                    if (str.Contains("5600") && str.Contains("oem"))
                        num = 6144;
                    if (str.Contains("5500") && str.Contains("m"))
                        num = 4096;
                    if (str.Contains("5500") && str.Contains("xt"))
                        num = 4096;
                    if (str.Contains("5500") && str.Contains("oem"))
                        num = 4096;
                    if (str.Contains("5300") && str.Contains("m"))
                        num = 3072;
                    if (str.Contains("5700") && str.Contains("xt"))
                        num = 8192;
                    if (str.Contains("5700"))
                        num = 8192;
                    if (str.Contains("vii"))
                        num = 16384;
                    if (str.Contains("vega") && str.Contains("m") && str.Contains("gl"))
                        num = 4096;
                    if (str.Contains("vega") && str.Contains("nano"))
                        num = 8192;
                    if (str.Contains("vega") && str.Contains("64"))
                        num = 8192;
                    if (str.Contains("vega") && str.Contains("56"))
                        num = 8192;
                }
                if (str.Contains("r9"))
                {
                    if (str.Contains("380") && str.Contains("x"))
                        num = 4096;
                    if (str.Contains("nano") || str.Contains("fury"))
                        num = 4096;
                    if (str.Contains("390") || str.Contains("x2"))
                        num = 16384;
                    if (str.Contains("fury") || str.Contains("x2"))
                        num = 8192;
                }
                if (str.Contains("nvidia") || str.Contains("geforce"))
                {
                    if (str.Contains("3050"))
                        num = 4096;
                    if (str.Contains("3080") && str.Contains("ti"))
                        num = 12288;
                    if (str.Contains("3070") && str.Contains("ti"))
                        num = 8192;
                    if (str.Contains("3080") && str.Contains("mobile"))
                        num = 8192;
                    if (str.Contains("3080") && str.Contains("max-q"))
                        num = 8192;
                    if (str.Contains("3070") && str.Contains("mobile"))
                        num = 8192;
                    if (str.Contains("3070") && str.Contains("max-q"))
                        num = 8192;
                    if (str.Contains("3060") && str.Contains("mobile"))
                        num = 6144;
                    if (str.Contains("3060") && str.Contains("max-q"))
                        num = 6144;
                    if (str.Contains("3060") && !str.Contains("max-q") && !str.Contains("mobile"))
                        num = 12288;
                    if (str.Contains("3070") && !str.Contains("ti") && !str.Contains("mobile") && !str.Contains("max-q"))
                        num = 8192;
                    if (str.Contains("3060") && str.Contains("ti"))
                        num = 8192;
                    if (str.Contains("3090"))
                        num = 24576;
                    if (str.Contains("3080") && !str.Contains("max-q") && !str.Contains("mobile"))
                        num = 10240;
                    if (str.Contains("1650"))
                        num = 4096;
                    if (str.Contains("rtx") && str.Contains("2080") && !str.Contains("ti"))
                        num = 8192;
                    if (str.Contains("rtx") && str.Contains("2060") && !str.Contains("super"))
                        num = 6144;
                    if (str.Contains("rtx") && str.Contains("2060") && str.Contains("super"))
                        num = 8192;
                    if (str.Contains("1660"))
                        num = 6144;
                    if (str.Contains("rtx") && str.Contains("2080") && str.Contains("ti"))
                        num = 11264;
                    if (str.Contains("rtx") && str.Contains("2070"))
                        num = 8192;
                    if (str.Contains("rtx") && str.Contains("2060") && !str.Contains("super"))
                        num = 6144;
                    if (str.Contains("rtx") && str.Contains("2060") && str.Contains("super"))
                        num = 8192;
                    if (str.Contains("titan") && str.Contains("rtx"))
                        num = 24576;
                    if (str.Contains("quadro") && str.Contains("rtx") && str.Contains("4000"))
                        num = 8192;
                    if (str.Contains("tesla") && str.Contains("t4"))
                        num = 16384;
                    if (str.Contains("quadro") && str.Contains("rtx") && str.Contains("8000"))
                        num = 49152;
                    if (str.Contains("titan") && str.Contains("v") && str.Contains("ceo") && str.Contains("edition"))
                        num = 32768;
                    if (str.Contains("titan") && str.Contains("v") && !str.Contains("ceo") && !str.Contains("edition"))
                        num = 12288;
                    if (str.Contains("1070"))
                        num = 8192;
                    if (str.Contains("titan") && str.Contains("xp"))
                        num = 12288;
                    if (str.Contains("1080") && !str.Contains("ti"))
                        num = 8192;
                    if (str.Contains("1080") && str.Contains("ti"))
                        num = 12288;
                    if (str.Contains("1050") && str.Contains("ti"))
                        num = 4096;
                    if (str.Contains("1050") && !str.Contains("ti"))
                        num = 2048;
                    if (str.Contains("1060") && !str.Contains("3gb"))
                        num = 6144;
                    if (str.Contains("1060") && str.Contains("3gb"))
                        num = 3072;
                    if (str.Contains("titan") && str.Contains("x") && str.Contains("pascal"))
                        num = 12288;
                    if (str.Contains("980") && str.Contains("ti"))
                        num = 6144;
                    if (str.Contains("980") && !str.Contains("ti"))
                        num = 8192;
                    if (str.Contains("940"))
                        num = 2048;
                    if (str.Contains("965"))
                        num = 2048;
                    if (str.Contains("950") && str.Contains("m"))
                        num = 4096;
                    if (str.Contains("950") && str.Contains("oem"))
                        num = 4096;
                    if (str.Contains("950") && !str.Contains("oem") && !str.Contains("m"))
                        num = 2048;
                    if (str.Contains("930"))
                        num = 2048;
                    if (str.Contains("920"))
                        num = 2048;
                    if (str.Contains("960") && str.Contains("m"))
                        num = 4096;
                    if (str.Contains("960") && str.Contains("oem"))
                        num = 4096;
                    if (str.Contains("960") && !str.Contains("m") && !str.Contains("oem"))
                        num = 2048;
                    if (str.Contains("titan") && str.Contains("titan x"))
                        num = 12288;
                    if (str.Contains("titan") && str.Contains("titan z"))
                        num = 6144;
                    if (str.Contains("titan") && str.Contains("black"))
                        num = 6144;
                    if (str.Contains("titan") && str.Contains("black"))
                        num = 6144;
                    if (str.Contains("880m"))
                        num = 8192;
                    if (str.Contains("1650"))
                        num = 4096;
                    if (str.Contains("680m"))
                        num = 4096;
                    if (str.Contains("1660"))
                        num = 6144;
                    if (str.Contains("780m"))
                        num = 4096;
                }
                source.Add(num);
                num = 0;
            }
            return source.Max();
        }

        public static List<string> GetName()
        {
            List<string> stringList = new List<string>();
            if (stringList.Count == 0)
            {
                try
                {
                    using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
                    {
                        foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                            stringList.Add(managementObject["Name"].ToString().ToLower());
                    }
                }
                catch (Exception)
                {
                }
            }
            return stringList;
        }
    }
}
