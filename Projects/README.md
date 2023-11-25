# My own .NET projects

### Using the Dockerfile (currently using sdk version 7 for all projects)

```bash
# build the image (will copy this directory "Projects" into the image)
docker build -t getacademydotnetprojects .

# run a project (for example HelloWorld)
## using project directory inside the container
docker run -it --rm getacademydotnetprojects HelloWorld
## using project directory on the host
docker run -it  --rm --mount type=bind,source="$(pwd)",target=/Projects getacademydotnetprojects HelloWorld

# run an interactive bash shell
## using project directory inside the container
docker run -it --rm getacademydotnetprojects bash
## using project directory on the host
docker run -it  --rm --mount type=bind,source="$(pwd)",target=/Projects getacademydotnetprojects bash
```
