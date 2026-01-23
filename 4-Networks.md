## Overview

The goal of this exercise is learn how to manage your docker networks using the `docker network` command to enable communication between your docker containers.

## Tasks

#### Using container names
- Create a docker bridge network with the name `docker-dp`
- Run your database container (postgres/mssql depending on your environment variables) and connect it to the `docker-dp` network
- Run your services as docker containers and connect them to the `docker-dp` network. You will need to make sure that the `DB_HOST`/`Db:Host` environment variable is equal to the container name of the database container.
- Test your database connection and run migrations using swagger.

#### Using an alias
- Delete your services docker containers.
- Disconnect the database container from `docker-dp` network.
- Connect database container to `docker-dp` network using the alias `db`.
- Run your service docker containers again, this time with the `DB_HOST`/`Db:Host` equal to the database alias `db`, and connect them to the `docker-dp` network.
- Test your database connection and run migrations using swagger.

## References

- [Docker Network](https://docs.docker.com/engine/network/)
- [Docker Network CLI](https://docs.docker.com/reference/cli/docker/network/)
