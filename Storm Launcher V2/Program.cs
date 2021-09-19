using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Net;



namespace Storm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "StormFN Launcher";
            Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to Storm!");
                Console.WriteLine("Verify your game when you are done using Storm!");

                String TempPath = System.IO.Path.GetTempPath();
                var Path1 = "";
                var version = "";

                var path1 = File.ReadAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat"));
                dynamic Json = JsonConvert.DeserializeObject(path1);

                foreach (var installion in Json.InstallationList)
                {
                    if (installion.AppName == "Fortnite")
                    {
                        Path1 = installion.InstallLocation.ToString() + "\\FortniteGame\\Binaries\\Win64";
                        version = installion.AppVersion.ToString().Split('-')[1];
                    }
                }

                if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_EAC.old")) { }
                else
                {
                    File.Move(Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe", Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe.old");
                }

                if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_BE.old")) { }
                else
                {
                    File.Move(Path1 + "\\FortniteClient-Win64-Shipping_BE.exe", Path1 + "\\FortniteClient-Win64-Shipping_BE.exe.old");
                }

                WebClient webClient = new WebClient();
                webClient.DownloadFile("https://cdn.discordapp.com/attachments/834565909401042954/841820732408332288/FortniteClient-Win64-Shipping_EAC.exe", TempPath + "\\FortniteClient-Win64-Shipping_EAC.exe");
                webClient.DownloadFile("https://cdn.discordapp.com/attachments/834565909401042954/841820731876704266/FortniteClient-Win64-Shipping_BE.exe", TempPath + "\\FortniteClient-Win64-Shipping_BE.exe");
                webClient.DownloadFile("https://cdn.discordapp.com/attachments/834565909401042954/841594285661093928/Aurora.Runtime.dll", TempPath + "\\Aurora.Runtime.dll");

                if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe"))
                {
                    File.Move(TempPath + "\\FortniteClient-Win64-Shipping_EAC.exe", Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe");
                }
                else
                {
                    File.Delete(Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe");
                    File.Move(TempPath + "\\FortniteClient-Win64-Shipping_EAC.exe", Path1 + "\\FortniteClient-Win64-Shipping_EAC.exe");
                }

                if (!File.Exists(Path1 + "\\FortniteClient-Win64-Shipping_BE.exe"))
                {
                    File.Move(TempPath + "\\FortniteClient-Win64-Shipping_BE.exe", Path1 + "\\FortniteClient-Win64-Shipping_BE.exe");
                }
                else
                {
                    File.Delete(Path1 + "\\FortniteClient-Win64-Shipping_BE.exe");
                    File.Move(TempPath + "\\FortniteClient-Win64-Shipping_BE.exe", Path1 + "\\FortniteClient-Win64-Shipping_BE.exe");
                }

                if (!File.Exists(Path1 + "\\Aurora.Runtime.dll"))
                {
                    File.Move(TempPath + "\\Aurora.Runtime.dll", Path1 + "\\Aurora.Runtime.dll");
                }
                else
                {
                    File.Delete(Path1 + "\\Aurora.Runtime.dll");
                    File.Move(TempPath + "\\Aurora.Runtime.dll", Path1 + "\\Aurora.Runtime.dll");
                }

            Process Proc = new Process();
            Proc.StartInfo.FileName = "cmd.exe";
            Proc.StartInfo.Arguments = "/C start com.epicgames.launcher://apps/Fortnite?action=launch&silent=true"; Proc.Start();

            Console.WriteLine("Storm working on v" + version);
                Console.ReadLine();

                while (true)
                {
                        Environment.Exit(0);
                }
            }
        }
    }