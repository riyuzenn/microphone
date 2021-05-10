## Building Serum Microphone
> [back](https://github.com/serumstudio/microphone/tree/main/docs)
---
[Serum Microphone](https://github.com/serumstudio/microphone) is compiled and build with [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/). If you have Visual Studio 2017 installed, it should work.

### Installing Visual Studio
Install Visual Studio Installer [here](https://visualstudio.microsoft.com/downloads/). After the installation of Visual Studio Installer, choose **.Net desktop development**. Now you're ready to go to compiled the project!

### Building Serum Microphone w/ Visual Studio
If you haven't install the source files, download it. After you download, open the file named "**Serum Microphone.sln**". It's a solution file provided by Visual Studio, for more information about solution files, check this [one](https://docs.microsoft.com/en-us/visualstudio/ide/solutions-and-projects-in-visual-studio?view=vs-2019).

After you opened the solution file, Navigate to menu bar and find change "**Debug**" option to "**Release**", this will build a release version instead of Debug, for deployment purposes. Next, navigate to "**Build**" menu at the very top of Visual Studio, and chose "**Build sln**". 

### Troubleshooting
If you ever encountered a problem called, "**Must use package reference**", right click the _`Solution`_ >  _`References`_ > _`"Migrate packages.config to PackageReference"`_. This option converts the "package.config" onto your reference and it will fixed the issue. However, if the issue is unfamilliar, feel free to open issues [here](https://github.com/serumstudio/microphone/issues)
