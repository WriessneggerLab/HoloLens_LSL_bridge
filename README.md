Hello! This is a short guide on how to develop this app on the HoloLens and how to use it.


## Installations and requirements:

Windows 10 is required to install and use all software successfully.
Download Unity Hub (used version: 2.4.5) from the official Unity website (https://unity3d.com/de/get-unity/download).

Then, open Unity Hub and install the Unity Editor (used version: 2020.3.24).  
•	Go to Installs  
•	Add  
•	Choose a Unity Editor Version and install it (if the wanted one is not listed, click on the download archive link and choose from there)

Download Microsoft Visual Studio 2019 from the official Microsoft website (https://visualstudio.microsoft.com/de/vs/older-downloads). 
Before installing, make sure to meet all the requirements from the installation checklist (https://docs.microsoft.com/en-us/windows/mixed-reality/develop/install-the-tools). 
Install the workloads:
•	Desktop development with C++  
•	Universal Windows Platform (UWP) development  
•	Game development with Unity

In the UWP workload, make sure, the following components are included:  
•	Windows 10 SDK version 10.0.19041.0 or 10.0.18362.0  
•	USB Device Connectivity  
•	C++ (v142) Universal Windows Platform tools

For debugging the app later on the HoloLens, make sure to enable developer mode on the PC (Settings > Update & Security > for developers) and the HoloLens.


## Opening the project:

Important! This part can be completely skipped, if no changes have to be made to the program and the App folder already exists. 
In that case go to Opening the Visual Studio solution. If not, continue here.

To get access to the project open the Unity Hub and press Add and choose the folder containing the program (HoloLens_LSL_Connection). 
The right folder has the folder Assets, App, Packages and others contained in it. Now you can go back to Unity Hub and press on the name you 
just added (the right Unity version has to be selected). 

Now the Unity Editor starts and you should be able to view the project. If you go to File > Build Settings make sure following points are checked:  
•	Only the Scenes/Main is checked in Scenes in Build.  
•	The selected platform is Universal Windows Platform  
•	Target Device: Any device  
•	Architecture: x86  
•	Build Type: D3D Project  
•	Target SDK Version: Latest installed (check additionally, if the previously installed SDK can be found here)  
•	Minimum Platform Version: 10.0.10240.0 (can be arbitrary, as it just needs to be lower than your current one)  
•	Visual Studio Version: Latest installed  
•	Build and Run on: Local Machine  
•	Build configuration: Release  
The rest of the check marks can be left as they are.

If some options are not available, something went wrong in the installations and requirements part, so make sure you follow it correctly. 
If the configurations were adjusted accordingly, press Build. Now you’re asked to choose a folder. Delete the App folder, if it exists (in the main folder of the project) 
and create a new one, which you have to choose. Now a Visual Studio solution is build.


## Opening the Visual Studio solution and deploy the App on the HoloLens:

Make sure, that the HoloLens is connected via USB to the used PC. Open the App folder and start the .sln-file with Visual Studio 2019. 
Now the solution opens and the only thing to do is change the Output to Release, x86 and the HoloLens (those options are underneath Project, Debug and so on and are next to each other). 
Now go to Debug > Start without Debugging and let the App upload to the HoloLens. This usually takes a few minutes and should terminate without any errors. 
After it finished, you can disconnect the HoloLens and start the App there. Sometimes the App doesn’t open the first time, in which case it needs to be closed on the HoloLens and reopened. 

