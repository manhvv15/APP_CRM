using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace AppCRM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (!Directory.Exists(Environment.GetEnvironmentVariable("APPDATA") + @"\Chat365\Certificate"))
            {
                Directory.CreateDirectory(Environment.GetEnvironmentVariable("APPDATA") + @"\Chat365\Certificates");
            }
            if (!System.IO.File.Exists(Environment.GetEnvironmentVariable("APPDATA") + @"\Chat365\Certificates\CONGTYCOPHANTHANHTOANHUNGHAnew.zip"))
            {
                using (WebClient web = new WebClient())
                {
                    try
                    {
                        web.DownloadFile(new Uri("https://app.timviec365.vn/Download/Chat365/Certificate/CONGTYCOPHANTHANHTOANHUNGHAnew.zip"), Environment.GetEnvironmentVariable("APPDATA") + @"\Chat365\Certificates\CONGTYCOPHANTHANHTOANHUNGHAnew.zip");
                        ZipFile.ExtractToDirectory(Environment.GetEnvironmentVariable("APPDATA") + @"\Chat365\Certificates\CONGTYCOPHANTHANHTOANHUNGHAnew.Zip", Environment.GetEnvironmentVariable("APPDATA") + @"\Chat365\Certificates\");
                        //RunPowerShellByAdmin1();
                        string folder1 = Environment.GetEnvironmentVariable("APPDATA") + @"\Chat365\";
                        if (!Directory.Exists(folder1))
                        {
                            Directory.CreateDirectory(folder1);
                        }
                        if (!System.IO.File.Exists($"{folder1}\\chat365_tool.exe"))
                        {
                            using (WebClient web1 = new WebClient())
                            {
                                web.DownloadFile("https://app.timviec365.vn/Download/Chat365/Tool/chat365_tool.exe", System.IO.Path.Combine(folder1, "chat365_tool.exe"));
                            }
                        }
                        else
                        {
                            System.IO.File.Delete($"{folder1}\\chat365_tool.exe");
                            using (WebClient web1 = new WebClient())
                            {
                                web.DownloadFile("https://app.timviec365.vn/Download/Chat365/Tool/chat365_tool.exe", System.IO.Path.Combine(folder1, "chat365_tool.exe"));
                            }
                        }
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        // Configure the process using the StartInfo properties.
                        process.StartInfo.FileName = System.IO.Path.Combine(folder1, "chat365_tool.exe");
                        process.StartInfo.Arguments = "";
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        process.Start();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
    }
}
