# 🌟 CyberGod: Revolutionizing Endpoint Security

**CyberGod** is an open-source project designed to transform endpoint security through advanced virtualization technologies. With a modular architecture combining C# and Python, CyberGod provides a robust foundation for modern cybersecurity. 🔒✨

---

## 👀 Overview

CyberGod includes two main components:

1. **🖥️ C# Script**: Automates Windows Subsystem for Linux (WSL2) and Ubuntu 24.04 setup on Windows.
2. **🐍 Python Script**: Configures Linux Containers (LXC) for secure browsing with Google Chrome.

> **Note:** Pre-install VcXsrv X Server ([Download](https://vcxsrv.com/wp-content/uploads/2024/09/vcxsrv-64.1.17.2.0.installer.zip)):
> - Launch `Xlaunch`: Select **Multiple windows > Start No Client > Disable access control > Finish**.
> - Confirm X server is running in the Windows system tray.

---

## 🛠️ Prerequisites

### 🖥️ System Requirements
- **OS**: Windows 10/11
- **Hardware**: PC, laptop, server, or VM capable of running WSL and Ubuntu

### 📦 Software Requirements
- **Code Editor**: VS Code, JetBrains Rider, or Notepad++
- **.NET SDK**: Download from [Microsoft](https://dotnet.microsoft.com/download)
- **Python 3**: Pre-installed in WSL Ubuntu environment

### ⚙️ Editor Plugins (for C#)
- **VS Code**: Install "C# for Visual Studio Code" extension
- Configure the editor for .NET Core projects.

---

## Step 1: 🚀 Setting Up with C#

### 🤔 What It Does
The C# script automates:
- Installing Chocolatey (Windows package manager).
- Configuring WSL2 and installing Ubuntu 24.04.
- Preparing the system for Python-based configurations.

### 🔎 Steps to Run

#### 1️⃣ Install .NET SDK
   - Install the .NET SDK and verify:
     ```bash
     dotnet --version
     ```
     Example output:
     ```
     9.0.100
     ```

#### 2️⃣ Prepare the Project
   - Open PowerShell as **Administrator**.
   - Create a new directory for the project and navigate to it:
     ```bash
     mkdir cybergod && cd cybergod
     dotnet new console --force
     ```
   - Replace the default `Program.cs` with the provided CyberGod `Program.cs` file.

#### 3️⃣ Run the Script
   ```bash
   dotnet run
   ```

#### 4️⃣ Follow Installation Prompts
   - Install Chocolatey.
   - Enable WSL2.
   - Install Ubuntu 24.04.
   - After completion:
     - Launch **Ubuntu 24.04** from the Start menu.
     - Create a **sudo user** and password during initial setup.
     - Use `ipconfig /all` in CMD to find the WSL IP (e.g., `172.24.16.x`).

---

## Step 2: 🔒 Configuring with Python

### 🤔 What It Does
The Python script:
- Configures LXC within Ubuntu.
- Sets up a secure Chrome browser container with X11 forwarding.

### 🔎 Steps to Run

#### 1️⃣ Edit the Script
   - Update `install_lxc_chrome_x12.py` with your WSL IP address:
     - Lines 80, 85, and 117 should reflect your IP (e.g., `172.24.16.1`).

#### 2️⃣ Run the Script
   - Save `install_lxc_chrome_x12.py` in a shared directory accessible by WSL.
   - In WSL, navigate to the directory:
     ```bash
     cd /mnt/c/Users/<YourUsername>/Documents/tests
     python3 install_lxc_chrome_x12.py
     ```

#### 3️⃣ Monitor Output
   - Install LXC and dependencies.
   - Configure containers and install Google Chrome.
   - Verify Chrome’s functionality with X11.

---

## ❌ Uninstallation

### 🗑️ 1. Remove LXC Container
Run the Python uninstallation script:
```bash
sudo python3 stop_delete_container.py
```

### 🗑️ 2. Remove Ubuntu and WSL
Run the C# uninstallation script:
1. Create a new directory for the project and navigate to it:
   ```bash
   mkdir cybergod_uninstall && cd cybergod_uninstall
   dotnet new console --force
   ```
2. Replace `Program.cs` with `uninstall.cs`.
3. Run the script:
   ```bash
   dotnet run
   ```
4. Verify:
   ```bash
   dism.exe /online /get-featureinfo /featurename:Microsoft-Windows-Subsystem-Linux
   dism.exe /online /get-featureinfo /featurename:VirtualMachinePlatform
   wsl --list --all
   ```
   Expected output should show `State : Disabled` and no installed distributions.

---

## 🧩 Supported Platforms

- **Windows 10/11**: Preferred for WSL2.
- **Ubuntu 24.04**: Base environment for Linux Containers.
- **Virtualization**: VMware, Hyper-V.
- **Cloud**: AWS, Azure, GCP.

---

## 🌍 Vision

CyberGod aims to:
- 🤖 Incorporate AI-driven threat detection.
- 📡 Expand support to IoT devices.
- 📜 Ensure compliance with frameworks like DORA, NIS2, and CRA.
- 🛡️ Develop advanced attack simulations using digital twins.

---

## 🤝 Contribution Guidelines

We welcome contributions:

1. Fork the repository.
2. Create a branch for your changes:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Description of changes"
   ```
4. Push and create a pull request.

---

## 📬 Contact

- **Telegram**: [Join Us](https://t.me/+WttALifnSAtjYTMy)
- **Discord**: Developers Only [Join](https://discord.gg/DscPJNkQ)

---

## ⚠️ Pre-Release Software Notice

CyberGod is a pre-release project. Use at your own risk:
- **Responsibility**: Users are responsible for their installations.
- **Open Source**: Provided "as-is" with no warranties.
- **Support**: Community-driven, best-effort basis.

---

Join us in building a safer digital future! 🌟

