# Emne 3 - GetAcademy
* OOP developement with C#

## Setup for Cross Platform .NET Developement
Windows users have the option to use Visual Studio instead and can skip this whole section

[Install .NET core](https://learn.microsoft.com/en-us/dotnet/core/install/)

[Install VS-Code](https://code.visualstudio.com/download)

[Setting up VS-Code for .NET](https://code.visualstudio.com/docs/languages/dotnet#_setting-up-vs-code-for-net-development)


## Guide .NET CLI Tool (dotnet)

Create new console project
* This example uses the project name HelloWorld, but you can use any name you want
```bash
# create a directory with name HelloWorld (will be the project name)
mkdir HelloWorld

# cd into the project root directory
cd HelloWorld

# choose one of these to create a new project
dotnet new console --framework net7.0 --use-program-main # standard
dotnet new console --framework net7.0 # top level statement

# add a gitignore file with standard dotnet ignores
dotnet new gitignore

# build the application
dotnet build

# run the application (will automatically build first)
dotnet run
```

## Opening a dotnet project
Make sure to navigate to the directory containing the Program.cs file.
Open the corresponding directory in your editor of choice
..the built-in dev-tools depend on it.
