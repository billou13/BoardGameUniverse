# https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/Dockerfile

# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY BGU.MarvelChampions.ApiGateway/*.csproj ./BGU.MarvelChampions.ApiGateway/
WORKDIR /src/BGU.MarvelChampions.ApiGateway
RUN dotnet restore

# copy everything else and build app
WORKDIR /src
COPY . .
WORKDIR /src/BGU.MarvelChampions.ApiGateway
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app .
CMD dotnet BGU.MarvelChampions.ApiGateway.dll