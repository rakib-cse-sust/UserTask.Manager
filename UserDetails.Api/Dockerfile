#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UserDetails.Api/UserDetails.Api.csproj", "UserDetails.Api/"]
COPY ["Masstransit.Shared/Masstransit.Shared.csproj", "Masstransit.Shared/"]
RUN dotnet restore "./UserDetails.Api/UserDetails.Api.csproj"
COPY . .
WORKDIR "/src/UserDetails.Api"
RUN dotnet build "./UserDetails.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UserDetails.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserDetails.Api.dll"]