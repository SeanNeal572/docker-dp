FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
RUN dotnet restore './EventScheduler.Api/EventScheduler.Api.csproj'

COPY . .
RUN dotnet build "./EventScheduler.Api/EventScheduler.Api.csproj"

RUN dotnet publish './EventScheduler.Api/EventScheduler.Api.csproj' /app/publish

COPY /app/publish .

EXPOSE 8081

ENTRYPOINT ["dotnet", "./EventScheduler.dll"]