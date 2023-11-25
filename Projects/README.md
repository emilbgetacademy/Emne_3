# My own .NET projects

### Using the Dockerfile (currently using sdk version 7 for all projects)

```bash
# build the image
docker build -t getacademydotnetprojects .

# run a project (example uses HelloWorld) from this directory
docker run -it --rm getacademydotnetprojects HelloWorld

# run an interactive bash shell
docker run -it --rm getacademydotnetprojects bash
```
