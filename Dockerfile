# https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/Dockerfile

# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Setup NodeJs
RUN apt-get update -y
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash --debug
Run apt-get install nodejs -yq

# copy csproj and restore as distinct layers
COPY *.sln .
COPY BoardGameUniverse.WebApp/*.csproj ./BoardGameUniverse.WebApp/
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /src/BoardGameUniverse.WebApp
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app .
CMD dotnet BoardGameUniverse.WebApp.dll