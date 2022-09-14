# demo-dev-containers
This is a demo project that shows a few different ways that containers can be used in development.

## Pre-Reqs
If you want to run these examples you will want to install:
* Docker Desktop (https://www.docker.com/products/docker-desktop/)
* VS Code (https://code.visualstudio.com/)
* Remote - Containers (Extension within VS Code)

---
## Containers:
The following containers make up the application and the supporting tools:
* Frontend(React): http://localhost:3000
* Backend(.NET): http://localhost:8080/api/v1/player/swagger/index.html
* Database(PostgreSQL): not exposed
* PG Admin: http://localhost:9000

---
## Containers in Dev
Here are some examples of different ways that you can utilize containers in your local development:

### Using Dockerfile
In the most straightforward case, we just reuse the existing Dockerfile(s) to build and run the application. There is nothing new to add or support, but it comes with some costs in terms of time to build and context switching.
* Run Docker Compose to build the application and run it
  ```
  docker compose -f compose/docker-compose-runtime.yaml up --build
  ```
* Stop & remove the containers
  ```
  (Use CTRL+C to stop them first or open a new terminal)
  docker compose -f compose/docker-compose-runtime.yaml down
  ```

### Run commands via Docker Exec
In this situation, we use containers running the tools we need to build and run the application. It's much closer to what we would do in terms of development and we don't have to install and support those tools. However, the IDE still isn't offering much beyond text editing.
* Run Docker Compose to build the application and run it
  ```
  docker compose -f compose/docker-compose-dev.yaml up --build -d
  ```
* Execute commands against the containers
  ```
  docker exec compose-backend-1 dotnet run
  docker exec compose-frontend-1 npm run start
  ```
* Alternatively exec into container in interactive mode
  ```
  docker exec -it compose-backend-1 bash
  dotnet run
  exit

  docker exec -it compose-frontend-1 bash
  npm run start
  exit
  ```
* Stop & remove the containers
  ```
  docker compose -f compose/docker-compose-dev.yaml down
  ```

### Dev Containers
Finally, we will do out development from within the containers themselves. This gives the IDE the tools it needs to be helpful (without us having to install/support those tools). There are multiple ways to do this and we'll look at using VS Code and Docker Desktop.

**VS CODE**
* Run Docker Compose to build the application and run it
  ```
  docker compose -f compose/docker-compose-dev.yaml up --build -d
  ```
* Use the Remote Expoloer within VS Code to attach to one of the running containers
* Open the /app directory in either the frontend or backend container
* VS Code should prompt you install the needed extensions
* Interact with code via VS Code (you can make changes and run tasks)
* Stop & remove the containers (from main VS Code window)
  ```
  docker compose -f compose/docker-compose-dev.yaml down
  ```

**Docker Desktop**
* Open Docker Desktop and Select the Dev Environments section
* Click "Create new environment" button
* Then click the "Get Started" button in the lower right corner
* Select "Use Existing Git Repo" and enter this **https://github.com/nsschultz/demo-dev-containers.git** into the text box and click continue
* Then click the "Continue" button in the lower right corner
* Click on the "Open in VS Code" button on the frontend container
* Once VS Code opens, switch to the /app directory (you can do this by going to File -> Open Folder)
* Once done, do back to Docker Desktop and you can stop and delete the containers

**Single Dev Container Example**
* Open Docker Desktop and Select the Dev Environments section
* Click "Create new environment" button
* Then click the "Get Started" button in the lower right corner
* Select "Use Existing Git Repo" and enter this **https://github.com/nsschultz/fantasy-baseball-position.git** into the text box and click continue
* Then click the "Continue" button in the lower right corner
* Click on the "Open in VS Code" button on the api container
* Once done, do back to Docker Desktop and you can stop and delete the containers