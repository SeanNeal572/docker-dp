### MSSQL

docker run --name docker_dp_sqlserver -d -p 1433:1433 -e ACCEPT_EULA=Y -e MSSQL_USER=chilli -e MSSQL_DB=main -e MSSQL_PASSWORD=S3cur3P@ssw0rd! -e MSSQL_SA_PASSWORD=Dek!05$q@A^T -v dp_mssql_data:/var/opt/mssql mcr.microsoft.com/mssql/server:2025-latest

### Postgres

docker run --name docker_dp_postgres -d -p 5432:5432 -e POSTGRES_USER=chilli -e POSTGRES_DB=main -e POSTGRES_PASSWORD=S3cur3P@ssw0rd! -v dp_postgres_data:/var/lib/postgresql postgres:latest