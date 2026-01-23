Useful scripts getting everything up and running as I go.

## 1 - Introduction

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_USER=chilli" -e "MSSQL_DB=main" -e "MSSQL_PASSWORD=S3cur3P@ssw0rd!" -e "MSSQL_SA_PASSWORD=Str0ngP@ssw0rd!" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2025-latest
```
