
## Postgres
# Pull image
docker pull postgres:latest

# Create Volumes
docker volume create pg_main_data

# Run Container
docker run -d `
  --name pg-main `
  -p 5432:5432 `
  -e POSTGRES_USER=chilli `
  -e POSTGRES_PASSWORD="S3cur3P@ssw0rd!" `
  -e POSTGRES_DB=main `
  -v pg_main_data:/var/lib/postgresql `
  postgres:latest


# Verify
docker logs -f pg-main
docker exec -it pg-main psql -U chilli -d main -c "select now();"

# Inspect
docker inspect pg-main --format '{{json .HostConfig.PortBindings}}'
docker inspect pg-main --format '{{json .Mounts}}'
docker inspect pg-main --format '{{json .Config.Env}}'

# Stop / Remove
docker rm -f pg-main

# Remove Volume
docker volume rm pg_main_data

## Mssql
# Create Volume
docker volume create mssql_main_data

# Test Connection
docker run -d `
  --name mssql-main `
  -p 1433:1433 `
  -e "ACCEPT_EULA=Y" `
  -e "MSSQL_PID=Developer" `
  -e "MSSQL_SA_PASSWORD=Str0ngP@ssw0rd!" `
  -v mssql_main_data:/var/opt/mssql `
  mcr.microsoft.com/mssql/server:2025-latest

# Create DB
docker exec mssql-main /opt/mssql-tools18/bin/sqlcmd `
  -S localhost `
  -U sa `
  -P "Str0ngP@ssw0rd!" `
  -C `
  -Q "IF DB_ID('main') IS NULL CREATE DATABASE [main];"

# Create login/user + grant permissions
docker exec mssql-main /opt/mssql-tools18/bin/sqlcmd `
  -S localhost `
  -U sa `
  -P "Str0ngP@ssw0rd!" `
  -C `
  -Q "
IF NOT EXISTS (SELECT 1 FROM sys.sql_logins WHERE name = 'chilli')
  CREATE LOGIN [chilli] WITH PASSWORD = 'S3cur3P@ssw0rd!';
USE [main];
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'chilli')
  CREATE USER [chilli] FOR LOGIN [chilli];
ALTER ROLE db_owner ADD MEMBER [chilli];
"
# Verify as chilli
docker exec mssql-main /opt/mssql-tools18/bin/sqlcmd `
  -S localhost `
  -U chilli `
  -P "S3cur3P@ssw0rd!" `
  -d main `
  -C `
  -Q "SELECT DB_NAME() AS CurrentDb, GETDATE() AS Now;"

# Inspect (proof of config)
docker inspect mssql-main --format '{{json .HostConfig.PortBindings}}'
docker inspect mssql-main --format '{{json .Mounts}}'
docker inspect mssql-main --format '{{json .Config.Env}}'

# Stop / Remove
docker rm -f mssql-main

# Removes volume
docker volume rm mssql_main_data

