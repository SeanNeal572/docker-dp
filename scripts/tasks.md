## 1

### MSSQL

docker pull mcr.microsoft.com/mssql/server:2025-latest

docker run --name docker_dp_sqlserver -d -p 1433 -e ACCEPT_EULA=Y -e MSSQL_USER=chilli -e MSSQL_DB=main -e MSSQL_PASSWORD=S3cur3P@ssw0rd! -e MSSQL_SA_PASSWORD=Dek!05$q@A^T mcr.microsoft.com/mssql/server:2025-latest

docker stop docker_dp_sqlserver
docker rm docker_dp_sqlserver

### Postgres

docker pull postgres:latest

docker run --name docker_dp_postgres -d -p 5432 -e POSTGRES_USER=chilli -e POSTGRES_DB=main -e POSTGRES_PASSWORD=S3cur3P@ssw0rd! postgres:latest

docker stop docker_dp_postgres
docker rm docker_dp_postgres

### Compose

docker compose up
docker compose down