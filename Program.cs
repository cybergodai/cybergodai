using System;
using System.Diagnostics;

public class Installer
{
    public void InstallChocolatey()
    {
        try
        {
            Console.WriteLine("Starting Chocolatey installation...");
            ShowProgress("Installing Chocolatey...", 0);
            RunCommand("powershell -Command \"Set-ExecutionPolicy RemoteSigned -Scope CurrentUser\"");
            ShowProgress("Setting execution policy...", 25);
            RunCommand("powershell -Command \"iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))\"");
            ShowProgress("Installing Chocolatey...", 50);
            ShowProgress("Chocolatey installation completed.", 100);
            Console.WriteLine("Chocolatey installed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error installing Chocolatey: {ex.Message}");
        }
    }

    public void InstallWSL()
{
    try
    {
        Console.WriteLine("Starting WSL2 installation...");
        ShowProgress("Installing WSL2...", 0);

        // Ensure WSL and Virtual Machine Platform features are enabled
        RunCommand("powershell -Command \"dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all\"");
        ShowProgress("Enabling WSL feature...", 25);

        RunCommand("powershell -Command \"dism.exe /online /enable-feature /featurename:VirtualMachinePlatform /all\"");
        ShowProgress("Enabling Virtual Machine Platform...", 50);

        // Install WSL feature with admin rights
        RunCommand("powershell -Command \"wsl --install --no-launch --quiet\"");
        ShowProgress("Installing WSL feature...", 60);

        // Set WSL2 as default version with admin rights
        RunCommand("powershell -Command \"wsl --set-default-version 2\"");
        ShowProgress("Setting WSL2 as default version...", 80);

        // Install Ubuntu 24.04 (if needed) in non-interactive mode with admin rights
        RunCommand("powershell -Command \"wsl --install -d Ubuntu-24.04 --quiet\"");
        ShowProgress("Installing Ubuntu 24.04...", 90);

        // Final progress update
        ShowProgress("WSL2 installation completed.", 100);
        Console.WriteLine("WSL2 installed successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error installing WSL2: {ex.Message}");
    }
}
public class WSLInstaller
{
    public void InstallUbuntu()
    {
        try
        {
            Console.WriteLine("Checking if Ubuntu 24.04 is installed...");
            ShowProgress("Checking for Ubuntu 24.04...", 0);

            // Check if Ubuntu is already installed
            string installedDistros = RunCommand("wsl --list --verbose");
            if (!installedDistros.Contains("Ubuntu-24.04"))
            {
                // If not installed, install Ubuntu 24.04
                Console.WriteLine("Ubuntu 24.04 is not installed. Installing...");
                ShowProgress("Installing Ubuntu 24.04...", 25);
                
                // Run the WSL install command for Ubuntu 24.04
                RunCommand("wsl --install -d Ubuntu-24.04");
                ShowProgress("Ubuntu 24.04 installation in progress...", 75);

                // Optionally set Ubuntu 24.04 as the default WSL distro
                RunCommand("wsl --set-default Ubuntu-24.04");
                ShowProgress("Setting Ubuntu 24.04 as default...", 100);

                Console.WriteLine("Ubuntu 24.04 installed and set as default distribution!");
            }
            else
            {
                Console.WriteLine("Ubuntu 24.04 is already installed.");
                ShowProgress("Ubuntu 24.04 already installed.", 100);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error installing Ubuntu 24.04: {ex.Message}");
        }
    }
public void InstallLXC()
{
    try
    {
        Console.WriteLine("Starting LXC installation...");
        ShowProgress("Installing LXC...", 0);

        // Install LXC in Ubuntu 24.04
        RunCommand("wsl sudo apt update");
        ShowProgress("Updating package lists...", 25);

        RunCommand("wsl sudo apt install -y lxc lxd");
        ShowProgress("Installing LXC and LXD...", 50);

        // Initialize LXC
        RunCommand("wsl sudo lxd init --auto");
        ShowProgress("Initializing LXC...", 75);

        ShowProgress("LXC installation completed.", 100);
        Console.WriteLine("LXC installed successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error installing LXC: {ex.Message}");
    }
}

    private string RunCommand(string command)
    {
        try
        {
            // Start a new process with elevated (administrator) rights
            var processStartInfo = new ProcessStartInfo("cmd.exe")
            {
                Arguments = "/C " + command,  // Use /C to run the command and then close cmd.exe
                Verb = "runas", // This will prompt for Administrator privileges
                UseShellExecute = true, // Required for 'runas' to work
                RedirectStandardOutput = true,
                CreateNoWindow = true // Don't create a window
            };

            using (var process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
                // Return the output of the command (if needed for debugging)
                return process.StandardOutput.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error running command: {ex.Message}");
            return string.Empty;
        }
    }

    private void ShowProgress(string taskDescription, int progress)
    {
        Console.Clear();
        Console.WriteLine(taskDescription);
        Console.WriteLine($"Progress: {progress}%");
        Console.Write("[");
        int barLength = 50;
        int progressBar = (int)((double)progress / 100 * barLength);
        Console.Write(new string('#', progressBar));
        Console.Write(new string('-', barLength - progressBar));
        Console.Write("]");
    }
}

    private void RunCommand(string command)
    {
        try
        {
            // Start a new process with elevated (administrator) rights
            var processStartInfo = new ProcessStartInfo("cmd.exe")
            {
                Arguments = "/C " + command,  // Command to run
                Verb = "runas", // This will prompt for Administrator privileges
                UseShellExecute = true, // Required for 'runas' to work
                RedirectStandardOutput = false,
                CreateNoWindow = true // Don't create a window
            };

            // Start the process and wait for it to finish
            using (var process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error running command: {ex.Message}");
        }
    }

    private void ShowProgress(string taskDescription, int progress)
    {
        Console.Clear();
        Console.WriteLine(taskDescription);
        Console.WriteLine($"Progress: {progress}%");
        Console.Write("[");
        int barLength = 50;
        int progressBar = (int)((double)progress / 100 * barLength);
        Console.Write(new string('#', progressBar));
        Console.Write(new string('-', barLength - progressBar));
        Console.Write("]");
        System.Threading.Thread.Sleep(500); // Simulate work being done with a brief delay
    }
}

class Program
{
    static void Main(string[] args)
    {
        Installer installer = new Installer();

        // First, install Chocolatey
        installer.InstallChocolatey();

        // Second, install WSL2
        installer.InstallWSL();
    }
}
