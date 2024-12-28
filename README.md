<!DOCTYPE html>
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            color: #333;
            margin: 0;
            padding: 0;
        }
        h1, h2, h3 {
            color: #0056b3;
        }
        a {
            color: #007bff;
            text-decoration: none;
        }
        a:hover {
            text-decoration: underline;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }
        table th, table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        table th {
            background-color: #f4f4f4;
        }
        .container {
            padding: 20px;
        }
        .emoji {
            font-size: 1.2em;
            margin-right: 5px;
        }
        .button {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            color: #fff;
            background-color: #28a745;
            border: none;
            border-radius: 5px;
            text-align: center;
            text-decoration: none;
        }
        .button:hover {
            background-color: #218838;
        }
        details {
            margin: 10px 0;
        }
        details summary {
            font-weight: bold;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>🌐 CyberGod: Revolutionizing Endpoint Security</h1>

        <p><strong>CyberGod</strong> is an open-source project designed to transform endpoint security through advanced virtualization technologies. 🚀</p>

        <h2>✨ Overview</h2>
        <ul>
            <li>🔹 <strong>C# Script:</strong> Automates WSL2 and Ubuntu 24.04 setup on Windows.</li>
            <li>🔹 <strong>Python Script:</strong> Configures LXC for secure browsing with Google Chrome.</li>
        </ul>

        <p><em>Note:</em> Pre-install VcXsrv X Server (<a href="https://vcxsrv.com/wp-content/uploads/2024/09/vcxsrv-64.1.17.2.0.installer.zip">Download</a>) and ensure it is running. ✅</p>

        <h2>🔧 Prerequisites</h2>
        <table>
            <tr>
                <th>Category</th>
                <th>Details</th>
            </tr>
            <tr>
                <td>System Requirements</td>
                <td>Windows 10/11, PC or VM with sufficient resources</td>
            </tr>
            <tr>
                <td>Software Requirements</td>
                <td>.NET SDK, Python 3, Code Editor (VS Code, JetBrains Rider, etc.)</td>
            </tr>
        </table>

        <h2>📖 Step-by-Step Guide</h2>

        <details>
            <summary>Step 1: Setting Up with C#</summary>
            <ol>
                <li>Install .NET SDK and verify installation:</li>
                <pre><code>dotnet --version</code></pre>
                <li>Create a new project and replace <code>Program.cs</code> with CyberGod's script:</li>
                <pre><code>mkdir cybergod &amp;&amp; cd cybergod
                dotnet new console --force</code></pre>
                <li>Run the script:</li>
                <pre><code>dotnet run</code></pre>
            </ol>
        </details>

        <details>
            <summary>Step 2: Configuring with Python</summary>
            <ol>
                <li>Edit <code>install_lxc_chrome_x12.py</code> with your WSL IP address.</li>
                <li>Run the script in WSL:</li>
                <pre><code>python3 install_lxc_chrome_x12.py</code></pre>
                <li>Monitor the output to ensure LXC and Chrome are installed securely.</li>
            </ol>
        </details>

        <h2>❌ Uninstallation</h2>
        <ul>
            <li>Run <code>stop_delete_container.py</code> to remove the LXC container.</li>
            <li>Run <code>uninstall.cs</code> to remove Ubuntu and WSL completely.</li>
        </ul>

        <h2>🌟 Vision</h2>
        <p>CyberGod aims to:</p>
        <ul>
            <li>🤖 Incorporate AI-driven threat detection.</li>
            <li>📡 Expand support to IoT devices.</li>
            <li>📜 Ensure compliance with DORA, NIS2, and CRA frameworks.</li>
        </ul>

        <h2>🤝 Contribution Guidelines</h2>
        <p>We welcome contributions!</p>
        <ul>
            <li>Fork the repository and create a new branch:</li>
            <pre><code>git checkout -b feature-name</code></pre>
            <li>Commit your changes:</li>
            <pre><code>git commit -m "Description of changes"</code></pre>
            <li>Push and create a pull request.</li>
        </ul>

        <h2>📬 Contact</h2>
        <p>Join us:</p>
        <ul>
            <li>Telegram: <a href="https://t.me/+WttALifnSAtjYTMy">Join Us</a></li>
            <li>Discord (Developers Only): <a href="https://discord.gg/DscPJNkQ">Join</a></li>
        </ul>

        <hr>
        <p style="text-align: center;">CyberGod is a community-driven initiative. 🌍 Let's build a safer digital future together! 💻</p>
    </div>
</body>
</html>

