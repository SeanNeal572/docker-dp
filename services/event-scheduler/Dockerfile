FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["EventScheduler.sln", "src/"]
COPY ["EventScheduler.Api/EventScheduler.Api.csproj", "src/EventScheduler.Api/"]
COPY ["EventScheduler.Core/EventScheduler.Core.csproj", "src/EventScheduler.Core/"]
COPY ["EventScheduler.Db/EventScheduler.Db.csproj", "src/EventScheduler.Db/"]
COPY ["EventScheduler.Db.Mssql/EventScheduler.Db.Mssql.csproj", "src/EventScheduler.Db.Mssql/"]
COPY ["EventScheduler.Db.Postgres/EventScheduler.Db.Postgres.csproj", "src/EventScheduler.Db.Postgres/"]
COPY ["EventScheduler.Db.Tests/EventScheduler.Db.Tests.csproj", "src/EventScheduler.Db.Tests/"]
COPY ["EventScheduler.TestInfrastructure/EventScheduler.TestInfrastructure.csproj", "src/EventScheduler.TestInfrastructure/"]

RUN dotnet restore src/EventScheduler.sln

COPY . .
RUN dotnet publish -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8081

ENTRYPOINT ["dotnet", "EventScheduler.Api.dll"]