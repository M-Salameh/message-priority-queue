FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./HTTPMessageNode.csproj", "./"]
RUN dotnet restore "./HTTPMessageNode.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "HTTPMessageNode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HTTPMessageNode.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://localhost:7095;http://localhost:5095
# ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 7095
EXPOSE 5095
ENTRYPOINT ["dotnet", "HTTPMessageNode.dll"]