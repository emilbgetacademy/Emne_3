#!/bin/bash

if [ $# -eq 0 ]; then
    echo "Provide an argument with the docker run command"
    echo "Either the name of the project directory or bash for opening an interactive shell"
elif [ $1 == "bash" ]; then
    echo "Stargin Bash shell inside container"
    /bin/bash
else
    dotnet run --project $1
fi
