# DotNet, SqlServer, SonarQube & Docker
Demo CRUD Web App, using .NET 6, Sql Server and SonarQube for testing Docker integration.

Make sure you're using __*Docker-Compose*__ as startup project in Visual Studio and your [Docker Desktop](https://www.docker.com/products/docker-desktop) is updated and running!


## Database (Sql Server instance)
Once you'll be running the docker container, the database will we exposed and accessible at `localhost,1440`
- Username: `sa`
- Password: `N3tDockeDemo@!`

## SonarQube
The SonarQube dashboard will be listening at [localhost:9000](http://localhost:9000/).

In order to use it, make sure you have Java SDK o JRE installed and JAVA_HOME as systema variables.

1. Login with `admin` and `admin`, then you'll need to choose a new password;
2. Select "Manually" and create a new project (ex. "DotNet-Docker-Easy");
3. Follow the "Locally" instructions for testing SonarQube using the *CLI Tool*;
4. Once done, the dashboard will automatically refresh and show the report.

### Test example
You'll find these instructions, with the correct token, in your local SonarQube Dashboard once you'll have configured the project.

As a prerequisite you need to have the sonarscanner tool installed globally using the following command:

`dotnet tool install --global dotnet-sonarscanner`

Make sure dotnet tools folder is in your path. See dotnet global tools documentation for more information.

Running a SonarQube analysis is straighforward. You just need to execute the following commands at the root of your solution.
```
dotnet sonarscanner begin /k:"DotNet-Docker-Easy" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="220a1b80db80794602542934ce81c250fc0e6cba"
dotnet build
dotnet sonarscanner end /d:sonar.login="220a1b80db80794602542934ce81c250fc0e6cba"
```

Once you'll have run the previous commands, the SonarQube dashboard will automatically refresh and look like this:

![image](https://user-images.githubusercontent.com/68862675/161421520-288b0375-a38c-4d12-9760-f2991a1fca98.png)

<!--
You may also want to configure [SonarLint Visual Studio Extension](https://www.sonarqube.org/sonarlint/) 
from `Visual Studio` > `Analyze` > `Manage SonarQube Connections`.

You'll need to specify: server, token and password (obtained from the dashboard).
-->
