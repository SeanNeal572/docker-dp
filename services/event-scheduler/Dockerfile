# Use .NET 8 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY EventScheduler.sln ./

COPY EventScheduler.Api/EventScheduler.Api.csproj EventScheduler.Api/
COPY EventScheduler.Core/EventScheduler.Core.csproj EventScheduler.Core/
COPY EventScheduler.Db/EventScheduler.Db.csproj EventScheduler.Db/
COPY EventScheduler.Db.Mssql/EventScheduler.Db.Mssql.csproj EventScheduler.Db.Mssql/
COPY EventScheduler.Db.Postgres/EventScheduler.Db.Postgres.csproj EventScheduler.Db.Postgres/
COPY EventScheduler.TestInfrastructure/EventScheduler.TestInfrastructure.csproj EventScheduler.TestInfrastructure/

RUN dotnet restore EventScheduler.Api/EventScheduler.Api.csproj

COPY . .

RUN dotnet publish EventScheduler.Api/EventScheduler.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "EventScheduler.Api.dll"]