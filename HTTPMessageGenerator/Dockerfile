
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./HTTPMessageGenerator.csproj", "./"]
RUN dotnet restore "./HTTPMessageGenerator.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "HTTPMessageGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HTTPMessageGenerator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HTTPMessageGenerator.dll"]