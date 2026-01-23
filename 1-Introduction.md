## Overview

The goal of this exercise is to introduce you to the basics of using docker both through the Docker Desktop GUI and through the docker CLI

Our first objective is to use docker to manage our application's database.
You will have to perform the below tasks with both a PostgreSQL DB and a Microsoft Sequel Server DB.

You can feel free to experiment with any other DB of your choosing, these are just the 2 DBs that I have made working examples for.
However, if you do choose to use a different DB, you will need to setup the environment config.

## Tasks

- Install relevant Docker image.
- Using the Docker Desktop GUI, run your database in a docker container.
- Using the Docker CLI, run your database with the same configuration as when you ran it with the GUI.
- Create and run a Docker Compose file with same configuration as the previous containers.

## Docker Environment

#### MSSQL

Image: mcr.microsoft.com/mssql/server:2025-latest

Port: 1433

Variables:
- Key: ACCEPT_EULA
  Value: "Y"
- Key: MSSQL_USER
  Value: "chilli"
- Key: MSSQL_DB
  Value: "main"
- Key: MSSQL_PASSWORD
  Value: "S3cur3P@ssw0rd!"
- Key: MSSQL_SA_PASSWORD
  Value: <any secure password satisfying the MSSQL password policy, e.g. Str0ngP@ssw0rd!>

[MSSQL Password Policy](https://learn.microsoft.com/en-us/sql/relational-databases/security/password-policy?view=sql-server-ver17#password-complexity)

#### PostgreSQL

Image: postgres:latest

Port: 5432

Variables:
- Key: POSTGRES_USER
  Value: "chilli"
- Key: POSTGRES_PASSWORD
  Value: "S3cur3P@ssw0rd!"
- Key: POSTGRES_DB
  Value: "main"

## Application Environment

- [User Management](services/user-management/README.md)
- [Event Scheduler](services/event-scheduler/README.md)

## References

- [Docker Docs](https://docs.docker.com/)
- [Docker Desktop](https://docs.docker.com/desktop/use-desktop/)
- [Docker Run](https://docs.docker.com/reference/cli/docker/container/run/)
- [Docker Compose](https://docs.docker.com/reference/cli/docker/compose/)
- [Docker Compose File](https://docs.docker.com/reference/compose-file/)
