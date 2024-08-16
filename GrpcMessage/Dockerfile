
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5783
EXPOSE 9091

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./GrpcMessageNode.csproj", "./"]
RUN dotnet restore "./GrpcMessageNode.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "GrpcMessageNode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcMessageNode.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://localhost:9091;http://localhost:5273
# ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 9091
EXPOSE 5273
ENTRYPOINT ["dotnet", "GrpcMessageNode.dll"]