# My own .NET projects

### Using the Dockerfile (currently using sdk version 7 for all projects)

```bash
docker build -t getacademydotnetprojects .

# runs the HelloWorld project (specified in the Dockerfile)
docker run -t --rm getacademydotnetprojects

# runs the project in the directory <YourProjectDirectory>
docker run -t --rm getacademydotnetprojects <YourProjectDirectory>
```
