# .NET

## Cross Platform Developement

* Note: If on Windows you have the option to use Visual Studio instead

[Install .NET core](https://learn.microsoft.com/en-us/dotnet/core/install/)

[Install VS-Code](https://code.visualstudio.com/download)

[Setting up VS-Code for .NET](https://code.visualstudio.com/docs/languages/dotnet#_setting-up-vs-code-for-net-development)

[Official .NET Documentation](https://learn.microsoft.com/en-us/dotnet/)


## .NET CLI Tool

### Create new console project

* This example uses the project name HelloWorld, but you can use any name you want

create a directory with name HelloWorld (will be the project name)
```bash
mkdir HelloWorld
```

cd into the project root directory
```bash
cd HelloWorld
```

create a new project with top level statement
```bash
dotnet new console --framework net7.0
```

create a new project w/o top level statement (standard Main)
```bash
dotnet new console --framework net7.0 --use-program-main
```

add a gitignore file with standard dotnet ignores
```bash
dotnet new gitignore
```

build the application
```bash

dotnet build
```

run the application (will automatically build first)
```bash
dotnet run
```

## Opening a project in your editor

Make sure to navigate to the directory containing the Program.cs file.
Open this directory in your editor of choice
The dev-tools in yor IDE depend on having the file and folder structure intact.


## Programming Conventions

```yaml
class property private field:
    _propertyName
class property public field:
    PropertyName

Variable declaration when type can be implied on same line:
    var someString = "hello";
    var someNumber = 10;
Variable declaration when type can not be implied on same line:
    string someString = ReturnsSomething();
    int someNumber = ReturnsSomething();
```


## Containers (Podman)

Build an image with .NET sdk (run the command from this directory)
```bash
podman build -t emilbgetacademydotnetimage .
```

With the image built, we can start a container in any directory and then navigate to our .NET apps
```bash
podman run -it --rm --mount type=bind,source="$(pwd)",target=/App emilbgetacademydotnetimage
```

Removing the image
```bash
podman rmi emilbgetacademydotnetimage
```

Dont want to build a local image, run a container from mcr.microsoft.com and cd into /App and navigate to our .NET apps
```bash
# sdk version 7
podman run -it --rm --mount type=bind,source="$(pwd)",target=/App mcr.microsoft.com/dotnet/sdk:7.0

# sdk version 8
podman run -it --rm --mount type=bind,source="$(pwd)",target=/App mcr.microsoft.com/dotnet/sdk:8.0
```
