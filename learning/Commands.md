# Docker Learning

## Introduction

### Postgres

Start a container

```bash
docker run --name my-postgres -e POSTGRES_PASSWORD=Password1234$ -p 5432:5432 -d postgres
```

Stop a container

```bash
docker stop my-postgres
```

Restart a container

```bash
docker restart my-postgres
```

Stop and remove a container 

```bash
docker rm -f my-postgres
```

List all containers

```bash
docker ps -a
```

## Persistent Storage

```bash
docker volume create pgdata
```

To delete:

```bash
docker volume rm pgdata
```

Run with storage

```bash
docker run --name my-postgres -e POSTGRES_PASSWORD=Password1234$ -p 5432:5432 -v pgdata:/var/lib/postgresql -d postgres
```

### Logs

To view all logs:

```bash
docker logs my-postgres
```

To tail logs:
```bash
docker logs -f my-postgres
```

### SQL Server

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password1234$" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

#### SQL Server with Persistent Storage

```bash
docker volume create sqlserverdata
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password1234$" -p 1433:1433 --name sqlserver -v sqlserverdata:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest
```

## Networking

```bash
docker network create myapp-net
```

Attach SQL Server to the network:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password1234$" -p 1433:1433 --name sqlserver -v sqlserverdata:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest --network myapp-net
```