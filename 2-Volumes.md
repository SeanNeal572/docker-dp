## Overview

The goal of this exercise is learn how to manage Docker volumes. We will be working with a database image just like we did with the first exercise.

## Tasks

#### GUI
- Create a volume.
- Run a docker container (mssql/postgres) and direct the database data to the created volume.
- Run the migrations against the database, run the application, and add some users.
- Delete your database container, but keep the volume.
- Run a new container for your database and direct the database data to the volume you kept.
- Run the application and get all users.
- You should find that the users you added should have persisted even though you made a new container cause the data was stored in the volume.

#### CLI
- Repeat all the above tasks using the equivalent CLI commands.

#### Docker Compose
- Create a docker compose file that does the following:
  - File 1:
    - Creates a named volume/uses the existing volume created by a previous run of the docker compose.
    - Runs a database instance that stores its data in the created volume

- Create a docker compose file that does the following:
  - Specifies an externally managed volume (i.e. a volume that the docker compose did not create)
  - Runs a database instance that stores its data in the externally managed volume

- Create a docker compose file that does the following:
  - Runs a database instance that mounts its data into a folder at `{path-to-docker-dp-repo}/data/db/`

- Create a docker compose file that does the following:
  - Runs a database instance that mounts its data into memory (tmpfs)

## Data paths

- postgres - /var/lib/postgresql
- mcr.microsoft.com/mssql/server:2025-latest - /var/opt/mssql

## References

- [Docker Volume](https://docs.docker.com/reference/cli/docker/volume/)
- [Docker Compose File (Volumes)](https://docs.docker.com/reference/compose-file/volumes/)
