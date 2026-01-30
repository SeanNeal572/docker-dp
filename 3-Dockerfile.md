## Overview

The goal of this exercise is learn how to containerize your application using the `docker build` command.

## Tasks

- Create Dockerfiles to create docker images for both the `user-management` service and the `event-scheduler` service.
- Build the docker images and give them the following tags:
  - `docker-dp/user-management:latest`
  - `docker-dp/event-scheduler:latest`
- Using the command line, run both service images in docker containers with their relevant environment variables.
- Test that your services are running using the swagger interfaces:
  - `http://localhost:8080/swagger`
  - `http://localhost:8081/swagger`
- Note that due to how docker containers communicate with each other, your applications won't be able to connect to your database unless you set up the networking correctly. As long as you are able to see the swagger dashboard you will know that your application is running. Networks will be the topic of the next exercise.
- Once you have learnt about docker networks and can get your containerized application to comunicate to your, you can update your Dockerfiles to run the migrations before running the application.

## Ports

User Management - 8080
Event Scheduler - 8081

## Environment Variables

#### User Management

- `DB_PROVIDER` : `mssql` / `postgresql` (depending on the database image your are running)
- `DB_PORT_MSSQL` : `1433`
- `DB_PORT_POSTGRES` : `5432`
- `DB_HOST` : `localhost`
- `DB_USER` : `chilli`
- `DB_PASSWORD` : `S3cur3P@ssw0rd!`
- `DB_DATABASE` : `main`

#### Event Scheduler

- `Db:Provider` : `mssql` / `postgresql` (depending on the database image your are running)
- `Db:PortMssql` : `1433`
- `Db:PortPostgres` : `5432`
- `Db:Host` : `localhost`
- `Db:User` : `chilli`
- `Db:Password` : `S3cur3P@ssw0rd!`
- `Db:Database` : `main`

## References

- [Docker Build](https://docs.docker.com/build/)
- [Docker Build CLI](https://docs.docker.com/reference/cli/docker/buildx/build/)
- [Dockerfile Overview](https://docs.docker.com/build/concepts/dockerfile/)
