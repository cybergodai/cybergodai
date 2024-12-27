import subprocess
import sys

def run_command(command):
    """
    Helper function to execute a shell command.
    """
    try:
        print(f"Running command: {command}")
        result = subprocess.run(command, shell=True, text=True, capture_output=True)
        if result.returncode != 0:
            print(f"Error: {result.stderr.strip()}")
            sys.exit(1)
        print(result.stdout.strip())
    except Exception as e:
        print(f"Error running command {command}: {e}")
        sys.exit(1)

def stop_container():
    """
    Stops the LXC container 'my-container'.
    """
    container_name = "my-container"
    print(f"Stopping container '{container_name}'...")
    run_command(f"lxc stop {container_name}")

def delete_container():
    """
    Deletes the LXC container 'my-container'.
    """
    container_name = "my-container"
    print(f"Deleting container '{container_name}'...")
    run_command(f"lxc delete {container_name}")

def main():
    """
    Main function to stop and delete the LXC container 'my-container'.
    """
    stop_container()
    delete_container()
    print("Container 'my-container' has been successfully stopped and deleted.")

if __name__ == "__main__":
    main()
