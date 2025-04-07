# ShellRunnerGUI

ShellRunnerGUI is Desktop App written in WindowsForms. App has two windows: input and output window. Input window accepts powershell commands and output window displays the output of them.


## 

👉 [Dowload from Releases](https://github.com/K0bi3l/ShellRunnerGUI/releases)

After downloading:
1. Extract `ShellRunnerGUI.zip`
2. Go to publish folder and run `ShellRunnerGUI.exe`  
   It shouldn't require the .NET8 installed on your device.
   Microsoft defender can display warning, because it takes .exe files from not trusted sources as potentially dangerous.

## 🛠️ How to run app from code

### Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) + Windows Desktop (should already be in SDK)
- Windows OS (prefferably 10 or 11)
- Visual Studio **or** JetBrains Rider

### Instructions
1. Clone repo:
   ```bash
   git clone https://github.com/K0bi3l/ShellRunnerGUI.git
   ```
2. Open the project in IDE (Visual Studio or Rider) and click run.
   
   Also, you can go to ShellRunnerGUI\Jetbrains_1 folder, open terminal and type
   ```powershell
   dotnet run
   ```
Repo contains one project for app code and one project for tests.

## Features
1. Running powershell commands and displaying output and error in different colors.
2. Path to working directory in input textbox, it should change when you execute: 
 ```bash
   cd <directory_name>
```
3. Commands memory: it works just as in shell or terminal, you can navigate through commands using up and down keys on keyboard. In right upper corner you can set the capacity of the memory - initial capacity is set for 20 commands.
