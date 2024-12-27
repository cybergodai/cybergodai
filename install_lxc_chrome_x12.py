import subprocess
import sys
import getpass
import os

def run_command(command, capture_output=False, use_sudo=False, inside_container=False, timeout=None):
    """
    Helper function to run a command and handle errors.
    Executes commands locally or inside the LXC container with optional sudo support.

    :param command: Command to execute.
    :param capture_output: Capture command output if True.
    :param use_sudo: Prepend sudo to the command if True.
    :param inside_container: Run the command inside the LXC container if True.
    :param timeout: Time in seconds to wait for the command to complete.
    :return: Command output if capture_output is True.
    """
    try:
        if use_sudo:
            password = getpass.getpass("Enter your sudo password: ")  # Prompt user for password securely
            command = f"echo {password} | sudo -S {command}"  # Automatically provide sudo password for non-LXC commands

        if inside_container:
            command = f"sudo lxc exec my-container -- /bin/bash -c \"{command}\""

        print(f"Running command: {command}")
        result = subprocess.run(command, shell=True, text=True, capture_output=capture_output, timeout=timeout)
        if result.returncode != 0:
            print(f"Error: {result.stderr}")
            sys.exit(1)
        if capture_output:
            return result.stdout
        return result
    except subprocess.TimeoutExpired:
        print(f"Command timed out: {command}")
        return None
    except Exception as e:
        print(f"Error running command {command}: {e}")
        sys.exit(1)

def install_and_update_ubuntu():
    """
    Install and update packages on the Ubuntu host.
    Updates the system and installs necessary tools.
    """
    run_command("sudo apt update && sudo apt upgrade -y", use_sudo=True)
    run_command("sudo apt install -y wget curl gnupg2 software-properties-common apt-transport-https ca-certificates", use_sudo=True)

def install_lxd():
    """
    Install LXD using snap.
    Installs the LXD container management tool.
    """
    print("Installing LXD via snap...")
    run_command("sudo snap install lxd", use_sudo=True)

def initialize_lxd():
    """
    Initialize LXD with default configurations.
    Ensures LXD is set up and ready to use.
    """
    print("Initializing LXD...")
    # Running lxd init non-interactively with default settings
    run_command("sudo lxd init --auto", use_sudo=True)    

def create_lxc_container():
    """
    Create the LXC container with Ubuntu 24.04.
    Launches a new LXC container with the specified base image.
    """
    print("Creating LXC container named 'my-container'...")
    run_command("sudo lxc launch ubuntu:24.04 my-container", use_sudo=False)

def install_packages_in_container():
    """
    Install all the latest packages inside the LXC container.
    Updates the container and installs required utilities including X11 apps.
    """
    print("Installing packages inside the LXC container...")
    run_command("sudo apt update && sudo apt upgrade -y", inside_container=True)
    run_command("sudo apt install -y x11-apps wget curl", inside_container=True)

def configure_x11_in_container():
    """
    Configure X11 and test connection.
    Sets up the DISPLAY environment variable and tests X11 connectivity with xeyes.
    """
    print("Configuring X11 inside the LXC container...")
    run_command('echo "export DISPLAY=172.26.160.1:0" >> ~/.bashrc', inside_container=True)
    run_command('source ~/.bashrc', inside_container=True)

    # Verify X11 connection (using xeyes as an example)
    print("Testing X11 connection with xeyes...")
    result = run_command("env DISPLAY=172.26.160.1:0 xeyes", inside_container=True, timeout=10)
    if result is None:
        print("Terminating xeyes to prevent blocking X server.")
        run_command("pkill xeyes", inside_container=True)  # Kill xeyes to free X server

def install_chrome_in_container():
    """
    Install Google Chrome in the LXC container.
    Downloads and installs the Chrome browser.
    """
    print("Installing dependencies for Google Chrome...")
    run_command("sudo apt install -y wget software-properties-common apt-transport-https ca-certificates", inside_container=True)

    print("Downloading Google Chrome...")
    run_command("wget -O /tmp/google-chrome-stable_current_amd64.deb https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb", inside_container=True)

    print("Fixing file permissions for Chrome installation...")
    run_command("chmod 644 /tmp/google-chrome-stable_current_amd64.deb", inside_container=True)

    print("Installing Google Chrome...")
    run_command("sudo apt install /tmp/google-chrome-stable_current_amd64.deb -y", inside_container=True)

    # Verify installation
    print("Verifying Chrome installation...")
    run_command("google-chrome --version", inside_container=True)

def run_chrome_in_container():
    """
    Run Google Chrome in the LXC container with no sandbox.
    Launches Chrome with the --no-sandbox flag.
    """
    print("Running Google Chrome inside the container...")
    run_command("env DISPLAY=172.26.160.1:0 google-chrome --no-sandbox", inside_container=True)

def main():
    """
    Main function to orchestrate the setup and configuration process.
    Runs the necessary steps to set up the LXC container and required applications.
    """
    install_and_update_ubuntu()
    install_lxd()
    initialize_lxd()  # New step to initialize LXD
    create_lxc_container()
    install_packages_in_container()
    configure_x11_in_container()
    install_chrome_in_container()
    run_chrome_in_container()
    print("Installation completed successfully!")

if __name__ == "__main__":
    main()
