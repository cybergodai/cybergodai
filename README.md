# 🌟 CyberGod — Secure Browser Sandbox (Docker + Web VNC)

## ✅ Update (09/01/2026) — Architecture Simplified (KISS)
This project was updated on 09/01/2026 to make the setup super KISS (Keep It Simple, Stupid).

### What changed?
We removed the old architecture:
- ❌ C# installer for Windows Subsystem for Linux (WSL)
- ❌ Ubuntu 24.04 inside WSL
- ❌ Linux Containers (LXC)
- ❌ X11 installation on Windows (VcXsrv, XLaunch, etc.)

We replaced everything with:
- ✅ Docker + Docker Compose
- ✅ One container that runs:
  - X virtual display (Xvfb)
  - Window manager (Openbox)
  - VNC server (x11vnc)
  - Web VNC (noVNC) — access via browser
  - Google Chrome
- ✅ You open Chrome using a web page (no Windows X11 needed)

Result: Clone repo → docker compose up → open browser → Chrome is there.

---

## 🧠 What is CyberGod?
CyberGod provides a safe, isolated Chrome browser running inside a Docker container.

Why?
- Browsing is risky.
- This sandbox isolates Chrome from your Windows host.
- If a website is malicious, the damage stays inside the container.

---

## 🧱 New Architecture (KISS)
Windows PC
- runs Docker Desktop

Docker Container
- runs Chrome inside a virtual display
- shares it via noVNC Web UI

You access it at:
- `http://localhost:9090/vnc_auto.html`
Video manual on how it suppose to work: https://app.screencastify.com/watch/X1XtFBB5r6SP4kvM0xIM?checkOrg=b7e279de-d85e-4c64-9bff-adbce5c43088
---

## ✅ Requirements (Windows 10 / 11)
You only need:

1. Docker Desktop for Windows
   - Install Docker Desktop
   - Enable WSL2 backend when Docker asks (default recommended)
2. Git (optional, but recommended)
3. A browser (Chrome/Edge)

That’s it.

---

## 🚀 Install & Run (Step-by-step for a 9-year-old)

### Step 1 — Install Docker Desktop
1. Download and install Docker Desktop
2. Reboot if it asks
3. Open Docker Desktop
4. Make sure bottom-left says: Engine running

✅ Done.

---

### Step 2 — Get the project
#### Option A (recommended): Clone with Git
Open PowerShell and run:

```powershell
cd "C:\Docker SW"
git clone https://github.com/cybergodai/cybergodai.git
cd cybergodai
````

#### Option B: Download ZIP

1. Click “Code” → “Download ZIP”
2. Unzip it
3. Open the folder

---

### Step 3 — Start the container

From the project folder, run:

```powershell
docker compose up -d --build
```

What this does:

* builds the Docker image
* starts the container in background

✅ Done.

---

### Step 4 — Open the browser UI

Open this in your browser:

👉 [http://localhost:9090/vnc_auto.html](http://localhost:9090/vnc_auto.html)

You should see a desktop + Chrome running.

Video Manual how its suppose to work: https://app.screencastify.com/watch/X1XtFBB5r6SP4kvM0xIM?checkOrg=b7e279de-d85e-4c64-9bff-adbce5c43088 
---

## 🛑 Stop / Start / Reset (KISS commands)

### Stop the container

```powershell
docker compose down
```

### Start again

```powershell
docker compose up -d
```

### Rebuild (if you changed Dockerfile or scripts)

```powershell
docker compose up -d --build
```

### Full reset (nuclear option)

This deletes container + rebuilds everything:

```powershell
docker compose down
docker compose up -d --build
```

---

## 🔍 Quick Troubleshooting (only the useful stuff)

### Problem: “This site can’t be reached” on localhost:9090

Do this:

1. Check container is running:

```powershell
docker ps
```

You must see something like:

* `chrome-vnc` running
* ports mapped to 9090

2. Check logs:

```powershell
docker logs -f chrome-vnc
```

3. Rebuild (most common fix):

```powershell
docker compose up -d --build
```

---

### Problem: Port 9090 already used

Change port in `docker-compose.yml` (example):

```yaml
ports:
  - "9091:9090"
```

Then use:

* `http://localhost:9091/vnc_auto.html`

---

### Problem: Container name conflict “chrome-vnc already exists”

Remove old container:

```powershell
docker rm -f chrome-vnc
docker compose up -d
```

---

## 📁 Repo Files (What is what)

* `docker-compose.yml` — how the container runs (ports, volumes)
* `Dockerfile` — how the image is built (Chrome + VNC stack)
* `run-chrome.sh` — startup script (waits for display, launches Chrome)
* `supervisord.conf` — starts processes (Xvfb, Openbox, VNC, noVNC, Chrome)
* `chrome-data/` — local persistent Chrome profile data (ignored by git)

---

## 🔐 Security Notes (Important)

* Chrome is isolated in a container, but still runs with `--no-sandbox` in most container setups.
* This is normal for Dockerized Chrome and is a common tradeoff.
* Treat this as a “safe browsing workspace” but not a military-grade isolation layer.

---

## 🤝 Contributing

1. Fork repo
2. Create branch

```bash
git checkout -b feature-name
```

3. Commit & push
4. Open Pull Request

---

## ⚠️ Pre-Release Notice

This software is provided “as-is.” Use it at your own risk.

---

## 📬 Need Help?

Open an issue in GitHub with:

* your OS (Windows 10/11)
* Docker Desktop version
* output of:

  * `docker ps`
  * `docker logs chrome-vnc --tail 200`

```
If you have any issues please contact me via https://www.itzen.ai/

```

OLD C# and Python Manual from 09/2023: # 🌟 CyberGod: Revolutionizing Endpoint Security

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

