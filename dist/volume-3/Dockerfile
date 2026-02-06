# 

# Building the API project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR ./services/event-scheduler

COPY . ./
RUN dotnet restore services/event-scheduler/EventScheduler.Api

WORKDIR ./services/event-scheduler/EventScheduler.Api
RUN dotnet build -c Release

# Publishing
RUN dotnet publish -c Release -o /bin

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR ./services/event-scheduler

COPY --from=build /bin .

ENTRYPOINT ["dotnet", "EventScheduler.Api.dll"]