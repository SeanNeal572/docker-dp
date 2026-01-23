## Overview

The goal of this exercise will be to utilize Docker's `docker compose` command to create and manage everything from the build phase of our docker image to running our applications and database all on the same docker network.

## Tasks

#### Docker compose for each service
- Create a `compose.yml` in the `user-management` service that will create and run a container using the `docker-dp/user-managament:latest` tag, the container name `docker-dp-user-management`, and all its relevant environment variables and publishing port `8080` to map to port `8080`.
- Create a `compose.yml` in the `event-scheduler` service that will create and run a container using the `docker-dp/event-scheduler:latest` tag, the container name `docker-dp-event-scheduler`, and all its relevant environment variables and publishing port `8081` to map to port `8080`.
- Test your `compose.yml` by running `docker compose up -d` from within each of the services' folders and visiting their swagger interface.

#### Networks
- Create (or use existing) a docker network called `docker-dp`.
- Run your database container using the command line and connect it to your `docker-dp` network.
- Update your services' `compose.yml` to use you `docker-dp` network as an external network and make sure the your `DB_HOST`/`Db:Host` environment variable is equal to your database container name.
- Test your usage of the `docker-dp` network using the dev controllers to test your db connection and run migrations.

#### Build with docker compose
- Add a build specification to your services' `compose.yml`.
- Test by deleting your services' images and running `docker compose up --build -d` from within each of the services' folders, then run `docker image ls` to see the images have been re-built. Running `docker compose up --build -d` will always re-build the image even if there is an existing image with a matching tag.

#### Including docker compose files
- Create a `compose.yml` in the `docker-dp/services` folder.
- Include both the `user-management/compose.yml` and the `event-scheduler/compose.yml`
- Test by running `docker compose up -d` with the `docker-dp/services` folder.
- You should be able to run `docker compose up --build -d` with the `docker-dp/services` folder and it will re-build your services then run them.

#### Adding in the database
- Create a `database.yml` in the `docker-dp/services` folder that will create and run your database container.
- Update your `docker-dp/services/compose.yml` to include your `database.yml`.
- Docker compose files automatically create networks and connect services defined in them to it so you can remove the external networks from your services' `compose.yml` and you containers will be able to communicate with each other.
- Test by running `docker compose up -d` and using the swagger interfaces to test db connection and run migrations.

#### Adding dependency
- Update your `docker-dp/services/compose.yml` so that your application services include your `database.yml` and depend on the database service.
- Test by running `docker compose up -d --force-recreate`. The application services should be created only after the database has been created.

#### Adding a health check
- Add a health check to you database service.
- Add a condition to your application services' dependencies that requires the database service to be healthy.
- Test by running `docker compose up -d --force-recreate`. The application services should only be started after the database is healthy.

## Health checks

- Postgres test: `pg_isready -U $${POSTGRES_USER}`
- Mssql test: `/opt/mssql-tools18/bin/sqlcmd -U sa -P "$${MSSQL_SA_PASSWORD}" -C -Q "SELECT 1" -b -o /dev/null`

## References

- [Docker Compose](https://docs.docker.com/compose/)
- [Docker Compose CLI](https://docs.docker.com/reference/cli/docker/compose/)
- [Docker Compose File](https://docs.docker.com/reference/compose-file/)
- [Docker Compose Health Check](https://docs.docker.com/reference/compose-file/services/#healthcheck)
- [Dockerfile Health Check](https://docs.docker.com/reference/dockerfile/#healthcheck)
