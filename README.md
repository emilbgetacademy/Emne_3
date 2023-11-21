# Emne_3

### Opening a dotnet project
Make sure to navigate to the directory containing the Program.cs file.
Open the corresponding directory in your editor of choice
..the built-in dev-tools depend on it.

### Install .NET on your OS to get the dotnet command (runtime and sdk)
[Click here](https://learn.microsoft.com/en-us/dotnet/core/install/)

### .NET cli tool (dotnet)
Using the dotnet command line utility to create, build and run a .NET application.

#### Create new console project
* This example uses the project name "HelloWorld"
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
