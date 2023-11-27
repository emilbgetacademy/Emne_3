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

## Opening a project
Make sure to navigate to the directory containing the Program.cs file.
Open the corresponding directory in your editor of choice
..the built-in dev-tools depend on it.


## Programming Conventions
```yaml
class property private field:
    _name
class property public field:
    Name

Variable declaration when type can be implied on same line:
    var aString = "hello";
    var aNumber = 10;
Variable declaration when type can not be implied on same line:
    var aString = ReturnsSomething();
    int aNumber = ReturnsSomething();
```


## Containers (Docker)

### Minimal Dockerfile for console app (Dockerfile must recide in the app directory for this example)
Dockerfile
* NOTE: change sdk version if needed
```bash
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY . ./
ENTRYPOINT ["dotnet"]
CMD ["run"]
```

Docker commands
Run the commands from the same directory as this file
Remember to set a container-name, an image-name and an argument (argument can be omitted)
```bash
# build image
docker build -t <imagename> .

# run and remove container after exit
docker run -t --rm <imagename> <argument>

# run and keep container after exit
docker run -t --name <containername> <imagename> <argument>

# remove container
docker rm <containername>

# remove image
docker rmi <imagename>
```
