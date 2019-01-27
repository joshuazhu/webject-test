FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

WORKDIR /src
COPY Webjet.sln ./
COPY Application/*.csproj ./Application/
COPY Domain/*.csproj ./Domain/
COPY Repository/*.csproj ./Repository/
COPY Webjet/*.csproj ./Webjet/

RUN dotnet restore

COPY . .

WORKDIR /src/Application
RUN dotnet build -c Release -o /app

WORKDIR /src/Domain
RUN dotnet build -c Release -o /app

WORKDIR /src/Repository
RUN dotnet build -c Release -o /app

WORKDIR /src/Webjet
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=publish /app .
CMD ASPNETCORE_URLS=http://*:80 dotnet Webjet.dll