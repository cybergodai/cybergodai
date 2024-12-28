# 🌟 CyberGod: Revolutionizing Endpoint Security

Welcome to CyberGod! This project will guide you step-by-step to set up a **secure browsing environment** on your Windows 10 or 11 computer using **Linux Containers (LXC)** and **Google Chrome**. Don’t worry if you’ve never worked with Linux before—we’ve got you covered! 🛡️

---

## What is CyberGod?

CyberGod is a project that uses advanced tools to keep your computer safe. Here’s how it works:

1. **🖥️ C# Script**: This script installs a Linux system (Ubuntu 24.04) on your Windows computer. Why? Because Linux is great for security and runs alongside Windows without any issues.
2. **🐍 Python Script**: This script creates a safe "container" for browsing the web using Google Chrome. Containers isolate risky activities, keeping your computer safe.

By the end of this guide, you’ll have a secure setup ready to handle potential threats safely. Let’s get started! 🚀

---

## 🛠️ What You’ll Need

### 1️⃣ Your Computer

- **Operating System**: Windows 10 or 11.
- **Hardware**: Any PC or laptop that runs Windows smoothly.

### 2️⃣ Software to Install

1. **Code Editor**: This is a tool to edit files. We recommend:
   - [Visual Studio Code (VS Code)](https://code.visualstudio.com/).
2. **.NET SDK**: This is required to run the C# script. [Download it here](https://dotnet.microsoft.com/download).
3. **VcXsrv X Server**: This software makes Linux apps appear on Windows. [Download it here](https://vcxsrv.com/wp-content/uploads/2024/09/vcxsrv-64.1.17.2.0.installer.zip).
   VcXsrv X Server Configuration on Windows 10/11
To use Linux graphical applications (like Google Chrome) on your Windows system, you need to configure VcXsrv X Server. Follow these steps:

Step 1: Install VcXsrv X Server
Download VcXsrv X Server:

Visit the VcXsrv download page.
Save the installer file to your computer (e.g., in your Downloads folder).
Install VcXsrv:

Locate the downloaded file and double-click to start the installation.
Follow the prompts (click "Next" for all options and ensure the installation completes successfully).
Step 2: Launch and Configure VcXsrv
Start VcXsrv:

Go to the Start menu.
Type Xlaunch in the search bar and press Enter.
Set Up VcXsrv:

In the Xlaunch configuration window, select:
Multiple Windows: This allows Linux apps to open as separate windows on Windows.
Click Next.
Choose:
Start No Client: This setting is essential for running apps from Linux containers.
Click Next.
In the next window:
Disable Access Control: This allows your Linux apps to connect to VcXsrv.
Click Finish.

### 3️⃣ Time

- About 30–40 minutes to follow the steps carefully.

---

## Step 1: Install the Linux Environment on Windows (C# Script)

### 🔍 Why Are We Doing This?

Linux is excellent for running secure applications. Windows lets you install Linux using **Windows Subsystem for Linux (WSL)**. The C# script automates this process, so you don’t have to do it manually.

### 📋 Step-by-Step Guide

#### 1️⃣ Install .NET SDK

1. Open your browser and [download .NET SDK](https://dotnet.microsoft.com/download).
2. Follow the installation prompts (click “Next” until it’s done).
3. Verify it’s installed correctly:
   - Right-click the **Start** button and choose **Windows PowerShell (Admin)**.
     - **How to do this**: 
       - Move your mouse to the bottom-left corner of the screen.
       - Right-click the Windows logo (start button).
       - From the list, click **Windows PowerShell (Admin)**. 
   - Type the following command:
     ```bash
     dotnet --version
     ```
   - You should see something like `9.0.100`. If you do, everything is set up correctly! 🎉

#### 2️⃣ Create Your Project Folder

1. Open **PowerShell (Admin)** again (use the steps from above).
2. Type the following commands to create a folder and navigate into it:
   ```bash
   mkdir cybergod
   ```
   - **What this does**: Creates a new folder called `cybergod` in your current location. You can think of a folder like a box to store related items.
   - Press **Enter**.
   ```bash
   cd cybergod
   ```
   - **What this does**: Enters the folder you just created so that any future actions happen inside it.
   - Press **Enter**.
3. Create a new C# project by typing:
   ```bash
   dotnet new console --force
   ```
   - **What this does**: Creates a new console app (like a command-line program) in the folder you just made.
   - Press **Enter**.
4. Replace the default `Program.cs` file:
   - Delete the existing `Program.cs` file in the folder.
   - Download the CyberGod `Program.cs` file from this repository and place it in the same folder.

#### 3️⃣ Run the C# Script

1. Navigate to the folder where your `Program.cs` is located. If you’re still in PowerShell, simply type:
   ```bash
   cd C:\cybergod
   ```
2. Run the script by typing:
   ```bash
   dotnet run
   ```
3. Follow the instructions on your screen. The script will:
   - Install **Chocolatey** (a Windows package manager).
   - Enable **Windows Subsystem for Linux (WSL2)**.
   - Download and set up **Ubuntu 24.04**.

#### 4️⃣ Set Up Ubuntu 24.04

1. Once the script finishes, open **Ubuntu 24.04** from your Start menu:
   - **How to do this**: Click the Start button in the bottom-left corner of your screen. Type `Ubuntu` in the search bar and click the Ubuntu 24.04 app when it appears.
2. Follow the prompts to:
   - Create a **username** (this will be your Linux login).
   - Create a **password** (you’ll need this often, so write it down).
3. Find your WSL IP address:
   - Open **Command Prompt** (search for `cmd` in the Start menu).
   - Type the following command:
     ```bash
     ipconfig /all
     ```
   - Look for **vEthernet (WSL)** and write down the IP address (e.g., `172.24.16.x`). This IP connects your Linux system with Windows.

---

## Step 2: Set Up a Secure Browser (Python Script)

### 🔍 Why Are We Doing This?

Browsing the internet can expose your computer to risks. Using a secure container (LXC) to run Chrome keeps your computer safe by isolating risky tasks.

### 📋 Step-by-Step Guide

#### 1️⃣ Prepare the Python Script

1. Download the `install_lxc_chrome_x12.py` file and save it in a shared folder, such as `Documents/tests`. **How to create a shared folder**:
   - Open File Explorer (press `Windows + E`).
   - Navigate to `Documents`.
   - Right-click an empty area and select **New > Folder**. Name it `tests`.
2. Open the file in a code editor (e.g., VS Code).
3. Update the script with your WSL IP:
   - Replace `172.24.16.1` on **lines 80, 85, and 117** with your actual WSL IP address.

#### 2️⃣ Run the Python Script in Ubuntu

1. Open **Ubuntu 24.04** (from the Start menu).
2. Navigate to the folder where you saved the script:
   ```bash
   cd /mnt/c/Users/<YourUsername>/Documents/tests
   ```
   - **What this does**: Moves to the `tests` folder in your Windows `Documents` directory.
   - Replace `<YourUsername>` with the actual name of your Windows user.
3. Run the script by typing:
   ```bash
   python3 install_lxc_chrome_x12.py
   ```
4. Watch the script do its job:
   - It will install tools like **LXC**.
   - Create a container for Chrome.
   - Set up **X11** so you can see the browser on Windows.

#### 3️⃣ Use Google Chrome

- Once the installation completes, open **VcXsrv X Server** and Chrome will launch automatically in a secure window. You can use it for Gmail, online SaaS tools, CRMs, or any browsing task! **Note**: Local file saving is disabled for now—please save all files to online storage.

---

## 🗑️ Uninstallation (Optional)

### 1️⃣ Remove the LXC Container

1. Open **Ubuntu 24.04**.
2. Run the following command to stop and delete the container:
   ```bash
   sudo python3 stop_delete_container.py
   ```

### 2️⃣ Remove Ubuntu and WSL

1. Create a folder for the uninstallation script:
   ```bash
   mkdir cybergod_uninstall
   cd cybergod_uninstall
   dotnet new console --force
   ```
2. Replace the default `Program.cs` file with the `uninstall.cs` file.
3. Run the script:
   ```bash
   dotnet run
   ```
4. Verify that WSL is uninstalled:
   ```bash
   dism.exe /online /get-featureinfo /featurename:Microsoft-Windows-Subsystem-Linux
   ```
   Look for `State : Disabled`.

---

## 🔗 Supported Platforms

- **Windows 10/11**: Preferred for WSL2.
- **Ubuntu 24.04**: Base environment for Linux Containers.
- **Cloud**: Works on AWS, Azure, and GCP.

---

## 🌍 Vision

CyberGod aims to:

- 🤖 Add AI-powered threat detection.
- 📡 Expand to IoT devices.
- 📜 Comply with global security standards like DORA and CRA.

---

## 🤝 Want to Contribute?

1. Fork the repository.
2. Create a branch:
   ```bash
   git checkout -b feature-name
   ```
3. Make your changes and commit:
   ```bash
   git commit -m "Your description here"
   ```
4. Push and submit a pull request.

---

## 📬 Need Help?

- **Telegram**: [Join Us](https://t.me/+WttALifnSAtjYTMy)
- **Discord**: [Developers Only](https://discord.gg/DscPJNkQ)

---

## ⚠️ Pre-Release Notice

This software is provided “as-is.” Use it at your own risk. We’re here to help, but bugs happen. 🐞

---

Let’s build a safer digital future together! 🌟

