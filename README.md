# Emne_3

### dotnet runtime (CLI)
create new console project (example uses name HelloWorld)
```bash
# create a directory which project is HelloWorld and jump into it
mkdir HelloWorld
cd HelloWorld

# choose one of these create a project
dotnet new console --framework net7.0 # use top level statement template
dotnet new console --framework net7.0 --use-program-main # use standard template

# add gitignore
dotnet new gitignore

# build application
dotnet build

# run application
dotnet run
```
