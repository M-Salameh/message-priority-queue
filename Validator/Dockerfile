FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./Validator.csproj", "./"]
RUN dotnet restore "./Validator.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Validator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Validator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://localhost:5205;http://localhost:9095
# ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "Validator.dll"]