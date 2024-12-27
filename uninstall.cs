using System;
using System.Diagnostics;
using System.Security.Principal;

namespace UninstallWSL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Check for Administrative Rights
            if (!IsRunningAsAdministrator())
            {
                Console.WriteLine("This application needs to be run as an administrator. Restarting with elevated privileges...");
                RestartAsAdministrator();
                return;
            }

            try
            {
                // Step 2: Unregister the WSL distribution
                Console.WriteLine("Unregistering Ubuntu-24.04...");
                RunCommand("wsl", "--unregister Ubuntu-24.04");

                // Step 3: Disable WSL features
                Console.WriteLine("Disabling WSL features...");
                RunCommand("dism.exe", "/online /disable-feature /featurename:VirtualMachinePlatform /norestart");
                RunCommand("dism.exe", "/online /disable-feature /featurename:Microsoft-Windows-Subsystem-Linux /norestart");

                // Final Message
                Console.WriteLine("WSL and Ubuntu-24.04 have been successfully uninstalled. Please restart your computer.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Helper function to check if the application is running as an administrator
        static bool IsRunningAsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        // Helper function to restart the application with administrative privileges
        static void RestartAsAdministrator()
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = Process.GetCurrentProcess().MainModule.FileName,
                UseShellExecute = true,
                Verb = "runas" // 'runas' triggers the UAC prompt for elevation
            };

            try
            {
                Process.Start(processInfo);
            }
            catch (Exception)
            {
                Console.WriteLine("The application could not be started with administrative privileges.");
            }
        }

        // Helper function to run a command and capture output
        static void RunCommand(string fileName, string arguments)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (!string.IsNullOrWhiteSpace(error))
            {
                throw new Exception(error);
            }

            Console.WriteLine(output);
        }
    }
}
