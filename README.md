 CyberGod Project 

CyberGod is an open-source project designed to revolutionize endpoint security by leveraging advanced virtualization technologies. By integrating a C# component for automated system setup and a Python component for containerized secure browsing, CyberGod provides a robust, scalable foundation for modern cybersecurity needs.

Overview

The CyberGod project includes two main components:
1. A C# script (`Program.cs`) for setting up Windows Subsystem for Linux (WSL2) and Ubuntu 24.04 on Windows.
2. A Python script (`install_lxc_chrome_x12.py`) for configuring Linux Containers (LXC) and securing applications like Google Chrome.
3. Nonice its important to preinstall in Win10/11 PC VcXsrv X Server Release: 1.17.2.0 https://vcxsrv.com/wp-content/uploads/2024/09/vcxsrv-64.1.17.2.0.installer.zip. After install go to Start-find Xlaunch->Multiple windows->Start No Client->Disable access control->Finish. Make sure in running apps in Windows on lower right corner you have X server. - Later this will be incorporated in C# installer

These components work together to establish a secure environment for endpoint protection, utilizing virtualization and containerization to isolate potential threats.

Prerequisites

Before using the CyberGod project, ensure the following requirements are met:

System Requirements
- Operating System: Windows 10 or Windows 11.
- Hardware: A PC, laptop, server, or virtual machine with sufficient resources to run WSL and Ubuntu.

Software Requirements
- Code Editor (choose one):
  - [Visual Studio Code (VS Code)](https://code.visualstudio.com/)
  - [JetBrains Rider](https://www.jetbrains.com/rider/)
  - [Notepad++](https://notepad-plus-plus.org/)
- .NET SDK: Download and install the latest version from [Microsoft](https://dotnet.microsoft.com/download).
- Python 3: Available within the Ubuntu environment in WSL.

Editor Plugins for C#
- For VS Code, install the "C# for Visual Studio Code" extension.
- Configure your editor to recognize and work with .NET Core projects.

Step 1: Setting Up with C# (`Program.cs`)

What It Does
The C# script automates the following tasks:
1. Installs Chocolatey, a package manager for Windows.
2. Enables and configures Windows Subsystem for Linux (WSL2).
3. Installs Ubuntu 24.04 inside WSL for a virtualized Linux environment.
4. Tracks progress and provides updates for each installation step.
5. Prepares the system for running additional configurations using the Python component.

Steps to Run

Install .NET SDK
1. Download and install the .NET SDK from [Microsoft’s official site](https://dotnet.microsoft.com/download).

Open the Script
1. Open the `Program.cs` file in your preferred code editor (e.g., VS Code).

Run the Script
1. Open a terminal or command prompt.
2. Navigate to the directory containing `Program.cs`:
   ```bash
   cd path/to/Program.cs
   ```
3. Run the program:
   ```bash
   dotnet run Program.cs
   ```

Follow Installation Steps
1. The script will prompt and guide you through:
   - Installing Chocolatey.
   - Enabling WSL2.
   - Installing Ubuntu 24.04.
2. Monitor the progress and ensure no errors occur.

Outcome: Upon completion, WSL2 and Ubuntu 24.04 will be installed and ready for further configurations.

---

Step 2: Configuring with Python (`install_lxc_chrome_x12.py`)

What It Does
The Python script performs the following:
1. Sets up Linux Containers (LXC) within the Ubuntu environment.
2. Configures an isolated container for secure browsing with Google Chrome.
3. Sets up X11 forwarding to enable graphical applications.
4. Installs Google Chrome in the container.
5. Verifies and tests Chrome’s functionality in a secure, sandboxed environment.

Steps to Run

Transfer the Python Script
1. Save `install_lxc_chrome_x12.py` to a shared directory accessible by both Windows and Ubuntu WSL, such as `C:\Users\<YourUsername>\SharedWSL`.

Access the Script in WSL
1. Open the WSL terminal and navigate to the shared directory:
   ```bash
   cd /mnt/c/Users/<YourUsername>/SharedWSL
   ```

Ensure Python 3 is Installed
1. Update package lists and install Python 3 if not already installed:
   ```bash
   sudo apt update && sudo apt install -y python3
   ```

Run the Script
1. Execute the Python script:
   ```bash
   python3 install_lxc_chrome_x12.py
   ```

Monitor Installation
1. Follow the script’s output to:
   - Install LXC and its dependencies.
   - Configure and launch the container.
   - Install Google Chrome inside the container.
   - Set up X11 for graphical interface support.
2. Test the setup to ensure Chrome runs securely in the container.

Outcome: The system will have a secure, sandboxed environment ready for isolated application execution.

Supported Platforms

- Preferred Platform: Windows 10 and 11 using WSL2 for seamless virtualization.
- Native Windows 10 and 11: Compatible with PCs, laptops, servers, and virtual machines, including Desktop as a Service (DaaS) environments.
- Ubuntu 24.04: As the base environment for Linux Containers.
- Virtualization Platforms: VMware, Hyper-V.
- Cloud Platforms: AWS, Azure, GCP.

Vision

CyberGod aims to be a comprehensive cybersecurity framework. Future plans include:
- AI-driven threat detection and remediation.
- Support for additional operating systems and IoT devices.
- Compliance with regulatory frameworks like DORA, NIS2, and CRA.
- Advanced attack simulations using digital twins.

Contribution Guidelines

We welcome contributions to expand and improve the CyberGod project. To contribute:
1. Fork the repository.
2. Create a new branch for your feature or bug fix:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes with clear messages:
   ```bash
   git commit -m "Description of changes"
   ```
4. Push your changes to your fork and create a pull request.

Contact

For inquiries, support, or collaboration opportunities:
- Telegram for all users: https://t.me/+WttALifnSAtjYTMy
- Discord DEVELOPERS & CONTRIBUTORS ONLY: https://discord.gg/DscPJNkQ 

CyberGod is a community-driven initiative, aiming to revolutionize endpoint security. Join us in building a safer digital future!
Pre-Release Software Notice

This software is provided as a pre-release version and is intended for testing and evaluation purposes only. By downloading, installing, or using this software, you acknowledge and agree to the following:

Responsibility: The installation, testing, and usage of this software are solely at your own risk. The developers and contributors are not responsible for any issues, damages, or losses arising from its use.

Open Source: This software is open source and provided "as-is" under its applicable open source license. There are no warranties, express or implied, including but not limited to merchantability or fitness for a particular purpose.

Support: All support for this software is provided on a best-effort basis by the community and contributors. There are no guarantees of response times or resolution of issues.

Feedback: Users are encouraged to provide feedback, report bugs, and suggest improvements to help enhance the software. Please use the designated channels (e.g., issue trackers, forums) for submitting feedback.

