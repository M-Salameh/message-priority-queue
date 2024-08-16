FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./Scheduler.csproj", "./"]
RUN dotnet restore "./Scheduler.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Scheduler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scheduler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://localhost:5004;http://localhost:9090
# ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "Scheduler.dll"]