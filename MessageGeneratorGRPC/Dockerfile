FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./GRPCMessageGenerator.csproj", "./"]
RUN dotnet restore "./GRPCMessageGenerator.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "GRPCMessageGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GRPCMessageGenerator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GRPCMessageGenerator.dll"]