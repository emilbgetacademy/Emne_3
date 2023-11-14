# Emne_3

### dotnet runtime (CLI)
create new console project (example uses name HelloWorld)
```bash
# create a directory which project is HelloWorld and jump into it
$ mkdir HelloWorld 
$ cd HelloWorld

# choose one of these
$ dotnet new console --framework net7.0 # create top level statement skeleton/template for the project
$ dotnet new console --framework net7.0 --use-program-main # create standard skeleton/template for the project

# add gitignore
$ dotnet new gitignore

# run application
$ dotnet run
```
